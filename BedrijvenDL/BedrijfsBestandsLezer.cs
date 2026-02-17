using BedrijvenBL;

namespace BedrijvenDL
{
    public class BedrijfsBestandsLezer : IBedrijvenLezer
    {
        public List<Bedrijf> LeesDataBedrijven(string pad,string padLog)
        {
            Dictionary<string,Bedrijf> bedrijven = new(); //string = bedrijfsnaam
            using(StreamWriter sw=new StreamWriter(padLog)) 
            using(StreamReader sr = new StreamReader(pad))
            {
                string lijn;
                while ((lijn = sr.ReadLine()) != null)
                {
                    try
                    {
                        string[] ss = lijn.Split("|"); string bedrijfsnaam = ss[0];
                        string industrie = ss[1]; string sector = ss[2];
                        string hoofdkwartier = ss[3]; int jaaroprichting = int.Parse(ss[4]);
                        string extraInfo = ss[5]; int id = int.Parse(ss[6]);
                        string voornaam = ss[7]; string familienaam = ss[8];
                        DateTime geboortedatum = DateTime.Parse(ss[9]);
                        string woonplaats = ss[10]; int postcode = int.Parse(ss[11]);
                        string straatnaam = ss[12]; string huisnummer = ss[13];
                        string email = ss[14];
                        if (!bedrijven.ContainsKey(bedrijfsnaam))
                        {
                            List<Personeel> lijstPersoneel = new();
                            lijstPersoneel.Add(new Personeel(id, voornaam, familienaam, email, geboortedatum, new Adres(huisnummer, straatnaam, postcode, woonplaats)));
                            Bedrijf bedrijf = new Bedrijf(bedrijfsnaam, sector, industrie, extraInfo, hoofdkwartier, jaaroprichting, lijstPersoneel);
                            bedrijven.Add(bedrijfsnaam, bedrijf);
                        }
                        else
                        {
                            bedrijven[bedrijfsnaam].VoegPersoneelToe(new Personeel(id, voornaam, familienaam, email, geboortedatum, new Adres(huisnummer, straatnaam, postcode, woonplaats)));
                        }
                    }
                    catch(BedrijfsException e) { 
                        sw.WriteLine(string.Join('|',e.Errors));
                    }
                }
            }
            return bedrijven.Values.ToList();
        }
    }
}
