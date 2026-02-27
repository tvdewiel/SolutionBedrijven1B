using BedrijvenBL.Domein;
using BedrijvenBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.Beheerders
{
    public class ImportBedrijfsBeheerder
    {
        IBedrijvenBestandsLezer lezer;
        IBedrijvenRepository repo;
        //Dictionary<string, Bedrijf> bedrijven=new();
        //Dictionary<string, List<Personeel>> personeelWoonplaats=new();

        public ImportBedrijfsBeheerder(IBedrijvenBestandsLezer lezer, IBedrijvenRepository repo)
        {
           this.lezer = lezer;
           this.repo = repo;
        }

        public void ImporteerGegegevens(string sourceFile, string logFile)
        {
            var data=lezer.LeesDataBedrijven(sourceFile, logFile);
            repo.ImporteerBedrijven(data);
        }

        //public IReadOnlyList<Personeel> GeefPersoneelBedrijf(string bedrijfsnaam)
        //{
        //    return bedrijven[bedrijfsnaam].Personeel();
        //}
        //public IReadOnlyList<Personeel> GeefPersoneelWoonplaats(string woonplaats)
        //{
        //    return personeelWoonplaats[woonplaats];
        //}
    }
}
