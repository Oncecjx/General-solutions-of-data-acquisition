using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;

namespace GeneralFrameMES.Config.SwaggerExt
{
    public class DefaultValueSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(schema == null)
            {
                return;
            }
            var objectSchema = schema;
            foreach (var property in objectSchema.Properties)
            {
                //通过类型
                if (property.Value.Type=="string" && property.Value.Default == null)
                {
                    property.Value.Default = new OpenApiString("");
                }


                //通过属性名
                //if (property.Key == "Description")
                //{
                //    property.Value.Default = new OpenApiString("123456789");
                //}



            }

        }
    }
}
