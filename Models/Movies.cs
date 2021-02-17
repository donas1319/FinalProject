using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketReservation.Models
{
    public class Movies
    {
        public int Id { get; set; } //PK
        [Required]
        public String MovieName { get; set; }
        public String DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Rating { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "${0:#,0}")]
        [Range(0.01, 999999)]
        public double Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; } //FK
        [Display(Name = "Category")]
        public Category category { get; set; }

    }
}
