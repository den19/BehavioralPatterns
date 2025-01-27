namespace WeatherStation
{
    /*
    Паттерн Observer (Наблюдатель) является одним из ключевых поведенческих паттернов проектирования.
    Он используется для создания зависимости типа «один ко многим», когда изменение состояния одного объекта
    приводит к уведомлению всех зависимых объектов об этом изменении.

    Участники паттерна Observer:
    Subject (Подписчик) — объект, состояние которого отслеживается наблюдателями.
    Subject отвечает за управление списком наблюдателей и уведомление их о любых изменениях своего состояния.
    Observer (Наблюдатель) — объекты, заинтересованные в состоянии Subject.
    Они получают уведомления при изменении состояния Subject и реагируют соответствующим образом.

    Как работает паттерн Observer:
    Subject хранит список своих Observers.
    Когда состояние Subject изменяется, он вызывает метод Update у каждого из своих Observers.
    Каждый Observer получает информацию об изменении и реагирует на него своим способом.

    Компоненты паттерна Observer:
    Subject (Субъект) – это объект, который следит за своими данными и состоянием. Он хранит список наблюдателей и уведомляет их о любых изменениях своего состояния.
    Observers (Наблюдатели) – это объекты, которые подписываются на субъект и получают уведомления о его изменениях.
    RegisterObserver/RemoveObserver/Attach/Detach – методы для добавления и удаления наблюдателей.
    Notify – метод, который вызывает обновление у всех подписчиков.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            var currentDisplay = new CurrentConditionsDisplay();
            var statisticsDisplay = new StatisticsDisplay();
            var forecastDisplay = new ForecastDisplay();

            weatherStation.RegisterObserver(currentDisplay);
            weatherStation.RegisterObserver(statisticsDisplay);
            weatherStation.RegisterObserver(forecastDisplay);

            weatherStation.SetMeasurements(80, 65, 30.1f);
            weatherStation.MeasurementChanged();

            Console.ReadLine();
        }
    }

    // Субъект
    class WeatherStation
    {
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherStation()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        public void MeasurementChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;           
        }

        public float GetTemperature() => temperature;
        public float GetHumidity() => humidity;
        public float GetPressure() => pressure;
    }

    // Наблюдатель
    interface IObserver
    {
        void Update(float temp, float humid, float press);
    }

    class CurrentConditionsDisplay : IObserver
    {
        public void Update(float temp, float humid, float press)
        {
            Console.WriteLine($"Temperature is: {temp}F, Humidity: {humid}%");
        }
    }

    class StatisticsDisplay : IObserver
    {
        public void Update(float temp, float humid, float press)
        {
            Console.WriteLine($"Average temperature: {temp}F, Average humidity: {humid}%");
        }
    }

    class ForecastDisplay : IObserver
    {
        public void Update(float temp, float humid, float press)
        {
            Console.WriteLine($"Forecast: {temp}F, Humidity: {humid}%");
        }
    }
}
