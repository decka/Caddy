using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caddy.Domain.Abstract;
using Caddy.Domain.Concrete;
using Caddy.Domain.Entities;
using NUnit.Framework;

namespace Caddy.UnitTests
{
    [TestFixture]
    class FakeRepositoryTests
    {
        [Test]
        public void TestPurchaseID1_IsAHammer()
        {
            //Arrange
            FakePurchasesRepository fakeRepository = new FakePurchasesRepository();

            //Act
            
            //Assert
            Assert.AreEqual(fakeRepository.GetPurchaseByID(1).Desription, "Hammer");
        }
        
        [Test]
        public void TestPurchaseID1_IsNotACheese()
        {
            //Arrange
            FakePurchasesRepository fakeRepository = new FakePurchasesRepository();

            //Act

            //Assert
            Assert.AreNotEqual(fakeRepository.GetPurchaseByID(1).Desription, "Cheese");
        }
    }
}
