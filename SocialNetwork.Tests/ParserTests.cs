using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

public class ParserTests
{
    [Fact]
    public void ParsesPost()
    {
        Command expectedCommand = new Command("Post", "Alice", "I love Python!");
        
        Parser parser = new();
        Command command = parser.ParseCommand("Alice -> I love Python!");
        
        Assert.Equivalent(expectedCommand, command);
    } 
    
    [Fact]
    public void ParsesRead()
    {
        Command expectedCommand = new Command("Read", "Alice", "");
        
        Parser parser = new();
        Command command = parser.ParseCommand("Alice");
        
        Assert.Equivalent(expectedCommand, command);
    } 
}