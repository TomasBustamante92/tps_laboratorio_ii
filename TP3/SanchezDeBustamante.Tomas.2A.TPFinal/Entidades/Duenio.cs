using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Duenio : IDatos
    {
        int id;
        string nombre;
        int telefono;
        string direccion;
        int[] idAnimales;

        public Duenio()
        {
        }

        public Duenio(int id, string nombre, int telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        public Duenio(int id, string nombre, int telefono, string direccion, int[] idAnimales) : 
            this(id, nombre,telefono, direccion)
        {
            this.idAnimales = idAnimales;
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        public int[] IdAnimales
        {
            get { return this.idAnimales; }
            set { this.idAnimales = value; }
        }

        //public static int BuscarDuenioIdPorNombre(List<Duenio> duenios, string nombre)
        //{
        //    for (int i = 0; i < duenios.Count; i++)
        //    {
        //        if (duenios[i].nombre == nombre)
        //        {
        //            return i;
        //        }
        //    }
        //    throw new NombreNoExisteEnLista();
        //}

        public string Mostrar()
        {
            int cantidadMascotas;

            if (this.idAnimales is not null)
            {
                cantidadMascotas = this.idAnimales.Length;
            }
            else
            {
                cantidadMascotas = 0;
            }

            return $"Nombre: {this.nombre} - Telefono: {this.telefono} - Dirección: {this.direccion}" +
                $" - Cantidad de mascotas: {cantidadMascotas}";
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public override bool Equals(object obj)
        {
            Duenio aux = obj as Duenio;
            return aux is not null && this.nombre == aux.nombre &&
                this.telefono == aux.telefono && this.direccion == aux.direccion;
        }

        //public static int[] DevolverIndiceAnimales(List<Animal> animales, Duenio d)
        //{
        //    List<int> indices = new List<int>();

        //    foreach (int id in d.idAnimales)
        //    {
        //        for (int i=0; i<animales.Count; i++)
        //        {
        //            if (animales[i].ID == id)
        //            {
        //                indices.Add(i);
        //            }
        //        }
        //    }

        //    return indices.ToArray();
        //}
    }
}
