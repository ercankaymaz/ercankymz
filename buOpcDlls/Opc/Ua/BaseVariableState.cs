// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseVariableState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#nullable disable
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

  public BaseVariableState(NodeState parent)
    : base(NodeClass.Variable, parent)
  {
    this.m_timestamp = DateTime.MinValue;
    this.m_userAccessLevel = (byte) 1;
    this.m_accessLevel = 1U;
    this.m_copyPolicy = VariableCopyPolicy.CopyOnRead;
    this.m_valueTouched = false;
    this.m_statusCode = (StatusCode) 2150760448U /*0x80320000*/;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is BaseVariableState baseVariableState)
    {
      this.m_value = this.ExtractValueFromVariant(context, baseVariableState.m_value, false);
      this.m_timestamp = baseVariableState.m_timestamp;
      this.m_dataType = baseVariableState.m_dataType;
      this.m_valueRank = baseVariableState.m_valueRank;
      this.m_arrayDimensions = (ReadOnlyList<uint>) null;
      this.m_accessLevel = baseVariableState.m_accessLevel;
      this.m_userAccessLevel = baseVariableState.m_userAccessLevel;
      this.m_minimumSamplingInterval = baseVariableState.m_minimumSamplingInterval;
      this.m_historizing = baseVariableState.m_historizing;
      this.m_valueTouched = baseVariableState.m_valueTouched;
      if (baseVariableState.m_arrayDimensions != null)
        this.m_arrayDimensions = new ReadOnlyList<uint>((IList<uint>) baseVariableState.m_arrayDimensions, true);
      this.m_value = this.ExtractValueFromVariant(context, this.m_value, false);
    }
    base.Initialize(context, source);
  }

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return (NodeId) 62U;
  }

  protected virtual NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris) => (NodeId) 24U;

  protected virtual int GetDefaultValueRank() => -2;

  [Obsolete("Should use the version that takes a ISystemContext (pass null if ISystemContext is not available).")]
  protected virtual object ExtractValueFromVariant(object value, bool throwOnError)
  {
    return this.ExtractValueFromVariant((ISystemContext) null, value, throwOnError);
  }

  protected virtual object ExtractValueFromVariant(
    ISystemContext context,
    object value,
    bool throwOnError)
  {
    return value;
  }

  public static T GetValue<T>(BaseDataVariableState<T> variable)
  {
    return variable == null ? default (T) : variable.Value;
  }

  public static T GetValue<T>(PropertyState<T> property)
  {
    return property == null ? default (T) : property.Value;
  }

  [Obsolete("Should use the version that takes a ISystemContext (pass null if ISystemContext is not available).")]
  public static object ExtractValueFromVariant<T>(object value, bool throwOnError)
  {
    return BaseVariableState.ExtractValueFromVariant<T>((ISystemContext) null, value, throwOnError);
  }

  public static object ExtractValueFromVariant<T>(
    ISystemContext context,
    object value,
    bool throwOnError)
  {
    if (value == null)
      return (object) default (T);
    if (typeof (T).IsInstanceOfType(value))
      return value;
    if (value is ExtensionObject extension)
    {
      if (typeof (T).IsInstanceOfType(extension.Body))
        return extension.Body;
      if (typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(typeof (T).GetTypeInfo()))
        return BaseVariableState.DecodeExtensionObject(context, typeof (T), extension, throwOnError);
      if (throwOnError)
        throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert {0} to {1}.", (object) value.GetType().Name, (object) typeof (T).Name);
      return (object) default (T);
    }
    Type elementType = typeof (T).GetElementType();
    if (elementType != (Type) null)
    {
      if (value is IList<ExtensionObject> extensionObjectList && typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()))
      {
        Array instance = Array.CreateInstance(elementType, extensionObjectList.Count);
        for (int index = 0; index < extensionObjectList.Count; ++index)
        {
          if (ExtensionObject.IsNull(extensionObjectList[index]))
            instance.SetValue((object) null, index);
          else if (elementType.IsInstanceOfType(extensionObjectList[index].Body))
          {
            instance.SetValue(extensionObjectList[index].Body, index);
          }
          else
          {
            object obj = BaseVariableState.DecodeExtensionObject(context, elementType, extensionObjectList[index], throwOnError);
            if (obj != null)
              instance.SetValue(obj, index);
            else if (throwOnError)
              throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert ExtensionObject to {0}. Index = {1}", (object) elementType.Name, (object) index);
          }
        }
        return (object) instance;
      }
      if (value is IList<Variant> variantList)
      {
        if (elementType != typeof (object) && throwOnError)
          throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert {0} to {1}.", (object) value.GetType().Name, (object) typeof (T).Name);
        object[] valueFromVariant = new object[variantList.Count];
        for (int index = 0; index < variantList.Count; ++index)
          valueFromVariant[index] = variantList[index].Value;
        return (object) valueFromVariant;
      }
      if (typeof (Guid).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()) && value is IList<Uuid> uuidList)
      {
        Guid[] valueFromVariant = new Guid[uuidList.Count];
        for (int index = 0; index < uuidList.Count; ++index)
          valueFromVariant[index] = (Guid) uuidList[index];
        return (object) valueFromVariant;
      }
      if (typeof (Enum).GetTypeInfo().IsAssignableFrom(elementType.GetTypeInfo()) && value is IList<int> intList)
      {
        Array instance = Array.CreateInstance(elementType, intList.Count);
        for (int index = 0; index < intList.Count; ++index)
          instance.SetValue((object) intList[index], index);
        return (object) instance;
      }
    }
    if (typeof (Guid).GetTypeInfo().IsAssignableFrom(typeof (T).GetTypeInfo()))
    {
      Uuid? nullable = value as Uuid?;
      if (nullable.HasValue)
        return (object) (Guid) nullable.Value;
    }
    if (typeof (Enum).GetTypeInfo().IsAssignableFrom(typeof (T).GetTypeInfo()))
    {
      int? nullable = value as int?;
      if (nullable.HasValue)
        return (object) (T) (ValueType) nullable.Value;
    }
    if (throwOnError)
      throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert {0} to {1}.", (object) value.GetType().Name, (object) typeof (T).Name);
    return (object) default (T);
  }

  public static object DecodeExtensionObject(
    ISystemContext context,
    Type targetType,
    ExtensionObject extension,
    bool throwOnError)
  {
    if (targetType.IsInstanceOfType(extension.Body))
      return extension.Body;
    if (Activator.CreateInstance(targetType) is IEncodeable instance)
    {
      IDecoder decoder = (IDecoder) null;
      ServiceMessageContext context1 = ServiceMessageContext.GlobalContext;
      if (context != null)
      {
        context1 = new ServiceMessageContext();
        context1.NamespaceUris = context.NamespaceUris;
        context1.ServerUris = context.ServerUris;
        context1.Factory = context.EncodeableFactory;
      }
      if (extension.Encoding == ExtensionObjectEncoding.Binary)
        decoder = (IDecoder) new BinaryDecoder(extension.Body as byte[], (IServiceMessageContext) context1);
      else if (extension.Encoding == ExtensionObjectEncoding.Xml)
        decoder = (IDecoder) new XmlDecoder(extension.Body as XmlElement, (IServiceMessageContext) context1);
      if (decoder != null)
      {
        try
        {
          instance.Decode(decoder);
          return (object) instance;
        }
        catch (Exception ex)
        {
          if (throwOnError)
            throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert ExtensionObject to {0}. Error = {1}", (object) targetType.Name, (object) ex.Message);
        }
      }
    }
    if (throwOnError)
      throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert ExtensionObject to {0}.", (object) targetType.Name);
    return (object) null;
  }

  public static T CheckTypeBeforeCast<T>(object value, bool throwOnError)
  {
    if ((value != null || !typeof (T).GetTypeInfo().IsValueType) && (value == null || typeof (T).IsInstanceOfType(value)))
      return (T) value;
    if (throwOnError)
      throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Cannot convert '{0}' to a {1}.", value, (object) typeof (T).Name);
    return default (T);
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType(), (object) this.Parent));
  }

  public object Value
  {
    get => this.m_value;
    set
    {
      if (value == null && this.IsValueType)
        value = this.ExtractValueFromVariant((ISystemContext) null, value, false);
      if (this.m_value != value)
        this.ChangeMasks |= NodeStateChangeMasks.Value;
      if (!this.m_valueTouched)
        this.StatusCode = (StatusCode) 0U;
      this.m_value = value;
      this.m_valueTouched = true;
    }
  }

  public bool IsValueType
  {
    get => this.m_isValueType;
    set => this.m_isValueType = value;
  }

  [DataMember(Name = "Value", Order = 0, IsRequired = false, EmitDefaultValue = false)]
  public Variant WrappedValue
  {
    get => new Variant(this.m_value);
    set => this.Value = this.ExtractValueFromVariant((ISystemContext) null, value.Value, false);
  }

  public DateTime Timestamp
  {
    get => this.m_timestamp;
    set
    {
      if (this.m_timestamp != value)
        this.ChangeMasks |= NodeStateChangeMasks.Value;
      this.m_timestamp = value;
    }
  }

  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set
    {
      if (this.m_statusCode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Value;
      this.m_statusCode = value;
    }
  }

  public VariableCopyPolicy CopyPolicy
  {
    get => this.m_copyPolicy;
    set => this.m_copyPolicy = value;
  }

  [DataMember(Name = "DataType", Order = 1, IsRequired = false, EmitDefaultValue = false)]
  public NodeId DataType
  {
    get => this.m_dataType;
    set
    {
      if ((object) this.m_dataType != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_dataType = value;
    }
  }

  [DataMember(Name = "ValueRank", Order = 2, IsRequired = false, EmitDefaultValue = false)]
  public int ValueRank
  {
    get => this.m_valueRank;
    set
    {
      if (this.m_valueRank != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_valueRank = value;
    }
  }

  public ReadOnlyList<uint> ArrayDimensions
  {
    get => this.m_arrayDimensions;
    set
    {
      if (this.m_arrayDimensions != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_arrayDimensions = value;
    }
  }

  [DataMember(Name = "AccessLevel", Order = 4, IsRequired = false, EmitDefaultValue = false)]
  public byte AccessLevel
  {
    get => (byte) (this.m_accessLevel & (uint) byte.MaxValue);
    set
    {
      if ((int) this.AccessLevel != (int) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_accessLevel = this.m_accessLevel & 4294967040U | (uint) value;
    }
  }

  [DataMember(Name = "UserAccessLevel", Order = 5, IsRequired = false, EmitDefaultValue = false)]
  public byte UserAccessLevel
  {
    get => this.m_userAccessLevel;
    set
    {
      if ((int) this.m_userAccessLevel != (int) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_userAccessLevel = value;
    }
  }

  [DataMember(Name = "MinimumSamplingInterval", Order = 6, IsRequired = false, EmitDefaultValue = false)]
  public double MinimumSamplingInterval
  {
    get => this.m_minimumSamplingInterval;
    set
    {
      if (this.m_minimumSamplingInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_minimumSamplingInterval = value;
    }
  }

  [DataMember(Name = "Historizing", Order = 7, IsRequired = false, EmitDefaultValue = false)]
  public bool Historizing
  {
    get => this.m_historizing;
    set
    {
      if (this.m_historizing != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_historizing = value;
    }
  }

  [DataMember(Name = "AccessLevelEx", Order = 8, IsRequired = false, EmitDefaultValue = false)]
  public uint AccessLevelEx
  {
    get => this.m_accessLevel;
    set
    {
      if ((int) this.m_accessLevel != (int) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_accessLevel = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is VariableNode variableNode))
      return;
    try
    {
      variableNode.Value = new Variant(Utils.Clone(this.Value));
      variableNode.DataType = this.DataType;
      variableNode.ValueRank = this.ValueRank;
      variableNode.ArrayDimensions = (UInt32Collection) null;
      if (this.ArrayDimensions != null)
        variableNode.ArrayDimensions = new UInt32Collection((IEnumerable<uint>) this.ArrayDimensions);
      variableNode.AccessLevel = this.AccessLevel;
      variableNode.UserAccessLevel = this.UserAccessLevel;
      variableNode.MinimumSamplingInterval = this.MinimumSamplingInterval;
      variableNode.Historizing = this.Historizing;
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
    if (this.m_value != null)
      encoder.WriteVariant("Value", this.WrappedValue);
    if (this.StatusCode != 0U)
      encoder.WriteStatusCode("StatusCode", this.StatusCode);
    if (!NodeId.IsNull(this.DataType))
      encoder.WriteNodeId("DataType", this.DataType);
    if (this.ValueRank != -2)
      encoder.WriteInt32("ValueRank", this.ValueRank);
    if (this.ArrayDimensions != null)
      encoder.WriteString("ArrayDimensions", BaseVariableState.ArrayDimensionsToXml((IList<uint>) this.ArrayDimensions));
    if (this.AccessLevel != (byte) 0)
      encoder.WriteByte("AccessLevel", this.AccessLevel);
    if (this.UserAccessLevel != (byte) 0)
      encoder.WriteByte("UserAccessLevel", this.UserAccessLevel);
    if (this.MinimumSamplingInterval != 0.0)
      encoder.WriteDouble("MinimumSamplingInterval", this.MinimumSamplingInterval);
    if (this.Historizing)
      encoder.WriteBoolean("Historizing", this.Historizing);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("Value"))
      this.WrappedValue = decoder.ReadVariant("Value");
    if (decoder.Peek("Timestamp"))
      this.Timestamp = decoder.ReadDateTime("Timestamp");
    this.StatusCode = !decoder.Peek("StatusCode") ? (StatusCode) 0U : decoder.ReadStatusCode("StatusCode");
    if (decoder.Peek("DataType"))
      this.DataType = decoder.ReadNodeId("DataType");
    if (decoder.Peek("ValueRank"))
      this.ValueRank = decoder.ReadInt32("ValueRank");
    if (this.m_value == null && this.m_valueRank == -1)
    {
      bool flag;
      if (!(flag = this.IsValueType) && TypeInfo.IsValueType(DataTypes.GetBuiltInType(this.m_dataType, context.TypeTable)))
        flag = true;
      if (flag)
        this.m_value = TypeInfo.GetDefaultValue(this.m_dataType, this.m_valueRank, context.TypeTable);
    }
    if (decoder.Peek("ArrayDimensions"))
      this.ArrayDimensions = BaseVariableState.ArrayDimensionsFromXml(decoder.ReadString("ArrayDimensions"));
    if (decoder.Peek("AccessLevel"))
      this.AccessLevel = decoder.ReadByte("AccessLevel");
    if (decoder.Peek("UserAccessLevel"))
      this.UserAccessLevel = decoder.ReadByte("UserAccessLevel");
    if (decoder.Peek("MinimumSamplingInterval"))
      this.MinimumSamplingInterval = decoder.ReadDouble("MinimumSamplingInterval");
    if (decoder.Peek("Historizing"))
      this.Historizing = decoder.ReadBoolean("Historizing");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.m_value != null)
      attributesToSave |= NodeState.AttributesToSave.Value;
    if (this.m_statusCode != 0U)
      attributesToSave |= NodeState.AttributesToSave.StatusCode;
    if (!NodeId.IsNull(this.m_dataType))
      attributesToSave |= NodeState.AttributesToSave.DataType;
    if (this.m_valueRank != -2)
      attributesToSave |= NodeState.AttributesToSave.ValueRank;
    if (this.m_arrayDimensions != null)
      attributesToSave |= NodeState.AttributesToSave.ArrayDimensions;
    if (this.m_accessLevel != 0U)
      attributesToSave |= NodeState.AttributesToSave.AccessLevel;
    if (this.m_userAccessLevel != (byte) 0)
      attributesToSave |= NodeState.AttributesToSave.UserAccessLevel;
    if (this.m_minimumSamplingInterval != 0.0)
      attributesToSave |= NodeState.AttributesToSave.MinimumSamplingInterval;
    if (this.m_historizing)
      attributesToSave |= NodeState.AttributesToSave.Historizing;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.Value) != NodeState.AttributesToSave.None)
      encoder.WriteVariant((string) null, this.WrappedValue);
    if ((attributesToSave & NodeState.AttributesToSave.StatusCode) != NodeState.AttributesToSave.None)
      encoder.WriteStatusCode((string) null, this.m_statusCode);
    if ((attributesToSave & NodeState.AttributesToSave.DataType) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_dataType);
    if ((attributesToSave & NodeState.AttributesToSave.ValueRank) != NodeState.AttributesToSave.None)
      encoder.WriteInt32((string) null, this.m_valueRank);
    if ((attributesToSave & NodeState.AttributesToSave.ArrayDimensions) != NodeState.AttributesToSave.None)
      encoder.WriteUInt32Array((string) null, (IList<uint>) this.m_arrayDimensions);
    if ((attributesToSave & NodeState.AttributesToSave.AccessLevel) != NodeState.AttributesToSave.None)
      encoder.WriteByte((string) null, this.AccessLevel);
    if ((attributesToSave & NodeState.AttributesToSave.UserAccessLevel) != NodeState.AttributesToSave.None)
      encoder.WriteByte((string) null, this.m_userAccessLevel);
    if ((attributesToSave & NodeState.AttributesToSave.MinimumSamplingInterval) != NodeState.AttributesToSave.None)
      encoder.WriteDouble((string) null, this.m_minimumSamplingInterval);
    if ((attributesToSave & NodeState.AttributesToSave.Historizing) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteBoolean((string) null, this.m_historizing);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attibutesToLoad)
  {
    base.Update(context, decoder, attibutesToLoad);
    if ((attibutesToLoad & NodeState.AttributesToSave.Value) != NodeState.AttributesToSave.None)
      this.WrappedValue = decoder.ReadVariant((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.StatusCode) != NodeState.AttributesToSave.None)
      this.m_statusCode = decoder.ReadStatusCode((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.DataType) != NodeState.AttributesToSave.None)
      this.m_dataType = decoder.ReadNodeId((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.ValueRank) != NodeState.AttributesToSave.None)
      this.m_valueRank = decoder.ReadInt32((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.ArrayDimensions) != NodeState.AttributesToSave.None)
    {
      UInt32Collection list = decoder.ReadUInt32Array((string) null);
      this.m_arrayDimensions = list == null || list.Count <= 0 ? (ReadOnlyList<uint>) null : new ReadOnlyList<uint>((IList<uint>) list);
    }
    if ((attibutesToLoad & NodeState.AttributesToSave.AccessLevel) != NodeState.AttributesToSave.None)
      this.AccessLevel = decoder.ReadByte((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.UserAccessLevel) != NodeState.AttributesToSave.None)
      this.m_userAccessLevel = decoder.ReadByte((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.MinimumSamplingInterval) != NodeState.AttributesToSave.None)
      this.m_minimumSamplingInterval = decoder.ReadDouble((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.Historizing) == NodeState.AttributesToSave.None)
      return;
    this.m_historizing = decoder.ReadBoolean((string) null);
  }

  public static string ArrayDimensionsToXml(IList<uint> arrayDimensions)
  {
    if (arrayDimensions == null)
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < arrayDimensions.Count; ++index)
    {
      if (stringBuilder.Length > 0)
        stringBuilder.Append(',');
      stringBuilder.Append(arrayDimensions[index]);
    }
    return stringBuilder.ToString();
  }

  public static ReadOnlyList<uint> ArrayDimensionsFromXml(string value)
  {
    if (string.IsNullOrEmpty(value))
      return (ReadOnlyList<uint>) null;
    string[] strArray = value.Split(new char[1]{ ',' }, StringSplitOptions.RemoveEmptyEntries);
    if (strArray == null || strArray.Length == 0)
      return (ReadOnlyList<uint>) null;
    uint[] list = new uint[strArray.Length];
    for (int index = 0; index < list.Length; ++index)
    {
      try
      {
        list[index] = Convert.ToUInt32(strArray[index]);
      }
      catch
      {
        list[index] = 0U;
      }
    }
    return new ReadOnlyList<uint>((IList<uint>) list);
  }

  public override void SetStatusCode(
    ISystemContext context,
    StatusCode statusCode,
    DateTime timestamp)
  {
    base.SetStatusCode(context, statusCode, timestamp);
    this.StatusCode = statusCode;
    if (!(timestamp != DateTime.MinValue))
      return;
    this.Timestamp = timestamp;
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 14:
        NodeId dataType = this.m_dataType;
        if (this.OnReadDataType != null)
          status = this.OnReadDataType(context, (NodeState) this, ref dataType);
        if (ServiceResult.IsGood(status))
          value = (object) dataType;
        return status;
      case 15:
        int valueRank = this.m_valueRank;
        if (this.OnReadValueRank != null)
          status = this.OnReadValueRank(context, (NodeState) this, ref valueRank);
        if (ServiceResult.IsGood(status))
          value = (object) valueRank;
        return status;
      case 16 /*0x10*/:
        IList<uint> arrayDimensions = (IList<uint>) this.m_arrayDimensions;
        if (this.OnReadArrayDimensions != null)
          status = this.OnReadArrayDimensions(context, (NodeState) this, ref arrayDimensions);
        if (ServiceResult.IsGood(status))
          value = (object) arrayDimensions;
        return status;
      case 17:
        byte accessLevel1 = this.AccessLevel;
        if (this.OnReadAccessLevel != null)
          status = this.OnReadAccessLevel(context, (NodeState) this, ref accessLevel1);
        if (ServiceResult.IsGood(status))
          value = (object) accessLevel1;
        return status;
      case 18:
        byte userAccessLevel = this.m_userAccessLevel;
        if (this.OnReadUserAccessLevel != null)
          status = this.OnReadUserAccessLevel(context, (NodeState) this, ref userAccessLevel);
        if (ServiceResult.IsGood(status))
          value = (object) userAccessLevel;
        return status;
      case 19:
        double samplingInterval = this.m_minimumSamplingInterval;
        if (this.OnReadMinimumSamplingInterval != null)
          status = this.OnReadMinimumSamplingInterval(context, (NodeState) this, ref samplingInterval);
        if (ServiceResult.IsGood(status))
          value = (object) samplingInterval;
        return status;
      case 20:
        bool historizing = this.m_historizing;
        if (this.OnReadHistorizing != null)
          status = this.OnReadHistorizing(context, (NodeState) this, ref historizing);
        if (ServiceResult.IsGood(status))
          value = (object) historizing;
        return status;
      case 27:
        uint accessLevel2 = this.m_accessLevel;
        if (this.OnReadAccessLevelEx != null)
          status = this.OnReadAccessLevelEx(context, (NodeState) this, ref accessLevel2);
        if (ServiceResult.IsGood(status))
          value = (object) accessLevel2;
        return status;
      default:
        return base.ReadNonValueAttribute(context, attributeId, ref value);
    }
  }

  protected override ServiceResult ReadValueAttribute(
    ISystemContext context,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref DateTime sourceTimestamp)
  {
    if (((int) this.m_accessLevel & 1) == 0)
      return (ServiceResult) 2151284736U /*0x803A0000*/;
    byte userAccessLevel = this.m_userAccessLevel;
    NodeAttributeEventHandler<byte> readUserAccessLevel = this.OnReadUserAccessLevel;
    if (readUserAccessLevel != null)
    {
      ServiceResult serviceResult = readUserAccessLevel(context, (NodeState) this, ref userAccessLevel);
    }
    if (((int) userAccessLevel & 1) == 0)
      return (ServiceResult) 2149515264U /*0x801F0000*/;
    if (this.m_timestamp == DateTime.MinValue)
      this.m_timestamp = DateTime.UtcNow;
    value = this.m_value;
    sourceTimestamp = this.m_timestamp;
    StatusCode statusCode = this.m_statusCode;
    if (this.OnReadValue != null)
    {
      ServiceResult status = this.OnReadValue(context, (NodeState) this, indexRange, dataEncoding, ref value, ref statusCode, ref sourceTimestamp);
      if (ServiceResult.IsBad(status) || !ServiceResult.IsGood(status) || !(statusCode != 0U))
        return status;
      status = (ServiceResult) statusCode;
      return status;
    }
    if (this.OnSimpleReadValue != null)
    {
      ServiceResult status = this.OnSimpleReadValue(context, (NodeState) this, ref value);
      if (ServiceResult.IsBad(status))
        return status;
    }
    ServiceResult status1 = BaseVariableState.ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
    if (ServiceResult.IsBad(status1))
      return status1;
    if (this.m_copyPolicy == VariableCopyPolicy.CopyOnRead || this.m_copyPolicy == VariableCopyPolicy.Always)
      value = Utils.Clone(value);
    if (ServiceResult.IsGood(status1) && statusCode != 0U)
      status1 = (ServiceResult) statusCode;
    return status1;
  }

  public static ServiceResult ApplyIndexRangeAndDataEncoding(
    ISystemContext context,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value)
  {
    if (indexRange != NumericRange.Empty)
    {
      ServiceResult status = (ServiceResult) indexRange.ApplyRange(ref value);
      if (ServiceResult.IsBad(status))
        return status;
    }
    if (!QualifiedName.IsNull(dataEncoding))
    {
      ServiceResult status = EncodeableObject.ApplyDataEncoding((IServiceMessageContext) new ServiceMessageContext()
      {
        NamespaceUris = context.NamespaceUris,
        ServerUris = context.ServerUris,
        Factory = context.EncodeableFactory
      }, dataEncoding, ref value);
      if (ServiceResult.IsBad(status))
        return status;
    }
    return ServiceResult.Good;
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 14:
        NodeId nodeId = value as NodeId;
        if (nodeId == (object) null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.DataType) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteDataType != null)
          status = this.OnWriteDataType(context, (NodeState) this, ref nodeId);
        if (ServiceResult.IsGood(status))
          this.DataType = nodeId;
        return status;
      case 15:
        int? nullable1 = value as int?;
        if (!nullable1.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.ValueRank) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        int num1 = nullable1.Value;
        if (this.OnWriteValueRank != null)
          status = this.OnWriteValueRank(context, (NodeState) this, ref num1);
        if (ServiceResult.IsGood(status))
          this.ValueRank = num1;
        return status;
      case 16 /*0x10*/:
        IList<uint> list = value as IList<uint>;
        if ((this.WriteMask & AttributeWriteMask.ArrayDimensions) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteArrayDimensions != null)
          status = this.OnWriteArrayDimensions(context, (NodeState) this, ref list);
        if (ServiceResult.IsGood(status))
          this.ArrayDimensions = list == null ? (ReadOnlyList<uint>) null : new ReadOnlyList<uint>(list);
        return status;
      case 17:
        byte? nullable2 = value as byte?;
        if (!nullable2.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.AccessLevel) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        byte num2 = nullable2.Value;
        if (this.OnWriteAccessLevel != null)
          status = this.OnWriteAccessLevel(context, (NodeState) this, ref num2);
        if (ServiceResult.IsGood(status))
          this.AccessLevel = num2;
        return status;
      case 18:
        byte? nullable3 = value as byte?;
        if (!nullable3.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.UserAccessLevel) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        byte num3 = nullable3.Value;
        if (this.OnWriteUserAccessLevel != null)
          status = this.OnWriteUserAccessLevel(context, (NodeState) this, ref num3);
        if (ServiceResult.IsGood(status))
          this.UserAccessLevel = num3;
        return status;
      case 19:
        double? nullable4 = value as double?;
        if (!nullable4.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.MinimumSamplingInterval) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        double num4 = nullable4.Value;
        if (this.OnWriteMinimumSamplingInterval != null)
          status = this.OnWriteMinimumSamplingInterval(context, (NodeState) this, ref num4);
        if (ServiceResult.IsGood(status))
          this.MinimumSamplingInterval = num4;
        return status;
      case 20:
        bool? nullable5 = value as bool?;
        if (!nullable5.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.Historizing) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        bool flag = nullable5.Value;
        if (this.OnWriteHistorizing != null)
          status = this.OnWriteHistorizing(context, (NodeState) this, ref flag);
        if (ServiceResult.IsGood(status))
          this.Historizing = flag;
        return status;
      default:
        return base.WriteNonValueAttribute(context, attributeId, value);
    }
  }

  protected override ServiceResult WriteValueAttribute(
    ISystemContext context,
    NumericRange indexRange,
    object value,
    StatusCode statusCode,
    DateTime sourceTimestamp)
  {
    if (((int) this.m_accessLevel & 2) == 0)
      return (ServiceResult) 2151350272U /*0x803B0000*/;
    byte userAccessLevel = this.m_userAccessLevel;
    NodeAttributeEventHandler<byte> readUserAccessLevel = this.OnReadUserAccessLevel;
    if (readUserAccessLevel != null)
    {
      ServiceResult serviceResult = readUserAccessLevel(context, (NodeState) this, ref userAccessLevel);
    }
    if (((int) userAccessLevel & 2) == 0)
      return (ServiceResult) 2149515264U /*0x801F0000*/;
    if (this.OnWriteValue != null)
    {
      ServiceResult status = this.OnWriteValue(context, (NodeState) this, indexRange, (QualifiedName) null, ref value, ref statusCode, ref sourceTimestamp);
      if (ServiceResult.IsBad(status))
        return status;
      this.m_value = value;
      this.m_statusCode = statusCode;
      this.m_timestamp = sourceTimestamp;
      if (sourceTimestamp == DateTime.MinValue)
        this.m_timestamp = DateTime.UtcNow;
      this.ChangeMasks |= NodeStateChangeMasks.Value;
      return status;
    }
    if (sourceTimestamp == DateTime.MinValue)
      sourceTimestamp = DateTime.UtcNow;
    TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(value, this.m_dataType, this.m_valueRank, context.NamespaceUris, context.TypeTable);
    if (typeInfo == null || typeInfo == TypeInfo.Unknown)
    {
      if (DataTypeIds.XmlElement == (object) this.m_dataType && TypeInfo.IsInstanceOfDataType(value, DataTypeIds.UInt32, -1, context.NamespaceUris, context.TypeTable) != null)
        return (ServiceResult) (StatusCode) (uint) value;
      if (!this.m_dataType.IsNullNodeId || value != null)
        return (ServiceResult) 2155085824U /*0x80740000*/;
    }
    value = this.ExtractValueFromVariant(context, value, true);
    if (this.m_copyPolicy == VariableCopyPolicy.CopyOnWrite || this.m_copyPolicy == VariableCopyPolicy.Always)
      value = Utils.Clone(value);
    if (this.OnSimpleWriteValue != null)
    {
      if (indexRange != NumericRange.Empty)
        return (ServiceResult) 2151022592U /*0x80360000*/;
      ServiceResult status = this.OnSimpleWriteValue(context, (NodeState) this, ref value);
      if (ServiceResult.IsBad(status))
        return status;
    }
    else if (indexRange != NumericRange.Empty)
    {
      object dst = this.m_value;
      ServiceResult status = (ServiceResult) indexRange.UpdateRange(ref dst, value);
      if (ServiceResult.IsBad(status))
        return status;
      value = dst;
    }
    this.m_value = value;
    this.m_statusCode = statusCode;
    this.m_timestamp = sourceTimestamp;
    this.ChangeMasks |= NodeStateChangeMasks.Value;
    return ServiceResult.Good;
  }
}
