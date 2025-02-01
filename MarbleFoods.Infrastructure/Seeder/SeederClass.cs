using MarbleFoods.Data;
using MarbleFoods.Domain.Enums;
using MarbleFoods.Domain.Models;
using MarbleFoods.Infrastructure.Commons;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarbleFoods.Infrastructure.Seeder
{
    public static class SeederClass
    {
        public static async Task SeedData(WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            await RunSeed(
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static async Task RunSeed(ApplicationDbContext context)
        {
            try
            {
                if (context != null)
                {
                    //await context.Database.EnsureCreatedAsync();
                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    {
                        await context.Database.MigrateAsync();
                    }

                    if (!context.MarbleFoodsUser.Any())
                    {
                        List<MarbleFoodsRoles> roles = new List<MarbleFoodsRoles> 
                        {
                            new MarbleFoodsRoles { Name = Policies.Admin, Description = "Administrator Functions" },
                            new MarbleFoodsRoles { Name = Policies.OperationsManager, Description = "Operations Manager Functions" },
                            new MarbleFoodsRoles { Name = Policies.ProcurementManager, Description = "Procureing Managers"},
                            new MarbleFoodsRoles { Name = Policies.WarehouseSupervisor, Description = "Warehouse Supervisor Functions" },
                            new MarbleFoodsRoles { Name = Policies.QualityControlSpecialist, Description = "QC Specialist Functions" },
                            new MarbleFoodsRoles { Name = Policies.WarehousePersonnel, Description = "Warehouse Keeper Functions" }
                        };

                        await context.MarbleFoodsRoles.AddRangeAsync(roles);

                        var controlUser = new MarbleFoodsUser
                        {
                            UserId = Guid.NewGuid(),
                            FirstName = "John",
                            LastName = "Doe",
                            Username = "SuperAdmin",
                            Email = "travltester@gmail.com",
                            PhoneNumber = "07025783611",
                            Gender = Gender.Male,
                            IsActive = true,
                            Avatar = "http://placehold.it/32x32",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            Status = UserStatus.Active,
                            RequiresMFA = false,
                            LastLoginDate = null,
                            CreatedTransactions = Enumerable.Empty<MarbleFoodsInventoryTransaction>().ToList(),
                            QualityChecks = Enumerable.Empty<MarbleFoodsQualityCheck>().ToList(),
                            UserRole = roles.FirstOrDefault(r => r.Name == Policies.Admin).RoleId,
                            TrustedDevices = Enumerable.Empty<MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice>().ToList(),
                            PasswordHash = "Password@123"
                        };
                        await context.MarbleFoodsUser.AddAsync(controlUser);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
