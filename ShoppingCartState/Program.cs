namespace ShoppingCartState
{
    /*
    Онлайн-магазин может находиться в разных состояниях: товар добавлен в корзину, товар удалён из корзины, 
    заказ оформлен, оплата произведена и т.д.
    Каждое состояние имеет свои правила обработки действий покупателя. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // Интерфейс для состояния онлайн-магазина
    interface ShoppingCartState
    {
        void AddItem(ShoppingCart cart, Product product);
        void RemoveItem(ShoppingCart cart, Product product);
        void Checkout(ShoppingCart cart);
        void Pay(ShoppingCart cart);
    }

    // Класс Context
    class ShoppingCart
    {
        private ShoppingCartState state;

        public ShoppingCart()
        {

        }
    }

    // Класс продукта
    class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Состояние пустой корзины
    class EmptyCartState : ShoppingCartState
    {
        public void AddItem(ShoppingCart cart, Product product)
        {
            throw new NotImplementedException();
        }

        public void Checkout(ShoppingCart cart)
        {
            throw new NotImplementedException();
        }

        public void Pay(ShoppingCart cart)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(ShoppingCart cart, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
