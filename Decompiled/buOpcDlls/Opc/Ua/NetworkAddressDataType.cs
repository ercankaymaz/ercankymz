using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NetworkAddressDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_networkInterface;

	[DataMember(Name = "NetworkInterface", IsRequired = false, Order = 1)]
	public string NetworkInterface
	{
		get
		{
			return m_networkInterface;
		}
		set
		{
			m_networkInterface = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NetworkAddressDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NetworkAddressDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NetworkAddressDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NetworkAddressDataType_Encoding_DefaultJson;

	public NetworkAddressDataType()
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
		m_networkInterface = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("NetworkInterface", NetworkInterface);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NetworkInterface = decoder.ReadString("NetworkInterface");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NetworkAddressDataType networkAddressDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkInterface, networkAddressDataType.m_networkInterface))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NetworkAddressDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkAddressDataType obj = (NetworkAddressDataType)base.MemberwiseClone();
		obj.m_networkInterface = (string)Utils.Clone(m_networkInterface);
		return obj;
	}
}
