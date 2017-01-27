using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.ModifyRegistry;
using System.IO;

namespace DragnDrop_Renamer
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contractnumber1.Text = "CK";
            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            // AllowDrop = true;

            // Add event handlers for the drag & drop functionality
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);
        }

        // This event occurs when the user drags over the form with 
        // the mouse during a drag drop operation 
        void Form_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Dataformat of the data can be accepted
            // (we only accept file drops from Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it

        }

        // Occurs when the user releases the mouse over the drop target 
        void Form_DragDrop(object sender, DragEventArgs e)
        {
            // clear the label
            label1.Text = String.Empty;
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...

            // For example add all files into a simple label control:
            foreach (string File in FileList)
                this.label1.Text += File + "\n";
        }

        private void CKFolderLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    // folderDialog.SelectedPath -- your result
                    //load the registry editor
                    ModifyRegistry myRegistry = new ModifyRegistry();
                    myRegistry.Write("CK Save Location", folderDialog.SelectedPath);
                }
            }
        }

        private void MNFolderLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    // folderDialog.SelectedPath -- your result
                    //load the registry editor
                    ModifyRegistry myRegistry = new ModifyRegistry();
                    myRegistry.Write("MN Save Location", folderDialog.SelectedPath);
                }
            }
        }

        private void Actualbutton1_Click(object sender, EventArgs e)
        {
            Filetype1.Text=("Actual");
        }

        private void Pickingtickets1_Click(object sender, EventArgs e)
        {
            Filetype1.Text = ("Picking Tickets");
        }

        private void Delnotes1_Click(object sender, EventArgs e)
        {
            Filetype1.Text = ("Del Notes");
        }

        private void Checkckmn1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkckmn1.Text == "CK")
            {
                checkckmn1.Text = "MN";
                contractnumber1.Text = "MN";
            }
            else
            {
                checkckmn1.Text = "CK";
                contractnumber1.Text = "CK";
            }
            
        }
    }  
}