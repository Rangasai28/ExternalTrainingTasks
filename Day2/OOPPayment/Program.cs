namespace OOPPayment
{
    public class ECommercePlatform
    {
        public void Checkout(paymentMethod paymentMethod, decimal amount)
        {
            paymentMethod.ProcessPayment(amount);
        }
    }
    public class Program
    {
        public static void Main()
        {
            // Instantiate the e-commerce platform
            ECommercePlatform platform = new ECommercePlatform();

            // Create different payment method instances
            paymentMethod creditCard = new CreditCardPayment();
            paymentMethod payPal = new PayPalPayment();
            paymentMethod bankTransfer = new BankTransferPayment();
            paymentMethod Upi = new UpiPayment();

            // Process payments using different methods
            platform.Checkout(creditCard, 100.00m);
            platform.Checkout(payPal, 50.00m);
            platform.Checkout(bankTransfer, 75.00m);
            platform.Checkout(Upi, 100.00m);
        }
    }
}
