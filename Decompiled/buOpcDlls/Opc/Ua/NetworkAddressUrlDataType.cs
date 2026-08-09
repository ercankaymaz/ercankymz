using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NetworkAddressUrlDataType : NetworkAddressDataType
{
	private string m_url;

	[DataMember(Name = "Url", IsRequired = false, Order = 1)]
	public string Url
	{
		get
		{
			return m_url;
		}
		set
		{
			m_url = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.NetworkAddressUrlDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultJson;

	public NetworkAddressUrlDataType()
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
		m_url = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Url", Url);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Url = decoder.ReadString("Url");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NetworkAddressUrlDataType networkAddressUrlDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_url, networkAddressUrlDataType.m_url))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (NetworkAddressUrlDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkAddressUrlDataType obj = (NetworkAddressUrlDataType)base.MemberwiseClone();
		obj.m_url = (string)Utils.Clone(m_url);
		return obj;
	}
}
