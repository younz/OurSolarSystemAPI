using Microsoft.EntityFrameworkCore;

namespace OurSolarSystemAPI.Models
{
    public class Admin : User
    {
        public override roles Roles { get; set; } = roles.Admin;
    }
}
