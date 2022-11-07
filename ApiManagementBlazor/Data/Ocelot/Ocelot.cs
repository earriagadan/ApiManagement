using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManagementBlazor.Data.Ocelot
{
    //internal class Ocelot
    //{
    //    public List<Api> ListaApi
    //}

    public class Api
    {
        public string NombreApi { get; set; }
        public bool SeguridadActivada { get; set; }
        public string UrlApi { get; set; }
        public string UrlGTW { get; set; }
    }
}
