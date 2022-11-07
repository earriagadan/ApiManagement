using ApiManagementBlazor.Data.Ocelot;

namespace ApiManagementBlazor.Data
{
    public class RespuestaGetGateway
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlRespositorio { get; set; }
        public string UrlSwagger { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UrlApi { get; set; }
        public RespuestaDetalleGetGateway Detalle { get; set; }
        public List<Api> Apis { get; set; }
    }
}
