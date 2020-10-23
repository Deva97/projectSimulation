using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MVCAuthClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCAuthClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Appointment> appointments;
            UserLogin obj = new UserLogin { Username = "abc", Password = "abc123" };
            using (HttpClient client = new HttpClient())
            {
                
                    var token = GetToken("https://localhost:44393/api/Token/", obj);
                client.BaseAddress = new Uri("https://localhost:44393/api/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                var getTask = client.GetAsync("Token");
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    getTask.Wait();
                appointments = JsonConvert.DeserializeObject<IEnumerable<Appointment>>(stringData);
                }
                else
                {
                    appointments = Enumerable.Empty<Appointment>();
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
                
            }
            return View(appointments);
        }
        static string GetToken(string url, UserLogin user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
