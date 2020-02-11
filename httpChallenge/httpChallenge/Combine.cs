using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace httpChallenge
{

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Addresses Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Companies Company { get; set; }
    }

    public class Addresses
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geometrics Geo { get; set; }
    }

    public class Geometrics
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Companies
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }

    public class Posts
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public class combineFetch : Posts
    {
        public Users User { get; set; }
    }

    public class Combine
    {
        public static async Task<string> fetchCombine()
        {
            var client = new HttpClient();
            var firstLink = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var secLink = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var jsUser = JsonConvert.DeserializeObject<List<Users>>(firstLink);
            var jsPost = JsonConvert.DeserializeObject<List<Posts>>(secLink);

            var result = new List<combineFetch>();
            
            foreach (var i in jsPost)
            {
                var j = jsUser.Where(x => x.Id == i.UserId).FirstOrDefault();
                if (j != null)
                {
                    result.Add(new combineFetch
                    {
                        UserId = i.UserId,
                        Id = i.Id,
                        Title = i.Title,
                        Body = i.Body,
                        User = new Users
                        {
                            Id = j.Id,
                            Name = j.Name,
                            Username = j.Username,
                            Email = j.Email,
                            Address = new Addresses
                            {
                                Street = j.Address.Street,
                                Suite = j.Address.Suite,
                                City = j.Address.City,
                                Zipcode = j.Address.Zipcode,
                                Geo = new Geometrics
                                {
                                    Lat = j.Address.Geo.Lat,
                                    Lng = j.Address.Geo.Lng
                                }
                            },
                            Phone = j.Phone,
                            Website = j.Website,
                            Company = new Companies
                            {
                                Name = j.Company.Name,
                                CatchPhrase = j.Company.CatchPhrase,
                                Bs = j.Company.Bs
                            }
                        }
                    });
                }
            }
            var hasil = JsonConvert.SerializeObject(result);
            return hasil;
        }
    }
}
