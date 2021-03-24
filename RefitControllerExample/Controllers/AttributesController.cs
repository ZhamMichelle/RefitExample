using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace RefitControllerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly ServiceRefit _serviceRefit;
        private readonly ILogger<AttributesController> _logger;
        public AttributesController(ServiceRefit serviceRefit, ILogger<AttributesController> logger)
        {
            _serviceRefit = serviceRefit;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> SendAttr([FromBody]List<RequestModel> request)
        {
            foreach (var attr in request)
            {
                var newAttr = new SendModel()
                {
                    system = "EXTERNALSITE",
                    attributes = new Attributes
                    {
                        data = new Data
                        {
                            name = $"city: {attr.city}, source: {attr.source}, auto: {attr.auto}, costGroup: {attr.costGroup}, url: {attr.url}",
                            phone = attr.phone,
                            iinBin = null,
                            organizationName = null,
                            email = null,
                            callTime = DateTime.Now.ToString("HH:mm"),
                            date = DateTime.Now.ToString("dd-MM-yyyy"),
                        }
                    }
                };
                try
                {
                    await _serviceRefit.SendAttr(newAttr);
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    //_logger.LogError("Error", newAttr.attributes.data.phone);
                    _logger.LogError(newAttr.attributes.data.phone);
                    return BadRequest(e);
                }
            }


            return Ok();
        }



        [HttpPost("test")]
        public async Task<ActionResult> Test([FromBody]List<RequestModel> request)
        {
            int z = 0;
            for (int i = 0; i < request.Count; i++)

            {

                try
                {
                    string tester = request[i].phone;
                    z++;
                    if (request[i].phone == null)
                    {
                        Console.WriteLine("tel: " + request[i - 1].phone);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(request[i - 1].phone);
                    return BadRequest(e);
                }
            }

            Console.WriteLine("z" + z);
            return Ok();
        }
    }
}