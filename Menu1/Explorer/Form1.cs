using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    public partial class Form1 : Form
    {
        ImageList imageForFolder;
        string fullPath;
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();
            treeView1.BeforeSelect += TreeView1_BeforeSelect;
            this.Load += Form1_Load;
            treeView1.AfterSelect += treeView1_AfterSelect;
        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            fullPath = selectedNode.FullPath;

            DirectoryInfo di = new DirectoryInfo(fullPath);
            FileInfo[] fiArray;
            DirectoryInfo[] diArray;

            try
            {
                fiArray = di.GetFiles();
                diArray = di.GetDirectories();
            }
            catch
            {
                return;
            }

            listView1.Items.Clear();

            foreach (DirectoryInfo dirInfo in diArray)
            {
                ListViewItem lvi = new ListViewItem(dirInfo.Name, imageLargeList.Images.IndexOfKey("folder"));
                lvi.ImageIndex = 0;

                listView1.Items.Add(lvi);
                
            }


            foreach (FileInfo fileInfo in fiArray)
            {
                ListViewItem lvi = new ListViewItem(fileInfo.Name,imageLargeList.Images.IndexOfKey("file"));
                lvi.Tag = fileInfo.FullName;
                lvi.Tag = fileInfo.FullName;
                lvi.SubItems.Add(fileInfo.Length.ToString());
                lvi.SubItems.Add(fileInfo.LastWriteTime.ToString());

                string filenameExtension =
                  Path.GetExtension(fileInfo.Name).ToLower();
                listView1.Items.Add(lvi);
                
            }
        }
        

        void Form1_Load(object sender, EventArgs e)
        {
            imageForFolder = new ImageList();
            imageForFolder.ImageSize = new Size(24, 24);
            imageForFolder.Images.Add(Image.FromFile("closed.png"));
            imageForFolder.Images.Add(Image.FromFile("opened.png"));
            treeView1.ImageList = imageForFolder;
            treeView1.SelectedImageIndex = 1;
            imageLargeList.ImageSize = new Size(36, 36);
            imageLargeList.Images.Add("folder",Image.FromFile("folderWithFiles.png"));
            imageLargeList.Images.Add("file",Image.FromFile("file.png"));
            listView1.LargeImageList = imageLargeList;
            listView1.View = View.LargeIcon;
        }

        //Событие перед выделением узла
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            string[] files;

            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }

                    files = Directory.GetFiles(e.Node.FullPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(files[i]));
                        e.Node.Nodes.Add(fileNode);
                    }
                }



            }
            catch (Exception)
            {

            }
        }

        //получения всех дисков на компьютере
        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    FillTreeNode(driveNode, drive.Name);
                    treeView1.Nodes.Add(driveNode);
                }
            }
            catch (Exception) { }
        }

        //Получаем дочерние узлы для диска компьютера
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }


            }
            catch (Exception)
            {

            }
        }
    }
}