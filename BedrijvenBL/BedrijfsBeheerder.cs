using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL
{
    public class BedrijfsBeheerder
    {
        IBedrijvenLezer lezer;
        Dictionary<string, Bedrijf> bedrijven=new();
        Dictionary<string, List<Personeel>> personeelWoonplaats=new();

        public BedrijfsBeheerder(IBedrijvenLezer lezer, string pad,string padLog)
        {
            this.lezer = lezer;
            List<Bedrijf> bedrijvenLijst = lezer.LeesDataBedrijven(pad,padLog);
            foreach (Bedrijf b in bedrijvenLijst)
            {
                bedrijven.Add(b.Naam, b);
                foreach(Personeel p in b.Personeel())
                {
                    if (!personeelWoonplaats.ContainsKey(p.Adres.Woonplaats))
                        personeelWoonplaats.Add(p.Adres.Woonplaats, new List<Personeel>());
                    personeelWoonplaats[p.Adres.Woonplaats].Add(p);
                }
            }
        }

        public IReadOnlyList<Personeel> GeefPersoneelBedrijf(string bedrijfsnaam)
        {
            return bedrijven[bedrijfsnaam].Personeel();
        }
        public IReadOnlyList<Personeel> GeefPersoneelWoonplaats(string woonplaats)
        {
            return personeelWoonplaats[woonplaats];
        }
    }
}
