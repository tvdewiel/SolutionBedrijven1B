using BedrijvenDL;

namespace ConsoleAppTestFileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string pad = @"c:\tmp\bedrijvenbelgie_18092025.txt";
            BedrijfsBestandsLezerTXT lezer = new BedrijfsBestandsLezerTXT();
            //var res=lezer.LeesTXTBestand(pad);
        }
    }
}
