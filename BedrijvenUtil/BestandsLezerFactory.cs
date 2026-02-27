using BedrijvenBL.Interfaces;
using BedrijvenDL;

namespace BedrijvenUtil
{
    public static class BestandsLezerFactory
    {
        public static IBedrijvenBestandsLezer GeefBedrijvenBestandsLezer(string fileType)
        {
            switch (fileType)
            {
                case "TXT": return new BedrijfsBestandsLezerTXT();
                //case "JSON":return new BedrijfsBestandsLezerJson();
                default: return null;
            }
        }
    }
}
