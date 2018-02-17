
using Postal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TSoft.Web.ViewModels
{
    public class EmailViewModel : Email
    {
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Please provide your full name")]        
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
            ErrorMessage = "The Email field is not valid, Please enter a valid email address!")]
        [Required(ErrorMessage = "Email address is required.")]
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        [DisplayName("Subject")]
        [Required(ErrorMessage = "Please select a topic")]
        public string Subject { get; set; }

        [DisplayName("Message")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "PLease provide a message for the email")]
        public string Message { get; set; }
    }
}