// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeTable : INodeTable, IEnumerable<INode>, IEnumerable
{
  private NodeIdDictionary<ILocalNode> m_localNodes;
  private SortedDictionary<ExpandedNodeId, NodeTable.RemoteNode> m_remoteNodes;
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private TypeTable m_typeTree;

  public NodeTable(NamespaceTable namespaceUris, StringTable serverUris, TypeTable typeTree)
  {
    this.m_namespaceUris = namespaceUris;
    this.m_serverUris = serverUris;
    this.m_typeTree = typeTree;
    this.m_localNodes = new NodeIdDictionary<ILocalNode>();
    this.m_remoteNodes = new SortedDictionary<ExpandedNodeId, NodeTable.RemoteNode>();
  }

  public NamespaceTable NamespaceUris => this.m_namespaceUris;

  public StringTable ServerUris => this.m_serverUris;

  public ITypeTable TypeTree => (ITypeTable) this.m_typeTree;

  public bool Exists(ExpandedNodeId nodeId) => this.InternalFind(nodeId) != null;

  public INode Find(ExpandedNodeId nodeId) => this.InternalFind(nodeId);

  public INode Find(
    ExpandedNodeId sourceId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    QualifiedName browseName)
  {
    INode node1 = this.InternalFind(sourceId);
    if (node1 == null)
      return (INode) null;
    if (!(node1 is ILocalNode localNode))
      return (INode) null;
    foreach (IReference reference in (IEnumerable<IReference>) localNode.References.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree))
    {
      INode node2 = this.InternalFind(reference.TargetId);
      if (node2 != null && (browseName == (QualifiedName) null || browseName == node2.BrowseName))
        return node2;
    }
    return (INode) null;
  }

  public IList<INode> Find(
    ExpandedNodeId sourceId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes)
  {
    IList<INode> nodeList = (IList<INode>) new List<INode>();
    INode node1 = this.InternalFind(sourceId);
    if (node1 == null || !(node1 is ILocalNode localNode))
      return nodeList;
    foreach (IReference reference in (IEnumerable<IReference>) localNode.References.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree))
    {
      INode node2 = this.InternalFind(reference.TargetId);
      if (node2 != null)
        nodeList.Add(node2);
    }
    return nodeList;
  }

  public IEnumerator<INode> GetEnumerator()
  {
    List<INode> nodeList = new List<INode>(this.Count);
    foreach (INode node in (IEnumerable<ILocalNode>) this.m_localNodes.Values)
      nodeList.Add(node);
    foreach (INode node in this.m_remoteNodes.Values)
      nodeList.Add(node);
    return (IEnumerator<INode>) nodeList.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public int Count => this.m_localNodes.Count + this.m_remoteNodes.Count;

  public List<Node> Import(
    NodeSet nodeSet,
    IDictionary<NodeId, IList<IReference>> externalReferences)
  {
    List<Node> nodeList = new List<Node>();
    if (nodeSet == null)
      return nodeList;
    foreach (Node node1 in (List<Node>) nodeSet.Nodes)
    {
      if (node1 != null && !NodeId.IsNull(node1.NodeId))
      {
        Node node2 = nodeSet.Copy(node1, this.m_namespaceUris, this.m_serverUris);
        if (QualifiedName.IsNull(node2.BrowseName))
          node2.BrowseName = new QualifiedName(node2.NodeId.ToString(), (ushort) 1);
        if (LocalizedText.IsNullOrEmpty(node2.DisplayName))
          node2.DisplayName = new LocalizedText(node2.BrowseName.Name);
        foreach (ReferenceNode reference in (List<ReferenceNode>) node2.References)
        {
          if (!NodeId.IsNull(reference.ReferenceTypeId) && !NodeId.IsNull(reference.TargetId))
          {
            ExpandedNodeId targetId = reference.TargetId;
            if (!NodeId.IsNull(targetId))
            {
              node2.ReferenceTable.Add(reference.ReferenceTypeId, reference.IsInverse, targetId);
              if (targetId.ServerIndex != 0U)
              {
                if (!(this.Find(targetId) is NodeTable.RemoteNode node3))
                {
                  node3 = new NodeTable.RemoteNode((INodeTable) this, targetId);
                  this.InternalAdd(node3);
                }
                node3.AddRef();
              }
            }
          }
        }
        node2.References.Clear();
        this.InternalAdd((ILocalNode) node2);
        nodeList.Add(node2);
      }
    }
    foreach (Node node4 in nodeList)
    {
      if (node4 != null && !NodeId.IsNull(node4.NodeId))
      {
        foreach (IReference reference in node4.ReferenceTable)
        {
          if (!(this.Find(reference.TargetId) is Node node5))
          {
            if (reference.TargetId.ServerIndex == 0U && externalReferences != null)
            {
              NodeId nodeId = ExpandedNodeId.ToNodeId(reference.TargetId, this.m_namespaceUris);
              if (!(nodeId == (object) null))
              {
                IList<IReference> referenceList = (IList<IReference>) null;
                if (!externalReferences.TryGetValue(nodeId, out referenceList))
                  externalReferences[nodeId] = referenceList = (IList<IReference>) new List<IReference>();
                referenceList.Add((IReference) new ReferenceNode()
                {
                  ReferenceTypeId = reference.ReferenceTypeId,
                  IsInverse = !reference.IsInverse,
                  TargetId = (ExpandedNodeId) node4.NodeId
                });
              }
            }
          }
          else if (reference.ReferenceTypeId != (object) ReferenceTypeIds.HasTypeDefinition && reference.ReferenceTypeId != (object) ReferenceTypeIds.HasModellingRule)
            node5.ReferenceTable.Add(reference.ReferenceTypeId, !reference.IsInverse, (ExpandedNodeId) node4.NodeId);
        }
        if (this.m_typeTree != null)
          this.m_typeTree.Add((ILocalNode) node4);
      }
    }
    return nodeList;
  }

  public INode Import(ReferenceDescription reference)
  {
    INode node1 = this.Find(reference.NodeId);
    if (node1 == null)
    {
      if (reference.NodeId.ServerIndex != 0U)
      {
        NodeTable.RemoteNode node2 = new NodeTable.RemoteNode((INodeTable) this, reference.NodeId);
        this.InternalAdd(node2);
        node1 = (INode) node2;
      }
      else
      {
        Node node3 = new Node();
        node3.NodeId = ExpandedNodeId.ToNodeId(reference.NodeId, this.m_namespaceUris);
        this.InternalAdd((ILocalNode) node3);
        node1 = (INode) node3;
      }
    }
    if (node1 is Node node4)
    {
      node4.NodeClass = reference.NodeClass;
      node4.BrowseName = reference.BrowseName;
      node4.DisplayName = reference.DisplayName;
      if (!NodeId.IsNull(reference.TypeDefinition))
        node4.ReferenceTable.Add(ReferenceTypeIds.HasTypeDefinition, false, reference.TypeDefinition);
      return (INode) node4;
    }
    if (!(node1 is NodeTable.RemoteNode remoteNode))
      return (INode) null;
    remoteNode.NodeClass = reference.NodeClass;
    remoteNode.BrowseName = reference.BrowseName;
    remoteNode.DisplayName = reference.DisplayName;
    remoteNode.TypeDefinitionId = reference.TypeDefinition;
    return (INode) remoteNode;
  }

  public void Attach(ILocalNode node)
  {
    if (this.Exists((ExpandedNodeId) node.NodeId))
      this.Remove((ExpandedNodeId) node.NodeId);
    if (node is Node node2 && node2.References.Count > 0 && node2.ReferenceTable.Count == 0)
    {
      foreach (ReferenceNode reference in (IEnumerable<IReference>) node.References)
      {
        if (!NodeId.IsNull(reference.ReferenceTypeId) && !NodeId.IsNull(reference.TargetId))
        {
          node.References.Add(reference.ReferenceTypeId, reference.IsInverse, reference.TargetId);
          if (reference.TargetId.ServerIndex != 0U)
          {
            if (!(this.Find(reference.TargetId) is NodeTable.RemoteNode node1))
            {
              node1 = new NodeTable.RemoteNode((INodeTable) this, reference.TargetId);
              this.InternalAdd(node1);
            }
            node1.AddRef();
          }
        }
      }
      node.References.Clear();
    }
    this.InternalAdd(node);
    foreach (IReference reference in (IEnumerable<IReference>) node.References)
    {
      if (this.Find(reference.TargetId) is ILocalNode localNode && reference.ReferenceTypeId != (object) ReferenceTypeIds.HasTypeDefinition && reference.ReferenceTypeId != (object) ReferenceTypeIds.HasModellingRule)
        localNode.References.Add(reference.ReferenceTypeId, !reference.IsInverse, (ExpandedNodeId) node.NodeId);
    }
    if (this.m_typeTree == null)
      return;
    this.m_typeTree.Add(node);
  }

  public bool Remove(ExpandedNodeId nodeId)
  {
    INode node1 = this.Find(nodeId);
    if (node1 == null || !(node1 is ILocalNode node2))
      return false;
    foreach (IReference reference in (IEnumerable<IReference>) node2.References)
    {
      INode node3 = this.InternalFind(reference.TargetId);
      if (node3 != null)
      {
        if (node3 is NodeTable.RemoteNode node4)
        {
          if (node4.Release() == 0)
            this.InternalRemove(node4);
        }
        else if (node3 is ILocalNode localNode)
          localNode.References.Remove(reference.ReferenceTypeId, reference.IsInverse, (ExpandedNodeId) node2.NodeId);
      }
    }
    this.InternalRemove(node2);
    return true;
  }

  public void Clear()
  {
    this.m_localNodes.Clear();
    this.m_remoteNodes.Clear();
  }

  private void InternalAdd(ILocalNode node)
  {
    if (node == null || node.NodeId == (object) null)
      return;
    this.m_localNodes.Add(node.NodeId, node);
  }

  private void InternalRemove(ILocalNode node)
  {
    if (node == null || node.NodeId == (object) null)
      return;
    this.m_localNodes.Remove(node.NodeId);
  }

  private void InternalAdd(NodeTable.RemoteNode node)
  {
    if (node == null || node.NodeId == (object) null)
      return;
    this.m_remoteNodes[node.NodeId] = node;
  }

  private void InternalRemove(NodeTable.RemoteNode node)
  {
    if (node == null || node.NodeId == (object) null)
      return;
    this.m_remoteNodes.Remove(node.NodeId);
  }

  private INode InternalFind(ExpandedNodeId nodeId)
  {
    if (nodeId == (object) null)
      return (INode) null;
    if (nodeId.ServerIndex != 0U)
    {
      NodeTable.RemoteNode remoteNode = (NodeTable.RemoteNode) null;
      return this.m_remoteNodes.TryGetValue(nodeId, out remoteNode) ? (INode) remoteNode : (INode) null;
    }
    NodeId nodeId1 = ExpandedNodeId.ToNodeId(nodeId, this.m_namespaceUris);
    if (nodeId1 == (object) null)
      return (INode) null;
    ILocalNode localNode = (ILocalNode) null;
    return this.m_localNodes.TryGetValue(nodeId1, out localNode) ? (INode) localNode : (INode) null;
  }

  private class RemoteNode : INode
  {
    private ExpandedNodeId m_nodeId;
    private NodeClass m_nodeClass;
    private QualifiedName m_browseName;
    private LocalizedText m_displayName;
    private ExpandedNodeId m_typeDefinitionId;
    private int m_refs;

    public RemoteNode(INodeTable owner, ExpandedNodeId nodeId)
    {
      this.m_nodeId = nodeId;
      this.m_refs = 0;
      this.m_nodeClass = NodeClass.Unspecified;
      this.m_browseName = new QualifiedName("(Unknown)");
      this.m_displayName = new LocalizedText(this.m_browseName.Name);
      this.m_typeDefinitionId = (ExpandedNodeId) null;
    }

    public int AddRef() => ++this.m_refs;

    public int Release()
    {
      if (this.m_refs == 0)
        throw new InvalidOperationException("Cannot decrement reference count below zero.");
      return --this.m_refs;
    }

    public ExpandedNodeId TypeDefinitionId
    {
      get => this.m_typeDefinitionId;
      internal set => this.m_typeDefinitionId = value;
    }

    public ExpandedNodeId NodeId => this.m_nodeId;

    public NodeClass NodeClass
    {
      get => this.m_nodeClass;
      internal set => this.m_nodeClass = value;
    }

    public QualifiedName BrowseName
    {
      get => this.m_browseName;
      internal set => this.m_browseName = value;
    }

    public LocalizedText DisplayName
    {
      get => this.m_displayName;
      internal set => this.m_displayName = value;
    }
  }
}
