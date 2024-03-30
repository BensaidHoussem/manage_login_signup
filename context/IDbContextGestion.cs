using ApplicationGestionFonciers.API.Models;

namespace ApplicationGestionFonciers.API.context
{
    public interface IDbContextGestion
    {
        GestionDbContext DbContext { get; }
    }
}
