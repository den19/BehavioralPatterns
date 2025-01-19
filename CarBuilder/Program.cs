namespace CarBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarBuilder sedanBuilder = new SedanBuilder();
            sedanBuilder.BuildCar();

            Console.WriteLine("\n\n");

            CarBuilder suvBuilder = new SUVBuilder();
            suvBuilder.BuildCar();
        }
    }

    abstract class CarBuilder
    {
        // Шаблонный метод
        public void BuildCar()
        {
            InstallEngine();
            InstallWheels();
            PaintCar();
        }

        // Шаги алгоритма
        protected abstract void InstallEngine();
        protected abstract void InstallWheels();
        protected abstract void PaintCar();
    }

    class SedanBuilder : CarBuilder
    {
        protected override void InstallEngine()
        {
            Console.WriteLine("Install sedan engine");
        }

        protected override void InstallWheels()
        {
            Console.WriteLine("Install sedan engine");
        }

        protected override void PaintCar()
        {
            Console.WriteLine("Paint sedan");
        }
    }

    class SUVBuilder : CarBuilder
    {
        protected override void InstallEngine()
        {
            Console.WriteLine("Install SUV engine");
        }

        protected override void InstallWheels()
        {
            Console.WriteLine("Install SUV wheels");
        }

        protected override void PaintCar()
        {
            Console.WriteLine("Paint SUV");
        }
    }
}
