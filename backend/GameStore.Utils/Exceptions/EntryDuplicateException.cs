using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class EntryDuplicateException(string message) : GStoreException(InternalErrorCode.EntryDuplicate, message)
{
}