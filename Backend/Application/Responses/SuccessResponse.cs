namespace Application.Responses;
public class SuccessResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public Guid ID { get; set; } // Adjust the type according to your needs
}
