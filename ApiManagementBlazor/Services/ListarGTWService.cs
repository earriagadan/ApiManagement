using ApiManagementBlazor.Data;
using Newtonsoft.Json;
using ApiManagementBlazor.Utils;

namespace ApiManagementBlazor.Services
{
    public class ListarGTWService
    {
        IConfiguration Configuration = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json")
                                   .AddEnvironmentVariables()
                                   .Build();


        public async Task<List<RespuestaGetGateway>> GetListarGTW()
        {
            await Logger.logInfo("INICIO GetListarGTW ");

            MensajeAPI<List<RespuestaGetGateway>> retorno = new()
            {
                Result = new()
            };

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = $"{Configuration["ApiManagerGTW"]}/api/GetGateway";
                    var data = string.Empty;
                    var responseString = client.PostAsJsonAsync(uri, data);
                    responseString.Wait();

                    if (responseString.Result.IsSuccessStatusCode)
                    {
                        var result = responseString.Result.Content.ReadAsStringAsync().Result;
                        retorno.Result = JsonConvert.DeserializeObject<MensajeAPI<List<RespuestaGetGateway>>>(result).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                await Logger.logError("ERROR GetListarGTW: " + ex);
                throw;
            }

            await Logger.logInfo("FIN GetListarGTW");
            return retorno.Result;
        }
    }
}
