using ApiManagementBlazor.Data;
using ApiManagementBlazor.Utils;
using Newtonsoft.Json;

namespace ApiManagementBlazor.Services
{
    public class ListarMicroserviciosService
    {
        IConfiguration Configuration = new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json")
                               .AddEnvironmentVariables()
                               .Build();

        public async Task<List<RespuestaGetApi>> GetListarMicroservicios()
        {
            await Logger.logInfo("INICIO GetListarMicroservicios ");

            MensajeAPI<List<RespuestaGetApi>> retorno = new()
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
                        retorno.Result = JsonConvert.DeserializeObject<MensajeAPI<List<RespuestaGetApi>>>(result).Result.OrderBy(x => x.Nombre).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                await Logger.logError("ERROR GetListarMicroservicios: " + ex);
                throw;
            }

            await Logger.logInfo("FIN GetListarMicroservicios");
            return retorno.Result;
        }
    }
}
