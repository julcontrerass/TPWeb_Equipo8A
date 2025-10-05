using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public Imagen() { }
        public Imagen(string url, int idArticulo)
        {
            this.URL = url;
            this.IdArticulo = idArticulo;
           
        }

        public string URL { get; set; }
        public int IdArticulo { get; set; }
       
    }
}

