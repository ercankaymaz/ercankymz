using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RedundantServerDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_serverId;

	private byte m_serviceLevel;

	private ServerState m_serverState;

	[DataMember(Name = "ServerId", IsRequired = false, Order = 1)]
	public string ServerId
	{
		get
		{
			return m_serverId;
		}
		set
		{
			m_serverId = value;
		}
	}

	[DataMember(Name = "ServiceLevel", IsRequired = false, Order = 2)]
	public byte ServiceLevel
	{
		get
		{
			return m_serviceLevel;
		}
		set
		{
			m_serviceLevel = value;
		}
	}

	[DataMember(Name = "ServerState", IsRequired = false, Order = 3)]
	public ServerState ServerState
	{
		get
		{
			return m_serverState;
		}
		set
		{
			m_serverState = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RedundantServerDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RedundantServerDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RedundantServerDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RedundantServerDataType_Encoding_DefaultJson;

	public RedundantServerDataType()
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
		m_serverId = null;
		m_serviceLevel = 0;
		m_serverState = ServerState.Running;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ServerId", ServerId);
		encoder.WriteByte("ServiceLevel", ServiceLevel);
		encoder.WriteEnumerated("ServerState", ServerState);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ServerId = decoder.ReadString("ServerId");
		ServiceLevel = decoder.ReadByte("ServiceLevel");
		ServerState = (ServerState)(object)decoder.ReadEnumerated("ServerState", typeof(ServerState));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RedundantServerDataType redundantServerDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverId, redundantServerDataType.m_serverId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serviceLevel, redundantServerDataType.m_serviceLevel))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverState, redundantServerDataType.m_serverState))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RedundantServerDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RedundantServerDataType obj = (RedundantServerDataType)base.MemberwiseClone();
		obj.m_serverId = (string)Utils.Clone(m_serverId);
		obj.m_serviceLevel = (byte)Utils.Clone(m_serviceLevel);
		obj.m_serverState = (ServerState)Utils.Clone(m_serverState);
		return obj;
	}
}
