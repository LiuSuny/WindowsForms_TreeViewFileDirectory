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

namespace WindowsForms_ListView
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
                driveTreeView.Nodes.Add(driveNode);
            }
        }

        private void DriveTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.Tag.ToString();
            DisplayProperties(selectedPath);
        }

        private void DisplayProperties(string path)
        {
            fileListView.Items.Clear();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                // Display folder properties
                ListViewItem folderItem = new ListViewItem("Folder Properties");
                folderItem.SubItems.Add("");
                fileListView.Items.Add(folderItem);

                folderItem.SubItems[1].Text = "Creation Time: " + dir.CreationTime.ToString();
                fileListView.Items.Add(folderItem);

                folderItem.SubItems[1].Text = "Last Access Time: " + dir.LastAccessTime.ToString();
                fileListView.Items.Add(folderItem);

                folderItem.SubItems[1].Text = "Last Write Time: " + dir.LastWriteTime.ToString();
                fileListView.Items.Add(folderItem);

                folderItem.SubItems[1].Text = "Attributes: " + dir.Attributes.ToString();
                fileListView.Items.Add(folderItem);

                // Display file properties
                foreach (var file in dir.GetFiles())
                {
                    ListViewItem fileItem = new ListViewItem(file.Name);
                    fileItem.SubItems.Add("");
                    fileListView.Items.Add(fileItem);

                    fileItem.SubItems[1].Text = "Creation Time: " + file.CreationTime.ToString();
                    fileListView.Items.Add(fileItem);

                    fileItem.SubItems[1].Text = "Last Access Time: " + file.LastAccessTime.ToString();
                    fileListView.Items.Add(fileItem);

                    fileItem.SubItems[1].Text = "Last Write Time: " + file.LastWriteTime.ToString();
                    fileListView.Items.Add(fileItem);

                    fileItem.SubItems[1].Text = "Size: " + file.Length.ToString() + " bytes";
                    fileListView.Items.Add(fileItem);

                    fileItem.SubItems[1].Text = "Attributes: " + file.Attributes.ToString();
                    fileListView.Items.Add(fileItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
