using System.Net;

namespace System.ServiceModel.Channels;

public interface IHttpCookieContainerManager
{
	CookieContainer CookieContainer { get; set; }
}
