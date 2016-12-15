using AkivaSoftwareWebRest.Api.Models;
using AkivaSoftwareWebRest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AkivaSoftwareWebRest.Domain.Models;

namespace AkivaSoftwareWebRest.Api.Controllers
{
    /// <summary>
    /// Controlador Principal do Usuario.
    /// </summary>
    [RoutePrefix("api/v1/users")]
    public class UserController : ApiController
    {
        private HttpResponseMessage _response;

        /// <summary>
        /// Construtor do controller Usuario.
        /// </summary>
        public UserController()
        {
            _response = new HttpResponseMessage();
        }

        /// <summary>
        /// Recurso que fornece uma coleção de dados de usuarios cadastrados.
        /// </summary>
        /// <returns>Retorna uma coleção de usuarios</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(ICollection<UserModelView>))]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var users = new UserBusiness().GetBusiness();
                ICollection<UserModelView> userList = new List<UserModelView>();
                foreach (var item in users)
                {
                    var userModel = new UserModelView
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email
                    };
                    userList.Add(userModel);
                }
                var result = userList;
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao tentar encontrar lista de usuarios - " + ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(_response);
            return await tsc.Task;
        }

        /// <summary>
        /// Recurso que fornece uma coleção de dados de usuario de acordo com codigo.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna uma coleção de dados de usuarios de acordo com codigo.</returns>
        [HttpGet]
        [Route("{userId:guid}")]
        [ResponseType(typeof(UserModelView))]
        public async Task<HttpResponseMessage> Get(Guid userId)
        {
            try
            {
                var users = new UserBusiness().GetUserBusiness(userId);
                var userModel = new UserModelView { Id = users.Id, Name = users.Name, Email = users.Email };
                var result = userModel;
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao tentar encontrar usuario: " + userId + " - " + ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(_response);
            return await tsc.Task;
        }

        /// <summary>
        /// Recurso que fornece uma listage de usuarios de acordo com código.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna listagem de usuarios de acordo com código.</returns>
        [HttpGet]
        [Route("user/{userId:guid}")]
        [ResponseType(typeof(ICollection<UserModelView>))]
        public async Task<HttpResponseMessage> GetList(Guid userId)
        {
            try
            {
                var users = new UserBusiness().GetBusiness();
                var userModel = new UserModelView();
                ICollection<UserModelView> userList = new List<UserModelView>();
                foreach (var item in users)
                {
                    userModel.Id = item.Id;
                    userModel.Name = item.Name;
                    userModel.Email = item.Email;
                    userList.Add(userModel);
                }
                var result = userList;
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao tentar encontrar lista de usuarios - " + ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(_response);
            return await tsc.Task;
        }

        /// <summary>
        /// Recurso que adiciona um novo usuario no banco de dados.
        /// </summary>
        /// <param name="modelView"></param>
        /// <returns>Retorna mensagem de sucesso ou erro.</returns>
        [HttpPost]
        //[Filters.HttpsRequire]
        [Route("")]
        [ResponseType(typeof(UserModelView))]
        public async Task<HttpResponseMessage> Post(UserModelView modelView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User(modelView.Name) { Id = modelView.Id, Email = modelView.Email };
                    var retornoPair = new UserBusiness().CreateUserBusiness(user);
                    var result = retornoPair.Value;
                    _response = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                    _response = Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
            }
            catch (Exception ex)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao tentar encontrar lista de usuarios - " + ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(_response);
            return await tsc.Task;
        }
    }
}
