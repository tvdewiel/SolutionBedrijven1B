using BedrijvenBL.Domein;
using BedrijvenBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.Beheerders
{
    public class BedrijfsBeheerder
    {
        private IBedrijvenRepository repository;

        public BedrijfsBeheerder(IBedrijvenRepository repository)
        {
            this.repository = repository;
        }

        public Bedrijf GeefBedrijf(string bedrijfsnaam)
        {
            return repository.GeefBedrijf(bedrijfsnaam);
        }
    }
}
