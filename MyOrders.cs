public class MyOrders : AddNewMobiles
{
    public static Dictionary<string, Dictionary<string, string>> myOrders = new Dictionary<string, Dictionary<string, string>>();

    public static void MyOrderList()
    {
        try
        {
            MyOrdersAppend(MopileSection.keyValue, MopileSection.keyValue1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }

    public static void DisplayMyOrders()
    {
        int j = 1;
        foreach (var entry in myOrders)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"|        {j}. {entry.Key}           |");
            Console.WriteLine("--------------------------------------");

            foreach (var innerEntry in entry.Value)
            {
                Console.WriteLine($"| {innerEntry.Key}: {innerEntry.Value} |");
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine();
            j++;
        }
    }

    public static void MyOrdersAppend(String keyValue, String keyValue1)
    {
        if (keyValue1 == null)
        {
            if (SpecsPhoneName.TryGetValue(keyValue, out var productDetails))
            {
                myOrders.Add(keyValue, productDetails);
            }

        }
        else
        {
            if (SpecsPhoneName.TryGetValue(keyValue1, out var productDetails))
            {
                myOrders.Add(keyValue1, productDetails);
            }
        }

    }

    public static void CancelTrack(Login ldetail)
    {
        int ctChoice;
        try
        {
        canceltrackvalidation:
            Console.WriteLine("1. Cancel Order");
            Console.WriteLine("2. Track Order");
            Console.WriteLine("3. Back");
            Console.WriteLine("Enter Your Choice: ");
            ctChoice = Convert.ToInt32(Console.ReadLine());
            switch (ctChoice)
            {
                case 1:
                    CancelOrder.OrderCancel(ldetail);
                    break;

                case 2:
                    TrackOrder.OrderTrack(ldetail);
                    break;

                case 3:
                    MopileSection.AvailableMobiles(ldetail);
                    break;

                default:
                    Console.WriteLine("Invalid Choice..!");
                    goto canceltrackvalidation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }
}
