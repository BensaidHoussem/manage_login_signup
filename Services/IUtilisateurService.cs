using ApplicationGestionFonciers.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationGestionFonciers.API.Services
{
    public interface IUtilisateurService
    {
        Task<Utilisateur> Authentifier(Access u );


        Task<ActionResult> Register(Utilisateur u);

        
    }
}
