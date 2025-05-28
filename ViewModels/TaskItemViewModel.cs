using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerMobile.Models;
using TaskManagerMobile.Services;

namespace TaskManagerMobile.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new();
        private DatabaseService _database;

        public TasksViewModel()
        {
            _database = new DatabaseService();
            LoadTasks();
        }

        public async void LoadTasks()
        {
            await _database.Init();
            var tasks = await _database.GetTasksAsync();
            Tasks.Clear();
            foreach (var task in tasks)
                Tasks.Add(task);
        }
    }
}
