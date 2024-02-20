public class AddNewMobiles 
{
    public static Dictionary<string, Dictionary<string, string>> SpecsPhoneName = new Dictionary<string, Dictionary<string, string>>();
    public static Dictionary<string, string> SpecsPhone;
    public static void AddMobiles()
    {
        int addCount;
        string? mobiles, mprice, dmodel, cpixel, ram, rom, processer;
        try
        {
            Console.WriteLine("How Many Mobiles You Will Be Added?");
            addCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < addCount; i++)
            {
                SpecsPhone = new Dictionary<string, string>();
                Console.WriteLine($"\nEnter The {i + 1} Mobile Name: ");
                mobiles = Console.ReadLine();
                Console.WriteLine("Enter The Mobile Price: ");
                mprice = Console.ReadLine();
                SpecsPhone.Add("Price", mprice);
                Console.WriteLine("Enter The Display Model: ");
                dmodel = Console.ReadLine();
                SpecsPhone.Add("Display", dmodel);
                Console.WriteLine("Enter The Camera Pixel Size: ");
                cpixel = Console.ReadLine();
                SpecsPhone.Add("Camera", cpixel);
                Console.WriteLine("Enter The Ram Size: ");
                ram = Console.ReadLine();
                SpecsPhone.Add("Ram", ram);
                Console.WriteLine("Enter The Rom Size: ");
                rom = Console.ReadLine();
                SpecsPhone.Add("Rom", rom);
                Console.WriteLine("Enter The Processor Name: ");
                processer = Console.ReadLine();
                SpecsPhone.Add("Processor", processer);
                SpecsPhoneName.Add(mobiles, SpecsPhone);
            }
            Console.WriteLine($"{addCount} Mobiles Added Successfully..");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message ?? "" + e.StackTrace ?? "");
        }
        finally
        {

        }
    }

    public static void DisplayMopileSpecs()
    {
        int j = 1;
        foreach (var entry in SpecsPhoneName)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"|        {j}. {entry.Key}           |");
            Console.WriteLine("--------------------------------------");

            foreach (var innerEntry in entry.Value)
            {
                Console.WriteLine($"| {innerEntry.Key}: {innerEntry.Value} |");
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine();
            j++;
        }
    }
}