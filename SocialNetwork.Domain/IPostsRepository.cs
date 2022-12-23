namespace SocialNetwork.Domain;

public interface IPostsRepository 
{
    void add(Post postMessage);

    List<Post> getAll();
    List<Post> getAllFrom(string userName);
}