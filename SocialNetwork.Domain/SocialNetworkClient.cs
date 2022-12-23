using SocialNetwork.BDD.Tests;

namespace SocialNetwork.Domain;

public class SocialNetworkClient
{
    private readonly IPrinter _printerMock;

    public SocialNetworkClient(IPrinter printerMock)
    {
        _printerMock = printerMock;
    }

    public void Accept(string command)
    {
        throw new NotImplementedException();
    }
}