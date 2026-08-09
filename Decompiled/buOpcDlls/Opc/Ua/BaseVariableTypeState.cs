using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public abstract class BaseVariableTypeState : BaseTypeState
{
	public NodeValueSimpleEventHandler OnSimpleReadValue;

	public NodeValueSimpleEventHandler OnSimpleWriteValue;

	public NodeAttributeEventHandler<NodeId> OnReadDataType;

	public NodeAttributeEventHandler<NodeId> OnWriteDataType;

	public NodeAttributeEventHandler<int> OnReadValueRank;

	public NodeAttributeEventHandler<int> OnWriteValueRank;

	public NodeAttributeEventHandler<IList<uint>> OnReadArrayDimensions;

	public NodeAttributeEventHandler<IList<uint>> OnWriteArrayDimensions;

	private object m_value;

	private NodeId m_dataType;

	private int m_valueRank;

	private ReadOnlyList<uint> m_arrayDimensions;

	public object Value
	{
		get
		{
			return m_value;
		}
		set
		{
			if (m_value != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Value;
			}
			m_value = value;
		}
	}

	public Variant WrappedValue
	{
		get
		{
			return new Variant(m_value);
		}
		set
		{
			Value = ExtractValueFromVariant(null, value.Value, throwOnError: false);
		}
	}

	public NodeId DataType
	{
		get
		{
			return m_dataType;
		}
		set
		{
			if ((object)m_dataType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_dataType = value;
		}
	}

	public int ValueRank
	{
		get
		{
			return m_valueRank;
		}
		set
		{
			if (m_valueRank != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_valueRank = value;
		}
	}

	public ReadOnlyList<uint> ArrayDimensions
	{
		get
		{
			return m_arrayDimensions;
		}
		set
		{
			if (m_arrayDimensions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_arrayDimensions = value;
		}
	}

	protected BaseVariableTypeState()
		: base(NodeClass.VariableType)
	{
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is BaseVariableTypeState baseVariableTypeState)
		{
			m_value = Utils.Clone(baseVariableTypeState.m_value);
			m_dataType = baseVariableTypeState.m_dataType;
			m_valueRank = baseVariableTypeState.m_valueRank;
			m_arrayDimensions = null;
			if (baseVariableTypeState.m_arrayDimensions != null)
			{
				m_arrayDimensions = new ReadOnlyList<uint>(baseVariableTypeState.m_arrayDimensions, makeCopy: true);
			}
		}
		m_value = ExtractValueFromVariant(context, m_value, throwOnError: false);
		base.Initialize(context, source);
	}

	protected virtual object ExtractValueFromVariant(ISystemContext context, object value, bool throwOnError)
	{
		return value;
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseTypeState clone = (BaseTypeState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (node is VariableTypeNode variableTypeNode)
		{
			variableTypeNode.Value = new Variant(Utils.Clone(Value));
			variableTypeNode.DataType = DataType;
			variableTypeNode.ValueRank = ValueRank;
			variableTypeNode.ArrayDimensions = null;
			if (ArrayDimensions != null)
			{
				variableTypeNode.ArrayDimensions = new UInt32Collection(ArrayDimensions);
			}
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (m_value != null)
		{
			encoder.WriteVariant("Value", WrappedValue);
		}
		if (!NodeId.IsNull(DataType))
		{
			encoder.WriteNodeId("DataType", DataType);
		}
		if (ValueRank != -2)
		{
			encoder.WriteInt32("ValueRank", ValueRank);
		}
		if (ArrayDimensions != null)
		{
			encoder.WriteString("ArrayDimensions", BaseVariableState.ArrayDimensionsToXml(ArrayDimensions));
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("Value"))
		{
			WrappedValue = decoder.ReadVariant("Value");
		}
		if (decoder.Peek("DataType"))
		{
			DataType = decoder.ReadNodeId("DataType");
		}
		if (decoder.Peek("ValueRank"))
		{
			ValueRank = decoder.ReadInt32("ValueRank");
		}
		if (decoder.Peek("ArrayDimensions"))
		{
			ArrayDimensions = BaseVariableState.ArrayDimensionsFromXml(decoder.ReadString("ArrayDimensions"));
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (WrappedValue != Variant.Null)
		{
			attributesToSave |= AttributesToSave.Value;
		}
		if (!NodeId.IsNull(m_dataType))
		{
			attributesToSave |= AttributesToSave.DataType;
		}
		if (m_valueRank != -2)
		{
			attributesToSave |= AttributesToSave.ValueRank;
		}
		if (m_arrayDimensions != null)
		{
			attributesToSave |= AttributesToSave.ArrayDimensions;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.Value) != AttributesToSave.None)
		{
			encoder.WriteVariant(null, WrappedValue);
		}
		if ((attributesToSave & AttributesToSave.DataType) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_dataType);
		}
		if ((attributesToSave & AttributesToSave.ValueRank) != AttributesToSave.None)
		{
			encoder.WriteInt32(null, m_valueRank);
		}
		if ((attributesToSave & AttributesToSave.ArrayDimensions) != AttributesToSave.None)
		{
			encoder.WriteUInt32Array(null, m_arrayDimensions);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attibutesToLoad)
	{
		base.Update(context, decoder, attibutesToLoad);
		if ((attibutesToLoad & AttributesToSave.Value) != AttributesToSave.None)
		{
			WrappedValue = decoder.ReadVariant(null);
		}
		if ((attibutesToLoad & AttributesToSave.DataType) != AttributesToSave.None)
		{
			m_dataType = decoder.ReadNodeId(null);
		}
		if ((attibutesToLoad & AttributesToSave.ValueRank) != AttributesToSave.None)
		{
			m_valueRank = decoder.ReadInt32(null);
		}
		if ((attibutesToLoad & AttributesToSave.ArrayDimensions) != AttributesToSave.None)
		{
			UInt32Collection uInt32Collection = decoder.ReadUInt32Array(null);
			if (uInt32Collection != null && uInt32Collection.Count > 0)
			{
				m_arrayDimensions = new ReadOnlyList<uint>(uInt32Collection);
			}
			else
			{
				m_arrayDimensions = null;
			}
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 14u:
		{
			NodeId value4 = m_dataType;
			if (OnReadDataType != null)
			{
				serviceResult = OnReadDataType(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value4;
			}
			return serviceResult;
		}
		case 15u:
		{
			int value3 = m_valueRank;
			if (OnReadValueRank != null)
			{
				serviceResult = OnReadValueRank(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value3;
			}
			return serviceResult;
		}
		case 16u:
		{
			IList<uint> value2 = m_arrayDimensions;
			if (OnReadArrayDimensions != null)
			{
				serviceResult = OnReadArrayDimensions(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value2;
			}
			return serviceResult;
		}
		default:
			return base.ReadNonValueAttribute(context, attributeId, ref value);
		}
	}

	protected override ServiceResult ReadValueAttribute(ISystemContext context, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref DateTime sourceTimestamp)
	{
		value = m_value;
		ServiceResult good = ServiceResult.Good;
		VariableCopyPolicy variableCopyPolicy = VariableCopyPolicy.CopyOnRead;
		if (OnSimpleReadValue != null)
		{
			good = OnSimpleReadValue(context, this, ref value);
			if (ServiceResult.IsBad(good))
			{
				return good;
			}
			variableCopyPolicy = VariableCopyPolicy.Never;
		}
		else if (value == null)
		{
			return 2150957056u;
		}
		good = BaseVariableState.ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
		if (ServiceResult.IsBad(good))
		{
			return good;
		}
		if (variableCopyPolicy == VariableCopyPolicy.CopyOnRead)
		{
			value = Utils.Clone(value);
		}
		return good;
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 14u:
		{
			NodeId value4 = value as NodeId;
			if (value4 == null)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.DataType) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteDataType != null)
			{
				serviceResult = OnWriteDataType(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				DataType = value4;
			}
			return serviceResult;
		}
		case 15u:
		{
			int? num = value as int?;
			if (!num.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.ValueRank) == 0)
			{
				return 2151350272u;
			}
			int value3 = num.Value;
			if (OnWriteValueRank != null)
			{
				serviceResult = OnWriteValueRank(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				ValueRank = value3;
			}
			return serviceResult;
		}
		case 16u:
		{
			IList<uint> value2 = value as IList<uint>;
			if ((base.WriteMask & AttributeWriteMask.ArrayDimensions) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteArrayDimensions != null)
			{
				serviceResult = OnWriteArrayDimensions(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				if (value2 != null)
				{
					m_arrayDimensions = new ReadOnlyList<uint>(value2);
				}
				else
				{
					ArrayDimensions = null;
				}
			}
			return serviceResult;
		}
		default:
			return base.WriteNonValueAttribute(context, attributeId, value);
		}
	}

	protected override ServiceResult WriteValueAttribute(ISystemContext context, NumericRange indexRange, object value, StatusCode statusCode, DateTime sourceTimestamp)
	{
		ServiceResult serviceResult = null;
		if ((base.WriteMask & AttributeWriteMask.ValueForVariableType) == 0)
		{
			return 2151350272u;
		}
		if (sourceTimestamp == DateTime.MinValue)
		{
			sourceTimestamp = DateTime.UtcNow;
		}
		if (indexRange != NumericRange.Empty)
		{
			return 2151022592u;
		}
		TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(value, m_dataType, m_valueRank, context.NamespaceUris, context.TypeTable);
		if (typeInfo == null || typeInfo == TypeInfo.Unknown)
		{
			return 2155085824u;
		}
		if (OnSimpleWriteValue != null)
		{
			serviceResult = OnSimpleWriteValue(context, this, ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
		}
		Value = value;
		return ServiceResult.Good;
	}
}
