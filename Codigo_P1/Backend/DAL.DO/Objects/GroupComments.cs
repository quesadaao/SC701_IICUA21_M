using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class GroupComments
    {
        public int GroupCommentId { get; set; }
        public string CommentText { get; set; }
        public int GroupUpdateId { get; set; }
        public DateTime CommentDate { get; set; }


        public virtual GroupUpdates GroupUpdate { get; set; }
    }
}
