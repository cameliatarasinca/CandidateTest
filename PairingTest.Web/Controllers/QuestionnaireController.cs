using System;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //        public async Task<ViewResult> Index()
        //        {
        //        }

        private readonly IConfiguration _config;

        public QuestionnaireController(IConfiguration config)
        {
            _config = config;
        }

        public ViewResult Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(_config.Url).Result;

                if (response == null)
                    return View("Error");

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var viewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<QuestionnaireViewModel>(data);

                    return View(viewModel);
                }
            }

            return View("Error");
        }
    }
}
