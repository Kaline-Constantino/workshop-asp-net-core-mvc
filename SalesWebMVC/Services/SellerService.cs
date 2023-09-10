using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        // readonly previne que essa dependência não possa ser alterada.
        private readonly SalesWebMVCContext _context;

        // construtor para que a injeção de dependência possa ocorrer
        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // Aqui implemento a operação findall para retornar uma lista com todos os vendedores do BD. 
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); //Isso irá acessar a minha fonte de dados relacionada a tabela de vendedores e converter para uma lista. 
            // Por enquanto será uma operação síncrona
        }

    }
}
