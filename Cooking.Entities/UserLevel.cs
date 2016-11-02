namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLevel
    {
        public int IdUserLevel { get; set; }
        public string Name { get; set; }
        public decimal RateMin { get; set; }
        public decimal RateMax { get; set; }
        public string Description { get; set; }
    }
}
