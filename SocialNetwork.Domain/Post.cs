namespace SocialNetwork.Domain;

public class Post
{
    public string User { get; }
    public string Message { get; }
    public DateTime Date { get; }
    
    public Post(string username, string message, DateTime date)
    {
        User = username;
        Message = message;
        Date = date;
    }
}