public class Cart : AddNewMobiles
{
    public static Dictionary<string, Dictionary<string, string>> cart = new Dictionary<string, Dictionary<string, string>>();

    public static void CartModule(int choice, Login ldetail, string keyValue, Dictionary<string, List<Address>> mobileStore)
    {
        int cartChoice;
        String? key_Value;
        try
        {
        cartvalidation:
            Console.WriteLine("1. Added a Product in to Cart");
            Console.WriteLine("2. Buy a Product");
            Console.WriteLine("3. Back");
            cartChoice = Convert.ToInt32(Console.ReadLine());
            switch (cartChoice)
            {
                case 1:
                    key_Value = SpecsPhoneName.Keys.Skip(choice - 1).FirstOrDefault();
                    if (SpecsPhoneName.ContainsKey(key_Value))
                    {
                        Dictionary<string, string> cartDictionary = SpecsPhoneName[key_Value];
                        Console.WriteLine($"Mopile Name: '{key_Value}':");
                        Console.WriteLine(".......................");
                        foreach (var kvp in cartDictionary)
                        {
                            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            Console.WriteLine(".......................");
                        }
                        //Add Selected Products
                        if (!cart.ContainsKey(key_Value))
                        {
                            Dictionary<string, string> selectedPhoneSpecs = new Dictionary<string, string>();
                            foreach (var kvp in cartDictionary)
                            {
                                selectedPhoneSpecs.Add(kvp.Key, kvp.Value);
                            }
                            cart.Add(key_Value, selectedPhoneSpecs);
                            Console.WriteLine($"The \"{key_Value}\" Mobile is Successfully Added to Cart.");
                            MopileSection.AvailableMobiles(ldetail);
                        }
                        else
                        {
                            Console.WriteLine($"The \"{key_Value}\" Mobile is already exists in the Cart.");
                            MopileSection.AvailableMobiles(ldetail);
                        }
                    }
                    break;

                case 2:
                    AddressManage.AddressSection(choice, ldetail, keyValue, mobileStore);
                    break;

                case 3:
                    MopileSection.AvailableMobiles(ldetail);
                    break;

                default:
                    Console.WriteLine("Please Enter a Valid Choice..");
                    goto cartvalidation;
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

    public static void DisplayCartMopile()
    {
        int j = 1;
        foreach (var entry in cart)
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
}