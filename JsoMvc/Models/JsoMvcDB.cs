using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JsoMvc.Models
{
    public class JsoMvcDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public JsoMvcDB() : base("name=JsoMvcDB")
        {
        }

        public System.Data.Entity.DbSet<JsoMvc.Models.Officer> Officers { get; set; }

        public System.Data.Entity.DbSet<JsoMvc.Models.Suspect> Suspects { get; set; }

        public System.Data.Entity.DbSet<JsoMvc.Models.Crime> Crimes { get; set; }

        public System.Data.Entity.DbSet<JsoMvc.Models.JsoCaseManager> JsoCaseManagers { get; set; }
    }
}
