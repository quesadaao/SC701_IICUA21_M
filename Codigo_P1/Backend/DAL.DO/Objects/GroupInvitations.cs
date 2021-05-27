using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class GroupInvitations
    {
        public int GroupInvitationId { get; set; }
        public string FromUserId { get; set; }
        public int GroupId { get; set; }
        public string ToUserId { get; set; }
        public DateTime SentDate { get; set; }
        public bool Accepted { get; set; }

        public virtual Groups Group { get; set; }
    }
}
