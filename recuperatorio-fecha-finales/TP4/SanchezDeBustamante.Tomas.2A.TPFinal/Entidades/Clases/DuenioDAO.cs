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
        /// <summary>
        /// Agrega un objeto duenio a la base de datos SQL
        /// </summary>
        /// <param name="duenio"></param>
        public static bool AgregarDuenioSql(Duenio duenio)
        {
            bool retorno = false;
            string query = "insert into duenios (nombre,telefono,direccion,activo)" +
                " values (@nombre,@telefono,@direccion,@activo)";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("nombre", duenio.Nombre);
                command.Parameters.AddWithValue("telefono", duenio.Telefono);
                command.Parameters.AddWithValue("direccion", duenio.Direccion);
                command.Parameters.AddWithValue("activo", duenio.Activo);
                command.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Modifica un objeto duenio de la base de datos SQL
        /// </summary>
        /// <param name="duenio"></param>
        public static bool ModificarDuenioSql(Duenio duenio)
        {
            bool retorno = false;
            string query = "update duenios set nombre=@nombre,telefono=@telefono,direccion=@direccion,activo=@activo where id=@id";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", duenio.Id);
                command.Parameters.AddWithValue("nombre", duenio.Nombre);
                command.Parameters.AddWithValue("telefono", duenio.Telefono);
                command.Parameters.AddWithValue("direccion", duenio.Direccion);
                command.Parameters.AddWithValue("activo", CambiarBoolPorInt(duenio.Activo));
                connection.Open();
                command.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
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
        /// Carga los datos de la base de datos SQL
        /// </summary>
        /// <param name="dueniosSql"></param>
        /// <param name="dueniosSqlOriginal"></param>
        public static void CargarDueniosSql(Serializador<Duenio> dueniosSql)
        {
            string query = "select * from duenios";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
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
                        dueniosSql.Agregar(aux);
                    }
                }
            }
        }

        /// <summary>
        /// devuelve el ultimo duenio agregado a la base de datos SQL
        /// </summary>
        /// <returns></returns>
        public static Duenio BuscarUltimoDuenio()
        {
            Duenio aux = null;
            string query = "select top(1) * from Duenios order by id desc";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
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
                        aux = new Duenio(id, nombre, telefono, direccion, activo);
                    }
                }
            }

            return aux;
        }
    }
}
