using System.Runtime.InteropServices;
using System.Threading;

namespace Opc.Ua;

[ComVisible(true)]
public class SecureChannelContext
{
	private string m_secureChannelId;

	private EndpointDescription m_endpointDescription;

	private RequestEncoding m_messageEncoding;

	private static ThreadLocal<SecureChannelContext> s_Dataslot = new ThreadLocal<SecureChannelContext>();

	public string SecureChannelId => m_secureChannelId;

	public EndpointDescription EndpointDescription => m_endpointDescription;

	public RequestEncoding MessageEncoding => m_messageEncoding;

	public static SecureChannelContext Current
	{
		get
		{
			return s_Dataslot.Value;
		}
		set
		{
			s_Dataslot.Value = value;
		}
	}

	public SecureChannelContext(string secureChannelId, EndpointDescription endpointDescription, RequestEncoding messageEncoding)
	{
		m_secureChannelId = secureChannelId;
		m_endpointDescription = endpointDescription;
		m_messageEncoding = messageEncoding;
	}

	protected SecureChannelContext()
	{
		SecureChannelContext current = Current;
		if (current != null)
		{
			m_secureChannelId = current.SecureChannelId;
			m_endpointDescription = current.EndpointDescription;
			m_messageEncoding = current.MessageEncoding;
		}
	}
}
