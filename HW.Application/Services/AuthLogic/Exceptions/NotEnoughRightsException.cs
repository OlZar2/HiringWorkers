namespace HW.Application.Services.AuthLogic.Exceptions;

public class NotEnoughRightsException : Exception
{
    public NotEnoughRightsException(string message) : base(message) { } 
}
