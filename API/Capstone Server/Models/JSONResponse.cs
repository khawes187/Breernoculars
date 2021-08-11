using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class JSONResponse
    {
        public Meta Meta { get; set; }
        public Notifications Notifications { get; set; }
        public Response Response { get; set; }

    }
}
