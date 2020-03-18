using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    public class BusinessContext:DbContext
    {
        public DbSet<Business> BusinessSet { get; set; }

        public BusinessContext()
            : base("name=SelfReferenceModel")
        {
        }
    }
}
