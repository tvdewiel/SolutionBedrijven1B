using BedrijvenDL;

namespace ConsoleAppTestFileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string pad = @"c:\tmp\bedrijvenbelgie_18092025.txt";
            BedrijfsBestandsLezer lezer = new BedrijfsBestandsLezer();
            //var res=lezer.LeesTXTBestand(pad);
        }
    }
}
