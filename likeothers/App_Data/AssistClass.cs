using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace likeothers.Models
{
    //help us maintain linq returns (StatView instead of annonimous type)
    public class StatView
    {
        public int idQ { get; set; }
        public float sumation { get; set; }
    }

    
}