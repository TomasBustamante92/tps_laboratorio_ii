using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MascotaDAO
    {
        /// <summary>
        /// Agrega un objeto mascota a la base de datos SQL
        /// </summary>
        /// <param name="mascota"></param>
        public static bool AgregarMascotaSql(Mascota mascota)
        {
            bool retorno = false;
            string query = "insert into mascotas (tipo,nombre,edad,raza,historial,idDuenio,activo)" +
                " values (@tipo,@nombre,@edad,@raza,@historial,@idDuenio,@activo)";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("tipo", mascota.Tipo.ToString());
                command.Parameters.AddWithValue("nombre", mascota.Nombre);
                command.Parameters.AddWithValue("edad", mascota.Edad);
                command.Parameters.AddWithValue("raza", mascota.Raza);
                command.Parameters.AddWithValue("historial", mascota.Historial);
                command.Parameters.AddWithValue("idDuenio", mascota.IdDuenio);
                command.Parameters.AddWithValue("activo", mascota.Activo);
                command.ExecuteNonQuery();
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Modifica un objeto mascota de la base de datos SQL
        /// </summary>
        /// <param name="mascota"></param>
        public static bool ModificarMascotaSql(Mascota mascota)
        {
            bool retorno = false;
            string query = "update mascotas set tipo=@tipo,nombre=@nombre,edad=@edad," +
                "raza=@raza,historial=@historial,idDuenio=@idDuenio,activo=@activo where id=@id";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", mascota.Id);
                command.Parameters.AddWithValue("tipo", mascota.Tipo.ToString());
                command.Parameters.AddWithValue("nombre", mascota.Nombre);
                command.Parameters.AddWithValue("edad", mascota.Edad);
                command.Parameters.AddWithValue("raza", mascota.Raza);
                command.Parameters.AddWithValue("historial", mascota.Historial);
                command.Parameters.AddWithValue("idDuenio", mascota.IdDuenio);
                command.Parameters.AddWithValue("activo", CambiarBoolPorInt(mascota.Activo));
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
        /// <param name="mascotasSql"></param>
        /// <param name="mascotasSqlOriginal"></param>
        public static void CargarMascotasSql(Serializador<Mascota> mascotasSql)
        {
            string query = "select * from mascotas";

            using (SqlConnection connection = new SqlConnection(Paths.CadenaDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    TipoAnimal tipo = CambiarFormatoTipoAnimal(reader.GetString(1));
                    string nombre = reader.GetString(2);
                    int edad = reader.GetInt32(3);
                    string raza = reader.GetString(4);
                    string historial = reader.GetString(5);
                    int idDuenio = reader.GetInt32(6);
                    bool activo = reader.GetBoolean(7);

                    if (activo)
                    {
                        Mascota aux = new Mascota(id, tipo, nombre, edad, raza, historial, idDuenio, activo);
                        mascotasSql.Agregar(aux);
                    }
                }
            }
        }

        /// <summary>
        /// Recibe un string y si es correcto devuelve un TipoAnimal,
        /// caso contrario devuelve MascotaModificadaException
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        static TipoAnimal CambiarFormatoTipoAnimal(string tipo)
        {
            TipoAnimal retorno;

            switch (tipo)
            {
                case "Gato":
                    retorno = TipoAnimal.Gato;
                    break;

                case "Perro":
                    retorno = TipoAnimal.Perro;
                    break;

                case "Ñandú":
                    retorno = TipoAnimal.Ñandú;
                    break;
                default:
                    throw new MascotaModificadaException();
            }
            return retorno;
        }
    }
}
