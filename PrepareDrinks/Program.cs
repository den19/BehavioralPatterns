using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;

namespace PrepareDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage coffee = new Coffee();
            coffee.PrepareRecipe();

            Console.WriteLine("\n\n");

            Beverage tea = new Tea();
            tea.PrepareRecipe();
        }
    }

    abstract class Beverage // Напиток
    {
        // Шаблонный метод
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiment();
        }

        // Шаги алгоритма
        protected abstract void Brew(); // Заваривать
        protected abstract void AddCondiment(); // Приправа
        protected void BoilWater()
        {
            Console.WriteLine("Кипячение воды");
        }
        protected void PourInCup()
        {
            Console.WriteLine("Разлив напитка по чашкам");
        }
    }

    class Coffee : Beverage
    {
        protected override void AddCondiment()
        {
            Console.WriteLine($"Добавление сахара и молока");
        }

        protected override void Brew()
        {
            Console.WriteLine("Заваривание кофе");
        }
    }

    class Tea : Beverage
    {
        protected override void AddCondiment()
        {
            Console.WriteLine($"Добавление лимона");
        }

        protected override void Brew()
        {
            Console.WriteLine("Заваривание чая");
        }
    }
}
