using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFrameSystem.SQL
{
    public class RepositoryFactory
    {
        public static IMySqlHelper BaseRepository(string name)
        {
            return new SqlHelper(name);
        }
    }
}
