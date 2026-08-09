using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServerOnNetwork : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_recordId;

	private string m_serverName;

	private string m_discoveryUrl;

	private StringCollection m_serverCapabilities;

	[DataMember(Name = "RecordId", IsRequired = false, Order = 1)]
	public uint RecordId
	{
		get
		{
			return m_recordId;
		}
		set
		{
			m_recordId = value;
		}
	}

	[DataMember(Name = "ServerName", IsRequired = false, Order = 2)]
	public string ServerName
	{
		get
		{
			return m_serverName;
		}
		set
		{
			m_serverName = value;
		}
	}

	[DataMember(Name = "DiscoveryUrl", IsRequired = false, Order = 3)]
	public string DiscoveryUrl
	{
		get
		{
			return m_discoveryUrl;
		}
		set
		{
			m_discoveryUrl = value;
		}
	}

	[DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 4)]
	public StringCollection ServerCapabilities
	{
		get
		{
			return m_serverCapabilities;
		}
		set
		{
			m_serverCapabilities = value;
			if (value == null)
			{
				m_serverCapabilities = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ServerOnNetwork;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ServerOnNetwork_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ServerOnNetwork_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ServerOnNetwork_Encoding_DefaultJson;

	public ServerOnNetwork()
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
		m_recordId = 0u;
		m_serverName = null;
		m_discoveryUrl = null;
		m_serverCapabilities = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("RecordId", RecordId);
		encoder.WriteString("ServerName", ServerName);
		encoder.WriteString("DiscoveryUrl", DiscoveryUrl);
		encoder.WriteStringArray("ServerCapabilities", ServerCapabilities);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RecordId = decoder.ReadUInt32("RecordId");
		ServerName = decoder.ReadString("ServerName");
		DiscoveryUrl = decoder.ReadString("DiscoveryUrl");
		ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ServerOnNetwork serverOnNetwork))
		{
			return false;
		}
		if (!Utils.IsEqual(m_recordId, serverOnNetwork.m_recordId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverName, serverOnNetwork.m_serverName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryUrl, serverOnNetwork.m_discoveryUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCapabilities, serverOnNetwork.m_serverCapabilities))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ServerOnNetwork)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ServerOnNetwork obj = (ServerOnNetwork)base.MemberwiseClone();
		obj.m_recordId = (uint)Utils.Clone(m_recordId);
		obj.m_serverName = (string)Utils.Clone(m_serverName);
		obj.m_discoveryUrl = (string)Utils.Clone(m_discoveryUrl);
		obj.m_serverCapabilities = (StringCollection)Utils.Clone(m_serverCapabilities);
		return obj;
	}
}
