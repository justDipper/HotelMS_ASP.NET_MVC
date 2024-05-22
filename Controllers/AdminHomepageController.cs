using HotelMS_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace HotelMS_ASP.NET_MVC.Controllers
{
    public class AdminHomepageController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AdminHomepageController> _logger; // Add ILogger

        public AdminHomepageController(ILogger<AdminHomepageController> logger)
        {

            //This part is to put in _httpCLient the URL of the API

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7102/Homepage")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            _logger = logger; // Initialize ILogger
        }



        //This Part is Responsible to GET REQUEST to WEB API which is responsible also to RETREIVE DATA to Database

        //READ
        public async Task<ActionResult> Index()
        {
            try
            {

                var response = await _httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Hasauthorization = true;
                    ViewBag.Username = "admin";
                    var userAcc = await response.Content.ReadAsAsync<List<HomepageModel>>();
                    return View(userAcc);
                }
                else
                {
                    // Handle error response
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                // Handle exception
                return RedirectToAction("Index", "Home");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
