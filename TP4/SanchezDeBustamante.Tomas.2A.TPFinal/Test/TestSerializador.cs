using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System.IO;
using System;

namespace Test
{
    [TestClass]
    public class TestSerializador
    {
        [TestMethod]
        public void AgregarDuenios_RecibeTrue()
        {
            // Arrange
            Serializador<Duenio> duenios = new Serializador<Duenio>();
            Duenio aux = new Duenio(0, "Pablo", 12345678, "Calle Falsa 123", true);
            Duenio aux2 = new Duenio(1, "Evil Pablo", 12345678, "Calle Falsa 123", true);
            duenios.Agregar(aux);
            bool actual;

            // Act
            actual = duenios.Agregar(aux2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AgregarDuenios_RecibeFalse()
        {
            // Arrange
            Serializador<Duenio> duenios = new Serializador<Duenio>();
            Duenio aux = new Duenio(0, "Pablo", 12345678, "Calle Falsa 123", true);
            Duenio aux2 = new Duenio(1, "Pablo", 12345678, "Calle Falsa 123", true);
            duenios.Agregar(aux);
            bool actual;

            // Act
            actual = duenios.Agregar(aux2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivoNoEncontradoException))]
        public void CargarArchivoJson_RecibeListaDuenios_Correcto()
        {
            // Arrange
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos"; ;
            Serializador<Duenio> duenios = new Serializador<Duenio>();

            // Act
            duenios.CargarListaJson(path, "Duenios");

            Assert.IsNotNull(duenios);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivoNoEncontradoException))]
        public void CargarArchivoJson_RecibeExcepcion()
        {
            // Arrange
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos"; ;
            Serializador<Duenio> duenios = new Serializador<Duenio>();

            // Act
            duenios.CargarListaJson(path, "ejemplo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivoNoEncontradoException))]
        public void CargarArchivoXml_RecibeListaMascotas_Correcto()
        {
            // Arrange
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos"; ;
            Serializador<Mascota> mascotas = new Serializador<Mascota>();

            // Act
            mascotas.CargarListaXml(path, "Mascotas");

            Assert.IsNotNull(mascotas);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivoNoEncontradoException))]
        public void CargarArchivoXml_RecibeExcepcion()
        {
            // Arrange
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos"; ;
            Serializador<Mascota> mascotas = new Serializador<Mascota>();

            // Act
            mascotas.CargarListaJson(path, "ejemplo");
        }
    }
}
