using System.Linq;
public class MopileSection : AddNewMobiles
{
    public static String keyValue, keyValue1, keyValue2;

    public static Dictionary<string, List<Address>> mobileStore = new Dictionary<string, List<Address>>();

    public static Dictionary<string, List<Address>> duplicateDictionary = new Dictionary<string, List<Address>>();

    public static void AvailableMobiles(Login ldetail)
    {
        int miniChoice, choice = 0, cartCount, caChoice, reChoice;
        try
        {
            do
            {
            mobilevalidation:
                Console.WriteLine($"\nWelcome {ldetail.l_Name}");
                Console.WriteLine("\nAvailable Mopiles");
                Console.WriteLine(".....................");
                DisplayMopileSpecs();
                Console.WriteLine($"{SpecsPhoneName.Count + 1}. Cart List");
                Console.WriteLine($"{SpecsPhoneName.Count + 2}. My Orders");
                Console.WriteLine($"{SpecsPhoneName.Count + 3}. EXIT");
                Console.WriteLine("\nEnter The Product You Going To Buy?");
                choice = Convert.ToInt32(Console.ReadLine());



                if (choice >= 1 && choice <= SpecsPhoneName.Count)
                {
                    keyValue = SpecsPhoneName.Keys.Skip(choice - 1).FirstOrDefault();
                    Cart.CartModule(choice, ldetail, keyValue, mobileStore);
                }




                else if (choice == SpecsPhoneName.Count + 1)
                {
                cartvalidation:
                    if (Cart.cart != null && Cart.cart.Count != 0)
                    {
                        Console.WriteLine("Mobiles List in Cart");
                        Cart.DisplayCartMopile();
                        Console.WriteLine("1. Buy a Product?");
                        Console.WriteLine("2. Remove a Product?");
                        Console.WriteLine("3. Back");
                        Console.WriteLine("Enter Your Choice: ");
                        caChoice = Convert.ToInt32(Console.ReadLine());
                        switch (caChoice)
                        {
                            case 1:
                                Cart.DisplayCartMopile();
                                Console.WriteLine("=>Enter The Product You Going To Buy?");
                                cartCount = Convert.ToInt32(Console.ReadLine());
                                if (cartCount >= 1 && cartCount <= Cart.cart.Count)
                                {
                                    keyValue1 = Cart.cart.Keys.Skip(cartCount - 1).FirstOrDefault();
                                    AddressManage.AddressSection(choice, ldetail, keyValue1, mobileStore);
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter a Valid Choice..");
                                    goto cartvalidation;
                                }

                            case 2:
                                Cart.DisplayCartMopile();
                                Console.WriteLine("=>Enter The Product You Going To Remove?");
                                reChoice = Convert.ToInt32(Console.ReadLine());
                                keyValue2 = Cart.cart.Keys.Skip(reChoice - 1).FirstOrDefault();
                                Cart.cart.Remove(keyValue2);
                                Console.WriteLine($"{keyValue} Removed Successfully in Your Cart.!");
                                break;

                            case 3:
                                goto mobilevalidation;

                            default:
                                Console.WriteLine("Please Enter a Valid Choice");
                                goto cartvalidation;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cart List is Empty..");
                        goto mobilevalidation;
                    }
                }




                else if (choice == SpecsPhoneName.Count + 2)
                {
                    if ((MyOrders.myOrders != null) && (MyOrders.myOrders.Count != 0))
                    {
                        Console.WriteLine("           My Orders List             ");
                        Console.WriteLine("--------------------------------------");
                        MyOrders.DisplayMyOrders();
                        MyOrders.CancelTrack(ldetail);
                        goto mobilevalidation;
                    }
                    else
                    {
                        Console.WriteLine("My Orders is Empty..");
                        goto mobilevalidation;
                    }
                }




                else if (choice == SpecsPhoneName.Count + 3)
                {
                exitvalidation:
                    Console.WriteLine("Do You Want To Exit..");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    Console.WriteLine("Enter The Choice:");
                    miniChoice = Convert.ToInt32(Console.ReadLine());
                    if (miniChoice == 1)
                    {
                        DuplicateAddress();
                        mobileStore.Remove(ldetail.l_Name);
                        Console.WriteLine("ThankYou Visit Again..");
                        ShippingSimpleApplication.Main();
                    }
                    else if (miniChoice == 2)
                    {
                        goto mobilevalidation;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Choice..");
                        goto exitvalidation;
                    }
                }



                else
                {
                    Console.WriteLine("Please Enter a Valid Choice..");
                    goto mobilevalidation;
                }
            } while (choice != SpecsPhoneName.Count + 2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }


    public static Dictionary<string, List<Address>> DuplicateAddress()
    {
        foreach (var kvp in mobileStore)
        {
            List<Address> addresses = new List<Address>();
            addresses.AddRange(kvp.Value);
            duplicateDictionary.Add(kvp.Key, addresses);
        }
        return duplicateDictionary;
    }
}

