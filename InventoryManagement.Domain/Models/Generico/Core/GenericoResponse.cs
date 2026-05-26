using InventoryManagement.Domain.Models.Farma.SP;
using InventoryManagement.Domain.Entities.CustomEntities;
using InventoryManagement.Domain.Models.Farma.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Models.Farma.Core
{
    public class GenericoResponse
    {
        public PagedList<UsuarioAdministrativo> PagedUsuarioAdministrativo { get; set; }
        public PagedList<FuncionarioTaquilla> PagedFuncionarioTaquilla { get; set; }
        public PagedList<EmpresaSede> PagedEmpresaSede { get; set; }
    }
}
