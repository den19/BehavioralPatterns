namespace TaskSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskList = new TaskList();

            var task1 = new Task("Задача 1");
            var task2 = new Task("Задача 2");

            taskList.AddTask(task1);
            taskList.AddTask(task2);

            taskList.ExecuteAllTasks();

            taskList.UnexecuteAllTasks();
        }
    }

    public interface ITask
    {
        void Execute();
        void Unexecute();
    }

    public class Task : ITask
    {
        private readonly string _taskDescription;
        private bool _executed;

        public Task(string taskDescription)
        {
            _taskDescription = taskDescription;
        }

        public void Execute()
        {
            _executed = true;
            Console.WriteLine($"Задача \"{_taskDescription}\" выполнена.");
        }

        public void Unexecute()
        {
            _executed = false;
            Console.WriteLine($"Задача \"{_taskDescription}\" отменена.");
        }
    }

    public class TaskList
    {
        private List<ITask> _tasks = new List<ITask>();

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
        }

        public void ExecuteAllTasks()
        {
            foreach (var task in _tasks)
            {
                task.Execute();
            }
        }

        public void UnexecuteAllTasks()
        {
            foreach (var task in _tasks)
            {
                task.Unexecute();
            }
        }
    }
}
