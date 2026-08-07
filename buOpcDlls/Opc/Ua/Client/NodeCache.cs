// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.NodeCache
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class NodeCache : INodeCache, INodeTable, ITypeTable, IDisposable
{
  private ReaderWriterLockSlim m_cacheLock = new ReaderWriterLockSlim();
  private ISession m_session;
  private TypeTable m_typeTree;
  private NodeTable m_nodes;
  private bool m_uaTypesLoaded;

  public NodeCache(ISession session)
  {
    this.m_session = session != null ? session : throw new ArgumentNullException(nameof (session));
    this.m_typeTree = new TypeTable(this.m_session.NamespaceUris);
    this.m_nodes = new NodeTable(this.m_session.NamespaceUris, this.m_session.ServerUris, this.m_typeTree);
    this.m_uaTypesLoaded = false;
    this.m_cacheLock = new ReaderWriterLockSlim();
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.m_session = (ISession) null;
    this.m_cacheLock?.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  public NamespaceTable NamespaceUris => this.m_session.NamespaceUris;

  public StringTable ServerUris => this.m_session.ServerUris;

  public ITypeTable TypeTree => (ITypeTable) this;

  public bool Exists(ExpandedNodeId nodeId) => this.Find(nodeId) != null;

  public INode Find(ExpandedNodeId nodeId)
  {
    if (NodeId.IsNull(nodeId))
      return (INode) null;
    INode node;
    try
    {
      this.m_cacheLock.EnterReadLock();
      node = this.m_nodes.Find(nodeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    if (node != null && node.GetType() != typeof (Opc.Ua.Node))
      return node;
    try
    {
      return (INode) this.FetchNode(nodeId);
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch node from server: NodeId={0}, Reason='{1}'.", (object) nodeId, (object) ex.Message);
      return (INode) null;
    }
  }

  public IList<INode> Find(IList<ExpandedNodeId> nodeIds)
  {
    if (nodeIds == null || nodeIds.Count == 0)
      return (IList<INode>) new List<INode>();
    int count = nodeIds.Count;
    IList<INode> nodeList1 = (IList<INode>) new List<INode>(count);
    ExpandedNodeIdCollection nodeIds1 = new ExpandedNodeIdCollection();
    for (int index = 0; index < count; ++index)
    {
      INode node;
      try
      {
        this.m_cacheLock.EnterReadLock();
        node = this.m_nodes.Find(nodeIds[index]);
      }
      finally
      {
        this.m_cacheLock.ExitReadLock();
      }
      if (node != null && node?.GetType() != typeof (Opc.Ua.Node))
      {
        nodeList1.Add(node);
      }
      else
      {
        nodeList1.Add((INode) null);
        nodeIds1.Add(nodeIds[index]);
      }
    }
    if (nodeIds1.Count == 0)
      return nodeList1;
    IList<Opc.Ua.Node> nodeList2;
    try
    {
      nodeList2 = this.FetchNodes((IList<ExpandedNodeId>) nodeIds1);
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch nodes from server: Reason='{0}'.", (object) ex.Message);
      return nodeList1;
    }
    int index1 = 0;
    foreach (Opc.Ua.Node node in (IEnumerable<Opc.Ua.Node>) nodeList2)
    {
      while (index1 < count && nodeList1[index1] != null)
        ++index1;
      if (index1 < count && nodeList1[index1] == null)
      {
        nodeList1[index1++] = (INode) node;
      }
      else
      {
        Utils.LogError("Inconsistency fetching nodes from server. Not all nodes could be assigned.");
        break;
      }
    }
    return nodeList1;
  }

  public INode Find(
    ExpandedNodeId sourceId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    QualifiedName browseName)
  {
    if (!(this.Find(sourceId) is Opc.Ua.Node node1))
      return (INode) null;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = node1.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      INode node2 = this.Find(reference.TargetId);
      if (node2 != null && node2.BrowseName == browseName)
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
    List<INode> nodeList = new List<INode>();
    if (!(this.Find(sourceId) is Opc.Ua.Node node1))
      return (IList<INode>) nodeList;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = node1.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      INode node2 = this.Find(reference.TargetId);
      if (node2 != null)
        nodeList.Add(node2);
    }
    return (IList<INode>) nodeList;
  }

  public bool IsKnown(ExpandedNodeId typeId)
  {
    if (this.Find(typeId) == null)
      return false;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.IsKnown(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public bool IsKnown(NodeId typeId)
  {
    if (this.Find((ExpandedNodeId) typeId) == null)
      return false;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.IsKnown(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public NodeId FindSuperType(ExpandedNodeId typeId)
  {
    if (this.Find(typeId) == null)
      return (NodeId) null;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindSuperType(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public NodeId FindSuperType(NodeId typeId)
  {
    if (this.Find((ExpandedNodeId) typeId) == null)
      return (NodeId) null;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindSuperType(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public IList<NodeId> FindSubTypes(ExpandedNodeId typeId)
  {
    if (!(this.Find(typeId) is ILocalNode localNode))
      return (IList<NodeId>) new List<NodeId>();
    List<NodeId> subTypes = new List<NodeId>();
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = localNode.References.Find(ReferenceTypeIds.HasSubtype, false, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      if (!reference.TargetId.IsAbsolute)
        subTypes.Add((NodeId) reference.TargetId);
    }
    return (IList<NodeId>) subTypes;
  }

  public bool IsTypeOf(ExpandedNodeId subTypeId, ExpandedNodeId superTypeId)
  {
    if (subTypeId == (object) superTypeId)
      return true;
    if (!(this.Find(subTypeId) is ILocalNode localNode1))
      return false;
    ExpandedNodeId target;
    for (ILocalNode localNode2 = localNode1; localNode2 != null; localNode2 = this.Find(target) as ILocalNode)
    {
      try
      {
        this.m_cacheLock.EnterReadLock();
        target = localNode2.References.FindTarget(ReferenceTypeIds.HasSubtype, true, true, (ITypeTable) this.m_typeTree, 0);
      }
      finally
      {
        this.m_cacheLock.ExitReadLock();
      }
      if (target == (object) superTypeId)
        return true;
    }
    return false;
  }

  public bool IsTypeOf(NodeId subTypeId, NodeId superTypeId)
  {
    if (subTypeId == (object) superTypeId)
      return true;
    if (!(this.Find((ExpandedNodeId) subTypeId) is ILocalNode localNode1))
      return false;
    ExpandedNodeId target;
    for (ILocalNode localNode2 = localNode1; localNode2 != null; localNode2 = this.Find(target) as ILocalNode)
    {
      try
      {
        this.m_cacheLock.EnterReadLock();
        target = localNode2.References.FindTarget(ReferenceTypeIds.HasSubtype, true, true, (ITypeTable) this.m_typeTree, 0);
      }
      finally
      {
        this.m_cacheLock.ExitReadLock();
      }
      if (target == (object) superTypeId)
        return true;
    }
    return false;
  }

  public QualifiedName FindReferenceTypeName(NodeId referenceTypeId)
  {
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindReferenceTypeName(referenceTypeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public NodeId FindReferenceType(QualifiedName browseName)
  {
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindReferenceType(browseName);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public bool IsEncodingOf(ExpandedNodeId encodingId, ExpandedNodeId datatypeId)
  {
    if (!(this.Find(encodingId) is ILocalNode localNode))
      return false;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = localNode.References.Find(ReferenceTypeIds.HasEncoding, true, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      if (reference.TargetId == (object) datatypeId)
        return true;
    }
    return false;
  }

  public bool IsEncodingFor(NodeId expectedTypeId, ExtensionObject value)
  {
    if (value == null)
      return false;
    if (expectedTypeId == (object) value.TypeId)
      return true;
    if (!(this.Find(value.TypeId) is ILocalNode localNode))
      return false;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = localNode.References.Find(ReferenceTypeIds.HasEncoding, true, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      if (reference.TargetId == (object) expectedTypeId)
        return true;
    }
    return false;
  }

  public bool IsEncodingFor(NodeId expectedTypeId, object value)
  {
    if (value == null)
      return false;
    if (NodeId.IsNull(expectedTypeId))
      return true;
    NodeId dataTypeId = Opc.Ua.TypeInfo.GetDataTypeId(value);
    if (this.IsTypeOf(dataTypeId, expectedTypeId))
      return true;
    if (dataTypeId != (object) 22U)
      return this.IsTypeOf(expectedTypeId, dataTypeId);
    switch (value)
    {
      case ExtensionObject extensionObject:
        return this.IsEncodingFor(expectedTypeId, extensionObject);
      case ExtensionObject[] extensionObjectArray:
        for (int index = 0; index < extensionObjectArray.Length; ++index)
        {
          if (!this.IsEncodingFor(expectedTypeId, extensionObjectArray[index]))
            return false;
        }
        return true;
      default:
        return false;
    }
  }

  public NodeId FindDataTypeId(ExpandedNodeId encodingId)
  {
    if (!(this.Find(encodingId) is ILocalNode localNode))
      return NodeId.Null;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = localNode.References.Find(ReferenceTypeIds.HasEncoding, true, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    return referenceList.Count > 0 ? ExpandedNodeId.ToNodeId(referenceList[0].TargetId, this.m_session.NamespaceUris) : NodeId.Null;
  }

  public NodeId FindDataTypeId(NodeId encodingId)
  {
    if (!(this.Find((ExpandedNodeId) encodingId) is ILocalNode localNode))
      return NodeId.Null;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = localNode.References.Find(ReferenceTypeIds.HasEncoding, true, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    return referenceList.Count > 0 ? ExpandedNodeId.ToNodeId(referenceList[0].TargetId, this.m_session.NamespaceUris) : NodeId.Null;
  }

  public void LoadUaDefinedTypes(ISystemContext context)
  {
    if (this.m_uaTypesLoaded)
      return;
    NodeStateCollection nodeStateCollection = new NodeStateCollection();
    Assembly assembly = typeof (ArgumentCollection).GetTypeInfo().Assembly;
    nodeStateCollection.LoadFromBinaryResource(context, "Opc.Ua.Stack.Generated.Opc.Ua.PredefinedNodes.uanodes", assembly, true);
    try
    {
      this.m_cacheLock.EnterWriteLock();
      for (int index = 0; index < nodeStateCollection.Count; ++index)
      {
        if (nodeStateCollection[index] is BaseTypeState baseTypeState)
          baseTypeState.Export(context, this.m_nodes);
      }
    }
    finally
    {
      this.m_cacheLock.ExitWriteLock();
    }
    this.m_uaTypesLoaded = true;
  }

  public void Clear()
  {
    this.m_uaTypesLoaded = false;
    try
    {
      this.m_cacheLock.EnterWriteLock();
      this.m_nodes.Clear();
    }
    finally
    {
      this.m_cacheLock.ExitWriteLock();
    }
  }

  public Opc.Ua.Node FetchNode(ExpandedNodeId nodeId)
  {
    NodeId nodeId1 = ExpandedNodeId.ToNodeId(nodeId, this.m_session.NamespaceUris);
    if (nodeId1 == (object) null)
      return (Opc.Ua.Node) null;
    Opc.Ua.Node node = this.m_session.ReadNode(nodeId1);
    try
    {
      ReferenceDescriptionCollection descriptionCollection = this.m_session.FetchReferences(nodeId1);
      try
      {
        this.m_cacheLock.EnterUpgradeableReadLock();
        foreach (ReferenceDescription reference in (List<ReferenceDescription>) descriptionCollection)
        {
          if (!this.m_nodes.Exists(reference.NodeId))
          {
            if (reference.NodeId != (object) null && reference.NodeId.IsAbsolute)
              reference.NodeId = (ExpandedNodeId) ExpandedNodeId.ToNodeId(reference.NodeId, this.NamespaceUris);
            this.InternalWriteLockedAttach((ILocalNode) new Opc.Ua.Node(reference));
          }
          node.ReferenceTable.Add(reference.ReferenceTypeId, !reference.IsForward, reference.NodeId);
        }
      }
      finally
      {
        this.m_cacheLock.ExitUpgradeableReadLock();
      }
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch references for valid node with NodeId = {0}. Error = {1}", (object) nodeId, (object) ex.Message);
    }
    this.InternalWriteLockedAttach((ILocalNode) node);
    return node;
  }

  public IList<Opc.Ua.Node> FetchNodes(IList<ExpandedNodeId> nodeIds)
  {
    int count = nodeIds.Count;
    if (count == 0)
      return (IList<Opc.Ua.Node>) new List<Opc.Ua.Node>();
    NodeIdCollection nodeIds1 = new NodeIdCollection(nodeIds.Select<ExpandedNodeId, NodeId>((Func<ExpandedNodeId, NodeId>) (nodeId => ExpandedNodeId.ToNodeId(nodeId, this.m_session.NamespaceUris))));
    IList<Opc.Ua.Node> nodeCollection;
    IList<ServiceResult> errors1;
    this.m_session.ReadNodes((IList<NodeId>) nodeIds1, out nodeCollection, out errors1);
    IList<ReferenceDescriptionCollection> referenceDescriptions;
    IList<ServiceResult> errors2;
    this.m_session.FetchReferences((IList<NodeId>) nodeIds1, out referenceDescriptions, out errors2);
    for (int index = 0; index < count; ++index)
    {
      if (!ServiceResult.IsBad(errors1[index]))
      {
        if (!ServiceResult.IsBad(errors2[index]))
        {
          foreach (ReferenceDescription reference in (List<ReferenceDescription>) referenceDescriptions[index])
          {
            try
            {
              this.m_cacheLock.EnterUpgradeableReadLock();
              if (!this.m_nodes.Exists(reference.NodeId))
              {
                if (reference.NodeId != (object) null && reference.NodeId.IsAbsolute)
                  reference.NodeId = (ExpandedNodeId) ExpandedNodeId.ToNodeId(reference.NodeId, this.NamespaceUris);
                this.InternalWriteLockedAttach((ILocalNode) new Opc.Ua.Node(reference));
              }
            }
            finally
            {
              this.m_cacheLock.ExitUpgradeableReadLock();
            }
            nodeCollection[index].ReferenceTable.Add(reference.ReferenceTypeId, !reference.IsForward, reference.NodeId);
          }
        }
        this.InternalWriteLockedAttach((ILocalNode) nodeCollection[index]);
      }
    }
    return nodeCollection;
  }

  public void FetchSuperTypes(ExpandedNodeId nodeId)
  {
    if (!(this.Find(nodeId) is ILocalNode localNode1))
      return;
    ILocalNode localNode2;
    for (ILocalNode localNode3 = localNode1; localNode3 != null; localNode3 = localNode2)
    {
      localNode2 = (ILocalNode) null;
      IList<IReference> referenceList = localNode3.References.Find(ReferenceTypeIds.HasSubtype, true, true, (ITypeTable) this);
      if (referenceList != null && referenceList.Count > 0)
        localNode2 = this.Find(referenceList[0].TargetId) as ILocalNode;
    }
  }

  public IList<INode> FindReferences(
    ExpandedNodeId nodeId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes)
  {
    IList<INode> references = (IList<INode>) new List<INode>();
    if (!(this.Find(nodeId) is Opc.Ua.Node node1))
      return references;
    IList<IReference> source;
    try
    {
      this.m_cacheLock.EnterReadLock();
      source = node1.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (INode node2 in (IEnumerable<INode>) this.Find((IList<ExpandedNodeId>) new ExpandedNodeIdCollection(source.Select<IReference, ExpandedNodeId>((Func<IReference, ExpandedNodeId>) (reference => reference.TargetId)))))
    {
      if (node2 != null)
        references.Add(node2);
    }
    return references;
  }

  public IList<INode> FindReferences(
    IList<ExpandedNodeId> nodeIds,
    IList<NodeId> referenceTypeIds,
    bool isInverse,
    bool includeSubtypes)
  {
    IList<INode> references = (IList<INode>) new List<INode>();
    if (nodeIds.Count == 0 || referenceTypeIds.Count == 0)
      return references;
    ExpandedNodeIdCollection nodeIds1 = new ExpandedNodeIdCollection();
    foreach (INode node1 in (IEnumerable<INode>) this.Find(nodeIds))
    {
      if (node1 is Opc.Ua.Node node2)
      {
        foreach (NodeId referenceTypeId in (IEnumerable<NodeId>) referenceTypeIds)
        {
          IList<IReference> source;
          try
          {
            this.m_cacheLock.EnterReadLock();
            source = node2.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
          }
          finally
          {
            this.m_cacheLock.ExitReadLock();
          }
          nodeIds1.AddRange(source.Select<IReference, ExpandedNodeId>((Func<IReference, ExpandedNodeId>) (reference => reference.TargetId)));
        }
      }
    }
    foreach (INode node in (IEnumerable<INode>) this.Find((IList<ExpandedNodeId>) nodeIds1))
    {
      if (node != null)
        references.Add(node);
    }
    return references;
  }

  public string GetDisplayText(INode node)
  {
    if (node == null)
      return string.Empty;
    if (!(node is Opc.Ua.Node node1))
      return node.ToString();
    string str = (string) null;
    NodeId modellingRule = node1.ModellingRule;
    IList<IReference> referenceList;
    try
    {
      this.m_cacheLock.EnterReadLock();
      referenceList = node1.ReferenceTable.Find(ReferenceTypeIds.Aggregates, true, true, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (IReference reference in (IEnumerable<IReference>) referenceList)
    {
      Opc.Ua.Node node2 = this.Find(reference.TargetId) as Opc.Ua.Node;
      if (!(modellingRule == (object) 78U))
      {
        if (node2 is VariableTypeNode || node2 is ObjectTypeNode)
        {
          str = this.GetDisplayText((INode) node2);
          break;
        }
      }
      else
      {
        str = this.GetDisplayText((INode) node2);
        break;
      }
    }
    if (str == null)
      return node.ToString();
    return Utils.Format("{0}.{1}", (object) str, (object) node);
  }

  public string GetDisplayText(ExpandedNodeId nodeId)
  {
    if (NodeId.IsNull(nodeId))
      return string.Empty;
    INode node = this.Find(nodeId);
    if (node != null)
      return this.GetDisplayText(node);
    return Utils.Format("{0}", (object) nodeId);
  }

  public string GetDisplayText(ReferenceDescription reference)
  {
    if (reference == null || NodeId.IsNull(reference.NodeId))
      return string.Empty;
    INode node = this.Find(reference.NodeId);
    return node != null ? this.GetDisplayText(node) : reference.ToString();
  }

  public NodeId BuildBrowsePath(ILocalNode node, IList<QualifiedName> browsePath)
  {
    browsePath.Add(node.BrowseName);
    return (NodeId) null;
  }

  private void InternalWriteLockedAttach(ILocalNode node)
  {
    try
    {
      this.m_cacheLock.EnterWriteLock();
      this.m_nodes.Attach(node);
    }
    finally
    {
      this.m_cacheLock.ExitWriteLock();
    }
  }

  public async Task<INode> FindAsync(ExpandedNodeId nodeId, CancellationToken ct = default (CancellationToken))
  {
    if (NodeId.IsNull(nodeId))
      return (INode) null;
    INode async;
    try
    {
      this.m_cacheLock.EnterReadLock();
      async = this.m_nodes.Find(nodeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    if (async != null && async.GetType() != typeof (Opc.Ua.Node))
      return async;
    try
    {
      return (INode) await this.FetchNodeAsync(nodeId, ct).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch node from server: NodeId={0}, Reason='{1}'.", (object) nodeId, (object) ex.Message);
      return (INode) null;
    }
  }

  public async Task<IList<INode>> FindAsync(IList<ExpandedNodeId> nodeIds, CancellationToken ct = default (CancellationToken))
  {
    if (nodeIds == null || nodeIds.Count == 0)
      return (IList<INode>) new List<INode>();
    int count = nodeIds.Count;
    IList<INode> nodes = (IList<INode>) new List<INode>(count);
    ExpandedNodeIdCollection nodeIds1 = new ExpandedNodeIdCollection();
    for (int index = 0; index < count; ++index)
    {
      INode node;
      try
      {
        this.m_cacheLock.EnterReadLock();
        node = this.m_nodes.Find(nodeIds[index]);
      }
      finally
      {
        this.m_cacheLock.ExitReadLock();
      }
      if (node != null && node?.GetType() != typeof (Opc.Ua.Node))
      {
        nodes.Add(node);
      }
      else
      {
        nodes.Add((INode) null);
        nodeIds1.Add(nodeIds[index]);
      }
    }
    if (nodeIds1.Count == 0)
      return nodes;
    IList<Opc.Ua.Node> nodeList;
    try
    {
      nodeList = await this.FetchNodesAsync((IList<ExpandedNodeId>) nodeIds1, ct).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch nodes from server: Reason='{0}'.", (object) ex.Message);
      return nodes;
    }
    int index1 = 0;
    foreach (Opc.Ua.Node node in (IEnumerable<Opc.Ua.Node>) nodeList)
    {
      while (index1 < count && nodes[index1] != null)
        ++index1;
      if (index1 < count && nodes[index1] == null)
      {
        nodes[index1++] = (INode) node;
      }
      else
      {
        Utils.LogError("Inconsistency fetching nodes from server. Not all nodes could be assigned.");
        break;
      }
    }
    return nodes;
  }

  public async Task<NodeId> FindSuperTypeAsync(ExpandedNodeId typeId, CancellationToken ct)
  {
    if (await this.FindAsync(typeId, ct).ConfigureAwait(false) == null)
      return (NodeId) null;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindSuperType(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public async Task<NodeId> FindSuperTypeAsync(NodeId typeId, CancellationToken ct = default (CancellationToken))
  {
    if (await this.FindAsync((ExpandedNodeId) typeId, ct).ConfigureAwait(false) == null)
      return (NodeId) null;
    try
    {
      this.m_cacheLock.EnterReadLock();
      return this.m_typeTree.FindSuperType(typeId);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
  }

  public async Task<Opc.Ua.Node> FetchNodeAsync(ExpandedNodeId nodeId, CancellationToken ct)
  {
    NodeId localId = ExpandedNodeId.ToNodeId(nodeId, this.m_session.NamespaceUris);
    if (localId == (object) null)
      return (Opc.Ua.Node) null;
    Opc.Ua.Node source = await this.m_session.ReadNodeAsync(localId, ct).ConfigureAwait(false);
    try
    {
      ReferenceDescriptionCollection descriptionCollection = await this.m_session.FetchReferencesAsync(localId, ct).ConfigureAwait(false);
      try
      {
        this.m_cacheLock.EnterUpgradeableReadLock();
        foreach (ReferenceDescription reference in (List<ReferenceDescription>) descriptionCollection)
        {
          if (!this.m_nodes.Exists(reference.NodeId))
          {
            if (reference.NodeId != (object) null && reference.NodeId.IsAbsolute)
              reference.NodeId = (ExpandedNodeId) ExpandedNodeId.ToNodeId(reference.NodeId, this.NamespaceUris);
            this.InternalWriteLockedAttach((ILocalNode) new Opc.Ua.Node(reference));
          }
          source.ReferenceTable.Add(reference.ReferenceTypeId, !reference.IsForward, reference.NodeId);
        }
      }
      finally
      {
        this.m_cacheLock.ExitUpgradeableReadLock();
      }
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not fetch references for valid node with NodeId = {0}. Error = {1}", (object) nodeId, (object) ex.Message);
    }
    this.InternalWriteLockedAttach((ILocalNode) source);
    return source;
  }

  public async Task<IList<Opc.Ua.Node>> FetchNodesAsync(
    IList<ExpandedNodeId> nodeIds,
    CancellationToken ct)
  {
    NodeCache nodeCache = this;
    int count = nodeIds.Count;
    if (count == 0)
      return (IList<Opc.Ua.Node>) new List<Opc.Ua.Node>();
    // ISSUE: reference to a compiler-generated method
    NodeIdCollection localIds = new NodeIdCollection(nodeIds.Select<ExpandedNodeId, NodeId>(new Func<ExpandedNodeId, NodeId>(nodeCache.\u003CFetchNodesAsync\u003Eb__50_0)));
    (IList<Opc.Ua.Node> nodeList, IList<ServiceResult> serviceResultList1) = await nodeCache.m_session.ReadNodesAsync((IList<NodeId>) localIds, NodeClass.Unspecified, ct: ct).ConfigureAwait(false);
    (IList<ReferenceDescriptionCollection> descriptionCollectionList, IList<ServiceResult> serviceResultList2) = await nodeCache.m_session.FetchReferencesAsync((IList<NodeId>) localIds, ct).ConfigureAwait(false);
    for (int index = 0; index < count; ++index)
    {
      if (!ServiceResult.IsBad(serviceResultList1[index]))
      {
        if (!ServiceResult.IsBad(serviceResultList2[index]))
        {
          foreach (ReferenceDescription reference in (List<ReferenceDescription>) descriptionCollectionList[index])
          {
            try
            {
              nodeCache.m_cacheLock.EnterUpgradeableReadLock();
              if (!nodeCache.m_nodes.Exists(reference.NodeId))
              {
                if (reference.NodeId != (object) null && reference.NodeId.IsAbsolute)
                {
                  // ISSUE: explicit non-virtual call
                  reference.NodeId = (ExpandedNodeId) ExpandedNodeId.ToNodeId(reference.NodeId, __nonvirtual (nodeCache.NamespaceUris));
                }
                Opc.Ua.Node node = new Opc.Ua.Node(reference);
                nodeCache.InternalWriteLockedAttach((ILocalNode) node);
              }
            }
            finally
            {
              nodeCache.m_cacheLock.ExitUpgradeableReadLock();
            }
            nodeList[index].ReferenceTable.Add(reference.ReferenceTypeId, !reference.IsForward, reference.NodeId);
          }
        }
        nodeCache.InternalWriteLockedAttach((ILocalNode) nodeList[index]);
      }
    }
    return nodeList;
  }

  public async Task<IList<INode>> FindReferencesAsync(
    ExpandedNodeId nodeId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    CancellationToken ct)
  {
    IList<INode> targets = (IList<INode>) new List<INode>();
    if (!(await this.FindAsync(nodeId, ct).ConfigureAwait(false) is Opc.Ua.Node node1))
      return targets;
    IList<IReference> source;
    try
    {
      this.m_cacheLock.EnterReadLock();
      source = node1.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
    }
    finally
    {
      this.m_cacheLock.ExitReadLock();
    }
    foreach (INode node2 in (IEnumerable<INode>) await this.FindAsync((IList<ExpandedNodeId>) new ExpandedNodeIdCollection(source.Select<IReference, ExpandedNodeId>((Func<IReference, ExpandedNodeId>) (reference => reference.TargetId))), ct).ConfigureAwait(false))
    {
      if (node2 != null)
        targets.Add(node2);
    }
    return targets;
  }

  public async Task<IList<INode>> FindReferencesAsync(
    IList<ExpandedNodeId> nodeIds,
    IList<NodeId> referenceTypeIds,
    bool isInverse,
    bool includeSubtypes,
    CancellationToken ct)
  {
    IList<INode> targets = (IList<INode>) new List<INode>();
    if (nodeIds.Count == 0 || referenceTypeIds.Count == 0)
      return targets;
    ExpandedNodeIdCollection targetIds = new ExpandedNodeIdCollection();
    foreach (INode node1 in (IEnumerable<INode>) await this.FindAsync(nodeIds, ct).ConfigureAwait(false))
    {
      if (node1 is Opc.Ua.Node node2)
      {
        foreach (NodeId referenceTypeId in (IEnumerable<NodeId>) referenceTypeIds)
        {
          IList<IReference> source;
          try
          {
            this.m_cacheLock.EnterReadLock();
            source = node2.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, (ITypeTable) this.m_typeTree);
          }
          finally
          {
            this.m_cacheLock.ExitReadLock();
          }
          targetIds.AddRange(source.Select<IReference, ExpandedNodeId>((Func<IReference, ExpandedNodeId>) (reference => reference.TargetId)));
        }
      }
    }
    foreach (INode node in (IEnumerable<INode>) await this.FindAsync((IList<ExpandedNodeId>) targetIds, ct).ConfigureAwait(false))
    {
      if (node != null)
        targets.Add(node);
    }
    return targets;
  }

  public async Task FetchSuperTypesAsync(ExpandedNodeId nodeId, CancellationToken ct)
  {
    NodeCache typeTree = this;
    // ISSUE: explicit non-virtual call
    if (!(await __nonvirtual (typeTree.FindAsync(nodeId, ct)).ConfigureAwait(false) is ILocalNode localNode1))
      return;
    ILocalNode localNode2;
    for (ILocalNode localNode3 = localNode1; localNode3 != null; localNode3 = localNode2)
    {
      localNode2 = (ILocalNode) null;
      IList<IReference> referenceList = localNode3.References.Find(ReferenceTypeIds.HasSubtype, true, true, (ITypeTable) typeTree);
      if (referenceList != null && referenceList.Count > 0)
      {
        // ISSUE: explicit non-virtual call
        ConfiguredTaskAwaitable<INode>.ConfiguredTaskAwaiter awaiter = __nonvirtual (typeTree.FindAsync(referenceList[0].TargetId, ct)).ConfigureAwait(false).GetAwaiter();
        if (awaiter.IsCompleted)
        {
          localNode2 = awaiter.GetResult() as ILocalNode;
        }
        else
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable<INode>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<INode>.ConfiguredTaskAwaiter, NodeCache.\u003CFetchSuperTypesAsync\u003Ed__53>(ref awaiter, this);
          break;
        }
      }
    }
  }
}
