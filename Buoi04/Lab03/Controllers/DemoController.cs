using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab03.Controllers
{
    public class DemoController : Controller
    {
        public async Task<IActionResult> AsyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            var x = MyDemo.FuncAAsync();
            var y = MyDemo.FuncBAsync();
            var z = MyDemo.FuncCAsync();
            await x; await y; await z;
            sw.Stop();

            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult SyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            MyDemo.FuncA();
            MyDemo.FuncB();
            MyDemo.FuncC();
            sw.Stop();

            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }
    }
}
