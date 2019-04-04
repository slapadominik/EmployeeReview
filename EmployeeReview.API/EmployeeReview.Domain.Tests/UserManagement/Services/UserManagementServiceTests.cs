using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using EmployeeReview.Domain.UserManagement.Services;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;


namespace EmployeeReview.Domain.Tests.UserManagement.Services
{
    [TestFixture]
    public class UserManagementServiceTests
    {
        private IUserManagementService _sut;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IEmployeeConverter> _employeeConverterMock;
        private IFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _userRepositoryMock = _fixture.Freeze<Mock<IUserRepository>>();
            _employeeConverterMock = _fixture.Freeze<Mock<IEmployeeConverter>>();
            _sut = _fixture.Create<UserManagementService>();
        }

        [Test]
        public void GetAll_ReturnsUserDetails()
        {
            //Arrange
            var usersDao = _fixture.Create<IEnumerable<UserDAO>>();
            _userRepositoryMock.Setup(x => x.GetAllUsersDetails()).Returns(usersDao);

            //Act
            var userDetails = _sut.GetAll();

            //Assert
            userDetails.Should().NotBeNull();
            userDetails.Should().NotContainNulls();
            userDetails.Should().NotContain(x => x.Roles == null || x.Roles.Count == 0);
        }
    }
}