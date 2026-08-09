using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public abstract class BaseVariableState : BaseInstanceState
{
	public NodeValueSimpleEventHandler OnSimpleReadValue;

	public NodeValueSimpleEventHandler OnSimpleWriteValue;

	public NodeValueEventHandler OnReadValue;

	public NodeValueEventHandler OnWriteValue;

	public NodeAttributeEventHandler<NodeId> OnReadDataType;

	public NodeAttributeEventHandler<NodeId> OnWriteDataType;

	public NodeAttributeEventHandler<int> OnReadValueRank;

	public NodeAttributeEventHandler<int> OnWriteValueRank;

	public NodeAttributeEventHandler<IList<uint>> OnReadArrayDimensions;

	public NodeAttributeEventHandler<IList<uint>> OnWriteArrayDimensions;

	public NodeAttributeEventHandler<byte> OnReadAccessLevel;

	public NodeAttributeEventHandler<byte> OnWriteAccessLevel;

	public NodeAttributeEventHandler<byte> OnReadUserAccessLevel;

	public NodeAttributeEventHandler<byte> OnWriteUserAccessLevel;

	public NodeAttributeEventHandler<double> OnReadMinimumSamplingInterval;

	public NodeAttributeEventHandler<double> OnWriteMinimumSamplingInterval;

	public NodeAttributeEventHandler<bool> OnReadHistorizing;

	public NodeAttributeEventHandler<bool> OnWriteHistorizing;

	public NodeAttributeEventHandler<uint> OnReadAccessLevelEx;

	public NodeAttributeEventHandler<uint> OnWriteAccessLevelEx;

	private object m_value;

	private bool m_isValueType;

	private DateTime m_timestamp;

	private bool m_valueTouched;

	private StatusCode m_statusCode;

	private NodeId m_dataType;

	private int m_valueRank;

	private ReadOnlyList<uint> m_arrayDimensions;

	private uint m_accessLevel;

	private byte m_userAccessLevel;

	private double m_minimumSamplingInterval;

	private bool m_historizing;

	private VariableCopyPolicy m_copyPolicy;

	public object Value
	{
		get
		{
			return m_value;
		}
		set
		{
			if (value == null && IsValueType)
			{
				value = ExtractValueFromVariant(null, value, throwOnError: false);
			}
			if (m_value != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Value;
			}
			if (!m_valueTouched)
			{
				StatusCode = 0u;
			}
			m_value = value;
			m_valueTouched = true;
		}
	}

	public bool IsValueType
	{
		get
		{
			return m_isValueType;
		}
		set
		{
			m_isValueType = value;
		}
	}

	[DataMember(Name = "Value", Order = 0, IsRequired = false, EmitDefaultValue = false)]
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

	public DateTime Timestamp
	{
		get
		{
			return m_timestamp;
		}
		set
		{
			if (m_timestamp != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Value;
			}
			m_timestamp = value;
		}
	}

	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			if (m_statusCode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Value;
			}
			m_statusCode = value;
		}
	}

	public VariableCopyPolicy CopyPolicy
	{
		get
		{
			return m_copyPolicy;
		}
		set
		{
			m_copyPolicy = value;
		}
	}

	[DataMember(Name = "DataType", Order = 1, IsRequired = false, EmitDefaultValue = false)]
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

	[DataMember(Name = "ValueRank", Order = 2, IsRequired = false, EmitDefaultValue = false)]
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

	[DataMember(Name = "AccessLevel", Order = 4, IsRequired = false, EmitDefaultValue = false)]
	public byte AccessLevel
	{
		get
		{
			return (byte)(m_accessLevel & 0xFF);
		}
		set
		{
			if (AccessLevel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_accessLevel = (m_accessLevel & 0xFFFFFF00u) | value;
		}
	}

	[DataMember(Name = "UserAccessLevel", Order = 5, IsRequired = false, EmitDefaultValue = false)]
	public byte UserAccessLevel
	{
		get
		{
			return m_userAccessLevel;
		}
		set
		{
			if (m_userAccessLevel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_userAccessLevel = value;
		}
	}

	[DataMember(Name = "MinimumSamplingInterval", Order = 6, IsRequired = false, EmitDefaultValue = false)]
	public double MinimumSamplingInterval
	{
		get
		{
			return m_minimumSamplingInterval;
		}
		set
		{
			if (m_minimumSamplingInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_minimumSamplingInterval = value;
		}
	}

	[DataMember(Name = "Historizing", Order = 7, IsRequired = false, EmitDefaultValue = false)]
	public bool Historizing
	{
		get
		{
			return m_historizing;
		}
		set
		{
			if (m_historizing != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_historizing = value;
		}
	}

	[DataMember(Name = "AccessLevelEx", Order = 8, IsRequired = false, EmitDefaultValue = false)]
	public uint AccessLevelEx
	{
		get
		{
			return m_accessLevel;
		}
		set
		{
			if (m_accessLevel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_accessLevel = value;
		}
	}

	public BaseVariableState(NodeState parent)
		: base(NodeClass.Variable, parent)
	{
		m_timestamp = DateTime.MinValue;
		m_accessLevel = (m_userAccessLevel = 1);
		m_copyPolicy = VariableCopyPolicy.CopyOnRead;
		m_valueTouched = false;
		m_statusCode = 2150760448u;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is BaseVariableState baseVariableState)
		{
			m_value = ExtractValueFromVariant(context, baseVariableState.m_value, throwOnError: false);
			m_timestamp = baseVariableState.m_timestamp;
			m_dataType = baseVariableState.m_dataType;
			m_valueRank = baseVariableState.m_valueRank;
			m_arrayDimensions = null;
			m_accessLevel = baseVariableState.m_accessLevel;
			m_userAccessLevel = baseVariableState.m_userAccessLevel;
			m_minimumSamplingInterval = baseVariableState.m_minimumSamplingInterval;
			m_historizing = baseVariableState.m_historizing;
			m_valueTouched = baseVariableState.m_valueTouched;
			if (baseVariableState.m_arrayDimensions != null)
			{
				m_arrayDimensions = new ReadOnlyList<uint>(baseVariableState.m_arrayDimensions, makeCopy: true);
			}
			m_value = ExtractValueFromVariant(context, m_value, throwOnError: false);
		}
		base.Initialize(context, source);
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return 62u;
	}

	protected virtual NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return 24u;
	}

	protected virtual int GetDefaultValueRank()
	{
		return -2;
	}

	[Obsolete("Should use the version that takes a ISystemContext (pass null if ISystemContext is not available).")]
	protected virtual object ExtractValueFromVariant(object value, bool throwOnError)
	{
		return ExtractValueFromVariant(null, value, throwOnError);
	}

	protected virtual object ExtractValueFromVariant(ISystemContext context, object value, bool throwOnError)
	{
		return value;
	}

	public static T GetValue<T>(BaseDataVariableState<T> variable)
	{
		if (variable == null)
		{
			return default(T);
		}
		return variable.Value;
	}

	public static T GetValue<T>(PropertyState<T> property)
	{
		if (property == null)
		{
			return default(T);
		}
		return property.Value;
	}

	[Obsolete("Should use the version that takes a ISystemContext (pass null if ISystemContext is not available).")]
	public static object ExtractValueFromVariant<T>(object value, bool throwOnError)
	{
		return ExtractValueFromVariant<T>(null, value, throwOnError);
	}

	public static object ExtractValueFromVariant<T>(ISystemContext context, object value, bool throwOnError)
	{
		if (value == null)
		{
			return default(T);
		}
		if (typeof(T).IsInstanceOfType(value))
		{
			return value;
		}
		if (value is ExtensionObject extensionObject)
		{
			if (typeof(T).IsInstanceOfType(extensionObject.Body))
			{
				return extensionObject.Body;
			}
			if (typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
			{
				return DecodeExtensionObject(context, typeof(T), extensionObject, throwOnError);
			}
			if (throwOnError)
			{
				throw ServiceResultException.Create(2155085824u, "Cannot convert {0} to {1}.", value.GetType().Name, typeof(T).Name);
			}
			return default(T);
		}
		Type elementType = typeof(T).GetElementType();
		if (elementType != null)
		{
			if (value is IList<ExtensionObject> list && typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()))
			{
				Array array = Array.CreateInstance(elementType, list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					if (ExtensionObject.IsNull(list[i]))
					{
						array.SetValue(null, i);
						continue;
					}
					if (elementType.IsInstanceOfType(list[i].Body))
					{
						array.SetValue(list[i].Body, i);
						continue;
					}
					object obj = DecodeExtensionObject(context, elementType, list[i], throwOnError);
					if (obj != null)
					{
						array.SetValue(obj, i);
					}
					else if (throwOnError)
					{
						throw ServiceResultException.Create(2155085824u, "Cannot convert ExtensionObject to {0}. Index = {1}", elementType.Name, i);
					}
				}
				return array;
			}
			if (value is IList<Variant> list2)
			{
				if (elementType != typeof(object) && throwOnError)
				{
					throw ServiceResultException.Create(2155085824u, "Cannot convert {0} to {1}.", value.GetType().Name, typeof(T).Name);
				}
				object[] array2 = new object[list2.Count];
				for (int j = 0; j < list2.Count; j++)
				{
					array2[j] = list2[j].Value;
				}
				return array2;
			}
			if (typeof(Guid).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()) && value is IList<Uuid> list3)
			{
				Guid[] array3 = new Guid[list3.Count];
				for (int k = 0; k < list3.Count; k++)
				{
					array3[k] = list3[k];
				}
				return array3;
			}
			if (typeof(Enum).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()) && value is IList<int> list4)
			{
				Array array4 = Array.CreateInstance(elementType, list4.Count);
				for (int l = 0; l < list4.Count; l++)
				{
					array4.SetValue(list4[l], l);
				}
				return array4;
			}
		}
		if (typeof(Guid).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
		{
			Uuid? uuid = value as Uuid?;
			if (uuid.HasValue)
			{
				return (Guid)uuid.Value;
			}
		}
		if (typeof(Enum).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
		{
			int? num = value as int?;
			if (num.HasValue)
			{
				return (T)(object)num.Value;
			}
		}
		if (throwOnError)
		{
			throw ServiceResultException.Create(2155085824u, "Cannot convert {0} to {1}.", value.GetType().Name, typeof(T).Name);
		}
		return default(T);
	}

	public static object DecodeExtensionObject(ISystemContext context, Type targetType, ExtensionObject extension, bool throwOnError)
	{
		if (targetType.IsInstanceOfType(extension.Body))
		{
			return extension.Body;
		}
		if (Activator.CreateInstance(targetType) is IEncodeable encodeable)
		{
			IDecoder decoder = null;
			ServiceMessageContext serviceMessageContext = ServiceMessageContext.GlobalContext;
			if (context != null)
			{
				serviceMessageContext = new ServiceMessageContext();
				serviceMessageContext.NamespaceUris = context.NamespaceUris;
				serviceMessageContext.ServerUris = context.ServerUris;
				serviceMessageContext.Factory = context.EncodeableFactory;
			}
			if (extension.Encoding == ExtensionObjectEncoding.Binary)
			{
				decoder = new BinaryDecoder(extension.Body as byte[], serviceMessageContext);
			}
			else if (extension.Encoding == ExtensionObjectEncoding.Xml)
			{
				decoder = new XmlDecoder(extension.Body as XmlElement, serviceMessageContext);
			}
			if (decoder != null)
			{
				try
				{
					encodeable.Decode(decoder);
					return encodeable;
				}
				catch (Exception ex)
				{
					if (throwOnError)
					{
						throw ServiceResultException.Create(2155085824u, "Cannot convert ExtensionObject to {0}. Error = {1}", targetType.Name, ex.Message);
					}
				}
			}
		}
		if (throwOnError)
		{
			throw ServiceResultException.Create(2155085824u, "Cannot convert ExtensionObject to {0}.", targetType.Name);
		}
		return null;
	}

	public static T CheckTypeBeforeCast<T>(object value, bool throwOnError)
	{
		if ((value == null && typeof(T).GetTypeInfo().IsValueType) || (value != null && !typeof(T).IsInstanceOfType(value)))
		{
			if (throwOnError)
			{
				throw ServiceResultException.Create(2155085824u, "Cannot convert '{0}' to a {1}.", value, typeof(T).Name);
			}
			return default(T);
		}
		return (T)value;
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseInstanceState clone = (BaseInstanceState)Activator.CreateInstance(GetType(), base.Parent);
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (!(node is VariableNode variableNode))
		{
			return;
		}
		try
		{
			variableNode.Value = new Variant(Utils.Clone(Value));
			variableNode.DataType = DataType;
			variableNode.ValueRank = ValueRank;
			variableNode.ArrayDimensions = null;
			if (ArrayDimensions != null)
			{
				variableNode.ArrayDimensions = new UInt32Collection(ArrayDimensions);
			}
			variableNode.AccessLevel = AccessLevel;
			variableNode.UserAccessLevel = UserAccessLevel;
			variableNode.MinimumSamplingInterval = MinimumSamplingInterval;
			variableNode.Historizing = Historizing;
		}
		catch (Exception ex)
		{
			Utils.LogError("Unexpected error exporting node:" + ex.Message);
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
		if (StatusCode != 0u)
		{
			encoder.WriteStatusCode("StatusCode", StatusCode);
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
			encoder.WriteString("ArrayDimensions", ArrayDimensionsToXml(ArrayDimensions));
		}
		if (AccessLevel != 0)
		{
			encoder.WriteByte("AccessLevel", AccessLevel);
		}
		if (UserAccessLevel != 0)
		{
			encoder.WriteByte("UserAccessLevel", UserAccessLevel);
		}
		if (MinimumSamplingInterval != 0.0)
		{
			encoder.WriteDouble("MinimumSamplingInterval", MinimumSamplingInterval);
		}
		if (Historizing)
		{
			encoder.WriteBoolean("Historizing", Historizing);
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
		if (decoder.Peek("Timestamp"))
		{
			Timestamp = decoder.ReadDateTime("Timestamp");
		}
		if (decoder.Peek("StatusCode"))
		{
			StatusCode = decoder.ReadStatusCode("StatusCode");
		}
		else
		{
			StatusCode = 0u;
		}
		if (decoder.Peek("DataType"))
		{
			DataType = decoder.ReadNodeId("DataType");
		}
		if (decoder.Peek("ValueRank"))
		{
			ValueRank = decoder.ReadInt32("ValueRank");
		}
		if (m_value == null && m_valueRank == -1)
		{
			bool flag = IsValueType;
			if (!flag && TypeInfo.IsValueType(DataTypes.GetBuiltInType(m_dataType, context.TypeTable)))
			{
				flag = true;
			}
			if (flag)
			{
				m_value = TypeInfo.GetDefaultValue(m_dataType, m_valueRank, context.TypeTable);
			}
		}
		if (decoder.Peek("ArrayDimensions"))
		{
			ArrayDimensions = ArrayDimensionsFromXml(decoder.ReadString("ArrayDimensions"));
		}
		if (decoder.Peek("AccessLevel"))
		{
			AccessLevel = decoder.ReadByte("AccessLevel");
		}
		if (decoder.Peek("UserAccessLevel"))
		{
			UserAccessLevel = decoder.ReadByte("UserAccessLevel");
		}
		if (decoder.Peek("MinimumSamplingInterval"))
		{
			MinimumSamplingInterval = decoder.ReadDouble("MinimumSamplingInterval");
		}
		if (decoder.Peek("Historizing"))
		{
			Historizing = decoder.ReadBoolean("Historizing");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (m_value != null)
		{
			attributesToSave |= AttributesToSave.Value;
		}
		if (m_statusCode != 0u)
		{
			attributesToSave |= AttributesToSave.StatusCode;
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
		if (m_accessLevel != 0)
		{
			attributesToSave |= AttributesToSave.AccessLevel;
		}
		if (m_userAccessLevel != 0)
		{
			attributesToSave |= AttributesToSave.UserAccessLevel;
		}
		if (m_minimumSamplingInterval != 0.0)
		{
			attributesToSave |= AttributesToSave.MinimumSamplingInterval;
		}
		if (m_historizing)
		{
			attributesToSave |= AttributesToSave.Historizing;
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
		if ((attributesToSave & AttributesToSave.StatusCode) != AttributesToSave.None)
		{
			encoder.WriteStatusCode(null, m_statusCode);
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
		if ((attributesToSave & AttributesToSave.AccessLevel) != AttributesToSave.None)
		{
			encoder.WriteByte(null, AccessLevel);
		}
		if ((attributesToSave & AttributesToSave.UserAccessLevel) != AttributesToSave.None)
		{
			encoder.WriteByte(null, m_userAccessLevel);
		}
		if ((attributesToSave & AttributesToSave.MinimumSamplingInterval) != AttributesToSave.None)
		{
			encoder.WriteDouble(null, m_minimumSamplingInterval);
		}
		if ((attributesToSave & AttributesToSave.Historizing) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_historizing);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attibutesToLoad)
	{
		base.Update(context, decoder, attibutesToLoad);
		if ((attibutesToLoad & AttributesToSave.Value) != AttributesToSave.None)
		{
			WrappedValue = decoder.ReadVariant(null);
		}
		if ((attibutesToLoad & AttributesToSave.StatusCode) != AttributesToSave.None)
		{
			m_statusCode = decoder.ReadStatusCode(null);
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
		if ((attibutesToLoad & AttributesToSave.AccessLevel) != AttributesToSave.None)
		{
			AccessLevel = decoder.ReadByte(null);
		}
		if ((attibutesToLoad & AttributesToSave.UserAccessLevel) != AttributesToSave.None)
		{
			m_userAccessLevel = decoder.ReadByte(null);
		}
		if ((attibutesToLoad & AttributesToSave.MinimumSamplingInterval) != AttributesToSave.None)
		{
			m_minimumSamplingInterval = decoder.ReadDouble(null);
		}
		if ((attibutesToLoad & AttributesToSave.Historizing) != AttributesToSave.None)
		{
			m_historizing = decoder.ReadBoolean(null);
		}
	}

	public static string ArrayDimensionsToXml(IList<uint> arrayDimensions)
	{
		if (arrayDimensions == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayDimensions.Count; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(arrayDimensions[i]);
		}
		return stringBuilder.ToString();
	}

	public static ReadOnlyList<uint> ArrayDimensionsFromXml(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return null;
		}
		string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		uint[] array2 = new uint[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			try
			{
				array2[i] = Convert.ToUInt32(array[i]);
			}
			catch
			{
				array2[i] = 0u;
			}
		}
		return new ReadOnlyList<uint>(array2);
	}

	public override void SetStatusCode(ISystemContext context, StatusCode statusCode, DateTime timestamp)
	{
		base.SetStatusCode(context, statusCode, timestamp);
		StatusCode = statusCode;
		if (timestamp != DateTime.MinValue)
		{
			Timestamp = timestamp;
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 14u:
		{
			NodeId value3 = m_dataType;
			if (OnReadDataType != null)
			{
				serviceResult = OnReadDataType(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value3;
			}
			return serviceResult;
		}
		case 15u:
		{
			int value8 = m_valueRank;
			if (OnReadValueRank != null)
			{
				serviceResult = OnReadValueRank(context, this, ref value8);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value8;
			}
			return serviceResult;
		}
		case 16u:
		{
			IList<uint> value9 = m_arrayDimensions;
			if (OnReadArrayDimensions != null)
			{
				serviceResult = OnReadArrayDimensions(context, this, ref value9);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value9;
			}
			return serviceResult;
		}
		case 17u:
		{
			byte value5 = AccessLevel;
			if (OnReadAccessLevel != null)
			{
				serviceResult = OnReadAccessLevel(context, this, ref value5);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value5;
			}
			return serviceResult;
		}
		case 27u:
		{
			uint value4 = m_accessLevel;
			if (OnReadAccessLevelEx != null)
			{
				serviceResult = OnReadAccessLevelEx(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value4;
			}
			return serviceResult;
		}
		case 18u:
		{
			byte value6 = m_userAccessLevel;
			if (OnReadUserAccessLevel != null)
			{
				serviceResult = OnReadUserAccessLevel(context, this, ref value6);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value6;
			}
			return serviceResult;
		}
		case 19u:
		{
			double value7 = m_minimumSamplingInterval;
			if (OnReadMinimumSamplingInterval != null)
			{
				serviceResult = OnReadMinimumSamplingInterval(context, this, ref value7);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value7;
			}
			return serviceResult;
		}
		case 20u:
		{
			bool value2 = m_historizing;
			if (OnReadHistorizing != null)
			{
				serviceResult = OnReadHistorizing(context, this, ref value2);
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
		if ((m_accessLevel & 1) == 0)
		{
			return 2151284736u;
		}
		byte value2 = m_userAccessLevel;
		OnReadUserAccessLevel?.Invoke(context, this, ref value2);
		if ((value2 & 1) == 0)
		{
			return 2149515264u;
		}
		if (m_timestamp == DateTime.MinValue)
		{
			m_timestamp = DateTime.UtcNow;
		}
		value = m_value;
		sourceTimestamp = m_timestamp;
		StatusCode statusCode = m_statusCode;
		ServiceResult serviceResult = null;
		if (OnReadValue != null)
		{
			serviceResult = OnReadValue(context, this, indexRange, dataEncoding, ref value, ref statusCode, ref sourceTimestamp);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
			if (ServiceResult.IsGood(serviceResult) && statusCode != 0u)
			{
				serviceResult = statusCode;
			}
			return serviceResult;
		}
		if (OnSimpleReadValue != null)
		{
			serviceResult = OnSimpleReadValue(context, this, ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
		}
		serviceResult = ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
		if (ServiceResult.IsBad(serviceResult))
		{
			return serviceResult;
		}
		if (m_copyPolicy == VariableCopyPolicy.CopyOnRead || m_copyPolicy == VariableCopyPolicy.Always)
		{
			value = Utils.Clone(value);
		}
		if (ServiceResult.IsGood(serviceResult) && statusCode != 0u)
		{
			serviceResult = statusCode;
		}
		return serviceResult;
	}

	public static ServiceResult ApplyIndexRangeAndDataEncoding(ISystemContext context, NumericRange indexRange, QualifiedName dataEncoding, ref object value)
	{
		ServiceResult serviceResult = null;
		if (indexRange != NumericRange.Empty)
		{
			serviceResult = indexRange.ApplyRange(ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
		}
		if (!QualifiedName.IsNull(dataEncoding))
		{
			serviceResult = EncodeableObject.ApplyDataEncoding(new ServiceMessageContext
			{
				NamespaceUris = context.NamespaceUris,
				ServerUris = context.ServerUris,
				Factory = context.EncodeableFactory
			}, dataEncoding, ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
		}
		return ServiceResult.Good;
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 14u:
		{
			NodeId value6 = value as NodeId;
			if (value6 == null)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.DataType) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteDataType != null)
			{
				serviceResult = OnWriteDataType(context, this, ref value6);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				DataType = value6;
			}
			return serviceResult;
		}
		case 15u:
		{
			int? num2 = value as int?;
			if (!num2.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.ValueRank) == 0)
			{
				return 2151350272u;
			}
			int value7 = num2.Value;
			if (OnWriteValueRank != null)
			{
				serviceResult = OnWriteValueRank(context, this, ref value7);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				ValueRank = value7;
			}
			return serviceResult;
		}
		case 16u:
		{
			IList<uint> value8 = value as IList<uint>;
			if ((base.WriteMask & AttributeWriteMask.ArrayDimensions) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteArrayDimensions != null)
			{
				serviceResult = OnWriteArrayDimensions(context, this, ref value8);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				if (value8 != null)
				{
					ArrayDimensions = new ReadOnlyList<uint>(value8);
				}
				else
				{
					ArrayDimensions = null;
				}
			}
			return serviceResult;
		}
		case 17u:
		{
			byte? b = value as byte?;
			if (!b.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.AccessLevel) == 0)
			{
				return 2151350272u;
			}
			byte value3 = b.Value;
			if (OnWriteAccessLevel != null)
			{
				serviceResult = OnWriteAccessLevel(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				AccessLevel = value3;
			}
			return serviceResult;
		}
		case 18u:
		{
			byte? b2 = value as byte?;
			if (!b2.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.UserAccessLevel) == 0)
			{
				return 2151350272u;
			}
			byte value4 = b2.Value;
			if (OnWriteUserAccessLevel != null)
			{
				serviceResult = OnWriteUserAccessLevel(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				UserAccessLevel = value4;
			}
			return serviceResult;
		}
		case 19u:
		{
			double? num = value as double?;
			if (!num.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.MinimumSamplingInterval) == 0)
			{
				return 2151350272u;
			}
			double value5 = num.Value;
			if (OnWriteMinimumSamplingInterval != null)
			{
				serviceResult = OnWriteMinimumSamplingInterval(context, this, ref value5);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				MinimumSamplingInterval = value5;
			}
			return serviceResult;
		}
		case 20u:
		{
			bool? flag = value as bool?;
			if (!flag.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.Historizing) == 0)
			{
				return 2151350272u;
			}
			bool value2 = flag.Value;
			if (OnWriteHistorizing != null)
			{
				serviceResult = OnWriteHistorizing(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				Historizing = value2;
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
		if ((m_accessLevel & 2) == 0)
		{
			return 2151350272u;
		}
		byte value2 = m_userAccessLevel;
		OnReadUserAccessLevel?.Invoke(context, this, ref value2);
		if ((value2 & 2) == 0)
		{
			return 2149515264u;
		}
		if (OnWriteValue != null)
		{
			serviceResult = OnWriteValue(context, this, indexRange, null, ref value, ref statusCode, ref sourceTimestamp);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
			m_value = value;
			m_statusCode = statusCode;
			m_timestamp = sourceTimestamp;
			if (sourceTimestamp == DateTime.MinValue)
			{
				m_timestamp = DateTime.UtcNow;
			}
			base.ChangeMasks |= NodeStateChangeMasks.Value;
			return serviceResult;
		}
		if (sourceTimestamp == DateTime.MinValue)
		{
			sourceTimestamp = DateTime.UtcNow;
		}
		TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(value, m_dataType, m_valueRank, context.NamespaceUris, context.TypeTable);
		if (typeInfo == null || typeInfo == TypeInfo.Unknown)
		{
			if (DataTypeIds.XmlElement == m_dataType && TypeInfo.IsInstanceOfDataType(value, DataTypeIds.UInt32, -1, context.NamespaceUris, context.TypeTable) != null)
			{
				return (StatusCode)(uint)value;
			}
			if (!m_dataType.IsNullNodeId || value != null)
			{
				return 2155085824u;
			}
		}
		value = ExtractValueFromVariant(context, value, throwOnError: true);
		if (m_copyPolicy == VariableCopyPolicy.CopyOnWrite || m_copyPolicy == VariableCopyPolicy.Always)
		{
			value = Utils.Clone(value);
		}
		if (OnSimpleWriteValue != null)
		{
			if (indexRange != NumericRange.Empty)
			{
				return 2151022592u;
			}
			serviceResult = OnSimpleWriteValue(context, this, ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
		}
		else if (indexRange != NumericRange.Empty)
		{
			object dst = m_value;
			serviceResult = indexRange.UpdateRange(ref dst, value);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
			value = dst;
		}
		m_value = value;
		m_statusCode = statusCode;
		m_timestamp = sourceTimestamp;
		base.ChangeMasks |= NodeStateChangeMasks.Value;
		return ServiceResult.Good;
	}
}
