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
            this.msMainMenu.SuspendLayout();
            this.gbViewEditXML.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
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
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // gbViewEditXML
            // 
            this.gbViewEditXML.Controls.Add(this.rtbViewEditXML);
            this.gbViewEditXML.Location = new System.Drawing.Point(12, 69);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 670);
            this.Controls.Add(this.gbViewEditXML);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "XML Configuration Editor";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.gbViewEditXML.ResumeLayout(false);
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
    }
}

