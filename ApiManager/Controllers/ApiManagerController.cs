using ApiManager.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiManager.Controllers
{
    public class ApiManagerController : Controller
    {
        public IActionResult? Index(string sistema, string idUsuario, string token)
        {
            Logger.logInfo("INICIO Index Token: " + idUsuario);
            var model = new Bandeja();

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = $"http://aazocar-pc:7780/IntegraApi/api/GetApi";
                    var data = string.Empty;
                    var responseString = client.PostAsJsonAsync(uri, data);
                    responseString.Wait();

                    if (responseString.Result.IsSuccessStatusCode)
                    {
                        var result = responseString.Result.Content.ReadAsStringAsync().Result;
                        model.respuestaGetApi = JsonConvert.DeserializeObject<MensajeAPI<List<RespuestaGetApi>>>(result).Result;
                    }
                }

                return View("Index", model);
            }
            catch (Exception ex)
            {
                Logger.logError("ERROR Index Token: ", ex);
            }

            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarApi(string nombreMicroservicio)
        {
            Logger.logInfo("INICIO BuscarApi nombre: " + nombreMicroservicio);
            var model = new Bandeja();

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = $"http://aazocar-pc:7780/IntegraApi/api/GetApi";
                    var data = string.Empty;
                    var responseString = client.PostAsJsonAsync(uri, data);
                    responseString.Wait();

                    if (responseString.Result.IsSuccessStatusCode)
                    {
                        var result = responseString.Result.Content.ReadAsStringAsync().Result;
                        model.respuestaGetApi = JsonConvert.DeserializeObject<MensajeAPI<List<RespuestaGetApi>>>(result).Result.Where(x => x.Nombre.ToUpper().Contains(nombreMicroservicio.ToUpper())).ToList();
                    }
                }

                return View("Index", model);
            }
            catch (Exception ex)
            {
                Logger.logError("ERROR BuscarApi: ", ex);
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult IrDetalleApi(string nombre)
        {
            Logger.logInfo("INICIO IrDetalleApi nombre: " + nombre);
            var model = new Bandeja();

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = $"http://aazocar-pc:7780/IntegraApi/api/GetDetalleApi";
                    var data = new
                    {
                        nombre = nombre
                    };
                    var responseString = client.PostAsJsonAsync(uri, data);
                    responseString.Wait();

                    if (responseString.Result.IsSuccessStatusCode)
                    {
                        var result = responseString.Result.Content.ReadAsStringAsync().Result;
                        model.respuestaDetalleGetApi = JsonConvert.DeserializeObject<MensajeAPI<RespuestaDetalleGetApi>>(result).Result;
                    }
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                Logger.logError("ERROR IrDetalleApi: ", ex);
            }

            return View("Index", model);
        }
    }
}
