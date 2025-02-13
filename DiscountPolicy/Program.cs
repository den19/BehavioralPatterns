namespace DiscountPolicy
{
    /*
    Политика скидок для покупателей. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            ISalePolicy policy = new BulkPurchaseSalePolicy();
            ShoppingCart cart = new ShoppingCart(policy);

            double price = 100;
            int count = 15;
            double discountedPrice = cart.ApplyDiscount(price, count);

            Console.WriteLine($"Price after apply discount: {discountedPrice}");
        }
    }

    public interface ISalePolicy
    {
        double CalculateDiscount(double price, int purchaseCount);
    }

    public class BulkPurchaseSalePolicy : ISalePolicy
    {
        public double CalculateDiscount(double price, int purchaseCount)
        {
            if (purchaseCount > 10)
            {
                return price * 0.9;
            }

            return price;
        }
    }

    public class ShoppingCart
    {
        private readonly ISalePolicy _salePolicy;

        public ShoppingCart(ISalePolicy salePolicy)
        {
            _salePolicy = salePolicy;
        }

        public double ApplyDiscount(double price, int count)
        {
            return _salePolicy.CalculateDiscount(price, count);
        }
    }
}
