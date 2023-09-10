using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        //Declarar uma dependência para o sellerservice
        private readonly SellerService _sellerService;

        //Construtor para injetar a dependência
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() //Esse indx chamará a operação findall do sellerservice.
        {
            var list = _sellerService.FindAll(); //Essa operação me retornará uma lista de seller

            return View(list); //Aqui passo esta lista como argumento no método view, gerando assim, um IActionResult contendo esta lista. 
        }
    }
}
