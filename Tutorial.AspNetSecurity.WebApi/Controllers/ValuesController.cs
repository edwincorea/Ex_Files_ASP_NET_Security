using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.AspNetSecurity.WebApi.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IDataProtector _protector;

        public ValuesController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(
                    "Tutorial.AspNetSecurity.WebApi.Controllers.ValuesController",
                    new string[] { "Tenant1" });
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("UserIds")]
        public IEnumerable<string> GetUserIds()
        {
            var secretId1 = _protector.Protect("ST123");
            var secretId2 = _protector.Protect("FC456");

            return new string[] { secretId1, secretId2 };
        }

        [HttpGet]
        [Route("PlainTextId")]
        public string GetPlainTextId(string encryptedId)
        {
            var plainText = _protector.Unprotect(encryptedId);

            return plainText;
        }
    }
}
