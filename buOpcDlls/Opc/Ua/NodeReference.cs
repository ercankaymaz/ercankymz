// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeReference
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NodeReference : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private NodeId m_referenceTypeId;
  private bool m_isForward;
  private NodeIdCollection m_referencedNodeIds;

  public NodeReference() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_referenceTypeId = (NodeId) null;
    this.m_isForward = true;
    this.m_referencedNodeIds = new NodeIdCollection();
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
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

  [DataMember(Name = "ReferencedNodeIds", IsRequired = false, Order = 4)]
  public NodeIdCollection ReferencedNodeIds
  {
    get => this.m_referencedNodeIds;
    set
    {
      this.m_referencedNodeIds = value;
      if (value != null)
        return;
      this.m_referencedNodeIds = new NodeIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NodeReference;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeReference_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeReference_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeReference_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsForward", this.IsForward);
    encoder.WriteNodeIdArray("ReferencedNodeIds", (IList<NodeId>) this.ReferencedNodeIds);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsForward = decoder.ReadBoolean("IsForward");
    this.ReferencedNodeIds = decoder.ReadNodeIdArray("ReferencedNodeIds");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NodeReference nodeReference && Utils.IsEqual((object) this.m_nodeId, (object) nodeReference.m_nodeId) && Utils.IsEqual((object) this.m_referenceTypeId, (object) nodeReference.m_referenceTypeId) && Utils.IsEqual((object) this.m_isForward, (object) nodeReference.m_isForward) && Utils.IsEqual((object) this.m_referencedNodeIds, (object) nodeReference.m_referencedNodeIds);
  }

  public virtual object Clone() => (object) (NodeReference) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeReference nodeReference = (NodeReference) base.MemberwiseClone();
    nodeReference.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    nodeReference.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    nodeReference.m_isForward = (bool) Utils.Clone((object) this.m_isForward);
    nodeReference.m_referencedNodeIds = (NodeIdCollection) Utils.Clone((object) this.m_referencedNodeIds);
    return (object) nodeReference;
  }
}
