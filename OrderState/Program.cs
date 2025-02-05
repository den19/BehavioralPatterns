namespace OrderState
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialItems = new List<string> { "Book", "Pen"};
            Order order = new Order("Alice", initialItems);
            CheckoutSystem checkoutSystem = new CheckoutSystem();

            // Добавляем новый товар
            order.AddItem("Notebook");

            // Сохраняем текущий заказ
            checkoutSystem.SaveOrderSnapshot(order);

            // Удаляем товар
            order.RemoveItem("Pen");

            Console.WriteLine("Current Items:");
            foreach (string item in order.GetItems())
            {
                Console.WriteLine(item); // Book, Notebook
            }

            // Восстанавливаем предыдущий заказ
            checkoutSystem.RestoreOrderSnapshot(order);

            Console.WriteLine("\nRestored Items:");
            foreach (string item in order.GetItems())
            {
                Console.WriteLine(item); // Book, Pen
            }
        }
    }

    // Класс Memento
    class OrderMemento
    {
        public readonly string CustomerName;
        public readonly List<string> Items;

        public OrderMemento(string customerName, List<string> items)
        {
            CustomerName = customerName;
            Items = items;
        }
    }

    // Класс Originator
    class Order
    {
        private string customerName;
        private List<string> items;

        public Order(string customerName, List<string> items)
        {
            this.customerName = customerName;
            this.items = items;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public List<string> GetItems()
        {
            return items;
        }

        // Метод для создания хранителя (memento)
        public OrderMemento CreateMemento()
        {
            return new OrderMemento(customerName, new List<string>(items));
        }

        // Метод для восстановления состояния из хранителя
        public void RestoreFromMemento(OrderMemento memento)
        {
            customerName = memento.CustomerName;
            items = new List<string>(memento.Items);
        }
    }

    // Класс Caretaker
    class CheckoutSystem
    {
        private OrderMemento orderSnapshot;

        public void SaveOrderSnapshot(Order order)
        {
            orderSnapshot = order.CreateMemento();
        }

        public void RestoreOrderSnapshot(Order order)
        {
            if (orderSnapshot != null)
            {
                order.RestoreFromMemento(orderSnapshot);
            }
        }
    }

}
