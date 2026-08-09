using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ObjectTypeNode : TypeNode, IObjectType, ILocalNode, INode
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

	public override ExpandedNodeId TypeId => DataTypeIds.ObjectTypeNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ObjectTypeNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ObjectTypeNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ObjectTypeNode_Encoding_DefaultJson;

	public ObjectTypeNode()
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
		if (!(encodeable is ObjectTypeNode objectTypeNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, objectTypeNode.m_isAbstract))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ObjectTypeNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ObjectTypeNode obj = (ObjectTypeNode)base.MemberwiseClone();
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		return obj;
	}

	public ObjectTypeNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.ObjectType;
		if (source is IObjectType objectType)
		{
			IsAbstract = objectType.IsAbstract;
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		if (attributeId == 8)
		{
			return true;
		}
		return base.SupportsAttribute(attributeId);
	}

	protected override object Read(uint attributeId)
	{
		if (attributeId == 8)
		{
			return m_isAbstract;
		}
		return base.Read(attributeId);
	}

	protected override ServiceResult Write(uint attributeId, object value)
	{
		if (attributeId == 8)
		{
			m_isAbstract = (bool)value;
			return ServiceResult.Good;
		}
		return base.Write(attributeId, value);
	}
}
