using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JsoMvc.Models
{
    public class Suspect
    {
        [Key]
        public virtual int SuspectId { get; set; }
        [DisplayName("Suspect Name")]
        public virtual string Name { get; set; }
        public virtual string Height { get; set; }
        public virtual string Weight { get; set; }
        public virtual string Race { get; set; }
        [DisplayName("Identifying Marks")]
        public virtual string IdentifyingMarks { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime SuspectDOB { get; set; }
    }
}