using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_rutas
{
    class Ruta
    {
        private Base inicio;
        private Base actual;
        private Base fin;

        public void agregar(string nombre, int minutos)
        {
            Base nueva = new Base(nombre, minutos);
            if(inicio==null)
            {
                inicio = nueva;
                inicio.siguiente = inicio;
                inicio.anterior = inicio;
                fin = nueva;
            }
            else
            {
                actual = inicio;
                agregarRec(nueva, actual, inicio);
                
            }
        }

        public void agregarRec(Base nuevo, Base actual, Base inicio)
        {
            if (actual.siguiente == inicio)
            {
                actual.siguiente = nuevo;
                nuevo.anterior = actual;
                nuevo.siguiente = inicio;
                fin = nuevo;
                inicio.anterior = fin;
            }
            else
            {
                agregarRec(nuevo, actual.siguiente, inicio);
            }
        }

        public string buscar(string nombre)
        {
            actual = inicio;
            if(inicio.nombre==nombre)
            {
                return actual.ToString();
            }
            else
            {
                while (actual.siguiente.nombre==nombre || actual.siguiente != inicio)
                {
                    actual = actual.siguiente;
                }
                return actual.siguiente.ToString();
            }
        }

        public void eliminar (string nombre)
        {
            actual = inicio;
            if (inicio.nombre == nombre)
            {
                inicio = inicio.siguiente;
                inicio.anterior = fin;
                fin.siguiente = inicio;
            }
            else
            {
                while (actual.siguiente.nombre != nombre && actual.siguiente != inicio)
                {
                    actual = actual.siguiente;
                }
                if (actual.siguiente.nombre == fin.nombre)
                {
                    actual.siguiente = inicio;
                    fin = actual;
                    inicio.anterior = fin;
                }
                else
                {
                    actual.siguiente = actual.siguiente.siguiente;
                }
            }
        }

        public string reporte()
        {
            actual = inicio;
            string cadena="";
            cadena = actual.ToString();
            actual = actual.siguiente;
            while (actual != inicio)
            {
                cadena += actual.ToString();
                actual = actual.siguiente;
            }
            return cadena;
        }

        public void agregarInicio(string nombre, int minutos)
        {
            Base nueva = new Base(nombre, minutos);
            if (inicio == null)
            {
                inicio = nueva;
                inicio.siguiente = inicio;
                inicio.anterior = inicio;
                fin = nueva;
            }
            else
            {
                nueva.siguiente = inicio;
                inicio.anterior = nueva;
                inicio = nueva;
                inicio.anterior = fin;
                fin.siguiente = inicio;
            }
        }

        public void agregarUltimo(string nombre, int minutos)
        {
            Base nueva = new Base(nombre, minutos);
            nueva.anterior = fin;
            fin.siguiente = nueva;
            fin = nueva;
            fin.siguiente = inicio;
            inicio.anterior = fin;
        }

        public void eliminarInicio()
        {
            inicio = inicio.siguiente;
            inicio.anterior = fin;
            fin.siguiente = inicio;
        }

        public void eliminarUltimo()
        {
            fin = fin.anterior;
            fin.siguiente = inicio;
            inicio.anterior = fin;
        }

        public void insertarDespuesDe(string nombre, string nombreB, int minutos)
        {
            Base nueva = new Base(nombreB, minutos);
            if(inicio.nombre==nombre)
            {
                nueva.siguiente = inicio.siguiente;
                inicio.siguiente = nueva;
                nueva.anterior = inicio;
                nueva.siguiente.anterior = nueva;
            }
            else
            {
                if (fin.nombre == nombre)
                {
                    agregarUltimo(nombreB,minutos);
                }
                else
                {
                    actual = inicio.siguiente;
                    while (actual.nombre != nombre)
                    {
                        actual = actual.siguiente;
                    }
                    nueva.siguiente = actual.siguiente;
                    actual.siguiente = nueva;
                    nueva.anterior = actual;
                    nueva.siguiente.anterior = nueva;
                }
            }
        }

        public string recorrido (string nombre, int hi,int mi, int hf, int mf)
        {
            if(inicio.nombre==nombre)
            {
                actual = inicio;
            }
            else
            {
                actual = inicio;
                while (actual.siguiente.nombre != nombre)
                {
                    actual = actual.siguiente;
                }
            }
            string cadena="", hora="";
            int h=hi, m=mi;
            bool var=false;
            while(var!=true)
            {
                hora = asigadorHora(h, m, hora);
                cadena += actual.nombre + " " + hora + " ---- ";
                m = m + actual.siguiente.minutos;
                if (m >= 60)
                {
                    m = m - 60;
                    h++;
                    if (h == 24)
                    {
                        h = h - 24;
                    }
                }
                hora = asigadorHora(h, m, hora);
                cadena += actual.siguiente.nombre + " " + hora + "\r\n";
                if (h >= hf)
                    if (m >= mf)
                        var = true;
                actual = actual.siguiente;
            }
            return cadena;
        }

        private string asigadorHora(int h, int m, string hora)
        {
            if (m == 0)
                hora = h + " : 00";
            else
            {
                if (m < 10)
                    hora = h + " : 0" + m;
                else
                    hora = h + " : " + m;
            }
            return hora;
        }
    }
}
