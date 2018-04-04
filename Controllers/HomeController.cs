using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
namespace quotes.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            return View("index");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult CreateQuote(string name, string quote)
        {
           
            DbConnector.Execute($"Insert into quotes(name, quote, created_at) values('{name}', '{quote}', now())");
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult ListQuote()
        {
           
            var quotes = DbConnector.Query("Select * from quotes");
            ViewBag.quotes = quotes;
            return View("quotes");
        }

    }
}