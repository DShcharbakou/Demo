using BLL;
using DAL;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class SomeServiceTests
    {
        private ISomeService someService;

        [SetUp]
        public void Setup()
        {
            var fakeRepository = new FakeRepository();
            someService = new SomeService(fakeRepository);

            TestContext.Out.WriteLine("Fake data from fake repository");
            foreach (var fakeItem in fakeRepository.GetAll())
            {
                TestContext.Out.WriteLine($"Id = {fakeItem.Id}, Name = {fakeItem.Name}, Age = {fakeItem.Age}");
            }
        }

        [Test]
        public void AddAdultPerson_WhenWeAddPersonWithAgeLessThen18_ShouldBeThrowValidationException()
        {
            // Arrange
            var model = new SomeModel
            {
                Id = 1,
                Name = "newFakeName",
                Age = 17
            };

            // Act
            // Assert
            Assert.Throws<ValidationException>(() => { someService.AddAdultPerson(model); });
        }

        [Test]
        public void AddAdultPerson_WhenWeAddPersonWithAgeMoreThen18_ShouldBeBeReturnIdForNewRow()
        {
            // Arrange
            const int expectedResult = 50;
            var model = new SomeModel
            {
                Id = 1,
                Name = "newFakeName",
                Age = 19
            };

            // Act
            var actualResult = someService.AddAdultPerson(model);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}