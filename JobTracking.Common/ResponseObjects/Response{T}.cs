using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Entities.Abstract;

namespace JobTracking.Common.ResponseObjects;

public class Response<T> : Response, IResponse<T>, IBaseEntity
{
    public Response(ResponseType responseType) : base(responseType)
    {
    }

    public Response(ResponseType responseType, string message) : base(responseType, message)
    {
    }

    public Response(ResponseType responseType, T data) : base(responseType)
    {
        this.Data = data;
    }

    public Response(ResponseType responseType, List<CustomValidationError> customValidationErrors) : base(responseType)
    {
        this.CustomValidationErrors = customValidationErrors;
    }

    public Response(ResponseType responseType, T data, List<CustomValidationError> customValidationErrors) : base(responseType)
    {
        this.Data = data;
        this.CustomValidationErrors = customValidationErrors;
    }

    public T? Data { get; set; }
    public List<CustomValidationError>? CustomValidationErrors { get; set; }
}