using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class VariableTypeNode : TypeNode, IVariableType, IVariableBase, ILocalNode, INode
{
	private Variant m_value;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private bool m_isAbstract;

	[DataMember(Name = "Value", IsRequired = false, Order = 1)]
	public Variant Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	[DataMember(Name = "DataType", IsRequired = false, Order = 2)]
	public NodeId DataType
	{
		get
		{
			return m_dataType;
		}
		set
		{
			m_dataType = value;
		}
	}

	[DataMember(Name = "ValueRank", IsRequired = false, Order = 3)]
	public int ValueRank
	{
		get
		{
			return m_valueRank;
		}
		set
		{
			m_valueRank = value;
		}
	}

	[DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 4)]
	public UInt32Collection ArrayDimensions
	{
		get
		{
			return m_arrayDimensions;
		}
		set
		{
			m_arrayDimensions = value;
			if (value == null)
			{
				m_arrayDimensions = new UInt32Collection();
			}
		}
	}

	[DataMember(Name = "IsAbstract", IsRequired = false, Order = 5)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.VariableTypeNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.VariableTypeNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.VariableTypeNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.VariableTypeNode_Encoding_DefaultJson;

	object IVariableBase.Value
	{
		get
		{
			return m_value.Value;
		}
		set
		{
			m_value.Value = value;
		}
	}

	IList<uint> IVariableBase.ArrayDimensions
	{
		get
		{
			return m_arrayDimensions;
		}
		set
		{
			if (value == null)
			{
				m_arrayDimensions = new UInt32Collection();
			}
			else
			{
				m_arrayDimensions = new UInt32Collection(value);
			}
		}
	}

	public VariableTypeNode()
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
		m_value = Variant.Null;
		m_dataType = null;
		m_valueRank = 0;
		m_arrayDimensions = new UInt32Collection();
		m_isAbstract = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteVariant("Value", Value);
		encoder.WriteNodeId("DataType", DataType);
		encoder.WriteInt32("ValueRank", ValueRank);
		encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
		encoder.WriteBoolean("IsAbstract", IsAbstract);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Value = decoder.ReadVariant("Value");
		DataType = decoder.ReadNodeId("DataType");
		ValueRank = decoder.ReadInt32("ValueRank");
		ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
		IsAbstract = decoder.ReadBoolean("IsAbstract");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is VariableTypeNode variableTypeNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, variableTypeNode.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, variableTypeNode.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, variableTypeNode.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, variableTypeNode.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, variableTypeNode.m_isAbstract))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (VariableTypeNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VariableTypeNode obj = (VariableTypeNode)base.MemberwiseClone();
		obj.m_value = (Variant)Utils.Clone(m_value);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		return obj;
	}

	public VariableTypeNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.VariableType;
		if (source is IVariableType variableType)
		{
			IsAbstract = variableType.IsAbstract;
			Value = new Variant(variableType.Value);
			DataType = variableType.DataType;
			ValueRank = variableType.ValueRank;
			if (variableType.ArrayDimensions != null)
			{
				ArrayDimensions = new UInt32Collection(variableType.ArrayDimensions);
			}
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		switch (attributeId)
		{
		case 13u:
			return m_value.Value != null;
		case 8u:
		case 14u:
		case 15u:
			return true;
		case 16u:
			if (m_arrayDimensions == null || m_arrayDimensions.Count == 0)
			{
				return false;
			}
			return true;
		default:
			return base.SupportsAttribute(attributeId);
		}
	}

	protected override object Read(uint attributeId)
	{
		switch (attributeId)
		{
		case 14u:
			return m_dataType;
		case 15u:
			return m_valueRank;
		case 13u:
			return m_value.Value;
		case 16u:
			if (m_arrayDimensions == null || m_arrayDimensions.Count == 0)
			{
				return 2150957056u;
			}
			return m_arrayDimensions.ToArray();
		default:
			return base.Read(attributeId);
		}
	}

	protected override ServiceResult Write(uint attributeId, object value)
	{
		switch (attributeId)
		{
		case 13u:
			m_value.Value = Utils.Clone(value);
			return ServiceResult.Good;
		case 14u:
		{
			NodeId nodeId = (NodeId)value;
			if (nodeId != m_dataType)
			{
				m_value.Value = null;
			}
			m_dataType = nodeId;
			return ServiceResult.Good;
		}
		case 15u:
		{
			int num = (int)value;
			if (num != m_valueRank)
			{
				m_value.Value = null;
			}
			m_valueRank = num;
			return ServiceResult.Good;
		}
		case 16u:
			m_arrayDimensions = new UInt32Collection((uint[])value);
			if (m_arrayDimensions.Count > 0 && m_valueRank != m_arrayDimensions.Count)
			{
				m_valueRank = m_arrayDimensions.Count;
				m_value.Value = null;
			}
			return ServiceResult.Good;
		default:
			return base.Write(attributeId, value);
		}
	}
}
