using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        // Aqui criei um construtor recebendo um obj do tipo Sales...Context para indicar que a injeção de dependência deve acontecer.
        // Ou seja, quando um seedingservice for criado, automaticamente ele irá receber uma instância com context também.  
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // Esta operção será responsável por popular a minha base de dados
        public void Seed()
        {
            // Primeiro vou fazer um teste para saber se existe algum dado na minha base de dados, se sim, vou interromper a  operação.
            // A operação Any do Linq vai testar se existe algum registro na tabela selecionada.
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // BD já foi populado
            }

            // Como estou usando o workflow code first, ou seja, eu crio os objetos e daí crio a base de dados, 
            // irei fazer aqui a instanciação dos objs e mandar salvá-los no BD.
            Department d1 = new Department(new int(), "Computers");
            Department d2 = new Department(new int(), "Electronics");
            Department d3 = new Department(new int(), "Fashion");
            Department d4 = new Department(new int(), "Books");

            Seller s1 = new Seller(new int(), "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(new int(), "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(new int(), "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(new int(), "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(new int(), "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(new int(), "Jonny Pink", "jonny@gmial.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(new int(), new DateTime(2023, 06, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(new int(), new DateTime(2023, 06, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecord r3 = new SalesRecord(new int(), new DateTime(2023, 06, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord r4 = new SalesRecord(new int(), new DateTime(2023, 06, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(new int(), new DateTime(2023, 06, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(new int(), new DateTime(2023, 06, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(new int(), new DateTime(2023, 06, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(new int(), new DateTime(2023, 06, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord(new int(), new DateTime(2023, 06, 14), 11000.0, SaleStatus.Pending, s6);
            SalesRecord r10 = new SalesRecord(new int(), new DateTime(2023, 07, 7), 9000.0, SaleStatus.Billed, s6);
            SalesRecord r11 = new SalesRecord(new int(), new DateTime(2023, 07, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(new int(), new DateTime(2023, 07, 25), 7000.0, SaleStatus.Pending, s3);
            SalesRecord r13 = new SalesRecord(new int(), new DateTime(2023, 07, 29), 10000.0, SaleStatus.Billed, s4);
            SalesRecord r14 = new SalesRecord(new int(), new DateTime(2023, 07, 4), 3000.0, SaleStatus.Billed, s5);
            SalesRecord r15 = new SalesRecord(new int(), new DateTime(2023, 07, 12), 4000.0, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(new int(), new DateTime(2023, 08, 5), 2000.0, SaleStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(new int(), new DateTime(2023, 08, 1), 12000.0, SaleStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(new int(), new DateTime(2023, 08, 24), 6000.0, SaleStatus.Billed, s3);
            SalesRecord r19 = new SalesRecord(new int(), new DateTime(2023, 08, 22), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(new int(), new DateTime(2023, 08, 15), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(new int(), new DateTime(2023, 08, 17), 9000.0, SaleStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(new int(), new DateTime(2023, 08, 24), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(new int(), new DateTime(2023, 08, 19), 11000.0, SaleStatus.Canceled, s2);
            SalesRecord r24 = new SalesRecord(new int(), new DateTime(2023, 08, 12), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r25 = new SalesRecord(new int(), new DateTime(2023, 08, 31), 7000.0, SaleStatus.Billed, s3);
            SalesRecord r26 = new SalesRecord(new int(), new DateTime(2023, 08, 6), 5000.0, SaleStatus.Billed, s4);
            SalesRecord r27 = new SalesRecord(new int(), new DateTime(2023, 08, 13), 9000.0, SaleStatus.Pending, s1);
            SalesRecord r28 = new SalesRecord(new int(), new DateTime(2023, 08, 7), 4000.0, SaleStatus.Billed, s3);
            SalesRecord r29 = new SalesRecord(new int(), new DateTime(2023, 08, 23), 12000.0, SaleStatus.Billed, s5);
            SalesRecord r30 = new SalesRecord(new int(), new DateTime(2023, 08, 12), 5000.0, SaleStatus.Billed, s2);

            // Vou mandar adicionar esses objs agora no BD usando o Entity Framework
            // O método addrange permite que adicione vários objs de uma só vez
            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                );

            // E para efetivar essas alterações, chamo o .savechanges(), ele salva e confirma as alterações no BD.
            _context.SaveChanges();

        }
    }
}
