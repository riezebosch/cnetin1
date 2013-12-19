using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR;

namespace TestDemo
{
    class PersoneelsAdministratieMock 
        : IPersoneelsAdministratie
    {
        public HR.Medewerker ZoekMedewerker(int medewerkersId)
        {
            return new Medewerker { Id = 12, Naam = "Test Medewerker" };
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAanpassenVanSalaris()
        {
            // Arrange
            IPersoneelsAdministratie pa = new PersoneelsAdministratieMock();
            SalarisAdministratie sa = new SalarisAdministratie(pa);
            
            // Act
            bool isGelukt = sa.PasSalarisAan(1234, 500m);

            // Assert
            Assert.IsTrue(isGelukt);
        }
    }
}
