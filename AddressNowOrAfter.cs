public class AddressNowOrAfter : MopileSection
{
    public static void AddNowAfter(List<Register> RegDetails, Login ldetail)
    {
        int addChoice;
        try
        {
        addressvalidation:
            Console.WriteLine($"Welcome {ldetail.l_Name} to our MI Store..?");
            Console.WriteLine("Add a Shipping Address Now Or After?");
            Console.WriteLine("1. Now");
            Console.WriteLine("2. After");
            Console.WriteLine("3. Back");
            addChoice = Convert.ToInt32(Console.ReadLine());
            switch (addChoice)
            {
                case 1:
                    if (mobileStore.ContainsKey(ldetail.l_Name))
                    {
                        DeleteUserAddresses(ldetail.l_Name);
                    }
                    Address.SetAddressDetails(mobileStore, ldetail.l_Name, "Permanent");
                    break;

                case 2:
                    MopileSection.AvailableMobiles(ldetail);
                    break;

                case 3:
                    OldCustomer.ExistCustomerProcess(RegDetails);
                    break;

                default:
                    Console.WriteLine("Please Enter a Valid Choice..");
                    goto addressvalidation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }

    private static void DeleteUserAddresses(string userName)
    {
        if (mobileStore.ContainsKey(userName))
        {
            mobileStore.Remove(userName);
        }
    }
}