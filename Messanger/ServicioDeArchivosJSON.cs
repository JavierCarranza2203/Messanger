using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Messanger
{
    internal class ServicioDeArchivosJSON<Tipo>
    {
        public string FormatearJSON(Tipo objeto)
        {
            return JsonConvert.SerializeObject(objeto, Formatting.Indented);
        }

        public string LeerJSON(string ruta)
        {
            return File.ReadAllText(ruta);
        }

        //Metodo para cargar en la lista lo de que hay en el archivo 
        public Tipo DeserializarJSON(string cadena)
        {
            return JsonConvert.DeserializeObject<Tipo>(cadena);
        }

        public void GuardarJSON(string texto, string ruta)
        {
            //Sobre escribe lo de la lista en el archivo
            File.WriteAllText(ruta, texto);
        }
    }
}
