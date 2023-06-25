using meeting.services.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_API.Resources
{
    public class SaveReservationResources
    {
        public string Id { get; set; }
        public UserResources UserId { get; set; }
    }
}
