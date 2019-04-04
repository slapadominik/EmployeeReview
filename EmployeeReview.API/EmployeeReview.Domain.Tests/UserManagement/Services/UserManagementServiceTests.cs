using System;
using AutoFixture;
using AutoFixture.AutoMoq;
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
        private readonly IUserManagementService _sut;
        private IFixture _fixture;

        public UserManagementServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _sut = _fixture.Create<UserManagementService>();
        }

        [Test]
        public void GetAll_ReturnsUserDetails()
        {
            //Arrange

            //Act
            var userDetails = _sut.GetAll();

            //Assert
            userDetails.Should().NotBeNull();
            userDetails.Should().NotContainNulls();
        }
    }
}