// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.INodeCache
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public interface INodeCache : INodeTable, ITypeTable
{
  void LoadUaDefinedTypes(ISystemContext context);

  void Clear();

  Opc.Ua.Node FetchNode(ExpandedNodeId nodeId);

  IList<INode> Find(IList<ExpandedNodeId> nodeIds);

  IList<Opc.Ua.Node> FetchNodes(IList<ExpandedNodeId> nodeIds);

  Task<INode> FindAsync(ExpandedNodeId nodeId, CancellationToken ct = default (CancellationToken));

  Task<IList<INode>> FindAsync(IList<ExpandedNodeId> nodeIds, CancellationToken ct = default (CancellationToken));

  Task<Opc.Ua.Node> FetchNodeAsync(ExpandedNodeId nodeId, CancellationToken ct = default (CancellationToken));

  Task<IList<Opc.Ua.Node>> FetchNodesAsync(IList<ExpandedNodeId> nodeIds, CancellationToken ct = default (CancellationToken));

  Task FetchSuperTypesAsync(ExpandedNodeId nodeId, CancellationToken ct = default (CancellationToken));

  void FetchSuperTypes(ExpandedNodeId nodeId);

  IList<INode> FindReferences(
    ExpandedNodeId nodeId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes);

  IList<INode> FindReferences(
    IList<ExpandedNodeId> nodeIds,
    IList<NodeId> referenceTypeIds,
    bool isInverse,
    bool includeSubtypes);

  Task<IList<INode>> FindReferencesAsync(
    ExpandedNodeId nodeId,
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    CancellationToken ct = default (CancellationToken));

  Task<IList<INode>> FindReferencesAsync(
    IList<ExpandedNodeId> nodeIds,
    IList<NodeId> referenceTypeIds,
    bool isInverse,
    bool includeSubtypes,
    CancellationToken ct = default (CancellationToken));

  string GetDisplayText(INode node);

  string GetDisplayText(ExpandedNodeId nodeId);

  string GetDisplayText(ReferenceDescription reference);

  NodeId BuildBrowsePath(ILocalNode node, IList<QualifiedName> browsePath);
}
