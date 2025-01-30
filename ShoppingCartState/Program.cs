namespace ShoppingCartState
{
    /*
    Поведенческий паттерн State (состояние) предназначен для изменения поведения объекта в зависимости от его внутреннего состояния.
    Паттерн позволяет объекту менять свое поведение при изменении состояния, избегая множества условных операторов и упрощая код.

    Давайте рассмотрим пример реализации паттерна State на языке C# для модели корзины покупок (Shopping Cart).
    В нашем примере корзина покупок может находиться в одном из трех состояний: пустая, заполненная товарами и оплаченная.
    Каждое состояние будет иметь свои особенности поведения.

    Онлайн-магазин может находиться в разных состояниях: товар добавлен в корзину, товар удалён из корзины, 
    заказ оформлен, оплата произведена и т.д.
    Каждое состояние имеет свои правила обработки действий покупателя. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.AddItem("Телефон");       // Добавляем первый товар
            shoppingCart.AddItem("Наушники");      // Добавляем второй товар
            shoppingCart.RemoveItem("Наушники");   // Удаляем второй товар
            shoppingCart.Checkout();               // Переходим к оплате
            shoppingCart.Pay();                    // Оплачиваем корзину

            Console.ReadKey();
        }
    }

// Интерфейс для всех состояний корзины покупок
    public interface IShoppingCartState
    {
        void AddItem(ShoppingCart cart, string item);
        void RemoveItem(ShoppingCart cart, string item);
        void Checkout(ShoppingCart cart);
        void Pay(ShoppingCart cart);
    }

    // Состояние пустой корзины
    public class EmptyCartState : IShoppingCartState
    {
        public void AddItem(ShoppingCart cart, string item)
        {
            Console.WriteLine($"Добавлен товар '{item}'");
            cart.Items.Add(item);
            cart.SetState(new FilledCartState());
        }

        public void RemoveItem(ShoppingCart cart, string item)
        {
            Console.WriteLine("Корзина пуста, удалить нечего.");
        }

        public void Checkout(ShoppingCart cart)
        {
            Console.WriteLine("Корзина пуста, нельзя перейти к оплате.");
        }

        public void Pay(ShoppingCart cart)
        {
            Console.WriteLine("Корзина пуста, оплата невозможна.");
        }
    }

    // Состояние заполненной корзины
    public class FilledCartState : IShoppingCartState
    {
        public void AddItem(ShoppingCart cart, string item)
        {
            Console.WriteLine($"Добавлен товар '{item}'");
            cart.Items.Add(item);
        }

        public void RemoveItem(ShoppingCart cart, string item)
        {
            if (cart.Items.Contains(item))
            {
                Console.WriteLine($"Удалён товар '{item}'");
                cart.Items.Remove(item);
                if (cart.Items.Count == 0)
                    cart.SetState(new EmptyCartState());
            }
            else
            {
                Console.WriteLine($"Товар '{item}' отсутствует в корзине.");
            }
        }

        public void Checkout(ShoppingCart cart)
        {
            Console.WriteLine("Переход к оплате...");
            cart.SetState(new PaidCartState());
        }

        public void Pay(ShoppingCart cart)
        {
            Console.WriteLine("Оплата уже началась, завершить её невозможно.");
        }
    }

    // Состояние оплаченной корзины
    public class PaidCartState : IShoppingCartState
    {
        public void AddItem(ShoppingCart cart, string item)
        {
            Console.WriteLine("Оплачено, добавить товары невозможно.");
        }

        public void RemoveItem(ShoppingCart cart, string item)
        {
            Console.WriteLine("Оплачено, удалить товары невозможно.");
        }

        public void Checkout(ShoppingCart cart)
        {
            Console.WriteLine("Оплачено, переход к оплате невозможен.");
        }

        public void Pay(ShoppingCart cart)
        {
            Console.WriteLine("Оплата завершена.");
        }
    }

    // Класс корзины покупок
    public class ShoppingCart
    {
        public List<string> Items { get; private set; }
        private IShoppingCartState _state;

        public ShoppingCart()
        {
            this.Items = new List<string>();
            this._state = new EmptyCartState(); // Начальное состояние - пустая корзина
        }

        public void SetState(IShoppingCartState state)
        {
            this._state = state;
        }

        public void AddItem(string item)
        {
            this._state.AddItem(this, item);
        }

        public void RemoveItem(string item)
        {
            this._state.RemoveItem(this, item);
        }

        public void Checkout()
        {
            this._state.Checkout(this);
        }

        public void Pay()
        {
            this._state.Pay(this);
        }
    }


}
