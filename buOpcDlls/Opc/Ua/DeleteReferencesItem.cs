// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteReferencesItem
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
public class DeleteReferencesItem : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_sourceNodeId;
  private NodeId m_referenceTypeId;
  private bool m_isForward;
  private ExpandedNodeId m_targetNodeId;
  private bool m_deleteBidirectional;

  public DeleteReferencesItem() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sourceNodeId = (NodeId) null;
    this.m_referenceTypeId = (NodeId) null;
    this.m_isForward = true;
    this.m_targetNodeId = (ExpandedNodeId) null;
    this.m_deleteBidirectional = true;
  }

  [DataMember(Name = "SourceNodeId", IsRequired = false, Order = 1)]
  public NodeId SourceNodeId
  {
    get => this.m_sourceNodeId;
    set => this.m_sourceNodeId = value;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 2)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IsForward", IsRequired = false, Order = 3)]
  public bool IsForward
  {
    get => this.m_isForward;
    set => this.m_isForward = value;
  }

  [DataMember(Name = "TargetNodeId", IsRequired = false, Order = 4)]
  public ExpandedNodeId TargetNodeId
  {
    get => this.m_targetNodeId;
    set => this.m_targetNodeId = value;
  }

  [DataMember(Name = "DeleteBidirectional", IsRequired = false, Order = 5)]
  public bool DeleteBidirectional
  {
    get => this.m_deleteBidirectional;
    set => this.m_deleteBidirectional = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DeleteReferencesItem;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteReferencesItem_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteReferencesItem_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteReferencesItem_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("SourceNodeId", this.SourceNodeId);
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsForward", this.IsForward);
    encoder.WriteExpandedNodeId("TargetNodeId", this.TargetNodeId);
    encoder.WriteBoolean("DeleteBidirectional", this.DeleteBidirectional);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SourceNodeId = decoder.ReadNodeId("SourceNodeId");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsForward = decoder.ReadBoolean("IsForward");
    this.TargetNodeId = decoder.ReadExpandedNodeId("TargetNodeId");
    this.DeleteBidirectional = decoder.ReadBoolean("DeleteBidirectional");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DeleteReferencesItem deleteReferencesItem && Utils.IsEqual((object) this.m_sourceNodeId, (object) deleteReferencesItem.m_sourceNodeId) && Utils.IsEqual((object) this.m_referenceTypeId, (object) deleteReferencesItem.m_referenceTypeId) && Utils.IsEqual((object) this.m_isForward, (object) deleteReferencesItem.m_isForward) && Utils.IsEqual((object) this.m_targetNodeId, (object) deleteReferencesItem.m_targetNodeId) && Utils.IsEqual((object) this.m_deleteBidirectional, (object) deleteReferencesItem.m_deleteBidirectional);
  }

  public virtual object Clone() => (object) (DeleteReferencesItem) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteReferencesItem deleteReferencesItem = (DeleteReferencesItem) base.MemberwiseClone();
    deleteReferencesItem.m_sourceNodeId = (NodeId) Utils.Clone((object) this.m_sourceNodeId);
    deleteReferencesItem.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    deleteReferencesItem.m_isForward = (bool) Utils.Clone((object) this.m_isForward);
    deleteReferencesItem.m_targetNodeId = (ExpandedNodeId) Utils.Clone((object) this.m_targetNodeId);
    deleteReferencesItem.m_deleteBidirectional = (bool) Utils.Clone((object) this.m_deleteBidirectional);
    return (object) deleteReferencesItem;
  }
}
