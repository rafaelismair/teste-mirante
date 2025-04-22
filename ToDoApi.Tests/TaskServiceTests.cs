using Moq;
using ToDoApi.Application.Services;
using ToDoApi.Domain;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _unitOfWorkMock.SetupGet(u => u.Tasks).Returns(_taskRepositoryMock.Object);

            _taskService = new TaskService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Should_Create_Task()
        {

            var task = new TaskItem
            {
                Title = "Test with Moq",
                Description = "Write a unit test using Moq",
                Status = Status.Pending,
                DueDate = DateTime.Today.AddDays(1)
            };

            var result = await _taskService.CreateAsync(task);

            _taskRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TaskItem>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);

            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal("Test with Moq", result.Title);
        }

        [Fact]
        public async Task Should_Update_Task_When_Found()
        {
            var existing = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = "Old Title",
                Description = "Old Desc",
                Status = Status.Pending,
                DueDate = DateTime.Today
            };

            _taskRepositoryMock.Setup(r => r.GetByIdAsync(existing.Id))
                .ReturnsAsync(existing);

            var updated = new TaskItem
            {
                Title = "New Title",
                Description = "New Desc",
                Status = Status.Completed,
                DueDate = DateTime.Today.AddDays(2)
            };

            var success = await _taskService.UpdateAsync(existing.Id, updated);

            Assert.True(success);
            _taskRepositoryMock.Verify(r => r.Update(It.IsAny<TaskItem>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Should_Return_False_When_Updating_Nonexistent_Task()
        {
            _taskRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((TaskItem?)null);

            var success = await _taskService.UpdateAsync(Guid.NewGuid(), new TaskItem());

            Assert.False(success);
            _taskRepositoryMock.Verify(r => r.Update(It.IsAny<TaskItem>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
        }

        [Fact]
        public async Task Should_Delete_Task_When_Found()
        {
            var taskId = Guid.NewGuid();
            _taskRepositoryMock.Setup(r => r.GetByIdAsync(taskId))
                .ReturnsAsync(new TaskItem { Id = taskId });

            var success = await _taskService.DeleteAsync(taskId);

            Assert.True(success);
            _taskRepositoryMock.Verify(r => r.Remove(It.IsAny<TaskItem>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Should_Return_False_When_Deleting_Nonexistent_Task()
        {
            _taskRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((TaskItem?)null);

            var success = await _taskService.DeleteAsync(Guid.NewGuid());

            Assert.False(success);
            _taskRepositoryMock.Verify(r => r.Remove(It.IsAny<TaskItem>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
        }
    }
}
