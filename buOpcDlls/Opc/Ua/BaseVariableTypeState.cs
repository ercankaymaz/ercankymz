// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseVariableTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
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

  protected BaseVariableTypeState()
    : base(NodeClass.VariableType)
  {
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is BaseVariableTypeState variableTypeState)
    {
      this.m_value = Utils.Clone(variableTypeState.m_value);
      this.m_dataType = variableTypeState.m_dataType;
      this.m_valueRank = variableTypeState.m_valueRank;
      this.m_arrayDimensions = (ReadOnlyList<uint>) null;
      if (variableTypeState.m_arrayDimensions != null)
        this.m_arrayDimensions = new ReadOnlyList<uint>((IList<uint>) variableTypeState.m_arrayDimensions, true);
    }
    this.m_value = this.ExtractValueFromVariant(context, this.m_value, false);
    base.Initialize(context, source);
  }

  protected virtual object ExtractValueFromVariant(
    ISystemContext context,
    object value,
    bool throwOnError)
  {
    return value;
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
  }

  public object Value
  {
    get => this.m_value;
    set
    {
      if (this.m_value != value)
        this.ChangeMasks |= NodeStateChangeMasks.Value;
      this.m_value = value;
    }
  }

  public Variant WrappedValue
  {
    get => new Variant(this.m_value);
    set => this.Value = this.ExtractValueFromVariant((ISystemContext) null, value.Value, false);
  }

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

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is VariableTypeNode variableTypeNode))
      return;
    variableTypeNode.Value = new Variant(Utils.Clone(this.Value));
    variableTypeNode.DataType = this.DataType;
    variableTypeNode.ValueRank = this.ValueRank;
    variableTypeNode.ArrayDimensions = (UInt32Collection) null;
    if (this.ArrayDimensions == null)
      return;
    variableTypeNode.ArrayDimensions = new UInt32Collection((IEnumerable<uint>) this.ArrayDimensions);
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (this.m_value != null)
      encoder.WriteVariant("Value", this.WrappedValue);
    if (!NodeId.IsNull(this.DataType))
      encoder.WriteNodeId("DataType", this.DataType);
    if (this.ValueRank != -2)
      encoder.WriteInt32("ValueRank", this.ValueRank);
    if (this.ArrayDimensions != null)
      encoder.WriteString("ArrayDimensions", BaseVariableState.ArrayDimensionsToXml((IList<uint>) this.ArrayDimensions));
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("Value"))
      this.WrappedValue = decoder.ReadVariant("Value");
    if (decoder.Peek("DataType"))
      this.DataType = decoder.ReadNodeId("DataType");
    if (decoder.Peek("ValueRank"))
      this.ValueRank = decoder.ReadInt32("ValueRank");
    if (decoder.Peek("ArrayDimensions"))
      this.ArrayDimensions = BaseVariableState.ArrayDimensionsFromXml(decoder.ReadString("ArrayDimensions"));
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.WrappedValue != Variant.Null)
      attributesToSave |= NodeState.AttributesToSave.Value;
    if (!NodeId.IsNull(this.m_dataType))
      attributesToSave |= NodeState.AttributesToSave.DataType;
    if (this.m_valueRank != -2)
      attributesToSave |= NodeState.AttributesToSave.ValueRank;
    if (this.m_arrayDimensions != null)
      attributesToSave |= NodeState.AttributesToSave.ArrayDimensions;
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
    if ((attributesToSave & NodeState.AttributesToSave.DataType) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_dataType);
    if ((attributesToSave & NodeState.AttributesToSave.ValueRank) != NodeState.AttributesToSave.None)
      encoder.WriteInt32((string) null, this.m_valueRank);
    if ((attributesToSave & NodeState.AttributesToSave.ArrayDimensions) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteUInt32Array((string) null, (IList<uint>) this.m_arrayDimensions);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attibutesToLoad)
  {
    base.Update(context, decoder, attibutesToLoad);
    if ((attibutesToLoad & NodeState.AttributesToSave.Value) != NodeState.AttributesToSave.None)
      this.WrappedValue = decoder.ReadVariant((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.DataType) != NodeState.AttributesToSave.None)
      this.m_dataType = decoder.ReadNodeId((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.ValueRank) != NodeState.AttributesToSave.None)
      this.m_valueRank = decoder.ReadInt32((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.ArrayDimensions) == NodeState.AttributesToSave.None)
      return;
    UInt32Collection list = decoder.ReadUInt32Array((string) null);
    if (list != null && list.Count > 0)
      this.m_arrayDimensions = new ReadOnlyList<uint>((IList<uint>) list);
    else
      this.m_arrayDimensions = (ReadOnlyList<uint>) null;
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
    value = this.m_value;
    ServiceResult good = ServiceResult.Good;
    VariableCopyPolicy variableCopyPolicy = VariableCopyPolicy.CopyOnRead;
    if (this.OnSimpleReadValue != null)
    {
      ServiceResult status = this.OnSimpleReadValue(context, (NodeState) this, ref value);
      if (ServiceResult.IsBad(status))
        return status;
      variableCopyPolicy = VariableCopyPolicy.Never;
    }
    else if (value == null)
      return (ServiceResult) 2150957056U /*0x80350000*/;
    ServiceResult status1 = BaseVariableState.ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
    if (ServiceResult.IsBad(status1) || variableCopyPolicy != VariableCopyPolicy.CopyOnRead)
      return status1;
    value = Utils.Clone(value);
    return status1;
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
        int? nullable = value as int?;
        if (!nullable.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.ValueRank) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        int num = nullable.Value;
        if (this.OnWriteValueRank != null)
          status = this.OnWriteValueRank(context, (NodeState) this, ref num);
        if (ServiceResult.IsGood(status))
          this.ValueRank = num;
        return status;
      case 16 /*0x10*/:
        IList<uint> list = value as IList<uint>;
        if ((this.WriteMask & AttributeWriteMask.ArrayDimensions) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteArrayDimensions != null)
          status = this.OnWriteArrayDimensions(context, (NodeState) this, ref list);
        if (ServiceResult.IsGood(status))
        {
          if (list != null)
            this.m_arrayDimensions = new ReadOnlyList<uint>(list);
          else
            this.ArrayDimensions = (ReadOnlyList<uint>) null;
        }
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
    if ((this.WriteMask & AttributeWriteMask.ValueForVariableType) == AttributeWriteMask.None)
      return (ServiceResult) 2151350272U /*0x803B0000*/;
    if (sourceTimestamp == DateTime.MinValue)
      sourceTimestamp = DateTime.UtcNow;
    if (indexRange != NumericRange.Empty)
      return (ServiceResult) 2151022592U /*0x80360000*/;
    TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(value, this.m_dataType, this.m_valueRank, context.NamespaceUris, context.TypeTable);
    if (typeInfo == null || typeInfo == TypeInfo.Unknown)
      return (ServiceResult) 2155085824U /*0x80740000*/;
    if (this.OnSimpleWriteValue != null)
    {
      ServiceResult status = this.OnSimpleWriteValue(context, (NodeState) this, ref value);
      if (ServiceResult.IsBad(status))
        return status;
    }
    this.Value = value;
    return ServiceResult.Good;
  }
}
