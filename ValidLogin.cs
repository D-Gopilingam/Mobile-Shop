public class ValidLogin
{
    public static void ValidLoginProcess(List<Register> RegDetails)
    {
        int key = 0;
        short cou = 0;
        int attempts = 0;
        try
        {
        attemptvalidation:
            Login ldetail = Login.GetLoginDetails();
            if (RegDetails.Count <= 0)
            {
                Console.WriteLine("Dear User Your Details Not Found..Please Created The New Account Before Login!");
                Console.WriteLine("=>Press Key 1 Go To the Register Section");
                Console.WriteLine("=>Press Key 2 Exit the MI Store");
                key = Convert.ToInt32(Console.ReadLine());
                if (key == 1)
                {
                    ShippingSimpleApplication.Main();
                }
                else if (key == 2)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Key..");
                }
            }
            else
            {
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