using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DuenioDAO
    {
        static string cadenaDeConeccion;

        static DuenioDAO()
        {
            cadenaDeConeccion = "Server=.;Database=SwiftMedicalDB;Trusted_Connection=True;";
        }

        /// <summary>
        /// Agrega un objeto duenio a la base de datos SQL
        /// </summary>
        /// <param name="duenio"></param>
        static void AgregarDuenioSql(Duenio duenio)
        {
            string query = "insert into duenios (id,nombre,telefono,direccion,activo)" +
                " values (@id,@nombre,@telefono,@direccion,@activo)";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", duenio.Id);
                command.Parameters.AddWithValue("nombre", duenio.Nombre);
                command.Parameters.AddWithValue("telefono", duenio.Telefono);
                command.Parameters.AddWithValue("direccion", duenio.Direccion);
                command.Parameters.AddWithValue("activo", duenio.Activo);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Modifica un objeto duenio de la base de datos SQL
        /// </summary>
        /// <param name="duenio"></param>
        static void ModificarDuenioSql(Duenio duenio)
        {
            string query = "update duenios set nombre=@nombre,telefono=@telefono,direccion=@direccion,activo=@activo where id=@id";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", duenio.Id);
                command.Parameters.AddWithValue("nombre", duenio.Nombre);
                command.Parameters.AddWithValue("telefono", duenio.Telefono);
                command.Parameters.AddWithValue("direccion", duenio.Direccion);
                command.Parameters.AddWithValue("activo", CambiarBoolPorInt(duenio.Activo));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Recibe un bool y devuelve 1 si fue verdadero o 0 si fue falso
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        static int CambiarBoolPorInt(bool b)
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

        /// <summary>
        /// Guarda los cambios realizados en la base de datos SQL
        /// </summary>
        /// <param name="dueniosSql"></param>
        /// <param name="dueniosSqlOriginal"></param>
        public static void GuardarDueniosSql(Serializador<Duenio> dueniosSql, Serializador<Duenio> dueniosSqlOriginal)
        {
            bool esta;

            foreach (Duenio duenioNuevo in dueniosSql.Lista)
            {
                esta = false;

                foreach (Duenio duenio in dueniosSqlOriginal.Lista)
                {
                    if (duenio.Id == duenioNuevo.Id && !duenio.Equals(duenioNuevo))
                    {
                        ModificarDuenioSql(duenioNuevo);
                        esta = true;
                        break;
                    }
                    else if (duenio.Id == duenioNuevo.Id && duenio.Equals(duenioNuevo))
                    {
                        esta = true;
                        break;
                    }
                }

                if (!esta)
                {
                    AgregarDuenioSql(duenioNuevo);
                }
            }
        }

        /// <summary>
        /// Carga los datos de la base de datos SQL
        /// </summary>
        /// <param name="dueniosSql"></param>
        /// <param name="dueniosSqlOriginal"></param>
        public static void CargarDueniosSql(Serializador<Duenio> dueniosSql, Serializador<Duenio> dueniosSqlOriginal)
        {
            string query = "select * from duenios";

            using (SqlConnection connection = new SqlConnection(cadenaDeConeccion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    int telefono = reader.GetInt32(2);
                    string direccion = reader.GetString(3);
                    bool activo = reader.GetBoolean(4);

                    if (activo)
                    {
                        Duenio aux = new Duenio(id, nombre, telefono, direccion, activo);
                        Duenio aux2 = new Duenio(id, nombre, telefono, direccion, activo);
                        dueniosSql.Agregar(aux);
                        dueniosSqlOriginal.Agregar(aux2);
                    }
                }
            }
        }
    }
}
