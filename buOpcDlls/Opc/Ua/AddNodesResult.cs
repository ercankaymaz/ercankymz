// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesResult
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
public class AddNodesResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private NodeId m_addedNodeId;

  public AddNodesResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_addedNodeId = (NodeId) null;
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "AddedNodeId", IsRequired = false, Order = 2)]
  public NodeId AddedNodeId
  {
    get => this.m_addedNodeId;
    set => this.m_addedNodeId = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AddNodesResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteNodeId("AddedNodeId", this.AddedNodeId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.AddedNodeId = decoder.ReadNodeId("AddedNodeId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AddNodesResult addNodesResult && Utils.IsEqual((object) this.m_statusCode, (object) addNodesResult.m_statusCode) && Utils.IsEqual((object) this.m_addedNodeId, (object) addNodesResult.m_addedNodeId);
  }

  public virtual object Clone() => (object) (AddNodesResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddNodesResult addNodesResult = (AddNodesResult) base.MemberwiseClone();
    addNodesResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    addNodesResult.m_addedNodeId = (NodeId) Utils.Clone((object) this.m_addedNodeId);
    return (object) addNodesResult;
  }
}
