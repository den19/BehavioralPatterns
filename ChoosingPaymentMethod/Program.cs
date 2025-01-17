namespace ChoosingPaymentMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalAmount = 100m;

            // Использование кредитной карты для оплаты
            var creditCardCheckout = new Checkout(new CreditCardPayment());
            creditCardCheckout.MakePayment(totalAmount);

            // Использование PayPal для оплаты
            var payPalCheckout = new Checkout(new PayPalPayment());
            payPalCheckout.MakePayment(totalAmount);

            Console.ReadLine();
        }
    }

    // Интерфейс стратегии
    public interface IPaymentMethod
    {
        void ProcessPayment(decimal amount);
    }

    // Контекст
    public class Checkout
    {
        private readonly IPaymentMethod _paymentMethod;

        public Checkout(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void MakePayment(decimal amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }
    }

    // Конкретная стретегия: Оплата банковской картой
    public class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Pay by credit card, sum: {amount:C}");
        }
    }

    // Конкретная стратегия: Оплата через PayPal
    public class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Pay by PayPal, sum: {amount:C}");
        }
    }
}
