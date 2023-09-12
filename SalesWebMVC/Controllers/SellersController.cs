using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
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
        private readonly DepartmentService _departmentService;

        //Construtor para injetar a dependência
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() //Esse indx chamará a operação findall do sellerservice.
        {
            var list = _sellerService.FindAll(); //Essa operação me retornará uma lista de seller

            return View(list); //Aqui passo esta lista como argumento no método view, gerando assim, um IActionResult contendo esta lista. 
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); //Aqui ele irá buscar do BD todos os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost] //Aqui indico que a minha ação abaixo será um Post e não Get.
        [ValidateAntiForgeryToken] //Aqui previno que minha aplicação sofra ataques CSRF
        public IActionResult Create(Seller seller)  //Essa operação receberá um objeto vendedor(seller) que veio da requisição. Para que eu receba esse objeto e instancie esse vendedor, 
        //basta colocá-lo como parâmetro
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //Aqui após inserir o novo vendedor, redireciono a página para a página Sellers
        }

        public IActionResult Delete(int? id) // ? pra dizer que int é opcional
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value); // Aqui tenho que colocar .value porque o id é um objeto opcional
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
