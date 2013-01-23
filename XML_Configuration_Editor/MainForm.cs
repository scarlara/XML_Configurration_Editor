// -----------------------------------------------------------------------------------------------
// Developer: 
// Oscar Lara
//
// Description:
// This is a simple c# win forms projects that allows to open and edit XML files and compare
// against a specified XML schema.
// If the input XML file matches XML schema, you can edit contents and save them.
// else you can just visualize the XML file. 
// A XML highlight function was implemented on the rich text box for convenience. 
// It is much easier to read when the attributes, nodes, text, etc. in the XML
// are visual friendly. 
//
// Unit tests will be implemented on the entire project based on NUnit framework. 
// 
// Only public methods are being tested. Nuint does not support private methods testing.
//
// Web references: 
// http://www.codeproject.com/Articles/3781/Test-Driven-Development-in-NET
// http://www.codeproject.com/Articles/7718/Using-XML-in-C-in-the-simplest-way
// http://blogs.msdn.com/b/cobold/archive/2011/01/31/xml-highlight-in-richtextbox.aspx
// http://www.nunit.org/
//
// -----------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NUnit.Framework;

namespace XML_Configuration_Editor
{
    [TestFixture]
    public partial class MainForm : Form
    {

#region Global Variables...
       
        //XML schema validation class
        CXMLValidator mXMLValidator;
        //XML schema file name.
        private string mXMLSchemaFileName;
        //XML file name.
        private string mXMLFileName;
#endregion


#region Constructor...

        /// <summary>
        /// Main form min. and max. size: 696, 765
        /// Maximize button disabled.
        /// </summary>
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

#endregion
       

#region Private Methods...

        /// <summary>
        /// Open XML menu option.
        /// </summary>
        /// <param name="sender">sender param</param>
        /// <param name="e">e param</param>
        private void openXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mofDialog.ShowDialog() == DialogResult.OK)
                {
                    //Clear rtbViewEditXML
                    rtbViewEditXML.Text = string.Empty;
                    //Clear rtbError
                    rtbError.Text = string.Empty;
                    //Save XML file name.
                    mXMLFileName = mofDialog.FileName;

                    //Create stream reader
                    StreamReader sr = new StreamReader(mXMLFileName);
                    //Initialize mXML validation 
                    mXMLValidator = new CXMLValidator(mXMLFileName, mXMLSchemaFileName);

                    //Validate input XML file against schema
                    mXMLValidator.ValidateXMLFile(rtbError, true, string.Empty);

                    String input;
                    //Read XML input file
                    while ((input = sr.ReadLine()) != null)
                    {
                        rtbViewEditXML.AppendText(input + "\n");

                    }
                    //Close stream reader
                    sr.Close();

                    //Highlight XML in rich text box.
                    CHightlightRTB.HighlightRTF(rtbViewEditXML);


                }
            }
            catch (System.NullReferenceException ex)
            {
                //Show exception if any.
                MessageBox.Show(ex.Message, "Application Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException ex) 
            {
                //Show exception if any.
                MessageBox.Show(ex.Message, "Application Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //In order to save an XML file must be opened using File/Open, then the
                //global variable mXMLFileName will hold file path/Name.
                if (File.Exists(mXMLFileName))
                {
                     //Clear rtbError
                     rtbError.Text = string.Empty;

                    //Validate XML in rich text box against xml schema.
                    if (!mXMLValidator.ValidateXMLFile(rtbError, false, rtbViewEditXML.Text))
                    {
                         //Create stream writer
                        StreamWriter sw = new StreamWriter(mXMLFileName);
                        //Write XML data into file.
                        sw.Write(rtbViewEditXML.Text);
                        //Notify successfully saved.
                        MessageBox.Show("File saved successfully.", "XML File Saved.", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
	                {
                         //There are XML schema errors in rich text box XML.
                    MessageBox.Show("Save invalid XML not allowed.\nCheck XML schema errors.", 
                        "XML Schema Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	                }
                }
                else
                {
                     //File does not exist. The user is trying to save something without opening an XML file first. 
                        MessageBox.Show("File does not exist.\nOpen an XML to edit first.", 
                            "File Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }
            catch (System.Exception ex)
            {
                //Show exceptions if any.
                MessageBox.Show(ex.Message, "Application Error.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



#endregion
       

    }
}
