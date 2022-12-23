namespace SocialNetwork.Domain;

public class Parser : IParser
{
    public Command ParseCommand(string postMessage)
    {
        if (postMessage.Contains("->"))
        {
            string[] parts = postMessage.Split("->", 2);

            return new Command("Post", parts[0].Trim(), parts[1].Trim());
        }

        return new Command("Read", postMessage.Trim(), "");
    }
}