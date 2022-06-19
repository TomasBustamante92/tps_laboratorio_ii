using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    public class Mascota : IDatos
    {
        int id;
        TipoAnimal tipo;
        string nombre;
        int edad;
        string raza;
        string historial;
        int idDuenio;
        bool activo;

        public Mascota()
        {
        }

        public Mascota(TipoAnimal tipo, string nombre, int edad, string raza, int idDuenio)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.edad = edad;
            this.raza = raza;
            this.historial = string.Empty;
        }

        public Mascota(int id, TipoAnimal tipo, string nombre, int edad, string raza,
            int idDuenio, bool activo) : this(tipo,nombre,edad,raza,idDuenio)
        {
            this.id = id;
            this.idDuenio = idDuenio;
            this.activo = activo;
        }

        public Mascota(int id, TipoAnimal tipo, string nombre, int edad, string raza,
            string historial,int idDuenio, bool activo) : this(id, tipo, nombre, edad, raza, idDuenio, activo)
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

        public int IdDuenio
        {
            get { return this.idDuenio; }
            set { this.idDuenio = value; }
        }

        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
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
