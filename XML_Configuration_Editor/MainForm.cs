using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XML_Configuration_Editor
{
    public partial class MainForm : Form
    {

#region Global Variables...
        Stream mstream;
        StreamReader mStreamReader;

#endregion
        public MainForm()
        {
            InitializeComponent();
            //Initialize global variables
            mofDialog = new OpenFileDialog();
            mofDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory; //"c:\\";
            mofDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            mofDialog.FilterIndex = 1;
            mofDialog.RestoreDirectory = true;

        }

        /// <summary>
        /// Open XML menu option.
        /// </summary>
        /// <param name="sender">sender param</param>
        /// <param name="e">e param</param>
        private void openXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ( mofDialog.ShowDialog() == DialogResult.OK )
                {
                    mStreamReader = new StreamReader(mofDialog.FileName);
                    String input;
                    while ( ( input = mStreamReader.ReadLine() ) != null)
                    {
                        rtbViewEditXML.AppendText(input + "\n");
                       
                    }

                    CHightlightRTB.HighlightRTF(rtbViewEditXML);
                    //if ((mstream = mofDialog.OpenFile()) != null)
                    //{
                    //    using (mstream) 
                    //    {
                    //        //mstream.
                    //        //String line = mstream.BeginRead()
                    //    }
                    //}
                     
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
