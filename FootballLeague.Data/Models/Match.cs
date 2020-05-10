using FootballLeague.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Team Guest { get; set; }

        public int HostId { get; set; }
        public Team Host { get; set; }

        [Display(Name = "Host result")]
        public Result Result { get; set; }
    }
}
