using BedrijvenBL.Domein;
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
        void ImporteerBedrijven(List<Bedrijf> data);
    }
}
