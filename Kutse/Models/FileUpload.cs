using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kutse.Models
{
    public class FileUpload
    {
        [Required(ErrorMessage ="Vali fail...")]
        [Display(Name="Faili lisamine")]
        [DataType(DataType.Upload)]
        public string FileName { get; set; }
    }
}