using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralBoardServer
{
    public class ConnectedDevice
    {
        public int No { get; set; }
        public string DeviceName { get; set; }

        public string DeviceIP { get; set; }

        public DateTime ConnectedTime { get; set; }
    }
}
