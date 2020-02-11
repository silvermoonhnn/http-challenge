using System;
using System.Linq;
using IronWebScraper;

namespace httpChallenge
{
    public class Movie : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.WorkingDirectory = @"/Users/gigaming/Projects/httpChallenge/httpChallenge/Movie.txt";
            this.Request("https://www.cgv.id/", Parse);
        }

        public override void Parse(Response response)
        {
            foreach (var i in response.Css("ul.slides > li > a"))
            {
                string getLink = i.Attributes["href"];
                this.Request(getLink, ParseDetails);
            }
        }

        public void ParseDetails(Response response)
        {
            string title = response.Css("div.movie-info-title").First().TextContentClean;
            Console.WriteLine(title);
            foreach(var i in response.Css("div.movie-add-info > ul")){

                string info = i.TextContentClean;
                Console.WriteLine(info);
            }
            string synopsis = response.Css("div.movie-synopsis").First().TextContentClean;
            
            Console.WriteLine(synopsis);
        }
    }
}
