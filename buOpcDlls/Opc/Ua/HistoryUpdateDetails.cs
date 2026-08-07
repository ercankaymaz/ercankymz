// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryUpdateDetails
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
public class HistoryUpdateDetails : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private object m_handle;
  private bool m_processed;

  public HistoryUpdateDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_nodeId = (NodeId) null;

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryUpdateDetails;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateDetails_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateDetails_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateDetails_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryUpdateDetails historyUpdateDetails && Utils.IsEqual((object) this.m_nodeId, (object) historyUpdateDetails.m_nodeId);
  }

  public virtual object Clone() => (object) (HistoryUpdateDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryUpdateDetails historyUpdateDetails = (HistoryUpdateDetails) base.MemberwiseClone();
    historyUpdateDetails.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    return (object) historyUpdateDetails;
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

  public static ServiceResult Validate(HistoryUpdateDetails valueId)
  {
    if (valueId == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    return NodeId.IsNull(valueId.NodeId) ? (ServiceResult) 2150825984U /*0x80330000*/ : (ServiceResult) null;
  }
}
