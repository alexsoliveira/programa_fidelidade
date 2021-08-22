using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class UserTokenDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimDTO> Claims { get; set; }
    }
}
