using Tavstal.PayPalSDK.Config;
using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Tests.Mocks;

public class FakePayPalHttpClient : PayPalHttpClient
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder;
    
    public FakePayPalHttpClient(Func<HttpRequestMessage, HttpResponseMessage> responder) :
        base(new SandboxEnvironment("fake-client-id", "fake-client-secret"))
    {
        _responder = responder;
    }

    /// <summary>
    /// Creates a new <see cref="FakePayPalHttpClient"/> with the specified responder function.
    /// </summary>
    /// <param name="responder">
    /// A function that takes an <see cref="HttpRequestMessage"/> and returns an <see cref="HttpResponseMessage"/>.
    /// </param>
    /// <returns>A new <see cref="FakePayPalHttpClient"/> instance.</returns>
    public static FakePayPalHttpClient CreateClient(Func<HttpRequestMessage, HttpResponseMessage> responder) =>
        new FakePayPalHttpClient(responder);

    public override Task<HttpResponseMessage> SendAsync(HttpRequestBase request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_responder(request));
    }
}