using System;
using HtmlAgilityPack;


namespace OurSolarSystemAPI.Utility {
    public class N2yoScraper() 
    {
        public Dictionary<string, string> ExtractSatelliteInfoFromHtml(string htmlContent) 
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            var satinfoDiv = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='satinfo']");

            var satelliteInfo = new Dictionary<string, string>
            {
                { "noradId", ExtractData(satinfoDiv, "NORAD ID") },
                { "intlCode", ExtractData(satinfoDiv, "Int'l Code") },
                { "perigee", ExtractData(satinfoDiv, "Perigee") },
                { "apogee", ExtractData(satinfoDiv, "Apogee") },
                { "inclination", ExtractData(satinfoDiv, "Inclination") },
                { "period", ExtractData(satinfoDiv, "Period") },
                { "semiMajorAxis", ExtractData(satinfoDiv, "Semi major axis") },
                { "rcs", ExtractData(satinfoDiv, "RCS") },
                { "launchDate", ExtractLaunchDate(satinfoDiv) },
                { "source", ExtractData(satinfoDiv, "Source") },
                { "launchSite", ExtractData(satinfoDiv, "Launch site") }
            };

            return satelliteInfo;
        }

        public string ExtractData(HtmlNode parentNode, string label)
        {
            var node = parentNode.SelectSingleNode($".//b[contains(text(), \"{label}\")]");
            if (node != null && node.NextSibling != null)
            {
                return node.NextSibling.InnerText.Trim();
            }
            return string.Empty;
        }

        public string ExtractLaunchDate(HtmlNode parentNode)
        {
            var dateNode = parentNode.SelectSingleNode(".//b[contains(text(), 'Launch date')]/following-sibling::a");

            if (dateNode != null)
            {
                return dateNode.InnerText.Trim();
            }

            return string.Empty;
        }
    }
}