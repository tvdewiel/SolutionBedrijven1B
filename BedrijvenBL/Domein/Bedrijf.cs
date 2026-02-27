using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.Domein
{
    public class Bedrijf
    {
        public Bedrijf(string naam, string sector, string industrie, string extraInfo, string hoofdkwartier, int jaarOprichting, List<Personeel> personeel)
        {
            Naam = naam;
            Sector = sector;
            Industrie = industrie;
            ExtraInfo = extraInfo;
            Hoofdkwartier = hoofdkwartier;
            JaarOprichting = jaarOprichting;
            if (personeel == null) throw new Exception("personeel is null");
            if (personeel.Count == 0) throw new Exception("lijst is leeg");
            foreach (Personeel p in personeel)
            {
                VoegPersoneelToe(p);
            }
        }
        public string Naam {  get; set; }
        public string Sector { get; set; }
        public string Industrie { get; set; }
        public string ExtraInfo { get; set; }
        public string Hoofdkwartier { get; set; }
        public int JaarOprichting { get; set; }
        private List<Personeel> _personeel { get;set; } = new();
        public IReadOnlyList<Personeel> Personeel()
        {
            return _personeel;
        }
        public void VoegPersoneelToe(Personeel personeel)
        {
            if (personeel == null) throw new Exception("personeel is null");
            if (_personeel.Contains(personeel)) throw new Exception("personeel bestaat al");
            _personeel.Add(personeel);
        }
        public void VerwijderPersoneel(Personeel personeel)
        {
            if (personeel == null) throw new Exception("personeel is null");
            if (!_personeel.Contains(personeel)) throw new Exception("personeel bestaat niet");
            if (_personeel.Count == 1) throw new Exception("minstens 1 nodig");
            _personeel.Remove(personeel);
        }
    }
}
