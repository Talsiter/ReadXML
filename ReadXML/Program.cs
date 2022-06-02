using System;
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
            // ReadXML_Linq();
            ReadXML_XDocument();
        }

        private static void ReadXML_XDocument()
        {
            XDocument xdoc = XDocument.Load(_fileName);

            foreach (var node in xdoc.DescendantNodes())
            {
                if (node is XText)
                {
                    //Console.WriteLine(((XText)node).Value);
                    //some code...
                }
                if (node is XElement)
                {
                    Console.WriteLine(((System.Xml.Linq.XElement)node).Name.LocalName);
                    Console.WriteLine(((System.Xml.Linq.XElement)node).Value);
                    //some code for XElement...
                }
            }

        }
        private static void ReadXML_Linq()
        {
            StringBuilder result = new StringBuilder();

            //Load xml
            XDocument xdoc = XDocument.Load(_fileName);

            //Run query
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
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(_fileName);
        }
    }
}
