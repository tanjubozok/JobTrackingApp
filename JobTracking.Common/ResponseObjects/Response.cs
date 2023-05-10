using JobTracking.Common.Abstract;
using JobTracking.Common.ComplexTypes;

namespace JobTracking.Common.ResponseObjects;

public class Response : IResponse
{
    public Response(ResponseType responseType)
    {
        this.ResponseType = responseType;
    }

    public Response(ResponseType responseType, string message)
    {
        this.ResponseType = responseType;
        this.Message = message;
    }

    public string? Message { get; set; }
    public ResponseType? ResponseType { get; set; }
}