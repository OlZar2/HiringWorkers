namespace HW.Application.Services.SharedLogic.Exceptions;

public class WrongDataException : Exception
{
    public WrongDataException(string message) : base(message) { }
}
