﻿using System.Windows.Forms;

namespace WindowsForms_TreeViewFileDirectory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Directory TreeView
            directoryTreeView = new TreeView();
            directoryTreeView.Dock = DockStyle.Left;
            directoryTreeView.AfterSelect += DirectoryTreeView_AfterSelect;
            this.Controls.Add(directoryTreeView);

            // File ListView
            fileListView = new ListView();
            fileListView.Dock = DockStyle.Fill;
            fileListView.View = View.Details;
            fileListView.Columns.Add("Name", 200);
            fileListView.Columns.Add("Size", 100);
            fileListView.Columns.Add("Type", 100);
            this.Controls.Add(fileListView);

            // Main Form
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Directory Browser";

        }
        private TreeView directoryTreeView;
        private ListView fileListView;
        #endregion
    }
}

