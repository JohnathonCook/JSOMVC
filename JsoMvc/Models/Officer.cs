using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JsoMvc.Models
{
    public class Officer
    {
        [Key]
        public virtual int OfficerId { get; set; }
        [DisplayName("Officer Name")]
        public virtual string Name { get; set; }
        public virtual string Rank { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date Of Hire")]
        public virtual DateTime DOH { get; set; }

    }
}