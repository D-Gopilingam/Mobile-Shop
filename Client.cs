using System;
using System.Collections.Generic;
public class ShippingSimpleApplication
{
    public static List<Register> RegDetails = new List<Register>();
    public static void Main()
    {
        int firstChoice, firstChoice1;
        try
        {
        home:
            Console.WriteLine("\nWelcome To MI Store");
            Console.WriteLine("You Are a CUSTOMER or ADMIN?");
            Console.WriteLine("1. New Customer");
            Console.WriteLine("2. Existing Customer");
            Console.WriteLine("3. ADMIN");
            Console.WriteLine("4. Exit MI Store");
            Console.WriteLine("Enter Your Choice: ");
            firstChoice = Convert.ToInt32(Console.ReadLine());
            switch (firstChoice)
            {
                case 1:
                    NewCustomer.NewCustomerProcess(RegDetails);
                    Console.WriteLine("Are You Want to Login?");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Back<-");
                    Console.WriteLine("Enter Your Choice: ");
                    firstChoice1 = Convert.ToInt32(Console.ReadLine());
                    if (firstChoice1 == 1)
                    {
                        OldCustomer.ExistCustomerProcess(RegDetails);
                    }
                    else
                    {
                        goto home;
                    }
                    break;

                case 2:
                    ValidLogin.ValidLoginProcess(RegDetails);
                    break;

                case 3:
                    Admin.AdminPanel(RegDetails);
                    break;

                case 4:
                    Environment.Exit(0);
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

    public static (String,String) Registerdetails(){
        return (RegDetails[0].r_Name, RegDetails[0].r_Mail);
    }
}