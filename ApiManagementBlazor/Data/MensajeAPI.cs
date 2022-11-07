using System.Runtime.Serialization;

namespace ApiManagementBlazor.Data
{
    /// <summary>
    /// Clase General de respuesta de API, en ella se almacena el objeto completo retornado desde la base de datos, 
    /// además de información de errores controlados y detalles entregados por el servicio
    /// </summary>
    /// <typeparam name="T">Representa a cualquier objeto que se necesite retornar</typeparam>
    public class MensajeAPI<T>
    {
        #region Constructores

        public MensajeAPI()
        {
            Codigo = "200";
            Mensaje = null;
            Result = default(T);
        }

        #endregion Constructores

        #region Properties

        [DataMember]
        public string Codigo
        {
            get; set;
        }

        [DataMember]
        public List<T>? Contenido
        {
            get; set;
        }

        [DataMember]
        public T? Result
        {
            get; set;
        }

        [DataMember]
        public string? Mensaje
        {
            get; set;
        }

        #endregion Properties

        public static MensajeAPI<T> OK()
        {
            return new MensajeAPI<T>() { Codigo = "200", Mensaje = "OK" };
        }

        public static MensajeAPI<T> Error()
        {
            return new MensajeAPI<T>() { Codigo = "400", Mensaje = "Error 400, la clase no tiene el formato correcto" };
        }

        public static MensajeAPI<T> Error(string? mensaje)
        {
            mensaje ??= "Error 400, la clase no tiene el formato correcto";
            return new MensajeAPI<T>() { Codigo = "400", Mensaje = mensaje };
        }

             
    }
}
