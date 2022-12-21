using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UsersAsp2.Models;

namespace UsersAsp2.Controllers
{
    [RoutePrefix("Logins")]
    public class LoginsController : Controller
    {   
            [Route("")]//basta solo /Logins
            public async Task<ActionResult> Index()
            {
                using (var context = new Entities())
                {
                    return View(await context.Logins.ToListAsync());
                }

            }
        

        [Route("GetOneById/{id}")]
        public async Task<ActionResult> GetLoginById(int idl)
        {
            using (var context = new Entities())
            {
                Login l = await context.Logins.FirstOrDefaultAsync(q => q.Id == idl);
                return View(idl);
            }
        }

        [Route("Create")]//parte get
        public async Task<ActionResult> Createl()
        {
            using (var context = new Entities())
            {
                var users = await context.Users
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text  = s.LastName + " " + s.FirstName
                    }).ToListAsync() ;
                return View();
            }
                
        }

        [HttpPost]
        [Route("Create")]//parte set
        public async Task<ActionResult> Createl(Login l)
        {
            using (var context = new Entities())
            {
                context.Logins.Add(l);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}