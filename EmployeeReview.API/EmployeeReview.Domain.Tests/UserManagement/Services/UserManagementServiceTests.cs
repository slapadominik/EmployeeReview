using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using EmployeeReview.Domain.UserManagement.Services;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeReview.Domain.Tests.UserManagement.Services
{
    public class UserManagementServiceTests
    {
        private readonly IUserManagementService _sut;
        private IFixture _fixture;

        public UserManagementServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _sut = _fixture.Create<UserManagementService>();
        }

        [Fact]
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