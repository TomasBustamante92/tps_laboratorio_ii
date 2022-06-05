using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Mascota : IDatos
    {
        public enum TipoAnimal { Gato, Perro, Ñandú };
        int id;
        TipoAnimal tipo;
        string nombre;
        int edad;
        string raza;
        string historial;

        public Mascota()
        {
        }

        public Mascota(int id, TipoAnimal tipo, string nombre, int edad, string raza)
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.edad = edad;
            this.raza = raza;
            this.historial = string.Empty;
        }

        public Mascota(int id, TipoAnimal tipo, string nombre, int edad, string raza, string historial) :
            this(id, tipo, nombre, edad, raza)
        {
            this.historial = historial;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public TipoAnimal Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        public string Raza
        {
            get { return this.raza; }
            set { this.raza = value; }
        }

        public string Historial
        {
            get { return this.historial; }
            set { this.historial = value; }
        }

        /// <summary>
        /// Devuelve los datos de la mascota
        /// </summary>
        /// <returns>string con los datos</returns>
        public string Mostrar()
        {
            return $"Nombre: {this.nombre} - Tipo: {this.tipo} - Edad: {this.edad} - Raza: {this.raza}";
        }

        public override string ToString()
        {
            return Mostrar();
        }
    }
}
