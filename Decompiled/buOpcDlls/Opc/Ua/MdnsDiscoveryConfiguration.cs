using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MdnsDiscoveryConfiguration : DiscoveryConfiguration
{
	private string m_mdnsServerName;

	private StringCollection m_serverCapabilities;

	[DataMember(Name = "MdnsServerName", IsRequired = false, Order = 1)]
	public string MdnsServerName
	{
		get
		{
			return m_mdnsServerName;
		}
		set
		{
			m_mdnsServerName = value;
		}
	}

	[DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 2)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.MdnsDiscoveryConfiguration;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultJson;

	public MdnsDiscoveryConfiguration()
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
		m_mdnsServerName = null;
		m_serverCapabilities = new StringCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("MdnsServerName", MdnsServerName);
		encoder.WriteStringArray("ServerCapabilities", ServerCapabilities);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		MdnsServerName = decoder.ReadString("MdnsServerName");
		ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MdnsDiscoveryConfiguration mdnsDiscoveryConfiguration))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_mdnsServerName, mdnsDiscoveryConfiguration.m_mdnsServerName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCapabilities, mdnsDiscoveryConfiguration.m_serverCapabilities))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (MdnsDiscoveryConfiguration)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MdnsDiscoveryConfiguration obj = (MdnsDiscoveryConfiguration)base.MemberwiseClone();
		obj.m_mdnsServerName = (string)Utils.Clone(m_mdnsServerName);
		obj.m_serverCapabilities = (StringCollection)Utils.Clone(m_serverCapabilities);
		return obj;
	}
}
