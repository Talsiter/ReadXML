using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ReadXML
{
    internal class Program
    {
        public static string _fileNameTemp = @"C:\Users\Jeff Wright\Desktop\TN0830400.04-17-22.04-23-22.xml";
        public static string _fileName = @"nibrs_GroupAIncident_Sample.xml";
        public static string _orderXML = @"Order.xml";

        static void Main(string[] args)
        {
           // ReadXMLToDataSet();
            //ReadXML_Linq1();
            //ReadXML_Linq2();
            // ReadXML_Linq3();
            //ReadXML_Linq4();
            //ReadXML_Linq5();
           // ReadXML_Linq6();
            ReadXML_Linq7();

        }




        private static void ReadXML_Linq7()
        {
            XNamespace nibrs = "http://fbi.gov/cjis/nibrs/4.2";
            XNamespace cjis = "http://fbi.gov/cjis/1.0";
            XNamespace cjiscodes = "http://fbi.gov/cjis/cjis-codes/1.0";
            XNamespace i = "http://release.niem.gov/niem/appinfo/3.0/";
            XNamespace ucr = "http://release.niem.gov/niem/codes/fbi_ucr/3.2/";
            XNamespace j = "http://release.niem.gov/niem/domains/jxdm/5.2/";
            XNamespace term = "http://release.niem.gov/niem/localTerminology/3.0/";
            XNamespace nc = "http://release.niem.gov/niem/niem-core/3.0/";
            XNamespace niem_xsd = "http://release.niem.gov/niem/proxy/xsd/3.0/";
            XNamespace s = "http://release.niem.gov/niem/structures/3.0/";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace xsd = "http://www.w3.org/2001/XMLSchema";
            XNamespace nibrscodes = "http://fbi.gov/cjis/nibrs/nibrs-codes/4.2";
            XNamespace moibrs = "http://www.beyond2020.com/moibrs/1.1";


           
        // https://stackoverflow.com/questions/40396966/c-sharp-read-xml-with-multiple-variable-namespaces

            var doc = XDocument.Load(_fileName);

            XElement element = doc.Root.Elements().Where(x => x.Name.LocalName == "MessageMetadata").FirstOrDefault();
            List<XElement> element1 = doc.Root.Elements().Where(x => x.Name.LocalName == "Report").ToList();

            var firstMessageDateTime = doc.Root.Elements().Where(x => x.Name.LocalName == "MessageMetadata").
                                                Elements().Where(x => x.Name.LocalName == "MessageDateTime").FirstOrDefault().Value;

            var n = doc.Root.Elements().Where(x => x.Name.LocalName == "MessageMetadata").
                                                Elements().Where(x => x.Name.LocalName == "MessageDateTime").FirstOrDefault().Value;


            XElement id = doc.Elements(nibrs + "Submission")
               .Elements(nibrs + "Report")
               .Single();
        }
        private static void ReadXML_Linq6()
        {
            XNamespace order = "urn:oasis:names:specification:ubl:schema:xsd:Order-2";
            XNamespace cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            XNamespace cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";

            var doc = XDocument.Load(_orderXML);

            var id = (string)doc.Elements(order + "Order")
                .Elements(cbc + "ID")
                .Single();

            var issueDate = (DateTime)doc.Elements(order + "Order")
                .Elements(cbc + "IssueDate")
                .Single();

            var buyerPartySchemeId = (string)doc.Descendants(cac + "BuyerCustomerParty")
                .Descendants(cbc + "ID")
                .Attributes("schemeID")
                .Single();
        }
        private static void ReadXML_Linq5()
        {
            // This gets all of the name spaces, but it is not helpful
            XDocument z = XDocument.Load(_fileName);

            var result = z.Root.Attributes().
                    Where(a => a.IsNamespaceDeclaration).
                    GroupBy(a => a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName,
                            a => XNamespace.Get(a.Value)).
                    ToDictionary(g => g.Key,
                                 g => g.First());
        }
        private static void ReadXML_Linq4()
        {
            XDocument submissions = XDocument.Load(_fileName);
            // None of these return anything
            var firstReportWithClearCodeN1 = submissions.Elements("IncidentAugmentation")
                .FirstOrDefault(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");
            var allReportsWithClearCodeN1 = submissions.Elements("IncidentAugmentation")
                .Where(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");

            var firstReportWithClearCodeN2 = submissions.Elements("Report")
                .FirstOrDefault(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");
            var allReportsWithClearCodeN2 = submissions.Elements("Report")
                .Where(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");

            var firstReportWithClearCodeN3 = submissions.Elements("Submission")
                .FirstOrDefault(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");
            var allReportsWithClearCodeN3 = submissions.Elements("Submission")
                .Where(m => m.Element("IncidentExceptionalClearanceCode").Value == "N");


        }
        private static void ReadXML_Linq3()
        {
            XDocument submissions= XDocument.Load(_fileName);
            // Get all Reports with a LocationCategoryCode = 12

            // Does not return anything
            IEnumerable<string> reports = submissions
                .Root // <Submission>.
                .Elements("Submission") // All <Report> under <Submission>.
                .Select(category => category.Element("LocationCategoryCode").Value = "12");
        }
        private static void ReadXML_Linq2()
        {
            XDocument doc = XDocument.Load(_fileName);
            // Get all the Reports in the Document
            
            
            // Does Not work
            foreach (XElement element in doc.Descendants("Report"))
            {
                Console.WriteLine(element);
            } 
            
            foreach (XElement element in doc.Descendants("Submission"))
            {
                Console.WriteLine(element);
            }
        }
        private static void ReadXML_Linq1()
        {

            //Load xml
            XDocument xdoc = XDocument.Load(_fileName);

            //Run query to see what I get
            var lv1s = from lv1 in xdoc.Descendants("Submission")
                       select new
                       {
                           Header = lv1.Attribute("Report").Value,
                           Children = lv1.Descendants("IdentificationID")
                       };
            // Returns no records
        }
        private static void ReadXMLToDataSet()
        {
            // Receive error:
            // Cannot add a column named 'IncidentAugmentation': a nested table with
            // the same name already belongs to this DataTable.'

            DataSet dataSet = new DataSet();
            dataSet.ReadXmlSchema("nibrs.xsd");
            dataSet.ReadXml(_fileName);
        }
    }
}
