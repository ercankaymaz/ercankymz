using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ObjectTypeAttributes : NodeAttributes
{
	private bool m_isAbstract;

	[DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
	public bool IsAbstract
	{
		get
		{
			return m_isAbstract;
		}
		set
		{
			m_isAbstract = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ObjectTypeAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ObjectTypeAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ObjectTypeAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ObjectTypeAttributes_Encoding_DefaultJson;

	public ObjectTypeAttributes()
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
		m_isAbstract = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("IsAbstract", IsAbstract);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		IsAbstract = decoder.ReadBoolean("IsAbstract");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ObjectTypeAttributes objectTypeAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, objectTypeAttributes.m_isAbstract))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ObjectTypeAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ObjectTypeAttributes obj = (ObjectTypeAttributes)base.MemberwiseClone();
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		return obj;
	}
}
