using GameStore.Utils.Models;

namespace GameStore.Utils.Exceptions;

public class BadRequestException(string message) : GStoreException(InternalErrorCode.BadRequest, message)
{
}