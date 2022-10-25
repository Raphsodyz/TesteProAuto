using CadastroMVC.Models;
using CadastroMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CadastroMVC.Controllers
{
    public class UserController : Controller
    {
        static HttpClient Client = new HttpClient();
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Submitlogin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await 
                    Client.PostAsJsonAsync(_configuration.GetSection("ConnectionEndPoints:Login").Value, loginViewModel);

                if (response.IsSuccessStatusCode)
                {
                    var returnValue = await response.Content.ReadAsStringAsync();
                    var returnToken = JsonConvert.DeserializeObject<Token>(returnValue);
                    HttpContext.Session.SetString("token", returnToken.token);
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", 
                                                                 HttpContext.Session.GetString("token"));

                    return RedirectToAction("Index", "Home");
                }
            }

            return View("Login");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
