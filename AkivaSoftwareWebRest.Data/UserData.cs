using AkivaSoftwareWebRest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AkivaSoftwareWebRest.Data
{
    public class UserData
    {
        //Lista generica
        private readonly ICollection<User> _user = new List<User>
        {
            new User("Luciano Carlos de Jesus"){Email = "l.carlos@akivasoftware.com.br"},
            new User("Marcelo Favinha"){Email = "m.favinha@akivasoftware.com.br"},
            new User("Rafão"){Email = "r.bombonatto@akivasoftware.com.br"}
        };

        public ICollection<User> Get()
        {
            return _user;
        }

        public User GetUser(Guid userId)
        {
            return _user.First(x => x.Id.Equals(userId));
        }

        public ICollection<User> GetList(Guid userId)
        {
            return _user.Where(x => x.Id.Equals(userId)).ToList();
        }

        public KeyValuePair<bool, string> CreateUser(User user)
        {
            try
            {
                return new KeyValuePair<bool, string>(true, "O cadastro do usuário " + user.Name + " foi realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "Houve problema ao tentar cadastrar o usuário " + user.Name + ". Segue erro: " + ex.Message);
            }
        }
    }
}
