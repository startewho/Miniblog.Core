using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebEssentials.AspNetCore.Serialization
{
    public static  class SerializationExtension
    {
        

        public static IApplicationBuilder UseSerialization(this IApplicationBuilder builder,SerializationOption option)
        {
           
            return builder.UseMiddleware<SerializationMiddleware>(option);
           
        }

    }
}
