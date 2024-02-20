public class GstBill : AddNewMobiles
{
    public static int pprice = 0;
    public static double cgst = 0, sgst = 0, roundPrice = 0;
    public static void BillCalculation(int choice, string keyValue)
    {
        string priceKey = "Price";
        double tprice;
        try
        {
            if (SpecsPhoneName.TryGetValue(keyValue, out var productDetails) && productDetails.TryGetValue(priceKey, out string? stringValue))
            {
                if (Int32.TryParse(stringValue, out pprice))
                {
                    cgst = Math.Round((Double)pprice / 9, 2);
                    sgst = Math.Round((Double)pprice / 9, 2);
                    tprice = (pprice + cgst + sgst);
                    roundPrice = Math.Round(tprice, 2);
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"|    Price Bill(*includes Gst..)    |");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"    Product Name :   {keyValue}     ");
                    Console.WriteLine($"      Price      :       Rs.{pprice} ");
                    Console.WriteLine($"      CGST(9%)   :       Rs.{cgst}   ");
                    Console.WriteLine($"      sGST(9%)   :       Rs.{sgst}   ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"   Total Price   :      |Rs.{roundPrice} ");
                    Console.WriteLine("--------------------------------------");
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }
}