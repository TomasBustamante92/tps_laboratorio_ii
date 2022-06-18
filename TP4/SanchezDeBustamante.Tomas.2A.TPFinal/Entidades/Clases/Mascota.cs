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

        ///// <summary>
        ///// Evalua que las mascotas sean iguales por Nombre-Tipo-Edad-Raza-Activo
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns>bool</returns>
        //public override bool Equals(object obj)
        //{
        //    Mascota aux = obj as Mascota;
        //    return aux is not null && this.nombre == aux.nombre &&
        //        this.tipo == aux.tipo && this.edad == aux.edad &&
        //        this.raza == aux.raza && this.activo == aux.activo;
        //}

        public void Agregar(string cadenaDeConeccion)
        {
            string query = "insert into mascotas (id,tipo,nombre,edad,raza,historial,idDuenio,activo)" +
                " values (@id,@tipo,@nombre,@edad,@raza,@historial,@idDuenio,@activo)";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", this.id);
                command.Parameters.AddWithValue("tipo", this.tipo.ToString());
                command.Parameters.AddWithValue("nombre", this.nombre);
                command.Parameters.AddWithValue("edad", this.edad);
                command.Parameters.AddWithValue("raza", this.raza);
                command.Parameters.AddWithValue("historial", this.historial);
                command.Parameters.AddWithValue("idDuenio", this.idDuenio);
                command.Parameters.AddWithValue("activo", this.activo);
                command.ExecuteNonQuery();
            }
        }

        public void Borrar(string cadenaDeConeccion)
        {
            string query = "delete from mascotas where id=@id";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", this.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Modificar(string cadenaDeConeccion)
        {
            string query = "update mascotas set tipo=@tipo,nombre=@nombre,edad=@edad," +
                "raza=@raza,historial=@historial,idDuenio=@idDuenio,activo=@activo where id=@id";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", this.id);
                command.Parameters.AddWithValue("tipo", this.tipo.ToString());
                command.Parameters.AddWithValue("nombre", this.nombre);
                command.Parameters.AddWithValue("edad", this.edad);
                command.Parameters.AddWithValue("raza", this.raza);
                command.Parameters.AddWithValue("historial", this.historial);
                command.Parameters.AddWithValue("idDuenio", this.idDuenio);
                command.Parameters.AddWithValue("activo", CambiarBoolPorInt(this.activo));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // TODO: hacerlo static??? se repite en duenio
        int CambiarBoolPorInt(bool b)
        {
            if(b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
