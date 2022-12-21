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

    [RoutePrefix("Users")]//vuol dire che tutti i route che ho scritto sono concatenati a questi prefisso per semplificarmi il lavoro

    public class UsersController : Controller
    {
        [Route("Random")]
        public async Task<ActionResult> Random()
        {
            using (var context = new Entities())
            {
                ViewData["Titolo"] = "Get One By Random"; //in random metto @((string)["Titolo"]) nel tag del titolo (solo per soluz. molto semplici)
                //oppure ancora usiamo una struttura viewbag che crea la mia proprietà nel momento in cui la assegno
                ViewBag.Titolo = "Get One By Random"; //quella più usata
                //oppure ancora potrei creare un viewmodel per la vista che contiene ciò che mi serve e poi passo tutto tramite vm (sconsigliato)
                int count = await context.Users.CountAsync();
                Random rnd = new Random();
                int toSkip = rnd.Next(0, count - 1);

                User u = await context.Users
                    .OrderBy(o => o.Id)
                    .Skip(toSkip).FirstOrDefaultAsync();

                return View(u);
            }

        }

        [Route("")]//basta solo /Users
        public async Task<ActionResult> Index()
        {
            //return View();
            //return Content("Questo è un content result");
            //return Redirect("https://www.google.com"); //stato risposta 302 redirect funzionante
            //return RedirectToRoute(//nome di route diverso da quello di default);
            //return RedirectToAction("Random", con questo parametro non obbligatorio posso specificare anche il nome del controller es. "Home");
            //"Random"=redirect verso l'azione random dallo stesso controller
            //return HttpNotFound(); //da come risultato un errore not found in certi casi può essere utile
            //return json("scrivere qua dentro il file json");
            //return File();
            //return new EmptyResult();
            //fine lista dei tipi di ritorno che si usano con ActionResult

            using (var context = new Entities())
            {
                return View(await context.Users.ToListAsync());
            }

        }

        [Route("GetOne/{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            using (var context = new Entities()) {
                //ViewData["Titolo"] = "Get One By Id";
                ViewBag.Titolo = "Get One By Id";
                User u = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
                return View("Random", u);
            }
        }

        /*public ActionResult GetOneByUsername(string username)
        {
            return Content(username);
        }*/ //senza attributes routing

        //con attributes routing
        [Route("GetOneByUsername/{username}")]
        public async Task<ActionResult> GetOneByUsername(string username)
        {
            using (var context = new Entities())
            {
                //ViewData["Titolo"] = "Get One By Username";
                ViewBag.Titolo = "Get One By Username";
                User u = await context.Users.FirstOrDefaultAsync(q => q.Username == username);
                return View("Random", u);
            }
        }

        [Route("Create")]//parte get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]//parte set
        public async Task<ActionResult> Create(User u)
        {
            using (var context = new Entities())
            {
                context.Users.Add(u);
                await context.SaveChangesAsync(); 
                return RedirectToAction("Index");
            }
        }
    

        [Route("Update/{id}")]//parte get
        public async Task<ActionResult> Update(int id)
        {
            using (var context = new Entities())
            {
                User candidate = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
                return View(candidate);
            }
        }

        [HttpPost]
        [Route("Update/{id}")]//parte set
        public async Task<ActionResult> Create(int id, User u)
        {
            using (var context = new Entities())
            {
                var candidate = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
                candidate.FirstName = u.FirstName;
                candidate.LastName = u.LastName;
                candidate.Password = u.Password;
                candidate.PostalCode = u.PostalCode;
                candidate.State = u.Username;
                candidate.Username = u.Username;
                candidate.Gender = u.Gender;
                candidate.Email = u.Email;
                candidate.City = u.City;
                candidate.BirthDate = u.BirthDate;
                candidate.Age = u.Age;
                candidate.Address = u.Address;
                await context.SaveChangesAsync();//in questo modo salva anche sul database
                return RedirectToAction("Index");
            }
        }

        [Route("Delete/{id}")]//parte get
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new Entities())
            {
                User candidate = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
                return View(candidate);
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]//parte set
        public async Task<ActionResult> DeleteConfig(int id) //nel set della delete dobbiamo per forza cambiare nome ma lasciamo lo stesso route
                                                             //perchè non ho un user da passare con la delete
        {
            using (var context = new Entities())
            {
                User candidate = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
                context.Users.Remove(candidate);//qui rimuove un elemento dal db solo se è appena creato
                                                //perchè gli altri hanno delle fk in logins su sql
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }


    }

}