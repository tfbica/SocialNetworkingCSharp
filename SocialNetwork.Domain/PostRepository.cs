namespace SocialNetwork.Domain;

public class PostRepository : IPostsRepository
{
    private List<Post> _posts = new();

    public void add(Post postMessage)
    {
        _posts.Add(postMessage);
    }

    public List<Post> getAll()
    {
        return _posts;
    }

    public List<Post> getAllFrom(string userName)
    {
        throw new NotImplementedException();
    }
}