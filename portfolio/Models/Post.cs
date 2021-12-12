using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string[] Tags { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public string[] Comments { get; set; }
        public string ImageName { get; set; }

    }
}
