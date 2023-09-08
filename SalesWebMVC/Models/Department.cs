using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Adicionar um vendedor a lista de vendedores
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        // Total de vendas desse Departamento num intervalo específico de tempo
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Aqui vou pegar a lista de todos os vendedores deste departamento e somar o total de vendas de cada vendedor nesse intervalo de tempo
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
