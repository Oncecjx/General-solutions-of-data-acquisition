using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSystemBoard.Tool
{
    public class RepositoryFactory
    {
        public static IMySqlHelper BaseRepository(string name)
        {
            return new SqlHelper(name);
        }
    }
}
