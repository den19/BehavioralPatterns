namespace OrderProcessing
{
    /*
    Представьте, что у вас есть система обработки заказов, которая должна обрабатывать заказы разными способами
    в зависимости от типа заказа: физический товар, цифровой продукт или услуга.
    Паттерн Стратегия позволяет легко изменять способ обработки заказа. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, Type = OrderType.PhysicalProduct },
                new Order { Id = 2, Type = OrderType.DigitalProduct },
                new Order { Id = 3, Type = OrderType.Service },
            };

            var factory = new OrderProcessorFactory();

            foreach (var order in orders)
            {
                var processor = factory.GetProcessor(order.Type);
                processor.Process(order);
            }

            Console.ReadLine();
        }
    }

    public enum OrderType
    {
        PhysicalProduct,
        DigitalProduct,
        Service
    }

    // Класс заказа
    public class Order
    {
        public int Id { get; set; }
        public OrderType Type { get; set; }
    }

    public interface IOrderProcessor
    {
        void Process(Order order);
    }

    // Конкретная стратегия: Обработка физического товара
    public class PhysicalProductProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            // Логика обработки физического товара
            Console.WriteLine($"Order for physical goods is being processed: {order.Id}");
        }
    }

    // Конкретная стратегия: Обработка цифрового продукта
    public class DigitalProductProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            // Логика обработки цифрового продукта
            Console.WriteLine($"Order for digital goods is being processed: {order.Id}");
        }
    }

    // Конкретная стратегия: Обработка услуги
    public class ServiceProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            // Логика обработки услуги
            Console.WriteLine($"Order for service is being processed: {order.Id}");
        }
    }

    // Фабрика стратегий
    public class OrderProcessorFactory
    {
        public IOrderProcessor GetProcessor(OrderType type)
        {
            switch (type)
            {
                case OrderType.PhysicalProduct:
                    return new PhysicalProductProcessor();
                case OrderType.DigitalProduct:
                    return new DigitalProductProcessor();
                case OrderType.Service:
                    return new ServiceProcessor();
                default:
                    throw new ArgumentException($"Unknown order type: {type}");
            }
        }
    }
}
