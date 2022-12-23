using Moq;
using SocialNetwork.Domain;

namespace SocialNetwork.BDD.Tests;

[Binding]
public class PostAndReadDefinitions
{
    private SocialNetworkClient _socialNetworkClient;
    private readonly Mock<IPrinter> _printerMock = new();

    [Given(@"In our Social Network")]
    public void GivenInOurSocialNetwork()
    {
        _socialNetworkClient = new SocialNetworkClient(_printerMock.Object);
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