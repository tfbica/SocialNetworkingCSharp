using SocialNetwork.BDD.Tests;

namespace SocialNetwork.Domain;

public class SocialNetworkClient
{
    private readonly IPrinter _printer;
    private readonly IPostsRepository _postsRepository;
    private readonly IParser _parser;
    private readonly IClockService _clockService;
    
    public SocialNetworkClient(IPrinter printer, IPostsRepository postsRepository, IParser parser, IClockService clockService)
    {
        _printer = printer;
        _postsRepository = postsRepository;
        _parser = parser;
        _clockService = clockService;
    }

    public void Accept(string command)
    {
        Command parsedCommand = _parser.ParseCommand(command);

        Post newPost = new Post(parsedCommand.UserName, parsedCommand.Message, _clockService.getCurrentDate());
        
        _postsRepository.add(newPost);
    }
}