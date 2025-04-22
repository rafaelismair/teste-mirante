using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Application.Interfaces;
using ToDoApi.Domain;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(Status? status, DateTime? dueDate)
        {
            return await _unitOfWork.Tasks.GetFilteredAsync(status, dueDate);
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.Tasks.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.CommitAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(Guid id, TaskItem task)
        {
            var existing = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.Status = task.Status;
            existing.DueDate = task.DueDate;

            _unitOfWork.Tasks.Update(existing);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Tasks.Remove(existing);
            await _unitOfWork.CommitAsync();

            return true;
        }

    }
}
