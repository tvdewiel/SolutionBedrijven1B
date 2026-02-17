using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL
{
    public interface IBedrijvenLezer
    {
        List<Bedrijf> LeesDataBedrijven(string pad,string logPad);
    }
}
