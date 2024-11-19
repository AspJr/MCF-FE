using McfFe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace McfFe.Controllers
{
    public class MainController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7061/api/v1");
        private readonly HttpClient _client;
        
        public MainController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<BPKB> list = new List<BPKB>();
            var session = HttpContext.Session.GetString("SessionUserId");
            if (session == null) {
                return RedirectToAction("Index", "Login");
            }

            var response = _client.GetAsync(baseAddress + "/BPKB/ListDataBpkb").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<BPKB>>(data);
            }

            return View(list);
        }

        public IActionResult Create()
        {
            var session = HttpContext.Session.GetString("SessionUserId");

            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            List<Storage> storages = new List<Storage>();
            var response = _client.GetAsync(baseAddress + "/StorageLoc/GetListLocation").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                storages = JsonConvert.DeserializeObject<List<Storage>>(data);
                ViewBag.DropdownStorages = storages; // Pass options to the view using ViewBag
            }

            return View();
        }

        public IActionResult CreateLogic([Bind] BPKB bpkb)
        {
            var session = HttpContext.Session.GetString("SessionUserId");
            int userID = JsonConvert.DeserializeObject<int>(session);
            bpkb.user_id = userID;
            var response = _client.PostAsJsonAsync(baseAddress + "/BPKB/InsertDataBpkb", bpkb).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return RedirectToAction("Index", "Main/Create");
            }

            return View();
        }

    }
}
