using Province_API.Infrastructure.Data;

namespace Province_API.Infrastructure.Utils
{
    public class JsonSeeder
    {
        private readonly JsonLoader loader;
        private readonly AppDbContext appDbContext;

        public JsonSeeder(JsonLoader loader, AppDbContext appDbContext)
        {
            this.loader = loader;
            this.appDbContext = appDbContext;
        }

        public void Seed() {
            if (appDbContext.AdministrativeUnits.Any()) return;
            var data = loader.LoadAdminstrativeUnits();

            appDbContext.AdministrativeUnits.AddRange(data);
            appDbContext.SaveChanges();
        }
    }
}
