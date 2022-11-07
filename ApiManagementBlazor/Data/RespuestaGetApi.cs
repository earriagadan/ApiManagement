namespace ApiManagementBlazor.Data
{
    public class RespuestaGetApi
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlRespositorio { get; set; }
        public string UrlSwagger { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UrlApi { get; set; }
        public RespuestaDetalleGetApi Detalle { get; set; }
    }
}
