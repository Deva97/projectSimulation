using MVCHttpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace MVCHttpClient.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments
        public ActionResult Index()
        {
            IEnumerable<Appointment> Appoint=null;
            using(var client =new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var responseTask = client.GetAsync("Appointments");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Appointment>>();
                   readTask.Wait();
                    Appoint = readTask.Result;

                }
                else
                {
                    Appoint = Enumerable.Empty<Appointment>();
                    ModelState.AddModelError(String.Empty, "Server Error");

                }
            }

            return View(Appoint);
        }
        //POST 
        public ActionResult create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult create(Appointment appoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var postTask = client.PostAsJsonAsync<Appointment>("Admins", appoint);
                postTask.Wait();
                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(String.Empty, "eRROR");
                return View(appoint);
            }
        }
        public ActionResult delete(int id)
        {
            using (var client =new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var deleteTask = client.DeleteAsync("Appointment/" + id.ToString());
                    deleteTask.Wait();
                var result = deleteTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

            }
            return RedirectToAction("Index");
        }

    }
}