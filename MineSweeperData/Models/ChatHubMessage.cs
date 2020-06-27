using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MineSweeperData.Models
{
    public class ChatHubMessage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
