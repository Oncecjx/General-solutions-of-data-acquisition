using static GeneralFrameMES.Controllers.MESController;

namespace GeneralFrameMES.Model
{
    public class ApiReturn
    {
        /// <summary>
        /// Api 统一返回结果
        /// </summary>
        public class ApiResult
        {
            /// <summary>
            /// 是否正常返回
            /// </summary>
            public bool Success { get; set; }
            /// <summary>
            /// 处理消息
            /// </summary>
            public ResponseCode Code { get; set; }
            /// <summary>
            /// 处理消息
            /// </summary>
            public string? Message { get; set; }
        }


        public class ApiDataResult<T> : ApiResult
        {
            /// <summary>
            /// 结果集
            /// </summary>
            public T? Data { get; set; }
        }
    }
}
