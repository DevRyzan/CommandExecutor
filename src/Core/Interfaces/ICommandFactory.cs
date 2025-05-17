namespace Core.Interfaces;

public interface ICommandFactory
{
    ICommand Command(string input);
}
