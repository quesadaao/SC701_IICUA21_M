using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class GroupUpdateSupports
    {
        public int GroupUpdateSupportId { get; set; }
        public int GroupUpdateId { get; set; }
        public int GroupUserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }

        public virtual GroupUpdates GroupUpdate { get; set; }
    }
}
