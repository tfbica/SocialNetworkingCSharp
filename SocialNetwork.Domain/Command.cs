namespace SocialNetwork.Domain;

public class Command
{
    public string Type { get; }
    public string UserName{ get; }
    public string Message{ get; }


    public Command(string type, string userName, string message)
    {
        Type = type;
        UserName = userName;
        Message = message;
    }
}