using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Post
    {
        [Display(Name = "Post Title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100")]
        public string Title { get; set; }

        public string Author { get; set; }


        [Display(Name = "Message")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Title mustat least 100 character")]
        public string Body { get; set; }

        public DateTime Posted { get; set; }
    }
}
