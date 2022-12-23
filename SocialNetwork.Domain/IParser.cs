namespace SocialNetwork.Domain;

public interface IParser
{
     Command ParseCommand(string postMessage);
}