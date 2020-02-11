using System;
using System.Linq;
using IronWebScraper;

namespace httpChallenge
{
    public class Scraping : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://www.kompas.com/", Parse);
        }

        public override void Parse(Response response)
        {
            foreach (var i in response.Css("a.headline__thumb__link"))
            {
                string getLink = i.Attributes["href"];
                string title = i.InnerTextClean;

                Console.WriteLine(title);
                Console.WriteLine(getLink);
            }
        }
    }
}
