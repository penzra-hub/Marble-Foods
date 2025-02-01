using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Infrastructure.Commons
{
    public static class Policies
    {

        public const string Admin = "Admin";
        public const string OperationsManager = "OperationsManager";
        public const string WarehouseSupervisor = "WarehouseSupervisor";
        public const string ProcurementManager = "ProcurementManager";
        public const string QualityControlSpecialist = "QualityControlSpecialist";
        public const string WarehousePersonnel = "WarehousePersonnel";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy OperationsManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(OperationsManager).Build();
        }

        public static AuthorizationPolicy WarehouseSupervisorPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(WarehouseSupervisor).Build();
        }

        public static AuthorizationPolicy ProcurementManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(ProcurementManager).Build();
        }

        public static AuthorizationPolicy QualityControlSpecialistPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(QualityControlSpecialist).Build();
        }

        public static AuthorizationPolicy WarehousePersonnelPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(WarehousePersonnel).Build();
        }
    }
}
