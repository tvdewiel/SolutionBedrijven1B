using BedrijvenBL;
using BedrijvenDL;
using System.Net.WebSockets;

namespace ConsoleAppBedrijven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string pad = @"c:\tmp\testbestandbedrijven.txt";
            string padLog = @"c:\tmp\testbestandbedrijven_log.txt";
            BedrijfsBeheerder beheerder = new BedrijfsBeheerder(new BedrijfsBestandsLezer(),pad,padLog);
            //var res = beheerder.GeefPersoneelWoonplaats("Aalst");
            //var res2 = beheerder.GeefPersoneelBedrijf("Volvo Car Gent");
        }
    }
}
