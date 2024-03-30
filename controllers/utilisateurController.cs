using ApplicationGestionFonciers.API.helpers;
using ApplicationGestionFonciers.API.Models;
using ApplicationGestionFonciers.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationGestionFonciers.API.controllers
{
    [Produces("application/json")]
    [Route("Application")]
    [ApiController]
    public class utilisateurController : ControllerBase
    {
        protected readonly IUtilisateurService _utilisateurService;

        public utilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [Route("Authentification")]
        [HttpPost]

        public async Task<IActionResult> Authentifier([FormBody] Access u)
        {

            Dictionary<string,string>dict= new Dictionary<string,string>();
     

            try
            {
                var user = await _utilisateurService.Authentifier(u);

                if (user != null)
                {
              
                    return new OkObjectResult(new
                    {
                        Message="Login success!"
                    });

                }
                else
                {
                    return BadRequest(new
                    { Message = "Login field" });
                }

            }catch (Exception ex)
            {
                var msg = "Error " + ex.Message;
                dict.Add("Message", msg);
                return BadRequest(msg);
            }

     
        }

        [Route("Register")]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody]Utilisateur utilisateur)
        {

            try
            {
                await _utilisateurService.Register(utilisateur)
                    .ConfigureAwait (false);
                return new OkObjectResult(new { Message = "done " });


            }
            catch (Exception ex)
            {

                return BadRequest(new {Message=ex.Message+" your email adress and account name must be unique"});

            }
        }

    }



}

