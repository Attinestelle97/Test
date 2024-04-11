using Microsoft.EntityFrameworkCore;

namespace Test_2.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Cette ligne de code est une configuration du modèle dans Entity Framework Core et concerne l'entité Produit. Elle utilise la méthode Property sur l'objet Entity<Diplome> de ModelBuilder pour configurer une propriété spécifique 
            modelBuilder.Entity<Product>().Property(d => d.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(d => d.PriceHt).IsRequired();
            modelBuilder.Entity<Product>().Property(d => d.CreationDate);
            modelBuilder.Entity<Product>().Property(d => d.DateUpdate);
            modelBuilder.Entity<Product>().HasKey(d => d.Id);

            
        }



    }



}
