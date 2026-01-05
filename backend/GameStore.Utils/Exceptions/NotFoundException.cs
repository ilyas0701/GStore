using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class NotFoundException(string message) : GStoreException(InternalErrorCode.EntryNotFound, message)
{
    
}