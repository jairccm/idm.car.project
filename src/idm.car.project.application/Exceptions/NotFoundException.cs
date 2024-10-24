namespace idm.car.project.application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base( message)
    {
    }
}
