using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObOpgave2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObOpgave2024.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetBeersTestAbv()
        {
            //Arrange;
            BeersRepository repository = new BeersRepository();
            int Abv = 13;

            //Act
            IEnumerable<Beer> result = repository.GetBeers(Abv);
            var Actualresult = result.Count();

            //Assert
            int ExpectedResult = 3;

            Assert.AreEqual(ExpectedResult, Actualresult);

        }
        [TestMethod()]
        public void GetBeersTestSortName()
        {
            //Arrange;
            BeersRepository repository = new BeersRepository();
            //string? SortName = "P";

            //Act
            IEnumerable<Beer> result = repository.GetBeers(null, "P");
            var Actualresult = result.Count();


            //Assert
            int expected = 1;
            Assert.AreEqual(expected, Actualresult);



        }

        [TestMethod()]
        public void GetBeerByIdTest()
        {
            //Arrange
            BeersRepository repository = new BeersRepository();
            int id = 1;
            //Act
            var bear = repository.GetBeerById(id);

            //Assert

            Assert.IsNotNull(bear);


        }

        [TestMethod()]
        public void AddBeerTest()
        {
            //Arrange;
            BeersRepository repository = new BeersRepository();
            Beer bear = new Beer() { Abv = 15, ID = 6, Name = "Guiness" };

            //Act
            repository.AddBeer(bear);

            //Assert
            Assert.IsTrue(repository.GetBeers().Contains(bear));

        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            //Arrange
            BeersRepository repository = new BeersRepository();
            int id = 1;
            Beer data = new Beer() { Name = "Mbuh", Abv = 50 };

            //Act
            var result = repository.UpdateBeer(1, data);

            //Assert

            Assert.AreEqual("Mbuh", result.Name);
            Assert.AreEqual(50, result.Abv);
        }
        [TestMethod()]
        public void TestUpdateExistingBeerReturnNull()
        {
            //Arrange;
            BeersRepository repository = new BeersRepository();
            Beer Data = new Beer { Name = "Test Beer", Abv = 5.0 };
            int Id = -10;

            //Act
            Beer? Existingbeer = repository.UpdateBeer(Id, Data);

            //Assert
            Assert.IsNull(Existingbeer);

        }

        [TestMethod()]
        public void RemoveBeerTest()
        {

            //Arrange;
            BeersRepository repository = new BeersRepository();
            int Id = 2;

            //Act
            var result = repository.RemoveBeer(Id);

            //Assert
            Assert.IsFalse(repository.GetBeers().Contains(result)); ;
        }
        [TestMethod()]

        public void TestRemoveBeerReturnNull()
        {
            //Arrange;
            BeersRepository repository = new BeersRepository();
            int Id = -1;

            //Act
            Beer removeBeer = repository.RemoveBeer(Id);

            //Assert
            Assert.IsNull(removeBeer);

        }
    }
}