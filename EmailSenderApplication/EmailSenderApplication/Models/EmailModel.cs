using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmailSenderApplication.Models
{
    public class EmalModel
    {
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> BCc { get; set; }
        public string Subject { get; set; }

        [Display(Name ="Compose Mail")]
        public string Body { get; set; }
        
        public ICollection<IFormFile> Files { get; set; }


    }
}
