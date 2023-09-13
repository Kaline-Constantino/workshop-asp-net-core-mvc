using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) //Irá me retornar o vendedor que possui esse id. Se não existir, retorna nulo 
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
