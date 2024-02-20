public class CancelOrder : MyOrders
{
    public static void OrderCancel(Login ldetail)
    {
        int c_Choice, sno;
        String? keyValue;
        try
        {
        cancelvalidation:
            MyOrders.DisplayMyOrders();
            Console.WriteLine("1. Serial No Based Order Cancellation");
            Console.WriteLine("2. Back");
            Console.WriteLine("Enter Your Choice: ");
            c_Choice = Convert.ToInt32(Console.ReadLine());
            switch (c_Choice)
            {
                case 1:
                    Console.WriteLine("1. Enter The Serial No:");
                    sno = Convert.ToInt32(Console.ReadLine());
                    keyValue = myOrders.Keys.Skip(sno - 1).FirstOrDefault();
                    if (myOrders.ContainsKey(keyValue))
                    {
                        myOrders.Remove(keyValue);
                        Console.WriteLine($"{keyValue} Order Canceled successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Your Order Not Found! Please Enter a Valid Serial Number");
                        goto cancelvalidation;
                    }
                    break;

                case 2:
                    MyOrders.CancelTrack(ldetail);
                    break;

                default:
                    Console.WriteLine("Please Enter a Valid Serial Number");
                    goto cancelvalidation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }
}