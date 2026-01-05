using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class ForbiddenException: GStoreException
{
    public ForbiddenException() : base(InternalErrorCode.Forbidden, "Forbidden")
    {
        
    }
    
    public ForbiddenException(string message) : base(InternalErrorCode.Forbidden, message)
    {
    }
}