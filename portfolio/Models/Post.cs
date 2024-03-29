﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class Post
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Tags { get; set; } //seperated by comma
        [Required]
        [MinLength(100,ErrorMessage ="متن کوتاه است")]
        [MaxLength(6000,ErrorMessage ="متن بیش از اندازه طولانی است")]
        public string Text { get; set; }
        [Required(ErrorMessage ="عنوان باید وارد شود")]
        [MaxLength(30,ErrorMessage ="بیشتر از 30 کاراکتر نباید باشد")]
        public string Header { get; set; }
        public Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string ImageName { get; set; }
        public void AddTag(string tag)
        {
            Tags += (tag + ",");
        }
        public void RemoveTag(string tag)
        {
            Tags = Tags?.Replace(tag + ",", "");
        }
        public string[] GetTags()
        {
            string[] tags = Tags?.TrimEnd(',').Split(',');
            return tags;
        }
    }
}
