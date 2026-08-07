// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriteValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class WriteValue : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private uint m_attributeId;
  private string m_indexRange;
  private DataValue m_value;
  private object m_handle;
  private bool m_processed;
  private NumericRange m_parsedIndexRange = NumericRange.Empty;

  public WriteValue() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_attributeId = 0U;
    this.m_indexRange = (string) null;
    this.m_value = new DataValue();
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 2)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 3)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 4)]
  public DataValue Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.WriteValue;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteValue_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteValue_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteValue_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.WriteDataValue("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    this.Value = decoder.ReadDataValue("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is WriteValue writeValue && Utils.IsEqual((object) this.m_nodeId, (object) writeValue.m_nodeId) && Utils.IsEqual((object) this.m_attributeId, (object) writeValue.m_attributeId) && Utils.IsEqual((object) this.m_indexRange, (object) writeValue.m_indexRange) && Utils.IsEqual((object) this.m_value, (object) writeValue.m_value);
  }

  public virtual object Clone() => (object) (WriteValue) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriteValue writeValue = (WriteValue) base.MemberwiseClone();
    writeValue.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    writeValue.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    writeValue.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    writeValue.m_value = (DataValue) Utils.Clone((object) this.m_value);
    return (object) writeValue;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public bool Processed
  {
    get => this.m_processed;
    set => this.m_processed = value;
  }

  public NumericRange ParsedIndexRange
  {
    get => this.m_parsedIndexRange;
    set => this.m_parsedIndexRange = value;
  }

  public static ServiceResult Validate(WriteValue value)
  {
    if (value == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    if (value.NodeId == (object) null)
      return (ServiceResult) 2150825984U /*0x80330000*/;
    if (!Attributes.IsValid(value.AttributeId))
      return (ServiceResult) 2150957056U /*0x80350000*/;
    value.ParsedIndexRange = NumericRange.Empty;
    if (!string.IsNullOrEmpty(value.IndexRange))
    {
      try
      {
        value.ParsedIndexRange = NumericRange.Parse(value.IndexRange);
      }
      catch (Exception ex)
      {
        string empty = string.Empty;
        object[] objArray = Array.Empty<object>();
        return ServiceResult.Create(ex, 2151022592U /*0x80360000*/, empty, objArray);
      }
      if (value.ParsedIndexRange.SubRanges != null)
      {
        if (!(value.Value.Value is Matrix))
        {
          Variant wrappedValue;
          int num;
          if (value.Value.Value is Array)
          {
            wrappedValue = value.Value.WrappedValue;
            if (wrappedValue.TypeInfo.BuiltInType == BuiltInType.String)
            {
              num = 1;
              goto label_15;
            }
          }
          wrappedValue = value.Value.WrappedValue;
          num = wrappedValue.TypeInfo.BuiltInType == BuiltInType.ByteString ? 1 : 0;
label_15:
          if (num == 0)
            return (ServiceResult) 2155085824U /*0x80740000*/;
        }
      }
      else if (value.Value.Value is Array array)
      {
        NumericRange parsedIndexRange = value.ParsedIndexRange;
        if (parsedIndexRange.End >= 0 && parsedIndexRange.End - parsedIndexRange.Begin != array.Length - 1)
          return (ServiceResult) 2151088128U /*0x80370000*/;
        if (parsedIndexRange.End < 0 && array.Length != 1)
          return (ServiceResult) 2151022592U /*0x80360000*/;
      }
      else
      {
        if (!(value.Value.Value is string str))
          return (ServiceResult) 2155085824U /*0x80740000*/;
        NumericRange parsedIndexRange = value.ParsedIndexRange;
        if (parsedIndexRange.End >= 0 && parsedIndexRange.End - parsedIndexRange.Begin != str.Length - 1)
          return (ServiceResult) 2151088128U /*0x80370000*/;
        if (parsedIndexRange.End < 0 && str.Length != 1)
          return (ServiceResult) 2151022592U /*0x80360000*/;
      }
    }
    else
      value.ParsedIndexRange = NumericRange.Empty;
    return (ServiceResult) null;
  }
}
