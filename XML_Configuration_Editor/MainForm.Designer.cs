namespace XML_Configuration_Editor
{
    partial class MainForm
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbViewEditXML = new System.Windows.Forms.GroupBox();
            this.rtbViewEditXML = new System.Windows.Forms.RichTextBox();
            this.mofDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbMessages = new System.Windows.Forms.GroupBox();
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.msMainMenu.SuspendLayout();
            this.gbViewEditXML.SuspendLayout();
            this.gbMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(680, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openXMLFileToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openXMLFileToolStripMenuItem
            // 
            this.openXMLFileToolStripMenuItem.Name = "openXMLFileToolStripMenuItem";
            this.openXMLFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openXMLFileToolStripMenuItem.Text = "&Open XML File";
            this.openXMLFileToolStripMenuItem.Click += new System.EventHandler(this.openXMLFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // gbViewEditXML
            // 
            this.gbViewEditXML.Controls.Add(this.rtbViewEditXML);
            this.gbViewEditXML.Location = new System.Drawing.Point(12, 40);
            this.gbViewEditXML.Name = "gbViewEditXML";
            this.gbViewEditXML.Size = new System.Drawing.Size(643, 570);
            this.gbViewEditXML.TabIndex = 1;
            this.gbViewEditXML.TabStop = false;
            this.gbViewEditXML.Text = "View Edit XML File";
            // 
            // rtbViewEditXML
            // 
            this.rtbViewEditXML.Location = new System.Drawing.Point(3, 16);
            this.rtbViewEditXML.Name = "rtbViewEditXML";
            this.rtbViewEditXML.Size = new System.Drawing.Size(634, 548);
            this.rtbViewEditXML.TabIndex = 0;
            this.rtbViewEditXML.Text = "";
            // 
            // mofDialog
            // 
            this.mofDialog.FileName = "openFileDialog1";
            // 
            // gbMessages
            // 
            this.gbMessages.Controls.Add(this.rtbError);
            this.gbMessages.Location = new System.Drawing.Point(12, 652);
            this.gbMessages.Name = "gbMessages";
            this.gbMessages.Size = new System.Drawing.Size(643, 63);
            this.gbMessages.TabIndex = 2;
            this.gbMessages.TabStop = false;
            this.gbMessages.Text = "XML Schema Errors";
            // 
            // rtbError
            // 
            this.rtbError.ForeColor = System.Drawing.Color.Red;
            this.rtbError.Location = new System.Drawing.Point(3, 14);
            this.rtbError.Name = "rtbError";
            this.rtbError.ReadOnly = true;
            this.rtbError.Size = new System.Drawing.Size(631, 43);
            this.rtbError.TabIndex = 0;
            this.rtbError.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 727);
            this.Controls.Add(this.gbMessages);
            this.Controls.Add(this.gbViewEditXML);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "XML Configuration Editor";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.gbViewEditXML.ResumeLayout(false);
            this.gbMessages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openXMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbViewEditXML;
        private System.Windows.Forms.RichTextBox rtbViewEditXML;
        private System.Windows.Forms.OpenFileDialog mofDialog;
        private System.Windows.Forms.GroupBox gbMessages;
        private System.Windows.Forms.RichTextBox rtbError;
    }
}

