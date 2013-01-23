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
       
        //XML schema validator class
        CXMLValidator mXMLValidator;
        //XML schema file name.
        private string mXMLSchemaFileName;
        //XML file name.
        private string mXMLFileName;
#endregion
        public MainForm()
        {
            InitializeComponent();
            //Initialize global variables
            mofDialog = new OpenFileDialog();
            mofDialog.InitialDirectory = System.IO.Path.GetFullPath("..\\..\\");//Environment.CurrentDirectory;//AppDomain.CurrentDomain.BaseDirectory;
            mofDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            mofDialog.FilterIndex = 1;
            mofDialog.RestoreDirectory = true;
            mXMLSchemaFileName = System.IO.Path.GetFullPath("..\\..\\") + "PurchaseOrderSchema.xsd";
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
                    //Clear rtbViewEditXML
                    rtbViewEditXML.Text = string.Empty;
                    //Clear rtbError
                    rtbError.Text = string.Empty;
                    //Save XML file name.
                    mXMLFileName = mofDialog.FileName;

                    //Create stream reader
                    StreamReader sr = new StreamReader(mXMLFileName);
                    //Initialize mXML Validator
                    mXMLValidator = new CXMLValidator(mXMLFileName, mXMLSchemaFileName);
                    
                    //Validate input XML file against schema
                    mXMLValidator.ValidateXMLFile(rtbError, true, string.Empty);

                    String input;
                    //Read XML input file
                    while ( ( input = sr.ReadLine() ) != null)
                    {
                        rtbViewEditXML.AppendText(input + "\n");
                       
                    }
                    //Close stream reader
                    sr.Close();

                    //Highlight XML in rich text box.
                    CHightlightRTB.HighlightRTF(rtbViewEditXML);

                     
                }
            }
            catch (System.Exception ex)
            {
                //Show exception if any.
                MessageBox.Show(ex.Message, "Application Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save XML menu option
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">e</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear rtbError
                rtbError.Text = string.Empty;
                //Validate XML in rich text box.
                if (!mXMLValidator.ValidateXMLFile(rtbError, false, rtbViewEditXML.Text))
                {
                    //Create stream writer
                    StreamWriter sw = new StreamWriter(mXMLFileName);
                    //Write XML data into file.
                    sw.Write(rtbViewEditXML.Text);

                }
                else 
                {
                    //There are XML schema errors in rich text box XML.
                    MessageBox.Show("Save invalid XML not allowed", "XML Schema Error.", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            catch (System.Exception ex)
            {
                //Show exceptions if any.
                MessageBox.Show(ex.Message, "Application Error.", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }





    }
}
