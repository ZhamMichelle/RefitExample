using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace RefitControllerExample
{
    public interface ServiceRefit
    {
        [Headers("some: something")]
        [Post("")]
        Task SendAttr([Body(BodySerializationMethod.Default)] SendModel data);
    }
}
