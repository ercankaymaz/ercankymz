using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ServiceMessageContext : IServiceMessageContext
{
	private readonly object m_lock = new object();

	private int m_maxStringLength;

	private int m_maxByteStringLength;

	private int m_maxArrayLength;

	private int m_maxMessageSize;

	private uint m_maxEncodingNestingLevels;

	private NamespaceTable m_namespaceUris;

	private StringTable m_serverUris;

	private IEncodeableFactory m_factory;

	private static ServiceMessageContext s_globalContext = new ServiceMessageContext(shared: true);

	public static ServiceMessageContext GlobalContext => s_globalContext;

	public static ServiceMessageContext ThreadContext
	{
		get
		{
			return s_globalContext;
		}
		set
		{
		}
	}

	public object SyncRoot => m_lock;

	public int MaxStringLength
	{
		get
		{
			lock (m_lock)
			{
				return m_maxStringLength;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_maxStringLength = value;
			}
		}
	}

	public int MaxArrayLength
	{
		get
		{
			lock (m_lock)
			{
				return m_maxArrayLength;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_maxArrayLength = value;
			}
		}
	}

	public int MaxByteStringLength
	{
		get
		{
			lock (m_lock)
			{
				return m_maxByteStringLength;
			}
		}
		set
		{
			lock (m_lock)
			{
				m_maxByteStringLength = value;
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

	public uint MaxEncodingNestingLevels
	{
		get
		{
			lock (m_lock)
			{
				return m_maxEncodingNestingLevels;
			}
		}
	}

	public NamespaceTable NamespaceUris
	{
		get
		{
			return m_namespaceUris;
		}
		set
		{
			lock (m_lock)
			{
				if (value == null)
				{
					m_namespaceUris = GlobalContext.NamespaceUris;
				}
				else
				{
					m_namespaceUris = value;
				}
			}
		}
	}

	public StringTable ServerUris
	{
		get
		{
			return m_serverUris;
		}
		set
		{
			lock (m_lock)
			{
				if (value == null)
				{
					m_serverUris = GlobalContext.ServerUris;
				}
				else
				{
					m_serverUris = value;
				}
			}
		}
	}

	public IEncodeableFactory Factory
	{
		get
		{
			return m_factory;
		}
		set
		{
			lock (m_lock)
			{
				if (value == null)
				{
					m_factory = GlobalContext.Factory;
				}
				else
				{
					m_factory = value;
				}
			}
		}
	}

	public ServiceMessageContext()
	{
		m_maxStringLength = 65535;
		m_maxByteStringLength = 1048560;
		m_maxArrayLength = 65535;
		m_maxMessageSize = 2097120;
		m_namespaceUris = new NamespaceTable();
		m_serverUris = new StringTable();
		m_factory = EncodeableFactory.GlobalFactory;
		m_maxEncodingNestingLevels = 200u;
	}

	private ServiceMessageContext(bool shared)
		: this()
	{
		m_maxStringLength = 65535;
		m_maxByteStringLength = 1048560;
		m_maxArrayLength = 65535;
		m_maxMessageSize = 2097120;
		m_namespaceUris = new NamespaceTable(shared);
		m_serverUris = new StringTable(shared);
		m_factory = EncodeableFactory.GlobalFactory;
		m_maxEncodingNestingLevels = 200u;
	}
}
