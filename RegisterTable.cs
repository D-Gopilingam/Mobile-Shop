public class RegisterTable
{
    public static void RtableDisplay(List<Register> RegDetails)
    {
        try
        {
            if (RegDetails.Count > 0)
            {
                Console.WriteLine("Welcome Admin..");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine("|                             All User Registration Details               |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                Console.WriteLine("|  User-Name  |   Password   |          Gmail          |     Phone No     |");
                Console.WriteLine("|-------------------------------------------------------------------------|");
                for (int i = 0; i < RegDetails.Count; i++)
                {
                    Console.WriteLine($"| \t{RegDetails[i].r_Name} \t{RegDetails[i].r_Password} \t{RegDetails[i].r_Mail} \t{RegDetails[i].r_phone}|");
                    Console.WriteLine("|---------------------------------------------------------------------------------------|");
                }
            }
            else
            {
                Console.WriteLine("No Registration Details Found..");
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