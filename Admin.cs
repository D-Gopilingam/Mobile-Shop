public class Admin : AddNewMobiles
{
    public static void AdminPanel(List<Register> RegDetails)
    {
        String? aPassword;
        int achoice, subChoice;
        short attempts = 0;
        try
        {
            do
            {
            validadmin:
                Console.WriteLine("ADMIN PORTAL..");
                Console.WriteLine("................");
                Console.WriteLine("1. Access The Admin Portal");
                Console.WriteLine("2. BACK<-");
                Console.WriteLine("Enter The Key: ");
                subChoice = Convert.ToInt32(Console.ReadLine());
                if (subChoice > 3 || subChoice == 0)
                {
                    Console.WriteLine("Please Enter a Valid Key..");
                }
                else if (subChoice == 2)
                {
                    ShippingSimpleApplication.Main();
                }
                else
                {
                    Console.WriteLine("");
                }
            adminpassword:
                Console.WriteLine("Enter a Admin Password: (*Minimun 2 Attempts Only Allowed.. Please Type Carefully!)");
                aPassword = Console.ReadLine();
                if (aPassword != "gopi2018")
                {
                    Console.WriteLine("Password is Incorrect..! Please Enter A Correct Password");
                    attempts++;
                    if (attempts == 2)
                    {
                        Console.WriteLine("Maximum Attempts Reached..");
                        ShippingSimpleApplication.Main();
                    }
                    goto adminpassword;
                }
                do
                {
                    Console.WriteLine("1. User Registration Table");
                    Console.WriteLine("2. User Address List");
                    Console.WriteLine("3. Add Mobiles");
                    Console.WriteLine("4. Mobiles List");
                    Console.WriteLine("5. User Orders List");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Enter Your Choice?");
                    achoice = Convert.ToInt32(Console.ReadLine());
                    switch (achoice)
                    {
                        case 1:
                            RegisterTable.RtableDisplay(RegDetails);
                            break;

                        case 2:
                            AddressTable.AddressTableDisplay();
                            break;

                        case 3:
                            AddNewMobiles.AddMobiles();
                            AddNewMobiles.DisplayMopileSpecs();
                            break;

                        case 4:
                            if (SpecsPhoneName != null && SpecsPhoneName.Count != 0)
                            {
                                AddNewMobiles.DisplayMopileSpecs();
                            }
                            else
                            {
                                Console.WriteLine("No Mobile Specifications Details Found..");
                            }
                            break;

                        case 5:
                            OrdersList.DisplayOrdersList();
                            break;

                        case 6:
                            Console.WriteLine("ThankYou..!WELCOME..");
                            goto validadmin;

                        default:
                            Console.WriteLine("Please Select a Valid Option..");
                            break;
                    }
                } while (achoice != 6);
            } while (achoice != 3 || subChoice != 2);
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