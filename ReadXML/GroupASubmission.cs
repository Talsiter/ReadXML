using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadXML
{
    public class GroupASubmission
    {
        public XNamespace nibrs = "http://fbi.gov/cjis/nibrs/4.2";
        public XNamespace cjis = "http://fbi.gov/cjis/1.0";
        public XNamespace cjiscodes = "http://fbi.gov/cjis/cjis-codes/1.0";
        public XNamespace i = "http://release.niem.gov/niem/appinfo/3.0/";
        public XNamespace ucr = "http://release.niem.gov/niem/codes/fbi_ucr/3.2/";
        public XNamespace j = "http://release.niem.gov/niem/domains/jxdm/5.2/";
        public XNamespace term = "http://release.niem.gov/niem/localTerminology/3.0/";
        public XNamespace nc = "http://release.niem.gov/niem/niem-core/3.0/";
        public XNamespace niem_xsd = "http://release.niem.gov/niem/proxy/xsd/3.0/";
        public XNamespace s = "http://release.niem.gov/niem/structures/3.0/";
        public XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        public XNamespace xsd = "http://www.w3.org/2001/XMLSchema";
        public XNamespace nibrscodes = "http://fbi.gov/cjis/nibrs/nibrs-codes/4.2";
        public XNamespace moibrs = "http://www.beyond2020.com/moibrs/1.1";

        public static string _fileName = @"nibrs_GroupAIncident_Sample.xml";
        private XDocument doc = new XDocument();

        public GroupASubmission()
        {
            doc = XDocument.Load(_fileName);
        }
        public DateTime MessageDateTime { get; set; }
    }
}
