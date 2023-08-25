using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;
using Tasks.MyClass;

namespace Tasks.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class isValidNumberController : ControllerBase
    {
        [HttpGet("isValidNumber")]
        public Object Get(string? telephoneNumber)
        {
            var _ValidNumber = new ValidNumber();
            var result = _ValidNumber.Check(telephoneNumber);
            return result;
        }
        [HttpGet("isValidNumberOther")]
        public Object GetOther(string? telephoneNumber, string CountryCode = "IR")
        {
            var _ValidNumber = new ValidNumber();
            _ValidNumber.setCountryCode(CountryCode);
            var result = _ValidNumber.Check(telephoneNumber);
            return result;
        }
    }
}
