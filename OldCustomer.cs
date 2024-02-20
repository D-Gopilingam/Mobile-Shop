public class OldCustomer
{
    public static void ExistCustomerProcess(List<Register> RegDetails)
    {
        int attempts = 0;
        short cou = 0;
        try
        {
        attemptvalidation:
            Login ldetail = Login.GetLoginDetails();
            for (int i = 0; i < RegDetails.Count; i++)
            {
                if (RegDetails[i].r_Name == ldetail.l_Name && RegDetails[i].r_Password == ldetail.l_Password)
                {
                    cou++;
                    Console.WriteLine("Login SuccessFully..");
                    Console.WriteLine("-----------------------------------");
                    if (AddNewMobiles.SpecsPhoneName == null || AddNewMobiles.SpecsPhoneName.Count == 0)
                    {
                        Console.WriteLine("No Mobiles Found.");
                        ShippingSimpleApplication.Main();
                    }
                    AddressNowOrAfter.AddNowAfter(RegDetails, ldetail);
                    MopileSection.AvailableMobiles(ldetail);
                }
            }
            if (cou == 0)
            {
                Console.WriteLine(" Details is incorrect..Please Enter a Correct Details.");
                attempts++;
                if (attempts == 1)
                {
                    goto attemptvalidation;
                }
                else
                {
                    Console.WriteLine("Maximum Login Attempts Reached..");
                    Environment.Exit(0);
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