using CadastroMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CadastroMVC.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient Client = new HttpClient();
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            Client.DefaultRequestHeaders.Authorization = new 
                AuthenticationHeaderValue("bearer", HttpContext.Session.GetString("token"));

            HttpResponseMessage response = await
                Client.GetAsync(_configuration.GetSection("ConnectionEndPoints:Show-Associado").Value);

            if (response.IsSuccessStatusCode)
            {
                var associado = await response.Content.ReadFromJsonAsync<AssociadoViewModel>();
                return View(associado);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}