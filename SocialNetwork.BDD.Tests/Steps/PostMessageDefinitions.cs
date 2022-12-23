namespace SocialNetwork.BDD.Tests;

[Binding]
public class PostMessageDefinitions
{
    [Given(@"The user is (.*)")]
    public void GivenTheUserIs(string name)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"Uses the -> command")]
    public void GivenUsesTheCommand()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"It types a (.*) message")]
    public void WhenItTypesAMessage(string message)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"A post is added to (.*) timeline")]
    public void ThenAPostIsAddedToTimeline(string name)
    {
        ScenarioContext.StepIsPending();
    }
}