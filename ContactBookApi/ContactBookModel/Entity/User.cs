
using Microsoft.AspNetCore.Identity;

namespace ContactBookModel.Entities
{
    public class User : IdentityUser
    {
        public string? ImageUrl { get;set; }
    }
}