using System;

namespace AkivaSoftwareWebRest.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name)
        {
            Id = new Guid();
            Name = name;
        }
    }
}
