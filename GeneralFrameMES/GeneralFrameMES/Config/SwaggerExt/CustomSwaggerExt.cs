
using Microsoft.OpenApi.Models;

namespace GeneralFrameMES.Config.SwaggerExt
{
    /// <summary>
    /// Swagger的配置
    /// </summary>
    public static class CustomSwaggerExt
    {
        public static void AddSwaggerExt(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                //1.设置对象类型参数默认值
                options.SchemaFilter<DefaultValueSchemaFilter>();

                //2.版本控制
                typeof(APIVersion).GetEnumNames().ToList().ForEach(version =>
                {
                    options.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"通用框架MES平台API文档",
                        Version = version,
                        Description = $"用于用户、生产验证，保存生产数据    版本{version}"
                    });
                });

                //3.显示注释
                //读取根据控制器api生成的XML的文件
                var file = Path.Combine(AppContext.BaseDirectory, "GeneralFrameMES.xml");
                //显示控制器注释
                options.IncludeXmlComments(file, true);
                //对action的名称进行排序
                options.OrderActionsBy(o => o.RelativePath);


            });
        }

        public static void UseSwaggerExt(this WebApplication app)
        {
            //使用Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //版本控制
                foreach (string version in typeof(APIVersion).GetEnumNames())
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"通用框架MES平台第【{version}】版本");
                }
            });
        }


    }
}
