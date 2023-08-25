using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Tasks.Contexts;
using Tasks.Models;
using Tasks.MyClass;

namespace Tasks.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet(Name = "Customer")]
        public List<Customer> Get()
        {
            using var context = new DbCustomer();
            //var List = context.Customer.Include(x => x.Sub).ThenInclude(x => x.Sub2).ToList();
            var List = context.Customer.ToList();
            return List;
        }
        [HttpPut]
        public Object Put(Customer _customers)
        {

            bool status = false;
            string message = "Unsuccessful";
            var _ValidNumber = new ValidNumber();
            bool isValidNumber = false;
            var result = _ValidNumber.Check(_customers.PhoneNumber);

            bool isEmail = Regex.IsMatch(_customers.Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            
            if (isEmail && result.IsValidNumber)
            {
                try
                {

                    using var context = new DbCustomer();
                    var Check = context.Customer.Where(x =>x.Email == _customers.Email).ToList();
                    if (Check.Count == 0)
                    {
                        var List = context.Customer.ToList();
                        context.Add(_customers);
                        context.SaveChanges();
                        status = true;
                        message = "Successful";
                    }
                    else
                    {
                        message = "کاربر از قبل موجود است";
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                if(!isEmail)
                {
                    message = "پست الکترونیک صحیح نمی باشد";
                }
                else
                {
                    message = "شماره تلفن صحیح نمی باشد";
                }
            }
            

            return new { status = status, message = message };
        }
        [HttpDelete]
        public Object Del(int id)
        {
            bool status = false;
            string message = "Unsuccessful";
            try
            {
                using var context = new DbCustomer();
                Customer customer = new Customer() { Id = id };
                context.Customer.Attach(customer);
                context.Customer.Remove(customer);
                context.SaveChanges();
                status = true;
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new { status = status, message = message };
        }
        [HttpPost]
        public Object Post(Customer _customers)
        {
            bool status = false;
            string message = "Unsuccessful";
            try
            {

                var context = new DbCustomer();

                var Selected = context.Customer.FirstOrDefault(item => item.Id == _customers.Id);
                if (Selected != null)
                {
                    Selected.Firstname = _customers.Firstname;
                    Selected.Lastname = _customers.Lastname;
                    Selected.DateOfBirth = _customers.DateOfBirth;
                    Selected.PhoneNumber = _customers.PhoneNumber;
                    Selected.Email = _customers.Email;
                    Selected.BankAccountNumber = _customers.BankAccountNumber;
                    context.SaveChanges();
                    status = true;
                    message = "Successful";
                }
                else
                {
                    message = "شناسه مورد نظر موجود نیست";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new { status = status, message = message };
        }
    }
}
