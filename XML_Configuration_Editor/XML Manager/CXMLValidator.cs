using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.IO;
using NUnit.Framework;

namespace XML_Configuration_Editor
{

   [TestFixture(mtcXMLFileName,mtcXMLSchemaFileName)]
    class CXMLValidator
    {

#region Global Variables... 

  //Private
    private string m_sXMLFileName;
    private string m_sSchemaFileName; 
    private XmlSchemaCollection m_objXmlSchemaCollection;
    private bool m_bIsFailure;
    private string m_Error;

#endregion


#region Constructor...

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
        m_objXmlSchemaCollection = new XmlSchemaCollection();
        //adding the schema file to the newly created schema collection
        m_objXmlSchemaCollection.Add(null, m_sSchemaFileName);
    }


#endregion



#region Test cases...

       //Specifies path for xml file
    private const string mtcXMLFileName = @"C:\Oscar\Fanshawe\2nd Semester\Configuration And Deployment\Project_1\XML_Configuration_Editor"+
                                          @"\XML_Configuration_Editor\PO.xml";

       //Specifies path for xml schema file.
    private const string mtcXMLSchemaFileName = @"C:\Oscar\Fanshawe\2nd Semester\Configuration And Deployment\Project_1\XML_Configuration_Editor"+
                                           @"\XML_Configuration_Editor\PurchaseOrderSchema.xsd";

       //Represents XML Valid Data.
    private const string tcXMLValidData = "<?xml version=\"1.0\"?><purchaseOrder xmlns=\"http://tempuri.org/po.xsd\" orderDate=\"1999-10-20\"> "+
                                "<shipTo country=\"US\"><name>Alice Smith</name><street>123 Maple Street</street><city>Mill Valley</city>"+
                                "<state>CA</state><zip>90952</zip></shipTo><billTo country=\"US\"><name>Robert Smith</name><street>8 Oak Avenue</street>"+
                                "<city>Old Town</city><state>PA</state><zip>95819</zip></billTo><comment>Hurry, my lawn is going wild!</comment>"+
                                "<items><item partNum=\"872-AA\"><productName>Lawnmower</productName><quantity>1</quantity><USPrice>148.95</USPrice>"+
                                "<comment>Confirm this is electric</comment></item><item partNum=\"926-AA\"><productName>Baby Monitor</productName>"+
                                "<quantity>1</quantity><USPrice>39.98</USPrice><shipDate>1999-05-21</shipDate></item></items></purchaseOrder>";

       //Represents XML Invalid data
    private const string tcXMLInvalidData = "<book>1</book><price>39.98</price><shipDate>1999-05-21</shipDate></item></items></purchaseOrder>";



       public static IEnumerable TestCases
    {
        get
        {
            //Using input xml and xsd files, must return false. aka. everything ok.
            yield return new TestCaseData(new RichTextBox(), true, string.Empty).Returns(false);

            //Using input string as input (string.empty) we expect true as return. "error"
            yield return new TestCaseData(new RichTextBox(), false, string.Empty).Returns(true);

            //Using input string as valid xml data we expect false as return ok.
            yield return new TestCaseData(new RichTextBox(), false, tcXMLValidData).Returns(false);

            //Using input string as invalid xml data we expect true as return. error.
            yield return new TestCaseData(new RichTextBox(), false, tcXMLInvalidData).Returns(true);
            
            //Pass null rich text box
            yield return new TestCaseData(null, true, string.Empty).Returns(true)
                .Throws(typeof(System.NullReferenceException));

            //Pass null bool
            yield return new TestCaseData(new RichTextBox(), null, string.Empty).Returns(true);

            //Pass null string
            yield return new TestCaseData(new RichTextBox(), false, null).Returns(true)
                .Throws(typeof(System.NullReferenceException));

            //Pass all nulls
            yield return new TestCaseData(null, null, null).Returns(true)
                .Throws(typeof(System.NullReferenceException));
        }
    }



#endregion
   
#region Public Methods...

    /// <summary>
    /// Validate XML Schema method.
    /// </summary>
    /// <param name="rtb">Rich text box to hightlight XML.</param>
    /// <param name="validateFile">Boolean if true use input file name for validation
    /// else use xmlData for validation.</param>
    /// <param name="xmlData">XML data to validate agains schema.</param>
    /// <returns>True if there is any error on input XML against schema.</returns>
    [Test, TestCaseSource("TestCases")]
    public bool ValidateXMLFile(RichTextBox rtb, bool validateFile, string xmlData)
    {
        XmlTextReader objXmlTextReader = null;
        XmlValidatingReader objXmlValidatingReader = null;

        try
        {
            //creating a text reader for the XML file already picked by the 
            //overloaded constructor above viz..clsSchemaValidator
            if (validateFile)
            {
                objXmlTextReader = new XmlTextReader(m_sXMLFileName);
            }
            else
            {

                objXmlTextReader = new XmlTextReader(new StringReader(xmlData));
            }
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
        catch (System.NullReferenceException ex) 
        {
            MessageBox.Show("Exception : " + ex.Message);
            return true;
        }
        catch (System.IO.IOException ex)
        {
            MessageBox.Show("Exception : " + ex.Message);
            return true;
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
            //
            if (m_bIsFailure)
            {
                //Print errors in rich text box.
                rtb.AppendText(m_Error);
            }
        }
    }


#endregion

        
#region Private Methods...

    /// <summary>
    /// Validation failed event handler method.
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="args">args</param>
    private void ValidationFailed(object sender, ValidationEventArgs args)
    {
        //Set m_bIsFailure to true.
        m_bIsFailure = true;
        // Save errrors in global variable.
        m_Error += "Invalid XML File: " + args.Message + " \n";
    }
        //This will be called only if an the XML file is not in proper format.
        //Since it is a file like HTML any one can go and change its format from 
        //any text editor. So we shud ensure that we are validating it properly.

#endregion
       
       
    }
}
