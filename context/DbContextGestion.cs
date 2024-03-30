using ApplicationGestionFonciers.API.config;
using ApplicationGestionFonciers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApplicationGestionFonciers.API.context
{
    public class DbContextGestion : IDbContextGestion,IDisposable
    {
        public DbContextGestion(IOptions<DbContextSettings> settings) 
        {
            var option =new DbContextOptionsBuilder<GestionDbContext>().UseNpgsql(settings.Value.DbConnectionString).EnableSensitiveDataLogging().Options;
            DbContext = new GestionDbContext(option);
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        
        }

        public GestionDbContext DbContext { get; set; }

        public void Dispose()
        {
            DbContext?.Dispose();
        }


    }
}
