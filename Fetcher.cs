using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace httpChallenge
{
    public class Fetcher
    {
        public static async Task<string> Get()
        {
            var client = new HttpClient();
            var resultAs = await client.GetStringAsync("https://httpbin.org/get");
            return resultAs;
        }

        public static async Task<string> Delete()
        {
            var client = new HttpClient();
            var resultAs = await client.GetStringAsync("https://httpbin.org/delete");
            return resultAs;
        }

        public static async Task<string> Post(string data)
        {
            var client = new HttpClient();
            var resultAs = await client.GetStringAsync("https://httpbin.org/post");
            var posts = JsonConvert.DeserializeObject<List<dtPost>>(resultAs);
            return resultAs;
        }

        public static async Task<string> Put(string data)
        {
            var client = new HttpClient();
            var resultAs = await client.GetStringAsync("https://httpbin.org/put");
            return resultAs;
        }

        public static async Task<string> Patch(string data)
        {
            var client = new HttpClient();
            var resultAs = await client.GetStringAsync("https://httpbin.org/put");
            return resultAs;
        }

        public class dtPost
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
