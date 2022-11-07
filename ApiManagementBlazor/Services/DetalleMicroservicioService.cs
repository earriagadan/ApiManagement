using ApiManagementBlazor.Data;
using Newtonsoft.Json;
using ApiManagementBlazor.Utils;

namespace ApiManagementBlazor.Services
{
    public class DetalleMicroservicioService
    {
        IConfiguration Configuration = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json")
                                   .AddEnvironmentVariables()
                                   .Build();


        public async Task<RespuestaDetalleGetApi> GetDetalleMicroservicio(string nombre)
        {
            await Logger.logInfo("INICIO GetDetalleMicroservicio nombre: " + nombre);
            
            MensajeAPI<RespuestaDetalleGetApi> retorno = new()
            {
                Result = new()
            };

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = $"{Configuration["ApiManagerGTW"]}/api/GetApi";
                    var data = string.Empty;
                    var responseString = client.PostAsJsonAsync(uri, data);
                    responseString.Wait();

                    if (responseString.Result.IsSuccessStatusCode)
                    {
                        var result = responseString.Result.Content.ReadAsStringAsync().Result;
                        retorno.Result = (JsonConvert.DeserializeObject<MensajeAPI<List<RespuestaGetApi>>>(result).Result.Where(x => x.Nombre.Equals(nombre)).ToList())[0].Detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                await Logger.logError("ERROR GetDetalleMicroservicio: " + ex);
                throw;
            }

            await Logger.logInfo("FIN GetDetalleMicroservicio");
            return retorno.Result;
        }
    }
}
