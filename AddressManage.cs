public class AddressManage : MopileSection
{
    public static void AddressSection(int choice, Login ldetail, string keyValue, Dictionary<string, List<Address>> mobileStore)
    {
        int addChoice, continueChoice;
        int schoice;
        try
        {
        addvalidation:
            Console.WriteLine("1. Already Have An Address");
            Console.WriteLine("2. New Address");
            Console.WriteLine("3. Back");
            Console.WriteLine("Enter Your Choice: ");
            addChoice = Convert.ToInt32(Console.ReadLine());
            switch (addChoice)
            {
                case 1:
                    if (mobileStore == null || mobileStore.Count == 0)
                    {
                        Console.WriteLine("No Address Found..");
                        goto addvalidation;
                    }
                    else
                    {
                        Console.WriteLine($"Dear {ldetail.l_Name} Your Address Displayed Below:");
                        DisplayOldAddress(ldetail.l_Name, keyValue);
                        Console.WriteLine("Select The S.No Of Address To Buy a Product");
                        schoice = Convert.ToInt32(Console.ReadLine());
                        DisplaySelectedAddress(ldetail.l_Name, schoice);
                        if (mobileStore.TryGetValue(keyValue, out List<Address> addressList))
                        {
                            if (addressList.Count > 0)
                            {
                                Address addressToModify = addressList[0];
                                addressToModify.pname = keyValue;
                            }
                        }
                    }
                continuevalidation:
                    Console.WriteLine("1. Continue To Payment Process");
                    Console.WriteLine("2. Back");
                    Console.WriteLine("Enter Your Choice: ");
                    continueChoice = Convert.ToInt32(Console.ReadLine());
                    switch (continueChoice)
                    {
                        case 1:
                            GstBill.BillCalculation(choice, keyValue);
                            Payment.PaymentMethods(keyValue, ldetail.l_Name);
                            break;

                        case 2:
                            goto addvalidation;

                        default:
                            Console.WriteLine("Invalid Choice..");
                            goto continuevalidation;
                    }
                    break;

                case 2:
                    Address.SetAddressDetails(mobileStore, ldetail.l_Name, "Temporary");
                    GstBill.BillCalculation(choice, keyValue);
                    Payment.PaymentMethods(keyValue, ldetail.l_Name);
                    break;

                case 3:
                    Cart.CartModule(choice, ldetail, keyValue, mobileStore);
                    break;

                default:
                    Console.WriteLine("Invalid Choice..");
                    goto addvalidation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }

    public static void DisplayOldAddress(String username, String product)
    {
        try
        {
            Console.WriteLine("|-------------------------------------------------------------------------|");
            Console.WriteLine("|                                  Addresses                              |");
            foreach (KeyValuePair<string, List<Address>> a in mobileStore)
            {
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine($"|                                      USER NAME - {username}            |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine("| S. NO |  ADDRESS  |    CITY    |   DISTRICT   |   PINCODE   |   STATE   |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                for (int i = 0; i < a.Value.Count; i++)
                {
                    Console.WriteLine($"|   {i + 1} \t{a.Value[i].address} \t{a.Value[i].city} \t {a.Value[i].district} \t {a.Value[i].pincode} \t {a.Value[i].state}|");
                    Console.WriteLine("|---------------------------------------------------------------------|");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }


    public static void DisplaySelectedAddress(String username, int schoice)
    {
        try
        {
            Console.WriteLine("|-------------------------------------------------------------------------|");
            Console.WriteLine("|                You Selected Address is                                  |");
            foreach (KeyValuePair<string, List<Address>> a in mobileStore)
            {
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine($"|                                      USER NAME - {username}            |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine("| S. NO |  ADDRESS  |    CITY    |   DISTRICT   |   PINCODE   |   STATE   |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                for (int i = schoice - 1; i <= schoice - 1; i++)
                {
                    Console.WriteLine($"|   1. \t{a.Value[i].address} \t{a.Value[i].city} \t {a.Value[i].district} \t {a.Value[i].pincode} \t {a.Value[i].state}|");
                    Console.WriteLine("|---------------------------------------------------------------------|");
                }
            }
        }
        finally
        {

        }
    }
}