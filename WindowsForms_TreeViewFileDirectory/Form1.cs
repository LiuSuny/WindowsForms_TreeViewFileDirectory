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

namespace WindowsForms_TreeViewFileDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();

        }

        private void LoadDrives()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory.FullName;
                driveNode.Nodes.Add("Dummy");
                directoryTreeView.Nodes.Add(driveNode);
            }
        }

        private void DirectoryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.Tag.ToString();
            DisplayContents(selectedPath);
        }

        private void DisplayContents(string path)
        {
            fileListView.Items.Clear();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (var subDir in dir.GetDirectories())
                {
                    TreeNode node = new TreeNode(subDir.Name);
                    node.Tag = subDir.FullName;
                    node.Nodes.Add("Dummy");
                    //e.Node.Nodes.Add(node);
                    directoryTreeView.SelectedNode.Nodes.Add(node);
                }

                foreach (var file in dir.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.Extension);
                    fileListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
