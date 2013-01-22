﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;

namespace XML_Configuration_Editor
{


    class CXMLValidator
    {

#region Global Variables... 

  //Private
    private string m_sXMLFileName;
    private string m_sSchemaFileName; 
    private XmlSchemaCollection m_objXmlSchemaCollection;
    private bool m_bIsFailure;

#endregion

        /// <summary>
        /// Constructor overload.
        /// </summary>
        /// <param name="sXMLFileName">XML File Name.</param>
        /// <param name="sSchemaFileName">Schema File Name.</param>
        public CXMLValidator(string sXMLFileName, string sSchemaFileName)
        {
            //Initialize global variables
            m_sXMLFileName = sXMLFileName; 
            m_sSchemaFileName = sSchemaFileName;
            m_objXmlSchemaCollection = new XmlSchemaCollection ();
            //adding the schema file to the newly created schema collection
            m_objXmlSchemaCollection.Add (null, m_sSchemaFileName);
        }


        
        /// <summary>
        /// This function will Validate the XML file(.xml) against xml schema(.xsd)
        /// </summary>
        /// <returns></returns>
        public bool ValidateXMLFile()
        {
            XmlTextReader objXmlTextReader = null;
            XmlValidatingReader objXmlValidatingReader = null;

            try
            {
                //creating a text reader for the XML file already picked by the 
                //overloaded constructor above viz..clsSchemaValidator
                objXmlTextReader = new XmlTextReader(m_sXMLFileName);
                //creating a validating reader for that objXmlTextReader just created
                objXmlValidatingReader = new XmlValidatingReader(objXmlTextReader);
                //For validation we are adding the schema collection in 
                //ValidatingReaders Schema collection.
                objXmlValidatingReader.Schemas.Add(m_objXmlSchemaCollection);
                //Attaching the event handler now in case of failures
                objXmlValidatingReader.ValidationEventHandler +=
                               new ValidationEventHandler
                (ValidationFailed);
                //Actually validating the data in the XML file with a empty while.
                //which would fire the event ValidationEventHandler and invoke 
                //our ValidationFailed function
                while (objXmlValidatingReader.Read())
                {
                }
                //Note:- If any issue is faced in the above while it will invoke 
                //ValidationFailed which will in turn set the module level 
                //m_bIsFailure boolean variable to false thus returning true as  
                //a signal to the calling function that the ValidateXMLFile
                //function(this function) has encountered failure
                return m_bIsFailure;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message);
                return true;
            }
            finally
            {
                // close the readers, no matter what.
                objXmlValidatingReader.Close();
                objXmlTextReader.Close();
            }
        }


        private void ValidationFailed(object sender, ValidationEventArgs args)
        {
            m_bIsFailure = true;
            MessageBox.Show("Invalid XML File: " + args.Message);
        }
        //This will be called only if an the XML file is not in proper format.
        //Since it is a file like HTML any one can go and change its format from 
        //any text editor. So we shud ensure that we are validating it properly.
    }
}
