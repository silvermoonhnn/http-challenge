using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace httpChallenge
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {

            var getJsonResponse = await Fetcher.Get();
            //var deleteJsonResponse = await Fetcher.Delete();

            //var data = @"
            //  {
            //    ""id"": 30,
            //    ""name"": ""Someone""
            //  }
            //";

            //var postJsonResponse = await Fetcher.Post(data);
            //var putJsonResponse = await Fetcher.Put(data);
            //var patchJsonResponse = await Fetcher.Patch(data);

            Console.WriteLine(getJsonResponse);
            //Console.WriteLine(deleteJsonResponse);
            //Console.WriteLine(postJsonResponse);
            //Console.WriteLine(putJsonResponse);
            //Console.WriteLine(patchJsonResponse);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            var http = new HttpClient();
            var result = await http.GetStringAsync("https://mul14.github.io/data/employees.json");
            var jconvert = JsonConvert.DeserializeObject<List<Employee>>(result);

            Console.WriteLine("Employees which have salary more than Rp15.000.000 : ");
            List<string> salary = new List<string>();
            foreach (var k in jconvert)
            {
                if (k.Salary > 15000000)
                {
                    salary.Add($"{k.First_name} {k.Last_name}");
                }
            }
            Console.WriteLine(String.Join(",", salary));
            Console.WriteLine(" ");

            Console.WriteLine("Employees which life in Jakarta : ");
            List<string> jkt = new List<string>();
            foreach (var k in jconvert)
            {
                foreach (var y in k.Addresses)
                {
                    if (y.City == "DKI Jakarta")
                    {
                        jkt.Add($"{k.First_name} {k.Last_name}");
                    }
                }

            }
            var JKT = jkt.Distinct();
            Console.WriteLine(String.Join(",", JKT));
            Console.WriteLine(" ");

            Console.WriteLine("Employees which birthday on March : ");
            List<string> born = new List<string>();
            foreach (var k in jconvert)
            {
                foreach (var b in jconvert)
                {
                    var m = k.Birthday.Month;
                    if (m == 03)
                    {
                        born.Add($"{k.First_name} {k.Last_name}");
                    }
                }
            }
            Console.WriteLine(String.Join(",", born));
            Console.WriteLine(" ");

            Console.WriteLine("Employees in Research and Development departement :");
            List<string> dept = new List<string>();
            foreach (var k in jconvert)
            {
                    var y = k.Department.Name;
                    if (y == "Research and development")
                    {
                        dept.Add($"{k.First_name} {k.Last_name}");
                    }
            }
            
            Console.WriteLine(String.Join(",", dept));
            Console.WriteLine(" ");

            Console.WriteLine("how many each employee absences in October 2019 ?");
            var names = new List<int>();
            foreach (var a in jconvert)
            {
                var oct = a.Presence_list
                    .Where(x => x.Month == 10)
                    .Count();
                names.Add(oct);
            }
            var count = names.Sum();
            Console.WriteLine(String.Join(",", count));
            Console.WriteLine(" ");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
