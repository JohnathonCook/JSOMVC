using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JsoMvc.Models
{
    public class Crime
    {
        [Key]
        public int CrimeId { get; set; }
        [DisplayName("Crime Type")]
        public string CrimeType { get; set; }
        [DisplayName("Crime Details")]
        [DataType(DataType.MultilineText)]
        public string CrimeDetails { get; set; }
    }
}