using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test.SBD.Front.WebApp.Models;

namespace Test.SBD.Front.WebApp.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            List<FacturaModel> facturas = null;
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Factura");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp = response.Content;
                resp = resp.Trim("\"".ToCharArray());
                resp = resp.Replace("\\", "");
                facturas = new List<FacturaModel>(JsonConvert.DeserializeObject<List<FacturaModel>>(resp));
            }
            return View(facturas);
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            FacturaModel factura = null;
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Factura/" + id);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp = response.Content;
                resp = resp.Trim("\"".ToCharArray());
                resp = resp.Replace("\\", "");
                factura = new List<FacturaModel>(JsonConvert.DeserializeObject<List<FacturaModel>>(resp)).FirstOrDefault();
            }
            return View(factura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(FacturaModel factura)
        {
            try
            {
                RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Factura");
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(factura);
                var response = restClient.Execute(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(FacturaModel factura)
        {
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Factura");
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(factura);
            var response = restClient.Execute(request);
            return RedirectToAction("Index");
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Factura/" + id);
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            return RedirectToAction("Index");
        }
    }
}