using ApplicationGestionFonciers.API.context;
using ApplicationGestionFonciers.API.helpers;
using ApplicationGestionFonciers.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationGestionFonciers.API.Services
{
    public class UtilisateurService:IUtilisateurService
    {
        protected readonly IDbContextGestion _dbContextGestion;

        protected GestionDbContext _dbContext => _dbContextGestion?.DbContext;

        public UtilisateurService(IDbContextGestion dbContextGestion)
        {
            _dbContextGestion = dbContextGestion;
        }   

        public async Task<Utilisateur> Authentifier(Access u)
        {
            
            var usr = await _dbContext.Utilisateurs
                .Where(k=> k.Account == u.username )
                .FirstOrDefaultAsync();

            if( HashPassword.VerifyPassword(u.password, usr.Password)==true)
                return usr;
            else
                return null;

        }



        public async Task<ActionResult>  Register(Utilisateur utilisateur)
        {
            if (await AccountNameChek(utilisateur))
                return null;
            if (await EmailChek(utilisateur))
                return null;

            var x = HashPassword.hashPassword(utilisateur.Password);
            utilisateur.Password = x;

            _dbContext.Utilisateurs.Add(utilisateur);
            await _dbContext.SaveChangesAsync();

            return  new OkObjectResult("register done ");


        }


        private  Task<bool> AccountNameChek(Utilisateur u) =>  _dbContext.Utilisateurs.AllAsync(x => x.Account == u.Account);
        private  Task<bool> EmailChek(Utilisateur u) =>  _dbContext.Utilisateurs.AllAsync(x => x.Email == u.Email);







    }
}
