using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers
{
    public class DemoController : Controller
    {
        // host/Demo/Random
        public int Random()
        {
            return new Random().Next(100, 1000);
        }

        // host/Demo/Hello
        // host/Demo/Hello?name=xys
        public string Hello(string name = "Admin")
        {
            return $"Hello {name}. Welcome...";
        }

        // host/info
        [Route("/info")]
        public IActionResult actionResult()
        {
            return Json(new { BirthDate = "06/12/2020" });
        }

        public IActionResult Forward()
        {
            //return Redirect("/Demo/MyView");
            return RedirectToAction(actionName: "MyView", controllerName: "Demo");
        }

        public IActionResult MyView()
        {
            ViewBag.FromAction = "MyView";
            return View();
        }

        public IActionResult ActionIndex()
        {
            ViewBag.FromAction = "ActionIndex";
            return View("MyView");
        }
    }
}
