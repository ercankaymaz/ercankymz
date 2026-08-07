// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteNodesItem
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
public class DeleteNodesItem : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private bool m_deleteTargetReferences;

  public DeleteNodesItem() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_deleteTargetReferences = true;
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "DeleteTargetReferences", IsRequired = false, Order = 2)]
  public bool DeleteTargetReferences
  {
    get => this.m_deleteTargetReferences;
    set => this.m_deleteTargetReferences = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DeleteNodesItem;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesItem_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesItem_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesItem_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteBoolean("DeleteTargetReferences", this.DeleteTargetReferences);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.DeleteTargetReferences = decoder.ReadBoolean("DeleteTargetReferences");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DeleteNodesItem deleteNodesItem && Utils.IsEqual((object) this.m_nodeId, (object) deleteNodesItem.m_nodeId) && Utils.IsEqual((object) this.m_deleteTargetReferences, (object) deleteNodesItem.m_deleteTargetReferences);
  }

  public virtual object Clone() => (object) (DeleteNodesItem) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteNodesItem deleteNodesItem = (DeleteNodesItem) base.MemberwiseClone();
    deleteNodesItem.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    deleteNodesItem.m_deleteTargetReferences = (bool) Utils.Clone((object) this.m_deleteTargetReferences);
    return (object) deleteNodesItem;
  }
}
