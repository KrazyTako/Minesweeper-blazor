using System;
using System.ComponentModel.DataAnnotations;

namespace MineSweeperData.Models
{
    public class Score
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [Range(4, int.MaxValue)]
        public int Width { get; set; }
        
        [Required]
        [Range(4, int.MaxValue)]
        public int Height { get; set; }
        
        [Required]
        public int MineCount { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
