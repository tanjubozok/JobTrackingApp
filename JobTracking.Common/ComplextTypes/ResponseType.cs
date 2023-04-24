namespace JobTracking.Common.ComplextTypes;

public enum ResponseType
{
    Success = 1,
    Error,
    TryCatch,
    ValidationError,
    SaveError,
    NotFound,
}