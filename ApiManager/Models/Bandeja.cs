namespace ApiManager.Models
{
    public class Bandeja
    {

        public string? token { get; set; }


        public int CodigoRespuesta { get; set; }
        public string? MensajeRespuesta { get; set; }


        public int USU_ID { get; set; }


        public List<RespuestaGetApi>? respuestaGetApi { get; set; }
        public RespuestaDetalleGetApi? respuestaDetalleGetApi { get; set; }


    }
}
