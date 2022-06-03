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
        public static string _fileName = @"Test2.xml";

        static void Main(string[] args)
        {
            //ReadXMLToDataSet();
             //ReadXML_Linq1();
             //ReadXML_Linq2();
            // ReadXML_Linq3();
             ReadXML_Linq4();
            ReadXMLToDataSet();
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
            dataSet.ReadXml(_fileName);
        }
    }
}
