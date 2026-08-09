using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointConfiguration : IEncodeable, ICloneable, IJsonEncodeable
{
	private int m_operationTimeout;

	private bool m_useBinaryEncoding;

	private int m_maxStringLength;

	private int m_maxByteStringLength;

	private int m_maxArrayLength;

	private int m_maxMessageSize;

	private int m_maxBufferSize;

	private int m_channelLifetime;

	private int m_securityTokenLifetime;

	[DataMember(Name = "OperationTimeout", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "UseBinaryEncoding", IsRequired = false, Order = 2)]
	public bool UseBinaryEncoding
	{
		get
		{
			return m_useBinaryEncoding;
		}
		set
		{
			m_useBinaryEncoding = value;
		}
	}

	[DataMember(Name = "MaxStringLength", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "MaxByteStringLength", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "MaxArrayLength", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "MaxMessageSize", IsRequired = false, Order = 6)]
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

	[DataMember(Name = "MaxBufferSize", IsRequired = false, Order = 7)]
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

	[DataMember(Name = "ChannelLifetime", IsRequired = false, Order = 8)]
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

	[DataMember(Name = "SecurityTokenLifetime", IsRequired = false, Order = 9)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.EndpointConfiguration;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EndpointConfiguration_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EndpointConfiguration_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EndpointConfiguration_Encoding_DefaultJson;

	public static EndpointConfiguration Create()
	{
		return new EndpointConfiguration
		{
			OperationTimeout = 120000,
			UseBinaryEncoding = true,
			MaxArrayLength = 65535,
			MaxByteStringLength = 1048560,
			MaxMessageSize = 4194240,
			MaxStringLength = 65535,
			MaxBufferSize = 65535,
			ChannelLifetime = 120000,
			SecurityTokenLifetime = 3600000
		};
	}

	public static EndpointConfiguration Create(ApplicationConfiguration applicationConfiguration)
	{
		if (applicationConfiguration == null || applicationConfiguration.TransportQuotas == null)
		{
			return Create();
		}
		return new EndpointConfiguration
		{
			OperationTimeout = applicationConfiguration.TransportQuotas.OperationTimeout,
			UseBinaryEncoding = true,
			MaxArrayLength = applicationConfiguration.TransportQuotas.MaxArrayLength,
			MaxByteStringLength = applicationConfiguration.TransportQuotas.MaxByteStringLength,
			MaxMessageSize = applicationConfiguration.TransportQuotas.MaxMessageSize,
			MaxStringLength = applicationConfiguration.TransportQuotas.MaxStringLength,
			MaxBufferSize = applicationConfiguration.TransportQuotas.MaxBufferSize,
			ChannelLifetime = applicationConfiguration.TransportQuotas.ChannelLifetime,
			SecurityTokenLifetime = applicationConfiguration.TransportQuotas.SecurityTokenLifetime
		};
	}

	public EndpointConfiguration()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_operationTimeout = 0;
		m_useBinaryEncoding = true;
		m_maxStringLength = 0;
		m_maxByteStringLength = 0;
		m_maxArrayLength = 0;
		m_maxMessageSize = 0;
		m_maxBufferSize = 0;
		m_channelLifetime = 0;
		m_securityTokenLifetime = 0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt32("OperationTimeout", OperationTimeout);
		encoder.WriteBoolean("UseBinaryEncoding", UseBinaryEncoding);
		encoder.WriteInt32("MaxStringLength", MaxStringLength);
		encoder.WriteInt32("MaxByteStringLength", MaxByteStringLength);
		encoder.WriteInt32("MaxArrayLength", MaxArrayLength);
		encoder.WriteInt32("MaxMessageSize", MaxMessageSize);
		encoder.WriteInt32("MaxBufferSize", MaxBufferSize);
		encoder.WriteInt32("ChannelLifetime", ChannelLifetime);
		encoder.WriteInt32("SecurityTokenLifetime", SecurityTokenLifetime);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		OperationTimeout = decoder.ReadInt32("OperationTimeout");
		UseBinaryEncoding = decoder.ReadBoolean("UseBinaryEncoding");
		MaxStringLength = decoder.ReadInt32("MaxStringLength");
		MaxByteStringLength = decoder.ReadInt32("MaxByteStringLength");
		MaxArrayLength = decoder.ReadInt32("MaxArrayLength");
		MaxMessageSize = decoder.ReadInt32("MaxMessageSize");
		MaxBufferSize = decoder.ReadInt32("MaxBufferSize");
		ChannelLifetime = decoder.ReadInt32("ChannelLifetime");
		SecurityTokenLifetime = decoder.ReadInt32("SecurityTokenLifetime");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EndpointConfiguration endpointConfiguration))
		{
			return false;
		}
		if (!Utils.IsEqual(m_operationTimeout, endpointConfiguration.m_operationTimeout))
		{
			return false;
		}
		if (!Utils.IsEqual(m_useBinaryEncoding, endpointConfiguration.m_useBinaryEncoding))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxStringLength, endpointConfiguration.m_maxStringLength))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxByteStringLength, endpointConfiguration.m_maxByteStringLength))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxArrayLength, endpointConfiguration.m_maxArrayLength))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxMessageSize, endpointConfiguration.m_maxMessageSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxBufferSize, endpointConfiguration.m_maxBufferSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_channelLifetime, endpointConfiguration.m_channelLifetime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityTokenLifetime, endpointConfiguration.m_securityTokenLifetime))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EndpointConfiguration)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointConfiguration obj = (EndpointConfiguration)base.MemberwiseClone();
		obj.m_operationTimeout = (int)Utils.Clone(m_operationTimeout);
		obj.m_useBinaryEncoding = (bool)Utils.Clone(m_useBinaryEncoding);
		obj.m_maxStringLength = (int)Utils.Clone(m_maxStringLength);
		obj.m_maxByteStringLength = (int)Utils.Clone(m_maxByteStringLength);
		obj.m_maxArrayLength = (int)Utils.Clone(m_maxArrayLength);
		obj.m_maxMessageSize = (int)Utils.Clone(m_maxMessageSize);
		obj.m_maxBufferSize = (int)Utils.Clone(m_maxBufferSize);
		obj.m_channelLifetime = (int)Utils.Clone(m_channelLifetime);
		obj.m_securityTokenLifetime = (int)Utils.Clone(m_securityTokenLifetime);
		return obj;
	}
}
