using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        bool activo;

        public event DelegadoCantidadMascotas ContarMascotasPorDuenio;

        public Duenio()
        {
        }

        public Duenio(string nombre, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.activo = true;
        }

        public Duenio(int id, string nombre, int telefono, string direccion, bool activo) : this(nombre,telefono,direccion)
        {
            this.id = id;
            this.activo = activo;
        }

        public int Id
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

        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Devuelve los datos del dueño
        /// </summary>
        /// <returns>string con los datos</returns>
        public string Mostrar()
        {
            int cantidadMascotas = 0;
            string retorno = $"Nombre: {this.nombre} - Telefono: {this.telefono} - Dirección: {this.direccion}";

            if (ContarMascotasPorDuenio is not null)
            {
                cantidadMascotas = ContarMascotasPorDuenio.Invoke(this);
                retorno += $" - Cantidad de mascotas: {cantidadMascotas}";
            }

            return retorno;
        }

        /// <summary>
        /// Cuenta la cantidad de mascotas que tiene el dueño
        /// </summary>
        /// <returns>int con la cantidad de mascotas</returns>
        //int ContarMascotas()
        //{
        //    int cantidadMascotas = 0;

        //    if (this.idMascotas is not null)
        //    {
        //        cantidadMascotas = this.idMascotas.Length;
        //    }
        //    return cantidadMascotas;
        //}

        public override string ToString()
        {
            return Mostrar();
        }

        /// <summary>
        /// Evalua que los Duenios sean iguales por Nombre-Telefono-Direccion-Activo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            Duenio aux = obj as Duenio;
            return aux is not null && this.nombre == aux.nombre &&
                this.telefono == aux.telefono && this.direccion == aux.direccion && this.activo == aux.activo;
        }

        public void Agregar(string cadenaDeConeccion)
        {
            string query = "insert into duenios (id,nombre,telefono,direccion,activo)" +
                " values (@id,@nombre,@telefono,@direccion,@activo)";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", this.id);
                command.Parameters.AddWithValue("nombre", this.nombre);
                command.Parameters.AddWithValue("telefono", this.telefono);
                command.Parameters.AddWithValue("direccion", this.direccion);
                command.Parameters.AddWithValue("activo", this.activo);
                command.ExecuteNonQuery();
            }
        }

        public void Borrar(string cadenaDeConeccion)
        {
            string query = "delete from duenios where id=@id";

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
            string query = "update duenios set nombre=@nombre,telefono=@telefono,direccion=@direccion,activo=@activo where id=@id";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", this.id);
                command.Parameters.AddWithValue("nombre", this.nombre);
                command.Parameters.AddWithValue("telefono", this.telefono);
                command.Parameters.AddWithValue("direccion", this.direccion);
                command.Parameters.AddWithValue("activo", CambiarBoolPorInt(this.activo));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // TODO: hacerlo static??? se repite en duemascota
        int CambiarBoolPorInt(bool b)
        {
            if (b)
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
