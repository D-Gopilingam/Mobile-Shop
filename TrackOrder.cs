using System;
using System.Diagnostics;
public class TrackOrder : Payment
{
    public static void OrderTrack(Login ldetail)
    {
        int t_Choice, sno;
        String? keyValue;
        try
        {
        trackvalidation:
            MyOrders.DisplayMyOrders();
            Console.WriteLine("1. Serial No Based Order Tracking");
            Console.WriteLine("2. Back");
            t_Choice = Convert.ToInt32(Console.ReadLine());
            switch (t_Choice)
            {
                case 1:
                    Console.WriteLine("1. Enter The Serial No:");
                    sno = Convert.ToInt32(Console.ReadLine());
                    keyValue = myOrders.Keys.Skip(sno - 1).FirstOrDefault();
                    if (deliverDate.ContainsKey(keyValue))
                    {
                        DateTime orderDate = deliverDate[keyValue];
                        DateTime deliverDateTime = orderDate.AddDays(4).AddHours(3).AddMinutes(30).AddSeconds(45);
                        Console.WriteLine($"Your {keyValue} Order Time is : {orderDate}");
                        Console.WriteLine($"Your Order {keyValue} Expected Delivery Time is : {deliverDateTime}");
                        string googleMapUrl = "https://www.google.com/maps/search/?api=1&query=Current+Location";
                        string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                        Process.Start(chromePath, googleMapUrl);
                    }
                    else
                    {
                        Console.WriteLine("Your Order Not Found! Please Enter a Valid Serial Number");
                        goto trackvalidation;
                    }
                    break;

                case 2:
                    MyOrders.CancelTrack(ldetail);
                    break;

                default:
                    Console.WriteLine("Please Enter a Valid Serial Number");
                    goto trackvalidation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
    }
}