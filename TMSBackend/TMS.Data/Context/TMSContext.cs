using Microsoft.EntityFrameworkCore;
using TMS.Data.DTO;
using TMS.Data.Enums;
using TMS.Data.Models;

namespace TMS.Data.Context
{
    public class TMSContext : DbContext
    {
        public TMSContext(DbContextOptions<TMSContext> options) : base(options)
        { }

        public DbSet<ProductionRecord> ProductionRecords { get; set; }

        public DbSet<TyreProduction> TyreProductions { get; set; }

        public DbSet<TyreSales> TyreSales { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }




        //DB Sets for DTO
        public DbSet<ProductionByDayDTO> ProductionByDay { get; set; }

        public DbSet<ProductionByShiftDTO> ProductionByShift { get; set; }

        public DbSet<ProductionByMachineDTO> ProductionByMachine { get; set; }

        public DbSet<ProductionByOperatorDTO> ProductionByOperator { get; set; }

        public DbSet<StockBalanceDTO> StockBalance { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TyreProduction>()
               .HasOne(tp => tp.Operator)
               .WithMany(u => u.TyreProductions)
               .HasForeignKey(tp => tp.OperatorId)
               .OnDelete(DeleteBehavior.Restrict);

            // Relationship: TyreProduction and TyreSales
            modelBuilder.Entity<TyreSales>()
                .HasOne(ts => ts.ReferenceProduction)
                .WithMany(tp => tp.TyreSales)
                .HasForeignKey(ts => ts.ReferenceProductionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();


            modelBuilder.Entity<ProductionByDayDTO>().HasNoKey();
            modelBuilder.Entity<ProductionByShiftDTO>().HasNoKey();
            modelBuilder.Entity<ProductionByMachineDTO>().HasNoKey();
            modelBuilder.Entity<ProductionByOperatorDTO>().HasNoKey();
            modelBuilder.Entity<StockBalanceDTO>().HasNoKey();


            string operator1 = "operator1";
            string supervisor1 = "supervisor1";
            string leader1 = "leader1";
            string hashed_operator1 = BCrypt.Net.BCrypt.HashPassword(operator1);
            string hashed_supervisor1 = BCrypt.Net.BCrypt.HashPassword(supervisor1);
            string hashed_leader1 = BCrypt.Net.BCrypt.HashPassword(leader1);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "operator1", Password = hashed_operator1, UserRole = Enums.UserRole.ProductionOperator },
                new User { Id = 2, Username = "supervisor1", Password = hashed_supervisor1, UserRole = Enums.UserRole.QualitySupervisor },
                new User { Id = 3, Username = "leader1", Password = hashed_leader1, UserRole = Enums.UserRole.BusinessUnitLeader }

                );

            modelBuilder.Entity<TyreProduction>().HasData(
                new TyreProduction { Id = 1, TyreCode = "T123", Quantity = 100, OperatorId = 1, ProductionDate = DateTime.Now, ProductionShift = ProductionShift.Morning, MachineNumber = "M001" },
                new TyreProduction { Id = 2, TyreCode = "T124", Quantity = 150, OperatorId = 1, ProductionDate = DateTime.Now, ProductionShift = ProductionShift.Night, MachineNumber = "M002" }
            );

            modelBuilder.Entity<TyreSales>().HasData(
                new TyreSales { Id = 1, TyreName = "T123", QuantitySold = 50, UnitOfMeasure = "pieces", Price = 100.00M, DateOfSale = DateTime.Now, ReferenceProductionId = 1, DestinationMarket = "Local", PurchasingCompany = "ABC Ltd." },
                new TyreSales { Id = 2, TyreName = "T124", QuantitySold = 30, UnitOfMeasure = "pieces", Price = 120.00M, DateOfSale = DateTime.Now, ReferenceProductionId = 2, DestinationMarket = "International", PurchasingCompany = "XYZ Corp." }
            );
        }






    }
}
