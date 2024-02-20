public class AddressTable
{
    public static Dictionary<string, List<Address>> dupAddress;
    public static void AddressTableDisplay()
    {
        try
        {
            Dictionary<string, List<Address>> dupAddress = MopileSection.DuplicateAddress();
            if (dupAddress == null || dupAddress.Count == 0)
            {
                Console.WriteLine("No Address Details Found..");
            }
            else
            {
                Console.WriteLine("Welcome Admin..");
                Console.WriteLine("|-------------------------------------------------------------------------------------------|");
                Console.WriteLine("|                             All Users Shipping Address List                               |");
                foreach (KeyValuePair<string, List<Address>> a in dupAddress)
                {
                    Console.WriteLine("|-------------------------------------------------------------------------------------------|");
                    Console.WriteLine("|                                      USER NAME - {0}                                      |", a.Key);
                    Console.WriteLine("|-------------------------------------------------------------------------------------------|");
                    Console.WriteLine("| S. NO |  ADDRESS  |    CITY    |   DISTRICT   |   PINCODE   |   STATE   | Address Type |");
                    Console.WriteLine("|----------------------------------------------------------------------------------------|");
                    for (int i = 0; i < a.Value.Count; i++)
                    {
                        Console.WriteLine($"|   {i + 1} \t{a.Value[i].address} \t{a.Value[i].city} \t {a.Value[i].district} \t {a.Value[i].pincode} \t {a.Value[i].state} \t {a.Value[i].pname}|");
                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                    }
                }
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
}