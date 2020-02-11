using System;
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
            foreach (var css1 in response.Css("latest ga--latest mt2 clearfix"))
            {
                string title = css1.TextContentClean;
            }
        }
    }
}
