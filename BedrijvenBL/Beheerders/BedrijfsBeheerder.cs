using BedrijvenBL.Domein;
using BedrijvenBL.DTOs;
using BedrijvenBL.Interfaces;
using System;
using System.Collections;
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

        public List<BedrijfDTO> GeefBedrijfDTOs()
        {
            return repository.GeefBedrijfDTOs();
        }

        public List<Personeel> GeefPersoneelBedrijf(string naam)
        {
           return repository.GeefBedrijf(naam).Personeel().ToList();
        }

        public List<Personeel> GeefPersoneelWoonplaats(string woonplaats)
        {
            return repository.GeefPersoneelWoonplaats(woonplaats);
        }
    }
}
