﻿using System;
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
        int[] idMascotas;

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

        public Duenio(int id, string nombre, int telefono, string direccion, int[] idMascotas) : 
            this(id, nombre,telefono, direccion)
        {
            this.idMascotas = idMascotas;
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

        public int[] IdMascotas
        {
            get { return this.idMascotas; }
            set { this.idMascotas = value; }
        }

        public string Mostrar()
        {
            return $"Nombre: {this.nombre} - Telefono: {this.telefono} - Dirección: {this.direccion}" +
                $" - Cantidad de mascotas: {ContarMascotas()}";
        }

        int ContarMascotas()
        {
            int cantidadMascotas = 0;

            if (this.idMascotas is not null)
            {
                cantidadMascotas = this.idMascotas.Length;
            }
            return cantidadMascotas;
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
    }
}
