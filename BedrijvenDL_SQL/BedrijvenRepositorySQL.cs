using BedrijvenBL.Domein;
using BedrijvenBL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace BedrijvenDL_SQL
{
    public class BedrijvenRepositorySQL : IBedrijvenRepository
    {
        string connectionString;

        public BedrijvenRepositorySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ImporteerBedrijven(List<Bedrijf> data)
        {
            string queryBedrijf = "INSERT INTO bedrijf(naam,sector,industrie,extrainfo,hoofdkwartier,jaaroprichting) output INSERTED.ID VALUES(@naam,@sector,@industrie,@extrainfo,@hoofdkwartier,@jaaroprichting)";
            string queryPersoneel = "INSERT INTO personeel(voornaam,familienaam,email,geboortedatum,woonplaats,postcode,straat,huisnummer,bedrijfsid) VALUES(@voornaam,@familienaam,@email,@geboortedatum,@woonplaats,@postcode,@straat,@huisnummer,@bedrijfsid)";
            using(SqlConnection conn = new SqlConnection(connectionString))
            using(SqlCommand cmdBedrijf=conn.CreateCommand()) 
            using(SqlCommand cmdPersoneel=conn.CreateCommand())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                cmdBedrijf.Transaction= transaction;
                cmdPersoneel.Transaction= transaction;

                cmdBedrijf.CommandText = queryBedrijf;
                cmdBedrijf.Parameters.Add(new SqlParameter("@naam",SqlDbType.NVarChar));
                cmdBedrijf.Parameters.Add(new SqlParameter("@sector", SqlDbType.NVarChar));
                cmdBedrijf.Parameters.Add(new SqlParameter("@industrie", SqlDbType.NVarChar));
                cmdBedrijf.Parameters.Add(new SqlParameter("@extrainfo", SqlDbType.NVarChar));
                cmdBedrijf.Parameters.Add(new SqlParameter("@hoofdkwartier", SqlDbType.NVarChar));
                cmdBedrijf.Parameters.Add(new SqlParameter("@jaaroprichting", SqlDbType.Int));
                cmdPersoneel.CommandText = queryPersoneel;
                cmdPersoneel.Parameters.Add(new SqlParameter("@voornaam",SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@familienaam", SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@geboortedatum", SqlDbType.DateTime2));
                cmdPersoneel.Parameters.Add(new SqlParameter("@woonplaats", SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@postcode", SqlDbType.Int));
                cmdPersoneel.Parameters.Add(new SqlParameter("@straat", SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@huisnummer", SqlDbType.NVarChar));
                cmdPersoneel.Parameters.Add(new SqlParameter("@bedrijfsid", SqlDbType.Int));
                try
                {
                    foreach (Bedrijf b in data)
                    {
                        cmdBedrijf.Parameters["@naam"].Value = b.Naam;
                        cmdBedrijf.Parameters["@sector"].Value = b.Sector;
                        cmdBedrijf.Parameters["@industrie"].Value = b.Industrie;
                        cmdBedrijf.Parameters["@extrainfo"].Value = b.ExtraInfo;
                        cmdBedrijf.Parameters["@hoofdkwartier"].Value = b.Hoofdkwartier;
                        cmdBedrijf.Parameters["@jaaroprichting"].Value = b.JaarOprichting;
                        int idBedrijf = (int)cmdBedrijf.ExecuteScalar();
                        cmdPersoneel.Parameters["@bedrijfsid"].Value = idBedrijf;
                        foreach (Personeel p in b.Personeel())
                        {
                            cmdPersoneel.Parameters["@voornaam"].Value = p.Voornaam;
                            cmdPersoneel.Parameters["@familienaam"].Value = p.Familienaam;
                            cmdPersoneel.Parameters["@email"].Value = p.Email;
                            cmdPersoneel.Parameters["@geboortedatum"].Value = p.Geboortedatum;
                            cmdPersoneel.Parameters["@woonplaats"].Value = p.Adres.Woonplaats;
                            cmdPersoneel.Parameters["@postcode"].Value = p.Adres.Postcode;
                            cmdPersoneel.Parameters["@straat"].Value = p.Adres.Straatnaam;
                            cmdPersoneel.Parameters["@huisnummer"].Value = p.Adres.Huisnummer;
                            cmdPersoneel.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex) {transaction.Rollback(); throw ex;}
            }
        }
    }
}
