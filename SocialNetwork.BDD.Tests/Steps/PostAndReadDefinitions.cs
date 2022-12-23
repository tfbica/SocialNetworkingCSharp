using Moq;
using SocialNetwork.Domain;

namespace SocialNetwork.BDD.Tests;

[Binding]
public class PostAndReadDefinitions
{
    public PostAndReadDefinitions(IPostPreparator postPreparator)
    {
        _postPreparator = postPreparator;
    }

    private SocialNetworkClient _socialNetworkClient;
    private readonly Mock<IClockService> _clockServiceMock = new();
    private readonly Mock<IPrinter> _printerMock = new();

    private Parser _parser = new Parser();
    private PostRepository _postRepository = new PostRepository();
    private DateTime _postDateTime = new DateTime(2022, 2, 22, 22, 22, 22);
    private IPostPreparator _postPreparator;

    [Given(@"In our Social Network")]
    public void GivenInOurSocialNetwork()
    {
        _socialNetworkClient = new SocialNetworkClient(_printerMock.Object, _postRepository, _parser, _clockServiceMock.Object, _postPreparator);
    }

    [When(@"The user writes a (.*)")]
    public void WhenTheUserWritesA(string postMessage)
    {
        _clockServiceMock.Setup(service => service.getCurrentDate()).Returns(_postDateTime);
        _socialNetworkClient.Accept(postMessage);
    }

    [When(@"The user writes the (.*)")]
    public void WhenTheUserWritesThe(string userName)
    {
        _socialNetworkClient.Accept(userName);
    }

    [When(@"(.*) has passed since the post")]
    public void WhenHasPassedSinceThePost(int seconds)
    {
        _postDateTime = _postDateTime.AddSeconds(seconds);
    }

    [Then(@"The last (.*) is displayed")]
    public void ThenTheLastIsDisplayed(string post)
    {
        _printerMock.Verify(printer => printer.print(post), Times.Once);
    }
}