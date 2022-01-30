using System.ComponentModel.DataAnnotations;


namespace Reklamation.Models.DTO
{
    public class NewMessagetoKundeDTO
    {
        [Required(ErrorMessage = "Can't send empty messages!")]
        public string Message { get; set; }
    }
}
