using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobEyeTest.Models
{
    public class FormJson
    {
        public int Id { get;set; }
        [DisplayName("Enter Form Content")]
        public string FormContent { get; set; }
    }

}
