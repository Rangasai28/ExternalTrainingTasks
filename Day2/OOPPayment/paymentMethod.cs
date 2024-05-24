using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPayment
{
    public abstract class paymentMethod
    {
        public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : paymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment for {amount:C}");

        }
    }

    public class BankTransferPayment : paymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing BankTransfer payment for {amount:C}");
        }
    }

    public class PayPalPayment : paymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment for {amount:C}");
        }
    }

    public class UpiPayment : paymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Upi payment for {amount:C}");

        }
    }
}
