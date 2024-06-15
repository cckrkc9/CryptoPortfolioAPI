
namespace Entities.Exceptions
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException()
            : base ($"Invalid client request. The token has some invalid values.")
        {
            
        }
    }
}
