using BedrijvenBL.Domein;
using BedrijvenBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.Interfaces
{
    public interface IBedrijvenRepository
    {
        Bedrijf GeefBedrijf(string bedrijfsnaam);
        List<BedrijfDTO> GeefBedrijfDTOs();
        List<Personeel> GeefPersoneelWoonplaats(string woonplaats);
        void ImporteerBedrijven(List<Bedrijf> data);
    }
}
