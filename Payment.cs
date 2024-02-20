public class Payment : MyOrders
{
    public static Dictionary<string, DateTime> deliverDate = new Dictionary<string, DateTime>();
    public static void PaymentMethods(string keyValue, string uname)
    {
        int payChoice;
        int cNum, cExpiry, cvv;
        String? upiId;
        var detail = ShippingSimpleApplication.Registerdetails();
        try
        {
            Console.WriteLine("=>Payment Methods:");
            Console.WriteLine("1. Cash On Delivery");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. UPI Payment");
            Console.WriteLine("4. EXIT");
            Console.WriteLine("Enter Your Payment Choice:");
            payChoice = Convert.ToInt32(Console.ReadLine());
            switch (payChoice)
            {
                case 1:
                    MyOrderList();
                    FindDate(keyValue);
                    OrdersList.UserOrder(keyValue, uname, DateTime.Now);
                    Console.WriteLine("Order Placed Successfully..");
                    Console.WriteLine("Delivery Estimated With in 4 Days..");
                    Console.WriteLine($"\nThankYou for Buy a Product..");
                    Console.WriteLine("Check Your Mail & Get The Order Summary Receipt..");
                    SentMail.MailSentSummary(keyValue, detail.Item1, detail.Item2);
                    break;
                case 2:
                    MyOrderList();
                    FindDate(keyValue);
                    Console.WriteLine("Enter Your Debit card Number:");
                    cNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Your Debit Card Expiry Date:");
                    cExpiry = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Your CVV Pin Number:");
                    cvv = Convert.ToInt32(Console.ReadLine());
                    OtpGeneration(keyValue);
                    SentMail.MailSentSummary(keyValue, detail.Item1, detail.Item2);
                    break;

                case 3:
                    MyOrderList();
                    FindDate(keyValue);
                    Console.WriteLine("Enter Your UPI ID:");
                    upiId = Console.ReadLine();
                    OtpGeneration(keyValue);
                    SentMail.MailSentSummary(keyValue, detail.Item1, detail.Item2);
                    break;

                case 4:
                    Console.WriteLine("ThankYou");
                    break;

                default:
                    Console.WriteLine("Please Enter a Valid Choice..");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
        finally
        {

        }
    }

    public static void OtpGeneration(string keyValue)
    {
        int gotp, userOtp, attempts = 0;
        try
        {
            Random generator = new Random();
            gotp = generator.Next(100000, 1000000);
            Console.WriteLine("OTP Sent The Registered Mail Successfully..");
            var detail = ShippingSimpleApplication.Registerdetails();
            SentMail.MailSent(gotp, keyValue, detail.Item2);
        validotp:
            Console.WriteLine("Enter OTP PIN: (*Only 2 Attempts Allowed Please Enter Carefully..)");
            userOtp = Convert.ToInt32(Console.ReadLine());
            if (userOtp == gotp)
            {
                Console.WriteLine("Order Placed Successfully..");
                Console.WriteLine("Delivery Estimated With in 4 Days..");
                Console.WriteLine("\nThankYou for Buy a Product..");
                Console.WriteLine("Check Your Mail & Get The Order Summary Receipt..");
            }
            else
            {
                attempts++;
                Console.WriteLine("Invalid OTP Pin Number");
                if (attempts < 2)
                {
                    goto validotp;
                }
                else
                {
                    Console.WriteLine("Payment Canceled for Some Misappropriated Activities..");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }

    public static void FindDate(String keyValue)
    {
        DateTime orderDateTime = DateTime.Now;
        deliverDate.Add(keyValue, orderDateTime);
    }
}