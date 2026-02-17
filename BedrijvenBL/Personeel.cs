using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL
{
    public class Personeel
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Email;

        public Personeel(int id, string voornaam, string familienaam, string email, DateTime geboortedatum, Adres adres)
        {
            Id = id;
            Voornaam = voornaam;
            Familienaam = familienaam;
            Email = email;
            Geboortedatum = geboortedatum;
            Adres = adres;
        }

        public DateTime Geboortedatum { get; set; }
        public Adres Adres { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Personeel personeel &&
                   Id == personeel.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
