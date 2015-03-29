using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class GrantInfoDBContext:DbContext
    {
        public GrantInfoDBContext()
            :base("Default Connection")
        {

        }

        DbSet<GrantInfo> GrantInfos { get; set; }
    }
        
}