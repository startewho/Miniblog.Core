using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebEssentials.AspNetCore.Serialization
{
    public class SerializationMiddleware
    {
      
        private readonly RequestDelegate _next;

        private readonly SerializationOption _option;


        public SerializationMiddleware(RequestDelegate next,SerializationOption option)
        {
            _next = next;
            _option = option;
           
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var servalue = context.Request.Query[_option.QueryName];

          

            if (_option.SerializeJson && !string.IsNullOrEmpty(servalue))
            {
                if (servalue == "json")
                {
                    context.Request.ContentType = "application/json";
                    context.Request.Headers["Accept"]= "application/json";
                }
                if (servalue == "xml")
                {

                    context.Request.ContentType = "text/xml, application/xml";
                    context.Request.Headers["Accept"] = " application/xml,text/xml";

                }
            }



            await _next.Invoke(context);
        }
    }


}

/// <summary>
/// 序列化选项
/// 是否序化Json/Xml
/// </summary>
public class SerializationOption
{
    public string QueryName { get; set; } = "queryType";
    public bool SerializeJson { get; set; } = false;

   public bool SerializeXml { get; set; } = false;
}
