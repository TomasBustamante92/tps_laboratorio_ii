using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestAnimal
    {
        List<Animal> animales = new List<Animal>();

        [TestMethod]
        public void BuscarIdAnimalPorNombre_RecibeNombreDevuelveId_Correcto()
        {
            // Arrange
            CargarLista();
            int expected = 3;

            // Act
            int actual = Animal.BuscarAnimalIdPorNombre(animales, "Roberto");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreNoExisteEnLista))]
        public void BuscarIdAnimalPorNombre_RecibeNombreDevuelveId_Incorrecto()
        {
            // Arrange
            CargarLista();

            // Act
            int actual = Animal.BuscarAnimalIdPorNombre(animales, "Nestor");
        }

        void CargarLista()
        {
            Animal a1 = new Animal(Animal.TipoAnimal.Gato, "Sancho", 17, "Comun");
            Animal a2 = new Animal(Animal.TipoAnimal.Perro, "Kaito", 2, "Shiba Inu");
            Animal a3 = new Animal(Animal.TipoAnimal.Gato, "Jason", 8, "Siames");
            Animal a4 = new Animal(Animal.TipoAnimal.Ñandú, "Roberto", 200, "Rhea americana");

            animales.Add(a1);
            animales.Add(a2);
            animales.Add(a3);
            animales.Add(a4);
        }
    }
}
