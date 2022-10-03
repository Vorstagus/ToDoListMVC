using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{
   
    public class RecordsController : Controller
    {

        // private  DataContext _context;
        private DataContext db;


        public RecordsController(DataContext context)
        {
            db = context;


        }


        /* Another possible way to display lists. Need to learn :)
                public async Task<List<RecordModel>> RecordsList()
                {

                    var UserId = HttpContext.Session.GetString("Id");

                    var records = await db.Records.ToListAsync();
                    if(records?.Any() == true)
                    {
                        foreach(var record in records)
                        {
                            if (record.UserId == UserId)
                            {
                                records.Add(new RecordModel()
                                {
                                    Id = record.Id,
                                    Name = record.Name,
                                    Description = record.Description,
                                    UserId = record.UserId,
                                });
                            }
                        }
                    }
                    return records;
                }
        */


        [Route("RecordsController/RegisterRecord")]
        [HttpPost]
        public IActionResult RegisterRecord(RecordModel model)
        {

         var newRecord = new RecordModel()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                UserId = HttpContext.Session.GetString("Id")
        };
            db.Records.Add(newRecord);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [Route("RecordsController/LoadEditRecord/{Id}")]
        public IActionResult LoadEditRecord(int Id)
        {
            var editedRecord = new RecordModel();
            var UserId = HttpContext.Session.GetString("Id");
            if (UserId != null)
            {
                editedRecord = db.Records.Where(x => x.Id == Id && x.UserId == UserId).FirstOrDefault();

                return RedirectToAction("EditRecord", "Home", editedRecord);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }





        [Route("RecordsController/EditRecord/{Id}")]
        public IActionResult EditRecord(RecordModel model)
        {
            return RedirectToAction("Index", "Home");
        }







        [Route("RecordsController/DeleteRecord/{Id}")]
        public IActionResult DeleteRecord(int Id)
        {
             var deletedRecord = new RecordModel();
             var UserId = HttpContext.Session.GetString("Id");
             if(UserId != null) { 
                deletedRecord = db.Records.Where(x => x.Id == Id && x.UserId == UserId).FirstOrDefault();
                db.Records.Remove(deletedRecord);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }else
            {
                return RedirectToAction("Index", "Home");
            }
        }






        }
}
