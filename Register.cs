public class Register
{
    public static int instanceCount = 0;
    public string? r_Name { get; set; }
    public string? r_Password { get; set; }
    public string? r_Mail { get; set; }
    public long r_phone { get; set; }

    public static Register GetRegisterDetails()
    {
        Register rdetail;
        try
        {
            rdetail = new Register();
            instanceCount++;
            Console.WriteLine("\nMI MOBILE STORE");
            Console.WriteLine("-----------------------");
            Console.WriteLine("USER REGISTRATION");
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter User-Name:");
            rdetail.r_Name = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            rdetail.r_Password = Console.ReadLine();
            Console.WriteLine("Enter Your Mail-Id:");
            rdetail.r_Mail = Console.ReadLine();
            Console.WriteLine("Enter Your Phone-No:");
            rdetail.r_phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Your Registration is Successful..");
            return rdetail;
        }
        finally
        {

        }
    }
}