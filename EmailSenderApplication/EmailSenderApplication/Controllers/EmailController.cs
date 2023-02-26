using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApplication.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Send()
        //{
        //    return View();
        //}
    }
}
