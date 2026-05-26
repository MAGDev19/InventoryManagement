using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Models.Dto
{
    public class TokenRequest
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}
