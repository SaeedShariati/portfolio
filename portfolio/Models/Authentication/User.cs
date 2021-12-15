using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models.Authentication
{
    //
    // Summary:
    //     Represents a User in this application
    //
    public class User:IdentityUser<string>
    {
        [MaxLength(500)]
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        [BindNever]
        public DateTime AccountCreationDate { get; set; }
        [MaxLength(500)]
        public string Interests { get; set; }
        public void AddInterest(string topic)
        {
            Interests += (topic + ",");
        }
        public void RemoveTag(string topic)
        {
            Interests = Interests.Replace(topic + ",", "");
        }
        public string[] GetInterests()
        {
            string[] topics = Interests?.TrimEnd(',').Split(',');
            return topics;
        }
    }
}
