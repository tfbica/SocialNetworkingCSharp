using SocialNetwork.BDD.Tests;

namespace SocialNetwork.Domain;

public class SocialNetworkClient
{
    private readonly IPrinter _printer;
    private readonly IPostsRepository _postsRepository;
    private readonly IParser _parser;
    private readonly IClockService _clockService;
    private readonly IPostPreparator _postPreparator;

    public SocialNetworkClient(IPrinter printer, IPostsRepository postsRepository, IParser parser,
        IClockService clockService, IPostPreparator postPreparator)
    {
        _printer = printer;
        _postsRepository = postsRepository;
        _parser = parser;
        _clockService = clockService;
        _postPreparator = postPreparator;
    }

    public void Accept(string command)
    {
        Command parsedCommand = _parser.ParseCommand(command);

        if (parsedCommand.Type == "Post") 
        {
            Post newPost = new Post(parsedCommand.UserName, parsedCommand.Message, _clockService.getCurrentDate());
            _postsRepository.add(newPost);
            return;
        }

        if (parsedCommand.Type == "Read")
        {
            var postsForUser = _postsRepository.getAllFrom(parsedCommand.UserName);
            _postPreparator.prepare(postsForUser);
        }
    }
}