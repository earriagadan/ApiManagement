namespace ApiManagementBlazor.Data
{
    public class RespuestaDetalleGetApi
    {
        public string TipoVerbo { get; set; }
        public string NombreMetodo { get; set; }
        public string BaseDeDatos { get; set; }
        public string Esquema { get; set; }
        public string Package { get; set; }
        public string Funcion { get; set; }
        public bool CacheActivo { get; set; }
        public int CacheMinutos { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string NombreDesarrollador { get; set; }
        public string EmailDesarrollador { get; set; }
        public string NombreJefeProyecto { get; set; }
        public string EmailJefeProyecto { get; set; }
        public List<Parametros> parametros { get; set; }
        public ArchivoReadme Readme { get; set; }
        public bool Duplicado { get; set; }

        public string descripcion { get; set; }
        public string urlBitbucket { get; set; }

    }
}
