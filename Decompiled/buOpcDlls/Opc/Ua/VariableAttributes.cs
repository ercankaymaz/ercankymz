using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class VariableAttributes : NodeAttributes
{
	private Variant m_value;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private byte m_accessLevel;

	private byte m_userAccessLevel;

	private double m_minimumSamplingInterval;

	private bool m_historizing;

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

	[DataMember(Name = "AccessLevel", IsRequired = false, Order = 5)]
	public byte AccessLevel
	{
		get
		{
			return m_accessLevel;
		}
		set
		{
			m_accessLevel = value;
		}
	}

	[DataMember(Name = "UserAccessLevel", IsRequired = false, Order = 6)]
	public byte UserAccessLevel
	{
		get
		{
			return m_userAccessLevel;
		}
		set
		{
			m_userAccessLevel = value;
		}
	}

	[DataMember(Name = "MinimumSamplingInterval", IsRequired = false, Order = 7)]
	public double MinimumSamplingInterval
	{
		get
		{
			return m_minimumSamplingInterval;
		}
		set
		{
			m_minimumSamplingInterval = value;
		}
	}

	[DataMember(Name = "Historizing", IsRequired = false, Order = 8)]
	public bool Historizing
	{
		get
		{
			return m_historizing;
		}
		set
		{
			m_historizing = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.VariableAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.VariableAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.VariableAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.VariableAttributes_Encoding_DefaultJson;

	public VariableAttributes()
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
		m_accessLevel = 0;
		m_userAccessLevel = 0;
		m_minimumSamplingInterval = 0.0;
		m_historizing = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteVariant("Value", Value);
		encoder.WriteNodeId("DataType", DataType);
		encoder.WriteInt32("ValueRank", ValueRank);
		encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
		encoder.WriteByte("AccessLevel", AccessLevel);
		encoder.WriteByte("UserAccessLevel", UserAccessLevel);
		encoder.WriteDouble("MinimumSamplingInterval", MinimumSamplingInterval);
		encoder.WriteBoolean("Historizing", Historizing);
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
		AccessLevel = decoder.ReadByte("AccessLevel");
		UserAccessLevel = decoder.ReadByte("UserAccessLevel");
		MinimumSamplingInterval = decoder.ReadDouble("MinimumSamplingInterval");
		Historizing = decoder.ReadBoolean("Historizing");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is VariableAttributes variableAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, variableAttributes.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, variableAttributes.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, variableAttributes.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, variableAttributes.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_accessLevel, variableAttributes.m_accessLevel))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userAccessLevel, variableAttributes.m_userAccessLevel))
		{
			return false;
		}
		if (!Utils.IsEqual(m_minimumSamplingInterval, variableAttributes.m_minimumSamplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historizing, variableAttributes.m_historizing))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (VariableAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VariableAttributes obj = (VariableAttributes)base.MemberwiseClone();
		obj.m_value = (Variant)Utils.Clone(m_value);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_accessLevel = (byte)Utils.Clone(m_accessLevel);
		obj.m_userAccessLevel = (byte)Utils.Clone(m_userAccessLevel);
		obj.m_minimumSamplingInterval = (double)Utils.Clone(m_minimumSamplingInterval);
		obj.m_historizing = (bool)Utils.Clone(m_historizing);
		return obj;
	}

	public VariableAttributes(object value, byte accessLevel)
	{
		Initialize();
		Value = new Variant(value);
		AccessLevel = accessLevel;
		UserAccessLevel = accessLevel;
		MinimumSamplingInterval = -1.0;
		Historizing = false;
		if (value == null)
		{
			DataType = 24u;
			ValueRank = -2;
		}
		else
		{
			DataType = TypeInfo.GetDataTypeId(value);
			ValueRank = TypeInfo.GetValueRank(value);
		}
	}
}
