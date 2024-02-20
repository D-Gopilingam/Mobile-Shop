public class NewCustomer
{
    public static List<Register> NewCustomerProcess(List<Register> RegDetails)
    {
        try
        {
            if (RegDetails == null || RegDetails.Count == 0)
            {
                Register rdetail = Register.GetRegisterDetails();
                RegDetails.Add(rdetail);
                return RegDetails;
            }
            else
            {
                Register rdetail = Register.GetRegisterDetails();
                RegDetails.AddRange(new List<Register> { rdetail });
                return RegDetails;
            }


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
            return RegDetails;
        }
        finally
        {

        }
    }
}