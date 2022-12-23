using SocialNetwork.BDD.Tests;
using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

public class SocialNetworkTests
{
    
    private SocialNetworkClient _socialNetworkClient;
    private readonly Mock<IPrinter> _printerMock = new();

    private readonly Mock<IPostsRepository> _postsRepositoryMock = new();
    private readonly Mock<IParser> _parserMock = new();
    private readonly Mock<IClockService> _clockServiceMock = new();
    
    
    [Fact]
    public void AcceptsAPostCommand()
    {
        string postMessage = "Alice -> Hey there!";

        DateTime ourMockedDate = new DateTime(2022, 2, 22, 22, 22, 22);
        string userName = "Alice";
        string message = "Hey there!";

        _parserMock.Setup(parser => parser.ParseCommand(postMessage)).Returns(new Command("Post", userName, message));
        _clockServiceMock.Setup(clock => clock.getCurrentDate()).Returns(ourMockedDate);
        
        _socialNetworkClient = new SocialNetworkClient(_printerMock.Object, _postsRepositoryMock.Object, _parserMock.Object, _clockServiceMock.Object);
        
        _socialNetworkClient.Accept(postMessage);
        
        
        
        _postsRepositoryMock.Verify(repo => repo.add(It.Is<Post>(
            post => post.User == userName &&
                 post.Message == message && 
                 post.Date.Equals(ourMockedDate))), 
            Times.Once);
   
        
    }
}