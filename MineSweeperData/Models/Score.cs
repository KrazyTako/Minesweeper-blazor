using System;
using System.ComponentModel.DataAnnotations;

namespace MineSweeperData.Models
{
    public class Score
    {
        public int Id { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
