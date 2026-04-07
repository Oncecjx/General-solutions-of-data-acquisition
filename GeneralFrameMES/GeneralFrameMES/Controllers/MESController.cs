using General.BussinessService.MySQL;
using GeneralFrameMES.Config.SwaggerExt;
using GeneralFrameMES.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using static GeneralFrameMES.Model.ApiReturn;

namespace GeneralFrameMES.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(APIVersion.V1))]
    public class MESController : ControllerBase
    {
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LoginVertify")]
        public IActionResult LoginVertify(string username, string password)
        {
            //判断用户名或密码是否为空
            if (username == "" || string.IsNullOrEmpty(username) || password == "" || string.IsNullOrEmpty(password))
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.用户名或密码为空,
                    Message = "验证失败，用户名或密码为空"
                });
            }


            //判断用户是否存在
            string adminIsExistsSQL = "select * from UserList where username='" + username + "';";
            RepositoryFactory.BaseRepository("connectionstring").GetDataTable(adminIsExistsSQL);

            DataTable adminIsExistsDT = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(adminIsExistsSQL);
            if (adminIsExistsDT.Rows.Count > 0)
            {
                //判断密码是否正确
                string pwdSQL = "select * from UserList where username='" + username + "' and password='" + password + "';";
                DataTable pwdDT = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(pwdSQL);
                if (pwdDT.Rows.Count > 0)
                {
                    //更改最近登录时间
                    string updateSQL = " update UserList set loginTime ='" + DateTime.Now + "' where username='" + username + "' and password='" + password + "';";
                    RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSQL);

                    return new JsonResult(new ApiResult()
                    {
                        Success = true,
                        Code = ResponseCode.验证成功,
                        Message = "验证成功"
                    });
                }
                else
                {
                    return new JsonResult(new ApiResult()
                    {
                        Success = false,
                        Code = ResponseCode.用户名或密码错误,
                        Message = "验证失败，用户名或密码错误"
                    });
                }
            }
            else
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.用户不存在,
                    Message = "验证失败，用户不存在"
                });

            }

        }




        /// <summary>
        /// 条码验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BarCodeVertify")]
        public IActionResult BarCodeVertify(string tool, string barCode)
        {
            if (barCode == "" || string.IsNullOrEmpty(barCode))
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.条码内容为空,
                    Message = "验证失败，条码内容为空"
                });
            }

            if (tool == "" || string.IsNullOrEmpty(tool))
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.工单号为空,
                    Message = "验证失败，工单号为空"
                });
            }


            //判断是否有对应的工单
            string formulaSQL = "select * from Tool where toolName='" + tool + "';";
            DataTable formulaDT = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(formulaSQL);
            if (formulaDT.Rows.Count > 0)
            {
                //实际生产情况：根据配方的验证规则进行条码验证
                //测试：
                //判断条码内容是否都是在0-9和A-Z之间
                //判断条码内容是否包含今天8位数的日期数字,比如20250125
                string dateStr = DateTime.Now.ToString("yyyyMMdd");
                string vertify = "^[A-Z0-9]*$";
                if (Regex.IsMatch(barCode, vertify) && barCode.Contains(dateStr))
                {
                    return new JsonResult(new ApiResult()
                    {
                        Success = true,
                        Code = ResponseCode.验证成功,
                        Message = "验证成功"
                    });
                }
                else
                {
                    return new JsonResult(new ApiResult()
                    {
                        Success = false,
                        Code = ResponseCode.条码验证失败,
                        Message = "条码规则验证失败"
                    });
                }
            }
            else
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.没有对应工单号,
                    Message = "验证失败，没有对应工单号"
                });
            }
        }


 
        /// <summary>
        /// 生产数据上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertData")]
        public IActionResult InsertData(StorageDataItem StorageData)
        {
            if (StorageData.tool == "" || string.IsNullOrEmpty(StorageData.tool) ||
                StorageData.barCode == "" || string.IsNullOrEmpty(StorageData.barCode) ||
                StorageData.result == "" || string.IsNullOrEmpty(StorageData.result) ||
                StorageData.deviceName == "" || string.IsNullOrEmpty(StorageData.deviceName)
            )
            {
                return new JsonResult(new ApiResult()
                {
                    Success = false,
                    Code = ResponseCode.上传数据为空,
                    Message = "上传失败，工单号/条码/结果/设备名称为空"
                });
            }


            //存储数据
            string insertSQL = "insert into HistoryData(deviceName,toolName,barCode,result,TestDate) values('" + StorageData.deviceName + "','" + StorageData.tool + "','" + StorageData.barCode + "','" + StorageData.result + "','"+ DateTime.Now +"');";
            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSQL);

            
            return new JsonResult(new ApiResult()
            {
                Success = true,
                Code = ResponseCode.上传成功,
                Message = "上传成功"
            });

        }








    }
}
