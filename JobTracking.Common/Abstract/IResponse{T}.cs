using JobTracking.Common.ResponseObjects;

namespace JobTracking.Common.Abstract;

public interface IResponse<T> : IResponse
{
    T? Data { get; set; }
    List<CustomValidationError>? CustomValidationErrors { get; set; }
}
