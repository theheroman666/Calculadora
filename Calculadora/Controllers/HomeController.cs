using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ModelCalculadora calculadora)
        {
            if ("+".Equals(calculadora.Operacion))
            {
                calculadora.Resultado = calculadora.Valor1 + calculadora.Valor2;
            }

            else if ("-".Equals(calculadora.Operacion))
            {
                calculadora.Resultado = calculadora.Valor1 - calculadora.Valor2;
            }
            else if ("/".Equals(calculadora.Operacion))
            {
                calculadora.Resultado = calculadora.Valor1 / calculadora.Valor2;
            }
            else if ("*".Equals(calculadora.Operacion))
            {
                calculadora.Resultado = calculadora.Valor1 * calculadora.Valor2;
            }
            else if ("!".Equals(calculadora.Operacion))
            {
                //factorial sin funcion recursiva
                if (calculadora.Valor1 > calculadora.Valor2)
                {

                    //    int fact = (int)calculadora.Valor1;
                    //    int n = (int)calculadora.Valor1;
                    //    for (int i = n; i > 1; i--)
                    //    {
                    //        fact = fact * (i - 1);
                    //    }
                    //        calculadora.Resultado = fact;
                    calculadora.Resultado = factorial(calculadora.Valor1);
                    calculadora.Valor2 = 0;
                }
                else if (calculadora.Valor2 > calculadora.Valor1)
                {
                    calculadora.Resultado = factorial(calculadora.Valor2);
                    calculadora.Valor1 = 0;

                }
            }

            return View("Index", calculadora);
        }


        //funcion recursiva
        public int factorial(int n)
        {
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}