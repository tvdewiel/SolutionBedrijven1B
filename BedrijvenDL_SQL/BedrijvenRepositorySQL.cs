using BedrijvenBL.Interfaces;

namespace BedrijvenDL_SQL
{
    public class BedrijvenRepositorySQL : IBedrijvenRepository
    {
        string connectionString;

        public BedrijvenRepositorySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
