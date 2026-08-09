using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelQuotas
{
	private readonly object m_lock = new object();

	private int m_maxMessageSize;

	private int m_maxBufferSize;

	private int m_channelLifetime;

	private int m_securityTokenLifetime;

	private IServiceMessageContext m_messageContext;

	private ICertificateValidator m_certificateValidator;

	public IServiceMessageContext MessageContext
	{
		get
		{
			lock (m_lock)
			{
				return m_messageContext;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_messageContext = value;
			}
		}
	}

	public ICertificateValidator CertificateValidator
	{
		get
		{
			lock (m_lock)
			{
				return m_certificateValidator;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_certificateValidator = value;
			}
		}
	}

	public int MaxMessageSize
	{
		get
		{
			lock (m_lock)
			{
				return m_maxMessageSize;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_maxMessageSize = value;
			}
		}
	}

	public int MaxBufferSize
	{
		get
		{
			lock (m_lock)
			{
				return m_maxBufferSize;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_maxBufferSize = value;
			}
		}
	}

	public int ChannelLifetime
	{
		get
		{
			lock (m_lock)
			{
				return m_channelLifetime;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_channelLifetime = value;
			}
		}
	}

	public int SecurityTokenLifetime
	{
		get
		{
			lock (m_lock)
			{
				return m_securityTokenLifetime;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_securityTokenLifetime = value;
			}
		}
	}

	public ChannelQuotas()
	{
		m_messageContext = ServiceMessageContext.GlobalContext;
		m_maxMessageSize = 1048560;
		m_maxBufferSize = 65535;
		m_channelLifetime = 60000;
		m_securityTokenLifetime = 3600000;
	}
}
