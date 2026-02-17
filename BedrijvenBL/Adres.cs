namespace BedrijvenBL
{
    public class Adres
    {
        public Adres(string huisnummer, string straatnaam, int postcode, string woonplaats)
        {
            List<string> errors = new();
            try { Huisnummer = huisnummer; } catch(BedrijfsException ex) { errors.Add(ex.Message); }
            try {Straatnaam = straatnaam; } catch (BedrijfsException ex) { errors.Add(ex.Message); }
            try {Woonplaats = woonplaats; } catch (BedrijfsException ex) { errors.Add(ex.Message); }
            try {Postcode = postcode; } catch (BedrijfsException ex) { errors.Add(ex.Message); }
            if (errors.Count > 0) throw new BedrijfsException(errors);
        }
        private string _huisnummer;
        public string Huisnummer {
            get { return _huisnummer; }
            set { if (string.IsNullOrWhiteSpace(value) || !char.IsDigit(value[0])) throw new BedrijfsException($"huisnummer niet ok : {value}");
                _huisnummer = value; ; } }
        private string _straatnaam;
        public string Straatnaam {
            get { return _straatnaam; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new BedrijfsException($"straatnaam niet ok : {value}"); _straatnaam = value; } }
        private int _postcode;
        public int Postcode {
            get { return _postcode; }
            set { if (value<1000 || value>9999) throw new BedrijfsException($"postcode niet ok : {value}"); 
                _postcode=value; } }
        private string _woonplaats;
        public string Woonplaats {
            get { return _woonplaats; }
            set { if (string.IsNullOrWhiteSpace(value) || value.Length < 3) throw new BedrijfsException($"woonplaats niet ok : {value}");
                _woonplaats=value; } }
        public override string ToString()
        {
            return $"{Woonplaats}-{Postcode}-{Straatnaam}-{Huisnummer}";
        }
    }
}
