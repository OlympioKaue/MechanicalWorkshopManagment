using MechanicalWorkshopManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWorkshopManagment.Infrastructure.DataAcess
{
    /// <summary>
    /// Classe responsável pelas tabelas e atribuições no banco de dados.
    /// </summary>
   public class MechanicalManagmentDbContext : DbContext
    {
        public MechanicalManagmentDbContext(DbContextOptions option) : base(option)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<PartsBudget> PartsBudgets { get; set; }
        public DbSet<Buy> Buy { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relaciomento.
            modelBuilder.Entity<PartsBudget>()
                .HasOne(op => op.Customer)
                .WithMany(c => c.PartsBudget)
                .HasForeignKey(op => op.CustomerId);

            //Relacionamento.
            modelBuilder.Entity<PartsBudget>()
                .HasOne(op => op.Parts)
                .WithMany(op => op.PartsBudget)
                .HasForeignKey(op => op.PartsId);
                

            //Relacionamento.
            modelBuilder.Entity<Buy>()
                .HasOne(op => op.Parts)
                .WithMany()
                .HasForeignKey(op => op.PartsId);



            //Definição de tabelas no banco de dados.
            modelBuilder.Entity<PartsBudget>()
               .Property(op => op.TotalPrice)
               .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<PartsBudget>()
              .Property(op => op.AppliedPrice)
              .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<PartsBudget>()
              .Property(op => op.DiscountApplied)
              .HasColumnType("numeric(10,2)");


            modelBuilder.Entity<Buy>()
              .Property(op => op.CostPrice)
              .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<Buy>()
              .Property(op => op.AmountReceivable)
              .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<Parts>()
              .Property(op => op.Price)
              .HasColumnType("numeric(10,2)");
        }


    }

    
}
