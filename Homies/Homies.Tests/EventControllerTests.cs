using NUnit.Framework;
using Moq;
using Homies.Controllers;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;
using Homies.Models.Event;

namespace Homies.Tests
{
    [TestFixture]
    public class EventControllerTests
    {
        private Mock<IEventService> _mockEventService;
        private EventController _controller;

        [SetUp]
        public void Setup()
        {
            _mockEventService = new Mock<IEventService>();

            var user = new ClaimsPrincipal(new GenericPrincipal(new GenericIdentity("User"), null));
            _controller = new EventController(_mockEventService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };
        }

        [Test]
        public async Task Add_ReturnsViewResult()
        {
            // Act
            var result = await _controller.Add();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Add_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = await _controller.Add(new EventFormModel());

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Join_UserNotJoined_ReturnsRedirectToActionResult()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(false);
            _mockEventService.Setup(s => s.JoinEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(true);

            // Act
            var result = await _controller.Join(eventId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Joined"));
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Event"));
        }

        [Test]
        public async Task Join_UserAlreadyJoined_ReturnsRedirectToActionResult()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(true);

            // Act
            var result = await _controller.Join(eventId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Joined"));
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Event"));
        }

        [Test]
        public async Task Leave_SuccessfulLeave_RedirectsToAll()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.LeaveEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(true);

            // Act
            var result = await _controller.Leave(eventId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        }

        [Test]
        public async Task Leave_UnsuccessfulLeave_ReturnsBadRequest()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.LeaveEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(false);

            // Act
            var result = await _controller.Leave(eventId);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Details_ValidEventId_ReturnsViewResultWithEvent()
        {
            // Arrange
            int eventId = 1;
            var eventDetails = new EventViewDetailsModel();
            _mockEventService.Setup(s => s.GetEventDetailsAsync(eventId)).ReturnsAsync(eventDetails);

            // Act
            var result = await _controller.Details(eventId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(eventDetails));
        }

        [Test]
        public async Task Details_InvalidEventId_ReturnsBadRequest()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.GetEventDetailsAsync(eventId)).ReturnsAsync((EventViewDetailsModel)null);

            // Act
            var result = await _controller.Details(eventId);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Edit_Get_InvalidEventId_ReturnsBadRequest()
        {
            // Arrange
            int eventId = 1;
            _mockEventService.Setup(s => s.GetEventForEditAsync(eventId)).ReturnsAsync((EventFormModel)null);

            // Act
            var result = await _controller.Edit(eventId);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }


    }
}
