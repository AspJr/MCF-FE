using McfFe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace McfFe.Controllers
{
    public class LoginController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7061/api/v1");
        private readonly HttpClient _client;

        public LoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;  
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActionIndex([Bind] User user)
        {
            var response = _client.PostAsJsonAsync(baseAddress + "/User/LoginUser", user).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonText = response.Content.ReadAsStringAsync().Result;
                ApiResponse responseData = JsonConvert.DeserializeObject<ApiResponse>(jsonText);
                HttpContext.Session.SetString("SessionUserId", JsonConvert.SerializeObject(responseData.data.user_id.ToString()));
                return RedirectToAction("Index", "Main");
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
