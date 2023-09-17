namespace RedisAPI.Models
{
    //request DTO
    public class UserDto
    {
        //required is new to C#11
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}