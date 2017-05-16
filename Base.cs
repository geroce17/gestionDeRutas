using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_rutas
{
    class Base
    {
        public string nombre { get; set; }
        public int minutos { get; set; }
        public Base siguiente { get; set; }
        public Base anterior { get; set; }

        public Base (string nombre, int minutos)
        {
            this.nombre = nombre;
            this.minutos = minutos;
        }

        public override string ToString()
        {
            string cadena = "nombre: " + nombre + "\r\n" + "Tiempo (minutos): " + minutos + "\r\n\r\n";
            return cadena;
        }
    }
}
