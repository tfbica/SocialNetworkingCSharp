using Moq;
using SocialNetwork.Domain;

namespace SocialNetwork.BDD.Tests;

[Binding]
public class PostAndReadDefinitions
{
    private SocialNetworkClient _socialNetworkClient;
    private readonly Mock<IClockService> _clockServiceMock = new();
    private readonly Mock<IPrinter> _printerMock = new();

    private Parser _parser = new Parser();
    private PostRepository _postRepository = new PostRepository();
    
    
    

    [Given(@"In our Social Network")]
    public void GivenInOurSocialNetwork()
    {
        _socialNetworkClient = new SocialNetworkClient(_printerMock.Object, _postRepository, _parser, _clockServiceMock.Object);
    }

    [When(@"The user writes a (.*)")]
    public void WhenTheUserWritesA(string postMessage)
    {
        _socialNetworkClient.Accept(postMessage);
    }

    [When(@"The user writes the (.*)")]
    public void WhenTheUserWritesThe(string userName)
    {
        _socialNetworkClient.Accept(userName);
    }

    [Then(@"The last (.*) is displayed")]
    public void ThenTheLastIsDisplayed(string post)
    {
        _printerMock.Verify(printer => printer.print(post), Times.Once);
    }
}