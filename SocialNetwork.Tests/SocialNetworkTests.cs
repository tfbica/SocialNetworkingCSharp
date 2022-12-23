using SocialNetwork.BDD.Tests;
using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

public class SocialNetworkTests
{

    private SocialNetworkClient _socialNetworkClient;
    private readonly Mock<IPrinter> _printerMock = new();

    private readonly Mock<IPostsRepository> _postsRepositoryMock = new();
    private readonly Mock<IParser> _parserMock = new();
    private readonly Mock<IPostPreparator> _postPreparatorMock = new();
    private readonly Mock<IClockService> _clockServiceMock = new();

    public SocialNetworkTests()
    {
        _socialNetworkClient = new SocialNetworkClient(_printerMock.Object, 
            _postsRepositoryMock.Object, _parserMock.Object, 
            _clockServiceMock.Object, _postPreparatorMock.Object);
    }

    [Fact]
    public void AcceptsAPostCommand()
    {
        string postMessage = "Alice -> Hey there!";

        DateTime ourMockedDate = new DateTime(2022, 2, 22, 22, 22, 22);
        string userName = "Alice";
        string message = "Hey there!";

        _parserMock.Setup(parser => parser.ParseCommand(postMessage)).Returns(new Command("Post", userName, message));
        _clockServiceMock.Setup(clock => clock.getCurrentDate()).Returns(ourMockedDate);

        _socialNetworkClient.Accept(postMessage);
        
        _postsRepositoryMock.Verify(repo => repo.add(It.Is<Post>(
            post => post.User == userName &&
                 post.Message == message && 
                 post.Date.Equals(ourMockedDate))), 
            Times.Once);
   
        
    } 
    
    [Fact]
    public void AcceptsAReadCommand()
    {
        string readCommand = "Alice";

        DateTime ourMockedDate = new DateTime(2022, 2, 22, 22, 22, 22);
        string userName = "Alice";
        string message = "";
        var listOfAlicePosts = new List<Post>()
        {
            new Post("Alice", "I love Python!", ourMockedDate)
        };

        _parserMock.Setup(parser => parser.ParseCommand(readCommand)).Returns(new Command("Read", userName, message));
        _postsRepositoryMock.Setup(repo => repo.getAllFrom(userName)).Returns(listOfAlicePosts);
        
        _socialNetworkClient.Accept(readCommand);

        _postPreparatorMock.Verify(prep => prep.prepare(listOfAlicePosts), Times.Once);

    }
}