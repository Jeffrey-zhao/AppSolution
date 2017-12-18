using System;

namespace App.Common
{
    public class GridPager  
    {
        public int Rows { get; set; }
        public int Page { get; set; }
        public string Order { get; set; }
        public string Sort { get; set; }
        public int TotalRows { get; set; }

        public int TotalPages
        {
            get { return (int) Math.Ceiling((float) TotalRows / (float) Rows); }
        }
    }
}
