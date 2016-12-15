using System;
using AkivaSoftwareWebRest.Data;
using AkivaSoftwareWebRest.Domain.Models;
using System.Collections.Generic;

namespace AkivaSoftwareWebRest.Business
{
    public class UserBusiness
    {
        /// <summary>
        /// Retorna uma lista de dados do usuarios dos sistema.
        /// </summary>
        /// <returns>Lista dos usuarios</returns>
        public ICollection<User> GetBusiness()
        {
            return new UserData().Get();
        }

        /// <summary>
        /// Retorna os dados do usuario de acordo com o Id
        /// </summary>
        /// <param name="userId">Código do usuario</param>
        /// <returns>Objeto contendo os dados do usuario</returns>
        public User GetUserBusiness(Guid userId)
        {
            return new UserData().GetUser(userId);
        }

        /// <summary>
        /// Retorna lista de dados do usuario de acordo com Id
        /// </summary>
        /// <param name="userId">Código do usuario</param>
        /// <returns>Objeto contendo os dados do usuario</returns>
        public ICollection<User> GetList(Guid userId)
        {
            return new UserData().GetList(userId);
        }

        /// <summary>
        /// Cria um novo usuario no banco de dados
        /// </summary>
        /// <param name="user">Objeto Usuario</param>
        /// <returns>Mensagem de sucesso ou erro</returns>
        public KeyValuePair<bool, string> CreateUserBusiness(User user)
        {
            return new UserData().CreateUser(user);
        }
    }
}
