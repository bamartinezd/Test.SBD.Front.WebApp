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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteModel> Clientes = null;
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Cliente");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp = response.Content;
                resp = resp.Trim("\"".ToCharArray());
                resp = resp.Replace("\\", "");
                Clientes = new List<ClienteModel>(JsonConvert.DeserializeObject<List<ClienteModel>>(resp));
            }
            return View(Clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(long id)
        {
            ClienteModel Cliente = null;
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Cliente/" + id);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp = response.Content;
                resp = resp.Trim("\"".ToCharArray());
                resp = resp.Replace("\\", "");
                Cliente = new List<ClienteModel>(JsonConvert.DeserializeObject<List<ClienteModel>>(resp)).FirstOrDefault();
            }
            return View(Cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteModel Cliente)
        {
            try
            {
                RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Cliente");
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(Cliente);
                var response = restClient.Execute(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteModel Cliente)
        {
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Cliente");
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(Cliente);
            var response = restClient.Execute(request);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(long id)
        {
            RestClient restClient = new RestClient(ConfigurationManager.AppSettings["URLBackend"] + "api/Cliente/" + id);
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            return RedirectToAction("Index");
        }
    }
}