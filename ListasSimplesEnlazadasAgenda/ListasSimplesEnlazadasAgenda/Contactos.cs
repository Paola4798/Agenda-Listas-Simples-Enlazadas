using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasSimplesEnlazadasAgenda
{
    class Contactos
    {
        Persona ultimo, primero, anterior, encontrado, temp;

        public Contactos()
        {
            primero = null;
        }

        public void agregar(Persona nuevaP)
        {
            if (primero == null)
            {

                primero = nuevaP;  
                ultimo = nuevaP;
                           
            }
            else
            {

               // nuevaP.anteriror = ultimo;
                ultimo.siguiente = nuevaP;
                ultimo = nuevaP;
            }
        }

        public void agregarEnInicio(Persona perEnInicio)
        {
            if(primero == null)
            {
                primero = perEnInicio;
                ultimo = perEnInicio;
            }
            else
            {
                perEnInicio.siguiente = primero;
                primero = perEnInicio;
            }
        }

        public void insertar(Persona perInsertar, int posicion)
        {
            if (posicion == 1)
                agregarEnInicio(perInsertar);
            else
            {
                int cont = 2;
                temp = primero;

                while(cont < posicion)
                {
                    temp = temp.siguiente;
                    cont++;
                }

                perInsertar.siguiente = temp.siguiente;
                temp.siguiente = perInsertar;
            }
        }

        public Persona buscar(int codigoP)
        {
            temp = primero;
            encontrado = null;

            while (encontrado == null && temp != null)
                if (temp.codigo == codigoP)
                    encontrado = temp;
                else
                {
                    anterior = temp;
                    temp = temp.siguiente;
                }
            return encontrado;
        }

        public bool eliminar(int codigoP)
        {
            if (buscar(codigoP) != null)
            {
                if (encontrado == primero)
                    primero = primero.siguiente;
                else
                    anterior.siguiente = encontrado.siguiente;
                return true;
            }
            else
                return false;
        }
        public bool eliminarPrimero()
        {
            if (primero == null)
                return false;
            else
            {
                primero = primero.siguiente;
               //primero.anteriror = null;
                return true;
            }
        }

        public bool eliminarUltimo()
        {
            if (ultimo == null)
                return false;
            else
            {
                ultimo = ultimo.anteriror;
                ultimo.siguiente = null;
                return true;
            }
        }

        public string mostrar()
        {
            string vPersona = "";
            temp = primero;

            while(temp != null)
            {
                vPersona += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }

            return vPersona;
        }
        public string inverso()
        {
            return mostrarInverso(primero);
        }
        private string mostrarInverso(Persona temp)
        {
            string vPersona = "";

            if (temp.siguiente != null)
                vPersona = mostrarInverso(temp.siguiente);
            vPersona += temp.ToString() + Environment.NewLine;
            return vPersona;
        }
    }
}
