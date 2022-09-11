using Microsoft.EntityFrameworkCore;

namespace ElectroApiTest.Models
{
    public class ElectroContext : DbContext
    {
        public ElectroContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1,
                Name = "Kalles Grustransporter AB Cementvägen 8, 111 11 Södertälje"               

            }, new Customer
            {
                CustomerID = 2,
                Name = "Johans Bulk AB Balkvägen 12, 222 22 Stockholm"
            }, new Customer
            {
                CustomerID = 3,
                Name = "Haralds Värdetransporter AB Budgetvägen 1, 333 33 Uppsala"
            });

            modelBuilder.Entity<Appliance>().HasData(new Appliance
            {
                ApplianceID = "YS2R4X20005399401",
                FactoryNo = "ABC123",
                CustomerID = 1

            }, new Appliance
            {
                ApplianceID = "VLUR4X20009093588",
                FactoryNo = "ABC123",
                CustomerID = 1
            }, new Appliance
            {
                ApplianceID = "VLUR4X20009048066",
                FactoryNo = "GHI789",
                CustomerID = 1
            }, new Appliance
            {
                ApplianceID = "YS2R4X20005388011",
                FactoryNo = "JKL012",
                CustomerID = 2
            }, new Appliance
            {
                ApplianceID = "YS2R4X20005387949",
                FactoryNo = "MNO345",
                CustomerID = 2
            }, new Appliance
            {
                ApplianceID = "YS2R4X20009048066",
                FactoryNo = "PQR678",
                CustomerID = 3
            }, new Appliance
            {
                ApplianceID = "YS2R4X20005387055",
                FactoryNo = "STU901",
                CustomerID = 3
            });     
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appliance> Appliances { get; set; }
        public DbSet<ApplianceStatus> ApplianceStatuses { get; set; }
    }
}
