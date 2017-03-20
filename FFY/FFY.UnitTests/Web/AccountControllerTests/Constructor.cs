﻿using FFY.Data.Factories;
using FFY.Providers.Contracts;
using FFY.Services.Contracts;
using FFY.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;

namespace FFY.UnitTests.Web.AccountControllerTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContextProviderIsPassed()
        {
            // Arrange
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(null,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContextProviderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Context provider cannot be null.";

            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(null,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRouteDataProviderIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    null,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRouteDataProviderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Route data provider cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    null,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullAuthenticationProviderIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    null,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAuthenticationProviderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Authentication provider cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    null,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUserFactoryIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    null,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUserFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "User factory cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    null,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartFactoryIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    null,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping cart factory cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    null,
                    mockedShoppingCartsService.Object,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    null,
                    mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping carts service cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    null,
                    mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AccountController(mockedContextProvider.Object,
                    mockedRouteDataProvider.Object,
                    mockedAuthenticationProvider.Object,
                    mockedUserFactory.Object,
                    mockedShoppingCartFactory.Object,
                    mockedShoppingCartsService.Object,
                    null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidArgumentsArePassed()
        {
            // Arrange
            var mockedContextProvider = new Mock<IHttpContextProvider>();
            var mockedRouteDataProvider = new Mock<IRouteDataProvider>();
            var mockedAuthenticationProvider = new Mock<IHttpContextAuthenticationProvider>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
                new AccountController(mockedContextProvider.Object,
                mockedRouteDataProvider.Object,
                mockedAuthenticationProvider.Object,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object));
        }
    }
}
