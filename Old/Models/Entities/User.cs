using System;
namespace Models.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
