using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFrameSystem.Model
{
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public string type { get; set; }
    }
}
