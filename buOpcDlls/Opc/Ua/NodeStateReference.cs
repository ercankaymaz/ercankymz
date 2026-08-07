// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeStateReference
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateReference : IReference
{
  private NodeId m_referenceTypeId;
  private bool m_isInverse;
  private ExpandedNodeId m_targetId;
  private NodeState m_target;

  public NodeStateReference(NodeId referenceTypeId, bool isInverse, NodeState target)
  {
    this.m_referenceTypeId = referenceTypeId;
    this.m_isInverse = isInverse;
    this.m_targetId = (ExpandedNodeId) target.NodeId;
    this.m_target = target;
  }

  public NodeStateReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    this.m_referenceTypeId = referenceTypeId;
    this.m_isInverse = isInverse;
    this.m_targetId = targetId;
    this.m_target = (NodeState) null;
  }

  public NodeState Target => this.m_target;

  public NodeId ReferenceTypeId => this.m_referenceTypeId;

  public bool IsInverse => this.m_isInverse;

  public ExpandedNodeId TargetId => this.m_targetId;
}
