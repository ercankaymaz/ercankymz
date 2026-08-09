using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TransportQuotas
{
	private int m_operationTimeout;

	private int m_maxStringLength;

	private int m_maxByteStringLength;

	private int m_maxArrayLength;

	private int m_maxMessageSize;

	private int m_maxBufferSize;

	private int m_channelLifetime;

	private int m_securityTokenLifetime;

	[DataMember(IsRequired = false, Order = 0)]
	public int OperationTimeout
	{
		get
		{
			return m_operationTimeout;
		}
		set
		{
			m_operationTimeout = value;
		}
	}

	[DataMember(IsRequired = false, Order = 1)]
	public int MaxStringLength
	{
		get
		{
			return m_maxStringLength;
		}
		set
		{
			m_maxStringLength = value;
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public int MaxByteStringLength
	{
		get
		{
			return m_maxByteStringLength;
		}
		set
		{
			m_maxByteStringLength = value;
		}
	}

	[DataMember(IsRequired = false, Order = 3)]
	public int MaxArrayLength
	{
		get
		{
			return m_maxArrayLength;
		}
		set
		{
			m_maxArrayLength = value;
		}
	}

	[DataMember(IsRequired = false, Order = 4)]
	public int MaxMessageSize
	{
		get
		{
			return m_maxMessageSize;
		}
		set
		{
			m_maxMessageSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 5)]
	public int MaxBufferSize
	{
		get
		{
			return m_maxBufferSize;
		}
		set
		{
			m_maxBufferSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 6)]
	public int ChannelLifetime
	{
		get
		{
			return m_channelLifetime;
		}
		set
		{
			m_channelLifetime = value;
		}
	}

	[DataMember(IsRequired = false, Order = 7)]
	public int SecurityTokenLifetime
	{
		get
		{
			return m_securityTokenLifetime;
		}
		set
		{
			m_securityTokenLifetime = value;
		}
	}

	public TransportQuotas()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_operationTimeout = 120000;
		m_maxStringLength = 65535;
		m_maxByteStringLength = 65535;
		m_maxArrayLength = 65535;
		m_maxMessageSize = 1048576;
		m_maxBufferSize = 65535;
		m_channelLifetime = 600000;
		m_securityTokenLifetime = 3600000;
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}
}
