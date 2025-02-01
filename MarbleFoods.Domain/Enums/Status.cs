using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Enums
{
    public enum ItemStatus
    {
        Active = 1,
        Reserved = 2, 
        Expired = 3, 
        Consumed = 4
    }

    public enum UserStatus
    {
        Active = 1,
        Inactive = 2,
        Deactivated = 3,
        Deleted = 4,
    }
}
