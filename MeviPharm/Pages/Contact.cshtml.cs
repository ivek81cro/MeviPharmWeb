using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeviPharm.Pages
{
    public class ContactModel : PageModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Message { get; set; }

        private readonly IEmailSender _emailSender;
        public ContactModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> Contact(ContactModel item)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync("info@elabdesign.net",
                    "Message from contact form",
                    $"<h3>Name: {item.Name}</h3><a href='{item.Email}'>Mail: {item.Email}</a><p>Message: {item.Message}</p>");

                return Redirect("ContactSuccess");
            }
            else
            {
                return Page();
            }
        }
    }
}
