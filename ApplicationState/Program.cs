namespace ApplicationState
{
    /*
    Паттерн Event Listener является ключевым механизмом взаимодействия между объектами в объектно-ориентированных 
    языках программирования, включая C#. Его суть заключается в создании связи между объектом-издателем (publisher),
    который генерирует события, и объектом-подписчиком (subscriber), который реагирует на эти события.
    Основные компоненты паттерна Event Listener:

    Издатель (Publisher) — объект, который генерирует события.
    Подписчик (Subscriber) — объект, который реагирует на события издателя.
    Событие (Event) — механизм уведомления подписчиков о произошедшем событии.
    Обработчик события (Event Handler) — метод, который выполняется при наступлении события.

    В C# паттерн Event Listener реализуется с помощью делегатов и событий. 
    Делегаты определяют сигнатуру метода, который будет вызван при наступлении события,
    а события позволяют подписчикам регистрироваться на получение уведомлений. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var stateManager = new ApplicationStateManager();
            stateManager.StateChanged += StateManager_StateChanged;

            stateManager.ChangeState(ApplicationState.Running);
            stateManager.ChangeState(ApplicationState.Paused);
        }

        private static void StateManager_StateChanged(object sender, ApplicationStateChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case ApplicationState.Running:
                    Console.WriteLine("Application started");
                    break;
                case ApplicationState.Paused:
                    Console.WriteLine("Application paused");
                    break;
                case ApplicationState.Stopped:
                    Console.WriteLine("Application stopped");
                    break;
            }
        }

    }

    public enum ApplicationState
    {
        Running,
        Paused,
        Stopped
    }

    public class ApplicationStateChangedEventArgs : EventArgs
    {
        public ApplicationState NewState;

        public ApplicationStateChangedEventArgs(ApplicationState newState)
        {
            NewState = newState;
        }
    }

    public class ApplicationStateManager
    {
        public event EventHandler<ApplicationStateChangedEventArgs> StateChanged;

        protected virtual void OnStateChanged(ApplicationStateChangedEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }

        public void ChangeState(ApplicationState newState)
        {
            OnStateChanged(new ApplicationStateChangedEventArgs(newState));
        }
    }
}

    
