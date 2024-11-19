using System;
using HtmlAgilityPack;


namespace OurSolarSystemAPI.Utility {
    public class N2yoScraper() 
    {
        public Dictionary<string, string> extractSatelliteInfoFromHtml(string htmlContent) 
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            var satinfoDiv = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='satinfo']");

            var satelliteInfo = new Dictionary<string, string>
            {
                { "NoradId", ExtractData(satinfoDiv, "NORAD ID") },
                { "IntlCode", ExtractData(satinfoDiv, "Int'l Code") },
                { "Perigee", ExtractData(satinfoDiv, "Perigee") },
                { "Apogee", ExtractData(satinfoDiv, "Apogee") },
                { "Inclination", ExtractData(satinfoDiv, "Inclination") },
                { "Period", ExtractData(satinfoDiv, "Period") },
                { "SemiMajorAxis", ExtractData(satinfoDiv, "Semi major axis") },
                { "Rcs", ExtractData(satinfoDiv, "RCS") },
                { "LaunchDate", ExtractLaunchDate(satinfoDiv) },
                { "Source", ExtractData(satinfoDiv, "Source") },
                { "LaunchSite", ExtractData(satinfoDiv, "Launch site") }
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