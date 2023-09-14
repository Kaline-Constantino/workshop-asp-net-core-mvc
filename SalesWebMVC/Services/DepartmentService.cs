using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        /* OPERAÇÃO SÍNCRONA
         
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
        */

        public async Task<List<Department>> FindAllAsync()                                     //O sufixo async é uma recomendação da plataforma, não é obrigatório, apenas um padrão
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();              // await serve para avisar ao compilador que essa é uma chamada assíncrona
        }
    }
}
