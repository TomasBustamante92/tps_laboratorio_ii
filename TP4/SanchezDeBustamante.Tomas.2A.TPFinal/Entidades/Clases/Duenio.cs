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
        public event DelegadoCantidadMascotas ContarMascotasPorDuenio;
        int id;
        string nombre;
        int telefono;
        string direccion;
        bool activo;

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

        public Duenio(int id, string nombre, int telefono, string direccion, bool activo)
            : this(nombre,telefono,direccion)
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
    }
}
