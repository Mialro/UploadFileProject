using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFiles.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "You Must Choose a File"), Display(Name = "Choose File To Upload")]
        public IFormFile File { get; set; }
    }
}
