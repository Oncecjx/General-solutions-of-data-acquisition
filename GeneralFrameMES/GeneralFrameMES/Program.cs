
using GeneralFrameMES.Config.SwaggerExt;

namespace GeneralFrameMES
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            //Swagger的配置
            builder.Services.AddSwaggerExt();

            //添加跨域策略
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", opt =>
                {
                    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            WebApplication app = builder.Build();

            //Swagger的配置
            app.UseSwaggerExt();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //使用跨域策略
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}
