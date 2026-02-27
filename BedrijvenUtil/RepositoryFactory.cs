using BedrijvenBL.Interfaces;
using BedrijvenDL_SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenUtil
{
    public static class RepositoryFactory
    {
        public static IBedrijvenRepository GeefRepository(string databaseType, string connectionString)
        {
            switch (databaseType)
            {
                case "SQL": return new BedrijvenRepositorySQL(connectionString);
                default: return null;
            }
        }
    }
}
