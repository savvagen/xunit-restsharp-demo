
using Newtonsoft.Json;

namespace nunit_restsharp_demo_project.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("name")]
        public string name{ get; set; }
        public string email{ get; set; }
        public string username{ get; set; }

        public User(string name, string email, string username, int id)
        {
            this.name = name;
            this.email = email;
            this.username = username;
            this.id = id;
        }

        public User(string name, string email, string username)
        {
            this.name = name;
            this.email = email;
            this.username = username;
        }

        public User()
        {
        }
    }
}