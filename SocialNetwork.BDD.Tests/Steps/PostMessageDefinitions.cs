using SocialNetwork.Domain;

namespace SocialNetwork.BDD.Tests;

[Binding]
public class PostMessageDefinitions
{
    private SocialNetworkClient _socialNetworkClient;
    

    [Given(@"In our Social Network")]
    public void GivenInOurSocialNetwork()
    {
        _socialNetworkClient = new SocialNetworkClient();
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
          
    }
}