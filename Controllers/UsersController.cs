 
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ToDoListMVC.Models;
 
 
namespace ToDoListMVC.Controllers
{
   
    public class UsersController : Controller
    {
        // private  DataContext _context;
        private DataContext db;

       
        public UsersController(DataContext context)
        {
            db = context;


        }



        [Route("UsersController/Login")]
        [HttpPost]
        public IActionResult Login(UserModel model) {

        
         
                var userDetails = db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if(userDetails != null)
            {
                HttpContext.Session.SetString("Id", ""+userDetails.Id+"");
                ViewBag.Message = HttpContext.Session.GetString("Id");
                ViewBag.session = HttpContext.Session.GetString("Id");
                return RedirectToAction("Index", "Home");

            }
            else
            {

                ViewBag.Message = "Incorrect email or password";
                return View("~/Views/Home/LoginView.cshtml");

            }
           
        }
    


        [Route("UsersController/Logout")]
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction("LoginView", "Home");
        }



        // return View("~/Views/Home/Index.cshtml");




        [Route("UsersController/Register")]
        
        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            //string confirmPassoword = ConfirmPassword;
       
            
           UserModel emailCheck = db.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            
            
            // exemplu de stored procedure call var resulttest = db.Users.FromSqlInterpolated($"exec [dbo].[user_registration] .... adaugarea de parametrii");
             if (emailCheck != null)
             {

                   ViewBag.Message = "User already exists";
                   return View("~/Views/Home/RegisterView.cshtml");
            }
             else
             {
                // var resultRegistration = new UserModel { Id = 2,  Username = "Willi32am", Password = "te32st", Email = "test@23test.com" }
             
                // var resultRegistration = db.Users.FromSqlInterpolated($"exec dbo.user_registration @Email = {email} @Username = {username} @Password = {password}");
                var newUser = new UserModel()
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password 
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                ViewBag.Message = "Registration successful";
                return RedirectToAction("LoginView", "Home");
             }
          





        }



        





    }
}