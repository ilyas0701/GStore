using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class GStoreException(InternalErrorCode code, string message) : Exception(message)
{
    public GStoreException(string message) : this(InternalErrorCode.UnknownError, message)
    {
    }

    public InternalErrorCode Code { get; } = code;
}