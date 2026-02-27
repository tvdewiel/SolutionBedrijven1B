using BedrijvenBL.Beheerders;
using BedrijvenDL;
using BedrijvenUtil;
using Microsoft.Extensions.Configuration;
using System.Net.WebSockets;

namespace ConsoleAppBedrijven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config= builder.Build();
            string connectionsString = config.GetConnectionString("SQLServerConnection");
            string sourceFile = config.GetSection("AppSettings")["sourceFile"];
            string logFile = config.GetSection("AppSettings")["logFile"];
            string sourceFileType = config.GetSection("AppSettings")["sourceFileType"];
            string databaseType = config.GetSection("AppSettings")["databaseType"];

            ImportBedrijfsBeheerder beheerder = new ImportBedrijfsBeheerder(
                BestandsLezerFactory.GeefBedrijvenBestandsLezer(sourceFileType),
                RepositoryFactory.GeefRepository(databaseType,connectionsString));
            beheerder.ImporteerGegegevens(sourceFile,logFile);

        }
    }
}
