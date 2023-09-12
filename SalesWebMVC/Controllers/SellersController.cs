using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Aqui indico que a minha ação abaixo será um Post e não Get.
        [ValidateAntiForgeryToken] //Aqui previno que minha aplicação sofra ataques CSRF
        public IActionResult Create(Seller seller)  //Essa operação receberá um objeto vendedor(seller) que veio da requisição. Para que eu receba esse objeto e instancie esse vendedor, 
        //basta colocá-lo como parâmetro
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //Aqui após inserir o novo vendedor, redireciono a página para a página Sellers
        }
    }
}
