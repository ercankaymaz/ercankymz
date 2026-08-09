using System.Net;

namespace System.ServiceModel.Channels;

internal class HttpCookieContainerManager : IHttpCookieContainerManager
{
	private CookieContainer _cookieContainer;

	public bool IsInitialized { get; private set; }

	public CookieContainer CookieContainer
	{
		get
		{
			return _cookieContainer;
		}
		set
		{
			IsInitialized = true;
			_cookieContainer = value;
		}
	}
}
