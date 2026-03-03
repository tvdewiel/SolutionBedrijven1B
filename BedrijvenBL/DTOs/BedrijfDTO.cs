using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.DTOs
{
    public class BedrijfDTO
    {
        public BedrijfDTO(int? id, string naam, string sector, string industrie, string extraInfo, string hoofdkwartier, int jaarOprichting, int aantalPersoneel)
        {
            Id = id;
            Naam = naam;
            Sector = sector;
            Industrie = industrie;
            ExtraInfo = extraInfo;
            Hoofdkwartier = hoofdkwartier;
            JaarOprichting = jaarOprichting;
            AantalPersoneel = aantalPersoneel;
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
        public string Sector { get; set; }
        public string Industrie { get; set; }
        public string ExtraInfo { get; set; }
        public string Hoofdkwartier { get; set; }
        public int JaarOprichting { get; set; }
        public int AantalPersoneel {  get; set; }
    }
}
