using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            //ViewBag.session = HttpContext.Session.GetString("Id");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var userId = HttpContext.Session.GetString("Id");
                ViewBag.session = HttpContext.Session.GetString("Id");
                return View(_context.Records.ToList().Where(x => x.UserId == userId));
            }
            else
            {
                ViewBag.session = HttpContext.Session.GetString("Id");
                return View();

            }
        }


        public IActionResult RegisterRecord()
        {
            ViewBag.session = HttpContext.Session.GetString("Id");
            return View();
        }

        public IActionResult EditRecord(int Id)
        {

            var editedRecord = new RecordModel();
            var UserId = HttpContext.Session.GetString("Id");
            if (UserId != null)
            {
                editedRecord = _context.Records.Where(x => x.Id == Id && x.UserId == UserId).FirstOrDefault();
                ViewBag.session = HttpContext.Session.GetString("Id");
                return RedirectToAction("EditRecord", "Home", editedRecord);
            }
            else
            {
                ViewBag.session = HttpContext.Session.GetString("Id");
                return RedirectToAction("Index", "Home");
            }









            //ViewBag.session = HttpContext.Session.GetString("Id");
            //return View();
        }



        public IActionResult Privacy()
        {
            ViewBag.session = HttpContext.Session.GetString("Id");
            return View();
        }

        public IActionResult RegisterView()
        {
            ViewBag.session = HttpContext.Session.GetString("Id");
            if (ViewBag.session != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else { 
            ViewBag.session = HttpContext.Session.GetString("Id");
            return View();
            }
        }

        public IActionResult LoginView()
        {
            ViewBag.session = HttpContext.Session.GetString("Id");
            if (ViewBag.session != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewBag.session = HttpContext.Session.GetString("Id");
                return View();
            }
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}