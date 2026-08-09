using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DatagramConnectionTransportDataType : ConnectionTransportDataType
{
	private ExtensionObject m_discoveryAddress;

	[DataMember(Name = "DiscoveryAddress", IsRequired = false, Order = 1)]
	public ExtensionObject DiscoveryAddress
	{
		get
		{
			return m_discoveryAddress;
		}
		set
		{
			m_discoveryAddress = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DatagramConnectionTransportDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultJson;

	public DatagramConnectionTransportDataType()
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
		m_discoveryAddress = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExtensionObject("DiscoveryAddress", DiscoveryAddress);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DiscoveryAddress = decoder.ReadExtensionObject("DiscoveryAddress");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DatagramConnectionTransportDataType datagramConnectionTransportDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryAddress, datagramConnectionTransportDataType.m_discoveryAddress))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DatagramConnectionTransportDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DatagramConnectionTransportDataType obj = (DatagramConnectionTransportDataType)base.MemberwiseClone();
		obj.m_discoveryAddress = (ExtensionObject)Utils.Clone(m_discoveryAddress);
		return obj;
	}
}
