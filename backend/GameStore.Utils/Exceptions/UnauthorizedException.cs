using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class UnauthorizedException : GStoreException
{
    public UnauthorizedException(string message) : base(InternalErrorCode.Unauthorized, message)
    {
    }
    public UnauthorizedException() : base(InternalErrorCode.Unauthorized, "Unauthorized")
    {
        
    }
}