namespace idm.car.project.api.Responses;

public class ApiResponse<T>
{
    public T Data { get; set; }

    public String Message { get; set; }
}
