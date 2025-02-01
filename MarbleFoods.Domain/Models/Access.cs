using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class Access
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ApiKey { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }
        public string Salt { get; set; }
    }
}
