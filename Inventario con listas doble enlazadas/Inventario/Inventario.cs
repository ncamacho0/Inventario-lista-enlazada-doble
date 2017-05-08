using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {
        private Producto inicio,final;
        public Inventario()
        {
            this.inicio = null;
            this.final = null;
        }
        public void AgregarEnInicio(Producto p)
        {

            if (inicio != null)
            {
                p.siguiente = inicio;
                inicio = p;
                p.anterior = inicio;
            }
            else
            {
                inicio = p;
                final = p;
            }
        }
        /*Recursividad
        private void agregarProducto(Producto ultimo, Producto nuevo)
        {
            if (ultimo.siguiente == null)
            {
                ultimo.siguiente = nuevo;
                final = nuevo;
            }
            else
                agregarProducto(ultimo.siguiente, nuevo); 
        }*/

        public void agregar(Producto p)
        {
            /* Recursividad
            if (inicio == null)
                inicio = p;
            else
                agregarProducto(inicio, p); */

            if (inicio != null)
            {
                final.siguiente = p;
                p.anterior = final;
                final = p; 
                                           
            }
            else
            {
                inicio = p;
                final = p;
            }
        }

        public Producto buscar(string nombre)
        {
            Producto actual=inicio;
            bool encontrado = false;

            if (inicio != null)
            {
                while (actual != null && encontrado == false)
                {
                    if (actual.nombre == nombre)
                        encontrado = true;
                    else
                        actual = actual.siguiente;
                }
            }
            return actual;
        }
        public void eliminar(string nombre)
        {
            Producto actual=inicio,anteriorTemporal=null;
            bool encontrado = false;
            if (inicio != null)
            {
                while (actual != null && encontrado == false)
                {
                    if (actual.nombre == nombre)
                    {
                        if (actual == inicio)
                        {
                            if (inicio == final)
                            {
                                inicio = null;
                                final = null;
                            }
                            else
                            {
                                inicio = inicio.siguiente;
                                inicio.anterior = null;
                            }
                            
                        }
                        else if (actual == final )
                        {
                            anteriorTemporal.siguiente = null;
                            final = anteriorTemporal;
                            anteriorTemporal.anterior = final.anterior;

                        }
                        else
                        {
                            actual.siguiente.anterior = anteriorTemporal;
                            anteriorTemporal.siguiente = actual.siguiente;
                        }
                        encontrado = true;
                    }
                    else
                    {
                        anteriorTemporal = actual;
                        actual = actual.siguiente;
                    }
                }
            }
        }
         public void eliminarInicio()
        {
            if (inicio != null)
            {
                if (inicio == final)
                {
                    inicio = null;
                    final = null;
                }                  
                else
                {
                    inicio = inicio.siguiente;
                    inicio.anterior = null;
                }
            }

         }
        public void eliminarUltimo()
        {
            if (inicio != null )
            {
                if (inicio == final)
                {
                    inicio = null;
                    final = null;

                }
                else {
                    final = final.anterior;
                    final.siguiente = null;
                }
             

            }
        }

        //Recursividad
        private string reporteInverso(Producto p)
        {
            string temp = null;
            if (p == null)
                return contenidoListaReversa;
            else
            {
                temp = p.ToString();
                contenidoListaReversa += temp + Environment.NewLine;
                reporteInverso(p.siguiente);

            }
            return contenidoListaReversa;
        }

        string contenidoListaReversa;
        public string reporteInversoRecursividad()
        {
            contenidoListaReversa = null;
            Producto ultimoDato = inicio;
            if (ultimoDato == null)
                return null;
            else
                contenidoListaReversa += reporteInverso(ultimoDato);
            return contenidoListaReversa;
        }
        
        
        public string reporteInverso()
        {
            Producto actual=final;
            string contenido = null;
            if (final != null)
            {
                while (actual != null)
                {
                    contenido += Environment.NewLine + actual.ToString() + Environment.NewLine + "-----------";
                    actual = actual.anterior;
                }
            }
            else
                contenido = "";
            return contenido;
        }



        public string reporte()
        {
            Producto actual= inicio;
            string contenidoLista = null;
            if (inicio != null)
            {
                while (actual != null) 
                {
                    contenidoLista += Environment.NewLine+ actual.ToString()+ Environment.NewLine + "-----------";
                    actual = actual.siguiente;
                }
            }
            else 
                 contenidoLista = "";
         return contenidoLista;
        }

        public void insertar(Producto p,int posI)
        {
            int bandera = 1;
            Producto actual=inicio;
            bool encontrado = false;
            if (inicio != null)
            {
                if (posI == 1)
                    AgregarEnInicio(p);            
                else
                {
                    while (actual != null && encontrado == false)
                    {
                        if (bandera == posI)
                        {
                            p.siguiente = actual;
                            p.anterior = actual.anterior;
                            actual.anterior.siguiente = p;
                            actual.anterior = p;
                            encontrado = true;
                        }
                        else
                        {
                            actual = actual.siguiente;
                            bandera++;
                        }
                    }
                 }
             }       
          }

    }
}
