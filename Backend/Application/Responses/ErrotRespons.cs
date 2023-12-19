namespace Application.Responses;
public class ErrorResponse
{
    public IEnumerable<string>? Errors { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
