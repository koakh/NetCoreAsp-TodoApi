using Microsoft.AspNetCore.Mvc;

namespace NetCoreAspTodoApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/Error
        public string Error()
        {
            return "CREATE ERROR PAGE";
        }
    }
}
