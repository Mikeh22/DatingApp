using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username {get; set;}
        [Required] // Use required to make the below field a required field, can select require a certain string length, if something isn't accomodated can use RegularExpression
        public string Password {get; set;}
    }
}