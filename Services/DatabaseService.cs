using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerMobile.Models;

namespace TaskManagerMobile.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        public async Task Init()
        {
            if (_db != null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Tasks.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<TaskItem>();
        }

        public Task<List<TaskItem>> GetTasksAsync() => _db.Table<TaskItem>().ToListAsync();
        public Task<TaskItem> GetTaskAsync(int id) => _db.Table<TaskItem>().Where(t => t.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveTaskAsync(TaskItem task) => task.Id != 0 ? _db.UpdateAsync(task) : _db.InsertAsync(task);
        public Task<int> DeleteTaskAsync(TaskItem task) => _db.DeleteAsync(task);
        public Task<int> GetTaskCountAsync() => _db.Table<TaskItem>().CountAsync();

        public  Task<int> GetCompletedTaskCountAsync()
        {
            return  _db.Table<TaskItem>().Where(t => t.IsCompleted).CountAsync();
        }

        public  Task<int> GetUncompletedTaskCountAsync()
        {
            return  _db.Table<TaskItem>().Where(t => !t.IsCompleted).CountAsync();
        }
    }
}
