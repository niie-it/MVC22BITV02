using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double a, double b, string op)
        {
            double result = 0;
            switch(op)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/": result = a / b; break;
                case "%": result = a % b; break;
                case "^": result = Math.Pow(a, b); break;
            }

            ViewBag.Result = result;
            ViewBag.A = a; ViewBag.B = b;
            ViewBag.Op = op;
            return View("Index");
        }
    }
}
