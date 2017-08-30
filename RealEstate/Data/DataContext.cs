using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstate.Data
{
    public class DataContext: DbContext
    {
        public DataContext():base("name=MyConnection")
        {

        }
        public virtual DbSet<EnquiryModel> enquiry{ get; set; }
    }
}