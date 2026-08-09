using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataTypeNode : TypeNode, IDataType, ILocalNode, INode
{
	private bool m_isAbstract;

	private ExtensionObject m_dataTypeDefinition;

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

	[DataMember(Name = "DataTypeDefinition", IsRequired = false, Order = 2)]
	public ExtensionObject DataTypeDefinition
	{
		get
		{
			return m_dataTypeDefinition;
		}
		set
		{
			m_dataTypeDefinition = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DataTypeNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DataTypeNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DataTypeNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DataTypeNode_Encoding_DefaultJson;

	public DataTypeNode()
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
		m_dataTypeDefinition = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("IsAbstract", IsAbstract);
		encoder.WriteExtensionObject("DataTypeDefinition", DataTypeDefinition);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		IsAbstract = decoder.ReadBoolean("IsAbstract");
		DataTypeDefinition = decoder.ReadExtensionObject("DataTypeDefinition");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataTypeNode dataTypeNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, dataTypeNode.m_isAbstract))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataTypeDefinition, dataTypeNode.m_dataTypeDefinition))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DataTypeNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeNode obj = (DataTypeNode)base.MemberwiseClone();
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		obj.m_dataTypeDefinition = (ExtensionObject)Utils.Clone(m_dataTypeDefinition);
		return obj;
	}

	public DataTypeNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.DataType;
		if (source is IDataType dataType)
		{
			IsAbstract = dataType.IsAbstract;
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		if (attributeId == 8 || attributeId == 23)
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
			23u => m_dataTypeDefinition, 
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
		case 23u:
			m_dataTypeDefinition = (ExtensionObject)value;
			return ServiceResult.Good;
		default:
			return base.Write(attributeId, value);
		}
	}
}
