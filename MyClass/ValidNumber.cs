using PhoneNumbers;
using Tasks.Models;

namespace Tasks.MyClass
{
    public class ValidNumber
    {
        string countryCode = "IR";
        string telephoneNumber = String.Empty;
        string message = "شماره صحیح نیست";
        bool isValidNumber = false;

        public void setCountryCode(string Code)
        {
            countryCode = Code;
        }
        public resValidNumber Check(string? telephoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            if (telephoneNumber != null)
            {
                if (telephoneNumber.Length == 11)
                {
                    try
                    {
                        PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);
                        isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
                        if (isValidNumber)
                        {
                            message = "شماره صحیح است";
                        }
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message.ToString();
                    }
                }
                else
                {
                    message = "شماره باید 11 رقم باشد";
                }
            }
            else
            {
                message = "شماره وارد نشده است";
            }
            resValidNumber Result = new resValidNumber
            {
                IsValidNumber = isValidNumber,
                Message = message
            };
            return Result;
        }
    }
}

