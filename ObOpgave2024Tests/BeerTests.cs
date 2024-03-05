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
    public class BeerTests
    {
        
            [TestMethod()]
            public void ToStringTest()
            {
                //Arrange
                Beer beer = new Beer()
                {
                    ID = 1,
                    Name = "Turborg",
                    Abv = 30
                };

                //Act
                string Result = beer.ToString();

                //Assert
                string actualResult = "1,Turborg,30";
                Assert.AreEqual(Result, actualResult);
            }
            [TestMethod()]
            public void ValidateAbvTest()
            {
                //Arrange
                Beer beer = new Beer()
                {
                    ID = 1,
                    Name = "Turborg",
                    Abv = 70
                };



                //Act


                //Assert
                Assert.ThrowsException<ArgumentException>(() => beer.ValidateAbv());
            }
            [TestMethod()]



            public void ValidateNameNullTest()
            {
                //Arrange
                Beer beer = new Beer()
                {
                    ID = 1,
                    Name = null,
                    Abv = 30
                };



                //Act


                //Assert
                Assert.ThrowsException<ArgumentNullException>(() => beer.ValidateName());

            }
            [TestMethod()]
            public void ValidateNameCharacterLenghtTest()
            {
                //Arrange
                Beer beer = new Beer()
                {
                    ID = 1,
                    Name = "TU",
                    Abv = -23
                };



                //Act


                //Assert
                Assert.ThrowsException<ArgumentException>(() => beer.ValidateName());
            }
        }
}