﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Post
    {
        public long Id { get; set; }

        public string _key;

        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

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
