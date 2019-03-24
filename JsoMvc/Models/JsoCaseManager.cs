using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JsoMvc.Models
{
    public class JsoCaseManager
    {
        [Key]
        public virtual int CaseId { get; set; }
        [DisplayName("Assigned Officer")]
        public virtual int OfficerId { get; set; }
        [DisplayName("Crime")]
        public virtual int CrimeId { get; set; }
        [DisplayName("Suspect Name")]
        public virtual int SuspectId { get; set; }
        [DisplayName("Hours Worked")]
        public virtual int HoursWorked { get; set; }
        [DisplayName("Is Case Completed?")]
        public virtual bool Completed { get; set; }
        public virtual Crime Crime { get; set; }
        public virtual Suspect Suspect { get; set; }
        public virtual Officer Officer { get; set; }
    }
}