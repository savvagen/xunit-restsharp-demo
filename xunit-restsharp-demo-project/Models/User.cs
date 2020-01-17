
namespace xunit_restsharp_demo_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Username{ get; set; }

        public User(string name, string email, string username, int id)
        {
            Name = name;
            Email = email;
            Username = username;
            Id = id;
        }
    }
}