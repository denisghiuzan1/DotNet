using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    [Table("eCommerce", Schema = "BazaDeDate")]
    public class eCommerce : Business
    {
        public string URL { get; set; }
    }

}
