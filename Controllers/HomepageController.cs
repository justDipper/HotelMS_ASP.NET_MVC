using HotelMS_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace HotelMS_ASP.NET_MVC.Controllers
{
    public class HomepageController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomepageController> _logger; // Add ILogger

        public HomepageController(ILogger<HomepageController> logger)
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
                    // Retrieve the customer_id from the session
                    string customerId = HttpContext.Session.GetString("customerid");

                    // Check if customer_id is not null or empty
                    if (string.IsNullOrEmpty(customerId))
                    {
                        // Handle case when customer_id is not available in the session
                        return RedirectToAction("Index", "AdminHomepage");
                    }

                    // Set ViewBag properties
                    ViewBag.Hasauthorization = true;
                    ViewBag.Username = "user";

                    // Read and parse the response content as a list of HomepageModel
                    var userAcc = await response.Content.ReadAsAsync<List<HomepageModel>>();

                    // Filter the data based on the customer_id
                    var filteredData = userAcc.Where(item => item.customerId == customerId).ToList();

                    return View(filteredData); // Pass the filtered data to the view
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
