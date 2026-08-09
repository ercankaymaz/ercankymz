using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class VariableNode : InstanceNode, IVariable, IVariableBase, ILocalNode, INode
{
	private Variant m_value;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private byte m_accessLevel;

	private byte m_userAccessLevel;

	private double m_minimumSamplingInterval;

	private bool m_historizing;

	private uint m_accessLevelEx;

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

	[DataMember(Name = "AccessLevelEx", IsRequired = false, Order = 9)]
	public uint AccessLevelEx
	{
		get
		{
			return m_accessLevelEx;
		}
		set
		{
			m_accessLevelEx = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.VariableNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.VariableNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.VariableNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.VariableNode_Encoding_DefaultJson;

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

	public VariableNode()
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
		m_accessLevelEx = 0u;
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
		encoder.WriteUInt32("AccessLevelEx", AccessLevelEx);
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
		AccessLevelEx = decoder.ReadUInt32("AccessLevelEx");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is VariableNode variableNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, variableNode.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, variableNode.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, variableNode.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, variableNode.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_accessLevel, variableNode.m_accessLevel))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userAccessLevel, variableNode.m_userAccessLevel))
		{
			return false;
		}
		if (!Utils.IsEqual(m_minimumSamplingInterval, variableNode.m_minimumSamplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historizing, variableNode.m_historizing))
		{
			return false;
		}
		if (!Utils.IsEqual(m_accessLevelEx, variableNode.m_accessLevelEx))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (VariableNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VariableNode obj = (VariableNode)base.MemberwiseClone();
		obj.m_value = (Variant)Utils.Clone(m_value);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_accessLevel = (byte)Utils.Clone(m_accessLevel);
		obj.m_userAccessLevel = (byte)Utils.Clone(m_userAccessLevel);
		obj.m_minimumSamplingInterval = (double)Utils.Clone(m_minimumSamplingInterval);
		obj.m_historizing = (bool)Utils.Clone(m_historizing);
		obj.m_accessLevelEx = (uint)Utils.Clone(m_accessLevelEx);
		return obj;
	}

	public VariableNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.Variable;
		if (source is IVariable variable)
		{
			DataType = variable.DataType;
			ValueRank = variable.ValueRank;
			AccessLevel = variable.AccessLevel;
			UserAccessLevel = variable.UserAccessLevel;
			MinimumSamplingInterval = variable.MinimumSamplingInterval;
			Historizing = variable.Historizing;
			object obj = variable.Value;
			if (obj == null)
			{
				obj = TypeInfo.GetDefaultValue(variable.DataType, variable.ValueRank);
			}
			Value = new Variant(obj);
			if (variable.ArrayDimensions != null)
			{
				ArrayDimensions = new UInt32Collection(variable.ArrayDimensions);
			}
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		switch (attributeId)
		{
		case 13u:
		case 14u:
		case 15u:
		case 17u:
		case 18u:
		case 19u:
		case 20u:
		case 27u:
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
		case 17u:
			return m_accessLevel;
		case 18u:
			return m_userAccessLevel;
		case 19u:
			return m_minimumSamplingInterval;
		case 20u:
			return m_historizing;
		case 27u:
			return m_accessLevelEx;
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
		case 17u:
			m_accessLevel = (byte)value;
			return ServiceResult.Good;
		case 18u:
			m_userAccessLevel = (byte)value;
			return ServiceResult.Good;
		case 27u:
			m_accessLevelEx = (uint)value;
			return ServiceResult.Good;
		case 19u:
			m_minimumSamplingInterval = (int)value;
			return ServiceResult.Good;
		case 20u:
			m_historizing = (bool)value;
			return ServiceResult.Good;
		case 13u:
			m_value.Value = Utils.Clone(value);
			return ServiceResult.Good;
		case 14u:
		{
			NodeId nodeId = (NodeId)value;
			if (nodeId != m_dataType)
			{
				m_value.Value = TypeInfo.GetDefaultValue(nodeId, m_valueRank);
			}
			m_dataType = nodeId;
			return ServiceResult.Good;
		}
		case 15u:
		{
			int num = (int)value;
			if (num != m_valueRank)
			{
				m_value.Value = TypeInfo.GetDefaultValue(m_dataType, num);
			}
			m_valueRank = num;
			return ServiceResult.Good;
		}
		case 16u:
			m_arrayDimensions = new UInt32Collection((uint[])value);
			if (m_arrayDimensions.Count > 0 && m_arrayDimensions.Count != m_valueRank)
			{
				m_valueRank = m_arrayDimensions.Count;
				m_value.Value = TypeInfo.GetDefaultValue(m_dataType, m_valueRank);
			}
			return ServiceResult.Good;
		default:
			return base.Write(attributeId, value);
		}
	}
}
