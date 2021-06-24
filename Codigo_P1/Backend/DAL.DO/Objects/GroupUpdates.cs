using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class GroupUpdates
    {
        public GroupUpdates()
        {
            GroupComments = new HashSet<GroupComments>();
            GroupUpdateSupports = new HashSet<GroupUpdateSupports>();
        }

        public int GroupUpdateId { get; set; }
        public string Updatemsg { get; set; }
        public double? Status { get; set; }
        public int GroupGoalId { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<GroupComments> GroupComments { get; set; }
        public virtual ICollection<GroupUpdateSupports> GroupUpdateSupports { get; set; }
    }
}
