using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Web.FormModels
{
    public class SendChatMessage
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(255, ErrorMessage = "Message length must be less than 256 characters.")]
        public string Message { get; set; }
    }
}
