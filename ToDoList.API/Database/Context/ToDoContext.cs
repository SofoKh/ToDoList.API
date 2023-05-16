using Microsoft.EntityFrameworkCore;

namespace ToDoList.API.Database.Context
{
    public class ToDoContext: DbContext
    {
        public virtual DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Server = (local); Database =ToDo; Trusted_Connection = True; ");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
