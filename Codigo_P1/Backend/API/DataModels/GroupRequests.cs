using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class GroupRequests
    {
        public int GroupRequestId { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public bool Accepted { get; set; }

        public Groups Group { get; set; }
        //public virtual AspNetUsers User { get; set; }
    }
}
