namespace GameStore.Utils.Models;

public enum InternalErrorCode
{
    UnknownError = 0,
    EntryNotFound = 1,
    Unauthorized = 2,
    Forbidden = 3,
    EntryDuplicate = 4,
    BadRequest = 5
}