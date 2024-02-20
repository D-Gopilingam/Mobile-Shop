public class Login
{
    public String? l_Name { get; set; }
    public String? l_Password { get; set; }
    public static Login GetLoginDetails()
    {
        Login ldetail = new Login();
        try
        {
            ldetail = new Login();
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("\nWELCOME TO ONLINE MOBILE STORE");
            Console.WriteLine("USER LOGIN");
            Console.WriteLine("---------------");
            Console.WriteLine("Enter User-Name:");
            ldetail.l_Name = Console.ReadLine();
            Console.WriteLine("Enter Your Password:(*Minimun 2 Attempts Only Allowed.. Please Type Carefully!)");
            ldetail.l_Password = Console.ReadLine();
            Console.WriteLine("------------------------------");
            return ldetail;
        }
        finally
        {
        }
    }
}