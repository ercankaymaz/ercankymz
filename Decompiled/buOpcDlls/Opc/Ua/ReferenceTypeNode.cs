using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReferenceTypeNode : TypeNode, IReferenceType, ILocalNode, INode
{
	private bool m_isAbstract;

	private bool m_symmetric;

	private LocalizedText m_inverseName;

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

	[DataMember(Name = "Symmetric", IsRequired = false, Order = 2)]
	public bool Symmetric
	{
		get
		{
			return m_symmetric;
		}
		set
		{
			m_symmetric = value;
		}
	}

	[DataMember(Name = "InverseName", IsRequired = false, Order = 3)]
	public LocalizedText InverseName
	{
		get
		{
			return m_inverseName;
		}
		set
		{
			m_inverseName = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ReferenceTypeNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReferenceTypeNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReferenceTypeNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReferenceTypeNode_Encoding_DefaultJson;

	public ReferenceTypeNode()
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
		m_symmetric = true;
		m_inverseName = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("IsAbstract", IsAbstract);
		encoder.WriteBoolean("Symmetric", Symmetric);
		encoder.WriteLocalizedText("InverseName", InverseName);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		IsAbstract = decoder.ReadBoolean("IsAbstract");
		Symmetric = decoder.ReadBoolean("Symmetric");
		InverseName = decoder.ReadLocalizedText("InverseName");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReferenceTypeNode referenceTypeNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, referenceTypeNode.m_isAbstract))
		{
			return false;
		}
		if (!Utils.IsEqual(m_symmetric, referenceTypeNode.m_symmetric))
		{
			return false;
		}
		if (!Utils.IsEqual(m_inverseName, referenceTypeNode.m_inverseName))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReferenceTypeNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceTypeNode obj = (ReferenceTypeNode)base.MemberwiseClone();
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		obj.m_symmetric = (bool)Utils.Clone(m_symmetric);
		obj.m_inverseName = (LocalizedText)Utils.Clone(m_inverseName);
		return obj;
	}

	public ReferenceTypeNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.ReferenceType;
		if (source is IReferenceType referenceType)
		{
			IsAbstract = referenceType.IsAbstract;
			InverseName = referenceType.InverseName;
			Symmetric = referenceType.Symmetric;
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		if (attributeId - 8 <= 2)
		{
			return true;
		}
		return base.SupportsAttribute(attributeId);
	}

	protected override object Read(uint attributeId)
	{
		return attributeId switch
		{
			8u => m_isAbstract, 
			10u => m_inverseName, 
			9u => m_symmetric, 
			_ => base.Read(attributeId), 
		};
	}

	protected override ServiceResult Write(uint attributeId, object value)
	{
		switch (attributeId)
		{
		case 8u:
			m_isAbstract = (bool)value;
			return ServiceResult.Good;
		case 10u:
			m_inverseName = (LocalizedText)value;
			return ServiceResult.Good;
		case 9u:
			m_symmetric = (bool)value;
			return ServiceResult.Good;
		default:
			return base.Write(attributeId, value);
		}
	}
}
