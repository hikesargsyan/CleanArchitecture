namespace App.Application.Common.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string entityName) : base($"{entityName} was not found.") { }
}
