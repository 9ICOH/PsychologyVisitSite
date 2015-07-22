
namespace PsychologyVisitSite.Domain.Entities
{
    using System;

    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ActivatedDate { get; set; }

        public string ActivatedLink { get; set; }

        public DateTime LastVisitDate { get; set; }

        public string AvatarPath { get; set; }

       
        
        //public static string GetActivateUrl()
        //{
        //    return Guid.NewGuid().ToString("N");
        //}

        //public string ConfirmPassword { get; set; }

        //public string Captcha { get; set; }

       
    }
}