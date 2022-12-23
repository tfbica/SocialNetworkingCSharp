using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

public class PostRepositoryTests
{
    [Fact]
    public void AddsPost()
    {
        var newPost = new Post("Alice", "I love Python!", 
            new DateTime(2022, 2, 22, 22, 22, 22));
        
        PostRepository repository = new();
        repository.add(newPost);

        Assert.Contains(repository.getAll(), post => post.Equals(newPost));
    }
}