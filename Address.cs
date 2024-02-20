public class Address : AddressTable
{
    public String? name;
    public String? pname;
    public string? address;
    public string? city;
    public string? district;
    public String? pincode;
    public string? state;

    public static void SetAddressDetails(Dictionary<string, List<Address>> mobileStore, string uname, String mname)
    {
        try
        {
            if (!mobileStore.ContainsKey(uname))
            {
                mobileStore[uname] = GetAddressDetails(uname, mname);
            }
            else
            {
                mobileStore[uname].AddRange(GetAddressDetails(uname, mname));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine((e.Message ?? "") + " " + ((e.InnerException != null) ? (e.InnerException.Message + (e.InnerException.StackTrace ?? "")) : (e.StackTrace ?? "")));
        }
        finally
        {

        }
    }

    public static List<Address> GetAddressDetails(string uname, string mname)
    {
        Address details;
        List<Address> addressList = new List<Address>();
        try
        {
            Console.WriteLine("Enter Your Shipping Address:");
            details = new Address();
            details.name = uname;
            details.pname = mname;
            Console.WriteLine($"=>Enter The House No & Address: ");
            details.address = Console.ReadLine();
            Console.WriteLine($"=>Enter The City Name: ");
            details.city = Console.ReadLine();
            Console.WriteLine($"=>Enter The District Name: ");
            details.district = Console.ReadLine();
            Console.WriteLine($"=>Enter The Pincode Number: ");
            details.pincode = Console.ReadLine();
            Console.WriteLine($"=>Enter The State Name: ");
            details.state = Console.ReadLine();
            addressList.Add(details);
            return addressList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
            return addressList;
        }
        finally
        {
            addressList = null;
        }
    }
}