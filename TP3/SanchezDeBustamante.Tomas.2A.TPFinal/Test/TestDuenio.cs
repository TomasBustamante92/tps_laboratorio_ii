using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestDuenio
    {
        List<Animal> animales = new List<Animal>();
        Duenio duenio;

        //[TestMethod]
        //public void BuscarIdsDuenio_RecibeListaYDuenio_DevuelveArrayDeIds()
        //{
        //    // Arrange
        //    CargarLista();
        //    int[] expected = new int[] {0,1};

        //    // Act
        //    int[] actual = Duenio.DevolverIndiceAnimales(this.animales, duenio);

        //    //int[] actual = new int[] {1,2};
        //    // Assert
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NombreNoExisteEnLista))]
        //public void BuscarIdAnimalPorNombre_RecibeNombreDevuelveId_Incorrecto()
        //{
        //    // Arrange
        //    CargarLista();

        //    // Act
        //    int actual = Animal.BuscarAnimalIdPorNombre(animales, "Nestor");
        //}

        void CargarLista()
        {
            duenio = new Duenio("Pablo", 41231234, "Calle falsa 123");
            //Duenio d2 = new Duenio("Evil Pablo", 41231235, "Siempre viva 777");
            //Duenio d3 = new Duenio("Lucas", 41231236, "Cordoba 5412");
            //Duenio d4 = new Duenio("Mariana", 41231237, "Santa Fe 9 3/4");
            //duenios.Add(d1);
            //duenios.Add(d2);
            //duenios.Add(d3);
            //duenios.Add(d4);

            Animal a1 = new Animal(Animal.TipoAnimal.Gato, "Sancho", 17, "Comun");
            Animal a2 = new Animal(Animal.TipoAnimal.Perro, "Kaito", 2, "Shiba Inu");
            Animal a3 = new Animal(Animal.TipoAnimal.Gato, "Jason", 8, "Siames");
            Animal a4 = new Animal(Animal.TipoAnimal.Ñandú, "Roberto", 200, "Rhea americana");
            animales.Add(a1);
            animales.Add(a2);
            animales.Add(a3);
            animales.Add(a4);

            a1.ID = 1;
            a2.ID = 2;
            a3.ID = 3;
            a4.ID = 4;

            duenio.IdAnimales = new int[]{0,1};
            //d2.IdAnimales = new int[] { 3 };
            //d3.IdAnimales = new int[] { 4 };
            //d4.IdAnimales = new int[] { 1, 2, 4 };
        }
    }
}
