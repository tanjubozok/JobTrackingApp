namespace JobTracking.Common.ComplexTypes;

public enum ResponseType
{
    Success = 1,
    Error,
    TryCatch,
    ValidationError,
    SaveError,
    NotFound,
}