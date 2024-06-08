using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Services;
using Microsoft.EntityFrameworkCore;

namespace Homies.Tests
{
    [TestFixture]
    internal class EventServiceTests
    {
        private HomiesDbContext _dbContext;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HomiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new HomiesDbContext(options);

            _eventService = new EventService(_dbContext);
        }

        [Test]
        public async Task AddEventAsync_ShouldAddEvent_WhenValidEventModelAndUserId()
        {
            // Arrange
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };
            string userId = "testUserId";

            // Act
            await _eventService.AddEventAsync(eventModel, userId);

            // Assert
            var addedEvent = await _dbContext.Events.FirstOrDefaultAsync(e => e.Name == "Test Event");
            Assert.IsNotNull(addedEvent);
            Assert.AreEqual(eventModel.Description, addedEvent.Description);
        }

        [Test]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            var eventModel1 = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };

            var eventModel2 = new EventFormModel
            {
                Name = "Test Event2",
                Description = "Test Description2",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };
            string userId = "testUserId";

            // Act
            await _eventService.AddEventAsync(eventModel1, userId);
            await _eventService.AddEventAsync(eventModel2, userId);

            // Act
            var count = _dbContext.Events.Count();

            // Assert
            Assert.That(count, Is.EqualTo(2));
        }

    }
}
