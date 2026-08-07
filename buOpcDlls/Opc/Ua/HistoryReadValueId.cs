// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryReadValueId
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
public class HistoryReadValueId : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private string m_indexRange;
  private QualifiedName m_dataEncoding;
  private byte[] m_continuationPoint;
  private object m_handle;
  private bool m_processed;
  private NumericRange m_parsedIndexRange;

  public HistoryReadValueId() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_indexRange = (string) null;
    this.m_dataEncoding = (QualifiedName) null;
    this.m_continuationPoint = (byte[]) null;
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 2)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  [DataMember(Name = "DataEncoding", IsRequired = false, Order = 3)]
  public QualifiedName DataEncoding
  {
    get => this.m_dataEncoding;
    set => this.m_dataEncoding = value;
  }

  [DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 4)]
  public byte[] ContinuationPoint
  {
    get => this.m_continuationPoint;
    set => this.m_continuationPoint = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryReadValueId;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadValueId_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadValueId_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadValueId_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.WriteQualifiedName("DataEncoding", this.DataEncoding);
    encoder.WriteByteString("ContinuationPoint", this.ContinuationPoint);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    this.DataEncoding = decoder.ReadQualifiedName("DataEncoding");
    this.ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryReadValueId historyReadValueId && Utils.IsEqual((object) this.m_nodeId, (object) historyReadValueId.m_nodeId) && Utils.IsEqual((object) this.m_indexRange, (object) historyReadValueId.m_indexRange) && Utils.IsEqual((object) this.m_dataEncoding, (object) historyReadValueId.m_dataEncoding) && Utils.IsEqual((object) this.m_continuationPoint, (object) historyReadValueId.m_continuationPoint);
  }

  public virtual object Clone() => (object) (HistoryReadValueId) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryReadValueId historyReadValueId = (HistoryReadValueId) base.MemberwiseClone();
    historyReadValueId.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    historyReadValueId.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    historyReadValueId.m_dataEncoding = (QualifiedName) Utils.Clone((object) this.m_dataEncoding);
    historyReadValueId.m_continuationPoint = (byte[]) Utils.Clone((object) this.m_continuationPoint);
    return (object) historyReadValueId;
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

  public static ServiceResult Validate(HistoryReadValueId valueId)
  {
    if (valueId == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    if (NodeId.IsNull(valueId.NodeId))
      return (ServiceResult) 2150825984U /*0x80330000*/;
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
