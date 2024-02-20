public class OrdersList : Login
{
    public static Dictionary<string, List<string>> orderList = new Dictionary<string, List<string>>();
    public static void UserOrder(string keyValue, string uname, DateTime order)
    {
        List<string> mopileName = new List<string>();
        mopileName.Add(keyValue);
        orderList.Add(uname, mopileName);
    }

    public static void DisplayOrdersList()
    {
        if (orderList == null || orderList.Count == 0)
        {
            Console.WriteLine("No Order Details Found..");
        }
        else
        {
            Console.WriteLine("Welcome Admin..");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|   All Users Order Products List   |");
            foreach (KeyValuePair<string, List<string>> a in orderList)
            {
                Console.WriteLine("|-----------------------------------|");
                Console.WriteLine("|         USER NAME - {0}           |", a.Key);
                Console.WriteLine("|-----------------------------------|");
                Console.WriteLine("| S. NO |  Product Name  | Purchased Time |");
                Console.WriteLine("|-----------------------------------|");
                for (int i = 0; i < a.Value.Count; i++)
                {
                    Console.WriteLine($"|   {i + 1} \t{a.Value[i]} \t|");
                    Console.WriteLine("|-----------------------------------|");
                }
            }
        }
    }
}