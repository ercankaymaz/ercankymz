using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class VariableTypeAttributes : NodeAttributes
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

	public override ExpandedNodeId TypeId => DataTypeIds.VariableTypeAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.VariableTypeAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.VariableTypeAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.VariableTypeAttributes_Encoding_DefaultJson;

	public VariableTypeAttributes()
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
		if (!(encodeable is VariableTypeAttributes variableTypeAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, variableTypeAttributes.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, variableTypeAttributes.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, variableTypeAttributes.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, variableTypeAttributes.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isAbstract, variableTypeAttributes.m_isAbstract))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (VariableTypeAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VariableTypeAttributes obj = (VariableTypeAttributes)base.MemberwiseClone();
		obj.m_value = (Variant)Utils.Clone(m_value);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_isAbstract = (bool)Utils.Clone(m_isAbstract);
		return obj;
	}
}
