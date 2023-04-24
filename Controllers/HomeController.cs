using CSKarteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSKarteAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> Index()
        {
            // Objet RestRequest utilisé dans les RESTful APIs pour récupérer des informations à partir du endpoint salesOrder 
            RestRequest request = new RestRequest("/salesOrder");
            // Ajout d'un AuthenticationToken dans le header de l'objet RestRequest
            request.AddHeader("AuthenticationToken", "08f67197-1bba-47e9-a892-38139da5adcf");
            // Objet RestClient(RESTful API client) qui prend l'URL racine de l'API en paramètre, pour envoyer une requete au serveur 
            RestClient client = new RestClient("https://nexgen.weclapp.com/webapp/api/v1");

            //IRestResponse result = await client.ExecuteAsync(request);
            var response = await client.ExecuteAsync(request);

            // objet avec comme clé result et valeur un array d'objets
            // Deserialize the response(json string) into an object and retrieve the data from the response
            WeclappResult<WeclappAuftrag> data = JsonConvert.DeserializeObject<WeclappResult<WeclappAuftrag>>(response.Content); 

            // pass the data(data.result = array of objects with the type WeclappAuftrag) to the view
            return View(data.result); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
