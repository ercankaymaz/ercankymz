using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SimpleTypeDescription : DataTypeDescription
{
	private NodeId m_baseDataType;

	private byte m_builtInType;

	[DataMember(Name = "BaseDataType", IsRequired = false, Order = 1)]
	public NodeId BaseDataType
	{
		get
		{
			return m_baseDataType;
		}
		set
		{
			m_baseDataType = value;
		}
	}

	[DataMember(Name = "BuiltInType", IsRequired = false, Order = 2)]
	public byte BuiltInType
	{
		get
		{
			return m_builtInType;
		}
		set
		{
			m_builtInType = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.SimpleTypeDescription;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.SimpleTypeDescription_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.SimpleTypeDescription_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.SimpleTypeDescription_Encoding_DefaultJson;

	public SimpleTypeDescription()
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
		m_baseDataType = null;
		m_builtInType = 0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("BaseDataType", BaseDataType);
		encoder.WriteByte("BuiltInType", BuiltInType);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		BaseDataType = decoder.ReadNodeId("BaseDataType");
		BuiltInType = decoder.ReadByte("BuiltInType");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SimpleTypeDescription simpleTypeDescription))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_baseDataType, simpleTypeDescription.m_baseDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_builtInType, simpleTypeDescription.m_builtInType))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (SimpleTypeDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SimpleTypeDescription obj = (SimpleTypeDescription)base.MemberwiseClone();
		obj.m_baseDataType = (NodeId)Utils.Clone(m_baseDataType);
		obj.m_builtInType = (byte)Utils.Clone(m_builtInType);
		return obj;
	}
}
