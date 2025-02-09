/*
Пример: Обработка заказов
Иногда заказы могут быть недействительными или отсутствующими.
Вместо того чтобы возвращать null, можно использовать объект-заместитель для обработки таких случаев.

Заключение
Паттерн Null Object позволяет избежать проверок на null, делая код более чистым и безопасным.
Вместо того чтобы возвращать null, возвращается объект-заместитель, который выполняет минимальное
количество действий или вообще ничего не делает. Это особенно полезно в ситуациях, когда отсутствие объекта не должно
приводить к исключениям или ошибкам, а должно обрабатываться корректным способом.
*/

interface IOrder
{
    decimal TotalAmount { get; }
    void ProcessPayment();
}

class ValidOrder : IOrder
{
    public decimal TotalAmount { get; }

    public ValidOrder(decimal totalAmount)
    {
        TotalAmount = totalAmount;
    }

    public void ProcessPayment()
    {
        Console.WriteLine($"Processing payment for ${TotalAmount}.");
    }
}

class InvalidOrder : IOrder
{
    public decimal TotalAmount => 0;

    public void ProcessPayment()
    {
        Console.WriteLine("Invalid order. Payment cannot be processed.");
    }
}

class OrderProcessor
{
    public IOrder GetOrder(int orderId)
    {
        // Предположим, что заказ с указанным ID не найден.
        return new InvalidOrder();
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderProcessor processor = new OrderProcessor();
        IOrder order = processor.GetOrder(12345);

        Console.WriteLine($"Total amount: {order.TotalAmount}"); // 0
        order.ProcessPayment(); // Invalid order. Payment cannot be processed.
    }
}