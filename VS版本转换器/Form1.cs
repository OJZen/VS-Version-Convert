using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace VS版本转换器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //文件夹的路径
        string path, Slnfilename;
        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog Fbd = new FolderBrowserDialog();
            //Fbd.Description = "请选择项目的文件夹：";
            //if (Fbd.ShowDialog() == DialogResult.OK)
            //{
            //    path = Fbd.SelectedPath;
            //    textBoxpath.Text = path;
            //}

            OpenFileDialog slnfile = new OpenFileDialog();
            slnfile.Title = "请选择一个VS解决方案文件：";
            slnfile.Filter = "VS解决方案|*.sln";
            slnfile.Multiselect = false;
            if (slnfile.ShowDialog() == DialogResult.OK)
            {
                Slnfilename = slnfile.FileName;
                textBoxpath.Text = Slnfilename;
            }

        }

        private void buttonstrat_Click(object sender, EventArgs e)
        {
            if (textBoxpath.Text == "")
            {
                MessageBox.Show("请先选择VS解决方案！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            path = Path.GetDirectoryName(Slnfilename);
            //获取子目录
            string[] projectPath = Directory.GetDirectories(path);
            //获取目录下的文件
            // string[] Projectfile = Directory.GetFiles(path, "*.sln");

            //if (Projectfile.Length < 0)
            //{
            //    MessageBox.Show("找不到sln项目文件！", "警告：", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //读取到的文本
            string text;
            //开始读取文件内容
            using (FileStream fileRead = new FileStream(Slnfilename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] b = new byte[1024 * 100];
                int r = fileRead.Read(b, 0, b.Length);
                text = Encoding.UTF8.GetString(b, 0, r);
            }

            if (text.Contains("Version"))
            {
                //替换文本
                text = text.Replace("Version 12.", "Version 10.");
                text = text.Replace("Studio 14", "Studio 2008");
                text = text.Replace("Studio 15", "Studio 2008");
                text = text.Replace("Studio 2013", "Studio 2008");
            }
            else
            {
                MessageBox.Show("不是一个VS2015的sln文件", "警告：", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //写入文件
            using (FileStream fileWrite = new FileStream(Slnfilename, FileMode.Create, FileAccess.Write))
            {
                byte[] b = Encoding.UTF8.GetBytes(text);
                fileWrite.Write(b, 0, b.Length);
            }


            //遍历子目录
            for (int i = 0; i < projectPath.Length; i++)
            {
                //找到bin下的debug文件夹，然后清空，解决一些框架兼容问题
                string debugPath = projectPath[i] + "\\bin\\Debug";
                if (Directory.Exists(debugPath))
                {
                    string[] debugFiles = Directory.GetFiles(debugPath);
                    for (int j = 0; j < debugFiles.Length; j++)
                    {
                        File.Delete(debugFiles[j]);
                        Console.WriteLine(debugFiles[j]);
                    }
                }

                //.csproj  找到每个子目录下这个文件的路径
                string[] csproj = Directory.GetFiles(projectPath[i], "*.csproj");

                if (csproj.Length == 0)
                {
                    //如果这个文件夹找不到项目文件就跳过本次循环；
                    continue;
                }
                operateXml(csproj[0]);
                //删除App.config
                File.Delete(projectPath[i] + "\\App.config");
                //删除cs文件下不包含的引用
                string[] cs = Directory.GetFiles(projectPath[i], "*.cs");
                for (int j = 0; j < cs.Length; j++)
                {
                    Delusing(cs[j]);
                }

            }

            MessageBox.Show("转换成功！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //删除引用的方法
        public void Delusing(string filename)
        {
            string t;
            using (FileStream Fread = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] b = new byte[1024 * 100];
                int r = Fread.Read(b, 0, b.Length);
                t = Encoding.UTF8.GetString(b, 0, r);
            }
            if (!t.Contains("using System"))
            {
                return;
            }
            t = t.Replace("\r\nusing System.Threading.Tasks;", "");
            using (FileStream Fwrite = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                byte[] bu = Encoding.UTF8.GetBytes(t);
                Fwrite.Write(bu, 0, bu.Length);
            }

        }


        /// <summary>
        /// 窗口的拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Slnfilename = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (Path.GetExtension(Slnfilename) == ".sln")
            {
                textBoxpath.Text = Slnfilename;
            }
            else
            {
                MessageBox.Show("不是VS的解决方案文件", "提示");
            }
        }
        /// <summary>
        /// 文本框的拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxpath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxpath_DragDrop(object sender, DragEventArgs e)
        {
            Slnfilename = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (Path.GetExtension(Slnfilename) == ".sln")
            {
                textBoxpath.Text = Slnfilename;
            }
            else
            {
                MessageBox.Show("不是VS的解决方案文件", "提示");
            }
        }

        private void buttonhelp_Click(object sender, EventArgs e)
        {

            help form = new help();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBoxpath, "请选择或者拖拽一个解决方案");
            toolTip1.SetToolTip(buttonopen, "点击选择解决方案");
            toolTip1.ToolTipTitle = "小提示：";
        }


        /// <summary>
        /// 对csproj文件进行操作
        /// </summary>
        /// <param name="filename"></param>
        public void operateXml(string filename)
        {
            //创建xml文档进行操作
            XmlDocument Xmldoc = new XmlDocument();
            //加载xml文件
            Xmldoc.Load(filename);
            XmlElement xmle = Xmldoc.DocumentElement;
            //这里设置版本号
            xmle.SetAttribute("ToolsVersion", "3.5");
            //Console.WriteLine(xmle.Attributes["ToolsVersion"].Value);

            //设置一个集合来存储需要删除的引用
            List<XmlNode> node = new List<XmlNode>();
            //遍历Reference下的"Include"属性
            foreach (XmlNode item in Xmldoc.GetElementsByTagName("Reference"))
            {
                string inclustr = item.Attributes["Include"].Value;
                //找到需要删除的属性节点，并添加到集合里
                if (inclustr == "System.Net.Http" || inclustr == "Microsoft.CSharp")
                {
                    node.Add(item);
                }
            }

            foreach (XmlNode item in Xmldoc.GetElementsByTagName("None"))
            {
                string inclustr = item.Attributes["Include"].Value;
                //找到需要删除的属性节点，并添加到集合里
                if (inclustr == "App.config")
                {
                    node.Add(item);
                }
            }

            //删除集合里面的节点
            foreach (XmlNode item in node)
            {
                item.ParentNode.RemoveChild(item);
            }

            //修改框架版本
            XmlNodeList xmllist = Xmldoc.GetElementsByTagName("TargetFrameworkVersion");
            foreach (XmlNode item in xmllist)
            {
                if (item.InnerText.Contains("v"))
                {
                    item.InnerText = "v3.5";
                    break;
                }
            }

            Xmldoc.Save(filename);
        }

    }
}
