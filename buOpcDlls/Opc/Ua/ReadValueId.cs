// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadValueId
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
public class ReadValueId : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private uint m_attributeId;
  private string m_indexRange;
  private QualifiedName m_dataEncoding;
  private object m_handle;
  private bool m_processed;
  private NumericRange m_parsedIndexRange = NumericRange.Empty;

  public ReadValueId() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_attributeId = 0U;
    this.m_indexRange = (string) null;
    this.m_dataEncoding = (QualifiedName) null;
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

  [DataMember(Name = "DataEncoding", IsRequired = false, Order = 4)]
  public QualifiedName DataEncoding
  {
    get => this.m_dataEncoding;
    set => this.m_dataEncoding = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadValueId;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadValueId_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadValueId_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadValueId_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.WriteQualifiedName("DataEncoding", this.DataEncoding);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    this.DataEncoding = decoder.ReadQualifiedName("DataEncoding");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ReadValueId readValueId && Utils.IsEqual((object) this.m_nodeId, (object) readValueId.m_nodeId) && Utils.IsEqual((object) this.m_attributeId, (object) readValueId.m_attributeId) && Utils.IsEqual((object) this.m_indexRange, (object) readValueId.m_indexRange) && Utils.IsEqual((object) this.m_dataEncoding, (object) readValueId.m_dataEncoding);
  }

  public virtual object Clone() => (object) (ReadValueId) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadValueId readValueId = (ReadValueId) base.MemberwiseClone();
    readValueId.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    readValueId.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    readValueId.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    readValueId.m_dataEncoding = (QualifiedName) Utils.Clone((object) this.m_dataEncoding);
    return (object) readValueId;
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

  public static ServiceResult Validate(ReadValueId valueId)
  {
    if (valueId == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    if (valueId.NodeId == (object) null)
      return (ServiceResult) 2150825984U /*0x80330000*/;
    if (!Attributes.IsValid(valueId.AttributeId))
      return (ServiceResult) 2150957056U /*0x80350000*/;
    if (valueId.AttributeId != 13U)
    {
      if (!string.IsNullOrEmpty(valueId.IndexRange))
        return (ServiceResult) 2151088128U /*0x80370000*/;
      if (!QualifiedName.IsNull(valueId.DataEncoding))
        return (ServiceResult) 2151153664U /*0x80380000*/;
    }
    valueId.ParsedIndexRange = NumericRange.Empty;
    if (!string.IsNullOrEmpty(valueId.IndexRange))
    {
      try
      {
        valueId.ParsedIndexRange = NumericRange.Parse(valueId.IndexRange);
      }
      catch (Exception ex)
      {
        string empty = string.Empty;
        object[] objArray = Array.Empty<object>();
        return ServiceResult.Create(ex, 2151022592U /*0x80360000*/, empty, objArray);
      }
    }
    else
      valueId.ParsedIndexRange = NumericRange.Empty;
    return (ServiceResult) null;
  }
}
