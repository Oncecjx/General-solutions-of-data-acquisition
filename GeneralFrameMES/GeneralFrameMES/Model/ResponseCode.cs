namespace GeneralFrameMES.Model
{
    public enum ResponseCode
    {
        验证成功 = 200,
        上传成功 = 201,
        用户不存在 = 420,
        用户名或密码错误 = 421,
        用户名或密码为空 = 422,
        条码内容为空 = 423,
        工单号为空 = 424,
        条码验证失败 = 425,
        没有对应工单号 = 426,
        上传数据为空 = 427,
    }
}
