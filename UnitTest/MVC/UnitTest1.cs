using Xunit;
using MVC.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using MVC.Controllers;
using MVC.Models;
namespace MVC
{

    public class UnitTest1
    {
        [Fact]
        public void TestGetAll()
        {
            //Arrange   
            var mockPerson = new Mock<IPerson>();
            var mockLogger = new Mock<ILogger<StudentController>>();

            mockPerson.Setup(x => x.List()).Returns(list);

            var controller = new StudentController(mockLogger.Object, mockPerson.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PersonModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());


        }
        [Fact]
        public void TestAddPerson_addNewPerson()
        {
            // Arrange
            var mockPerson = new Mock<IPerson>();

            var mockLogger = new Mock<ILogger<StudentController>>();
            var controller = new StudentController(mockLogger.Object, mockPerson.Object);


            var person = new PersonModel
            {
                Id = 4,
                BirthPlace = "Ha Noi",
                DateOfBirth = new DateTime(2000, 1, 20),
                FirstName = "Tuan ",
                Gender = Gender.Male,
                LastName = "Phong",
                IsGraduated = true,
                PhoneNumber = "0111222333"
            };

            var expectActionName = "Index";

            // Act
            var result = controller.Add(person);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectActionName, viewResult.ActionName);
            mockPerson.Verify(r => r.Create(It.IsAny<PersonModel>()), Times.Once);
        }
        [Fact]
        public void TestUpdatePerson_editPerson()
        {
            // Arrange
            var mockPerson = new Mock<IPerson>();

            var mockLogger = new Mock<ILogger<StudentController>>();
            var controller = new StudentController(mockLogger.Object, mockPerson.Object);


            var person = new PersonModel
            {
                Id = 1,
                BirthPlace = "Ha Noi",
                DateOfBirth = new DateTime(2000, 1, 20),
                FirstName = "Tuan ",
                Gender = Gender.Male,
                LastName = "Phong",
                IsGraduated = true,
                PhoneNumber = "0111222333"
            };

            var expectActionName = "Index";

            // Act
            var result = controller.Edit(person);

            // Assert

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectActionName, viewResult.ActionName);
            mockPerson.Verify(r => r.Update(It.IsAny<PersonModel>()), Times.Once);
        }

        [Fact]
        public void Test()
        {
            var mockPerson = new Mock<IPerson>();
            var mockLogger = new Mock<ILogger<StudentController>>();

            // Arrange
            mockPerson.Setup(x => x.Details(1)).Returns(list[0]);
            var controller = new StudentController(mockLogger.Object, mockPerson.Object);
            // Act
            var result = controller.Edit(1);
            // Assert
            // var viewResult = Assert.IsType<RedirectToActionResult>(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Edit", viewResult.ViewData.Model);
            mockPerson.Verify(r => r.Details(1), Times.Once);
        }
        [Fact]
        public void TestDeletePerson()
        {
            // Arrange
            var mockPerson = new Mock<IPerson>();

            var mockLogger = new Mock<ILogger<StudentController>>();
            var controller = new StudentController(mockLogger.Object, mockPerson.Object);

            mockPerson.Setup(p => p.Delete(1)).Callback(() =>
            {
                list.Remove(list[0]);
            }).Returns(list[0]);


            var expectActionName = "Index";

            // Act
            var result = controller.DeletePerson(1);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectActionName, viewResult.ActionName);
            mockPerson.Verify(r => r.Delete(1), Times.Once);
        }
        private static List<PersonModel> list = new List<PersonModel>()
        {

             new PersonModel
            {
                Id = 1,
                BirthPlace = "Ha Noi", DateOfBirth = new DateTime(2000, 1, 20), FirstName = "Tuan ",
                Gender = Gender.Male, LastName = "Phong", IsGraduated = true, PhoneNumber = "0111222333"
            },
            new PersonModel
            {
                Id = 2,
                BirthPlace = "HCM", DateOfBirth = new DateTime(1999, 1, 20), FirstName = "Van",
                Gender = Gender.Female, LastName = "Phuc", IsGraduated = false, PhoneNumber = "0111422333"
            },
            new PersonModel
            {
                Id = 3,
                BirthPlace = "Da Nang", DateOfBirth = new DateTime(2000, 11, 11), FirstName = "Dinh",
                Gender = Gender.Other, LastName = "Khoi", IsGraduated = true, PhoneNumber = "0111522333"
            }
        };



    }
}