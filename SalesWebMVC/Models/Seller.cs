﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        // Operação para adicionar uma venda na lista de vendas
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        // Remover uma venda desse vendedor
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // Operação para retornar o total de vendas num período selecionado (data de entrada e data final)
         public double TotalSales(DateTime initial, DateTime final)
         {
            // Aqui vou filtrar primeiramente a lista de vendas obtendo uma nova lista contendo apenas as vendas nesse intervalo de data
            // Em seguida vou fazer a soma das vendas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
             
         }
    }
}