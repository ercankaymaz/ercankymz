using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class NodeCache : INodeCache, INodeTable, ITypeTable, IDisposable
{
	private ReaderWriterLockSlim m_cacheLock = new ReaderWriterLockSlim();

	private ISession m_session;

	private TypeTable m_typeTree;

	private NodeTable m_nodes;

	private bool m_uaTypesLoaded;

	public NamespaceTable NamespaceUris => m_session.NamespaceUris;

	public StringTable ServerUris => m_session.ServerUris;

	public ITypeTable TypeTree => this;

	public NodeCache(ISession session)
	{
		if (session == null)
		{
			throw new ArgumentNullException("session");
		}
		m_session = session;
		m_typeTree = new TypeTable(m_session.NamespaceUris);
		m_nodes = new NodeTable(m_session.NamespaceUris, m_session.ServerUris, m_typeTree);
		m_uaTypesLoaded = false;
		m_cacheLock = new ReaderWriterLockSlim();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			m_session = null;
			m_cacheLock?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public bool Exists(ExpandedNodeId nodeId)
	{
		return Find(nodeId) != null;
	}

	public INode Find(ExpandedNodeId nodeId)
	{
		if (NodeId.IsNull(nodeId))
		{
			return null;
		}
		INode node;
		try
		{
			m_cacheLock.EnterReadLock();
			node = m_nodes.Find(nodeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		if (node != null && node.GetType() != typeof(Node))
		{
			return node;
		}
		try
		{
			return FetchNode(nodeId);
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch node from server: NodeId={0}, Reason='{1}'.", nodeId, ex.Message);
			return null;
		}
	}

	public IList<INode> Find(IList<ExpandedNodeId> nodeIds)
	{
		if (nodeIds == null || nodeIds.Count == 0)
		{
			return new List<INode>();
		}
		int count = nodeIds.Count;
		IList<INode> list = new List<INode>(count);
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		int i;
		for (i = 0; i < count; i++)
		{
			INode node;
			try
			{
				m_cacheLock.EnterReadLock();
				node = m_nodes.Find(nodeIds[i]);
			}
			finally
			{
				m_cacheLock.ExitReadLock();
			}
			if (node != null && node?.GetType() != typeof(Node))
			{
				list.Add(node);
				continue;
			}
			list.Add(null);
			expandedNodeIdCollection.Add(nodeIds[i]);
		}
		if (expandedNodeIdCollection.Count == 0)
		{
			return list;
		}
		IList<Node> list2;
		try
		{
			list2 = FetchNodes(expandedNodeIdCollection);
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch nodes from server: Reason='{0}'.", ex.Message);
			return list;
		}
		i = 0;
		foreach (Node item in list2)
		{
			for (; i < count && list[i] != null; i++)
			{
			}
			if (i < count && list[i] == null)
			{
				list[i++] = item;
				continue;
			}
			Utils.LogError("Inconsistency fetching nodes from server. Not all nodes could be assigned.");
			break;
		}
		return list;
	}

	public INode Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes, QualifiedName browseName)
	{
		if (!(Find(sourceId) is Node node))
		{
			return null;
		}
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list)
		{
			INode node2 = Find(item.TargetId);
			if (node2 != null && node2.BrowseName == browseName)
			{
				return node2;
			}
		}
		return null;
	}

	public IList<INode> Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes)
	{
		List<INode> list = new List<INode>();
		if (!(Find(sourceId) is Node node))
		{
			return list;
		}
		IList<IReference> list2;
		try
		{
			m_cacheLock.EnterReadLock();
			list2 = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list2)
		{
			INode node2 = Find(item.TargetId);
			if (node2 != null)
			{
				list.Add(node2);
			}
		}
		return list;
	}

	public bool IsKnown(ExpandedNodeId typeId)
	{
		if (Find(typeId) == null)
		{
			return false;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.IsKnown(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public bool IsKnown(NodeId typeId)
	{
		if (Find(typeId) == null)
		{
			return false;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.IsKnown(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public NodeId FindSuperType(ExpandedNodeId typeId)
	{
		if (Find(typeId) == null)
		{
			return null;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindSuperType(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public NodeId FindSuperType(NodeId typeId)
	{
		if (Find(typeId) == null)
		{
			return null;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindSuperType(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public IList<NodeId> FindSubTypes(ExpandedNodeId typeId)
	{
		if (!(Find(typeId) is ILocalNode localNode))
		{
			return new List<NodeId>();
		}
		List<NodeId> list = new List<NodeId>();
		IList<IReference> list2;
		try
		{
			m_cacheLock.EnterReadLock();
			list2 = localNode.References.Find(ReferenceTypeIds.HasSubtype, isInverse: false, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list2)
		{
			if (!item.TargetId.IsAbsolute)
			{
				list.Add((NodeId)item.TargetId);
			}
		}
		return list;
	}

	public bool IsTypeOf(ExpandedNodeId subTypeId, ExpandedNodeId superTypeId)
	{
		if (subTypeId == superTypeId)
		{
			return true;
		}
		if (!(Find(subTypeId) is ILocalNode localNode))
		{
			return false;
		}
		ILocalNode localNode2 = localNode;
		while (localNode2 != null)
		{
			ExpandedNodeId expandedNodeId;
			try
			{
				m_cacheLock.EnterReadLock();
				expandedNodeId = localNode2.References.FindTarget(ReferenceTypeIds.HasSubtype, isInverse: true, includeSubtypes: true, m_typeTree, 0);
			}
			finally
			{
				m_cacheLock.ExitReadLock();
			}
			if (expandedNodeId == superTypeId)
			{
				return true;
			}
			localNode2 = Find(expandedNodeId) as ILocalNode;
		}
		return false;
	}

	public bool IsTypeOf(NodeId subTypeId, NodeId superTypeId)
	{
		if (subTypeId == superTypeId)
		{
			return true;
		}
		if (!(Find(subTypeId) is ILocalNode localNode))
		{
			return false;
		}
		ILocalNode localNode2 = localNode;
		while (localNode2 != null)
		{
			ExpandedNodeId expandedNodeId;
			try
			{
				m_cacheLock.EnterReadLock();
				expandedNodeId = localNode2.References.FindTarget(ReferenceTypeIds.HasSubtype, isInverse: true, includeSubtypes: true, m_typeTree, 0);
			}
			finally
			{
				m_cacheLock.ExitReadLock();
			}
			if (expandedNodeId == superTypeId)
			{
				return true;
			}
			localNode2 = Find(expandedNodeId) as ILocalNode;
		}
		return false;
	}

	public QualifiedName FindReferenceTypeName(NodeId referenceTypeId)
	{
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindReferenceTypeName(referenceTypeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public NodeId FindReferenceType(QualifiedName browseName)
	{
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindReferenceType(browseName);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public bool IsEncodingOf(ExpandedNodeId encodingId, ExpandedNodeId datatypeId)
	{
		if (!(Find(encodingId) is ILocalNode localNode))
		{
			return false;
		}
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = localNode.References.Find(ReferenceTypeIds.HasEncoding, isInverse: true, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list)
		{
			if (item.TargetId == datatypeId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsEncodingFor(NodeId expectedTypeId, ExtensionObject value)
	{
		if (value == null)
		{
			return false;
		}
		if (expectedTypeId == value.TypeId)
		{
			return true;
		}
		if (!(Find(value.TypeId) is ILocalNode localNode))
		{
			return false;
		}
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = localNode.References.Find(ReferenceTypeIds.HasEncoding, isInverse: true, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list)
		{
			if (item.TargetId == expectedTypeId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsEncodingFor(NodeId expectedTypeId, object value)
	{
		if (value == null)
		{
			return false;
		}
		if (NodeId.IsNull(expectedTypeId))
		{
			return true;
		}
		NodeId dataTypeId = TypeInfo.GetDataTypeId(value);
		if (IsTypeOf(dataTypeId, expectedTypeId))
		{
			return true;
		}
		if (dataTypeId != 22u)
		{
			return IsTypeOf(expectedTypeId, dataTypeId);
		}
		if (value is ExtensionObject value2)
		{
			return IsEncodingFor(expectedTypeId, value2);
		}
		if (value is ExtensionObject[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (!IsEncodingFor(expectedTypeId, array[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public NodeId FindDataTypeId(ExpandedNodeId encodingId)
	{
		if (!(Find(encodingId) is ILocalNode localNode))
		{
			return NodeId.Null;
		}
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = localNode.References.Find(ReferenceTypeIds.HasEncoding, isInverse: true, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		if (list.Count > 0)
		{
			return ExpandedNodeId.ToNodeId(list[0].TargetId, m_session.NamespaceUris);
		}
		return NodeId.Null;
	}

	public NodeId FindDataTypeId(NodeId encodingId)
	{
		if (!(Find(encodingId) is ILocalNode localNode))
		{
			return NodeId.Null;
		}
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = localNode.References.Find(ReferenceTypeIds.HasEncoding, isInverse: true, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		if (list.Count > 0)
		{
			return ExpandedNodeId.ToNodeId(list[0].TargetId, m_session.NamespaceUris);
		}
		return NodeId.Null;
	}

	public void LoadUaDefinedTypes(ISystemContext context)
	{
		if (m_uaTypesLoaded)
		{
			return;
		}
		NodeStateCollection nodeStateCollection = new NodeStateCollection();
		Assembly assembly = typeof(ArgumentCollection).GetTypeInfo().Assembly;
		nodeStateCollection.LoadFromBinaryResource(context, "Opc.Ua.Stack.Generated.Opc.Ua.PredefinedNodes.uanodes", assembly, updateTables: true);
		try
		{
			m_cacheLock.EnterWriteLock();
			for (int i = 0; i < nodeStateCollection.Count; i++)
			{
				if (nodeStateCollection[i] is BaseTypeState baseTypeState)
				{
					baseTypeState.Export(context, m_nodes);
				}
			}
		}
		finally
		{
			m_cacheLock.ExitWriteLock();
		}
		m_uaTypesLoaded = true;
	}

	public void Clear()
	{
		m_uaTypesLoaded = false;
		try
		{
			m_cacheLock.EnterWriteLock();
			m_nodes.Clear();
		}
		finally
		{
			m_cacheLock.ExitWriteLock();
		}
	}

	public Node FetchNode(ExpandedNodeId nodeId)
	{
		NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId, m_session.NamespaceUris);
		if (nodeId2 == null)
		{
			return null;
		}
		Node node = m_session.ReadNode(nodeId2);
		try
		{
			ReferenceDescriptionCollection referenceDescriptionCollection = m_session.FetchReferences(nodeId2);
			try
			{
				m_cacheLock.EnterUpgradeableReadLock();
				foreach (ReferenceDescription item in referenceDescriptionCollection)
				{
					if (!m_nodes.Exists(item.NodeId))
					{
						if (item.NodeId != null && item.NodeId.IsAbsolute)
						{
							item.NodeId = ExpandedNodeId.ToNodeId(item.NodeId, NamespaceUris);
						}
						Node node2 = new Node(item);
						InternalWriteLockedAttach(node2);
					}
					node.ReferenceTable.Add(item.ReferenceTypeId, !item.IsForward, item.NodeId);
				}
			}
			finally
			{
				m_cacheLock.ExitUpgradeableReadLock();
			}
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch references for valid node with NodeId = {0}. Error = {1}", nodeId, ex.Message);
		}
		InternalWriteLockedAttach(node);
		return node;
	}

	public IList<Node> FetchNodes(IList<ExpandedNodeId> nodeIds)
	{
		int count = nodeIds.Count;
		if (count == 0)
		{
			return new List<Node>();
		}
		NodeIdCollection nodeIds2 = new NodeIdCollection(nodeIds.Select((ExpandedNodeId nodeId) => ExpandedNodeId.ToNodeId(nodeId, m_session.NamespaceUris)));
		m_session.ReadNodes(nodeIds2, out var nodeCollection, out var errors);
		m_session.FetchReferences(nodeIds2, out var referenceDescriptions, out var errors2);
		int num = 0;
		for (num = 0; num < count; num++)
		{
			if (ServiceResult.IsBad(errors[num]))
			{
				continue;
			}
			if (!ServiceResult.IsBad(errors2[num]))
			{
				foreach (ReferenceDescription item in referenceDescriptions[num])
				{
					try
					{
						m_cacheLock.EnterUpgradeableReadLock();
						if (!m_nodes.Exists(item.NodeId))
						{
							if (item.NodeId != null && item.NodeId.IsAbsolute)
							{
								item.NodeId = ExpandedNodeId.ToNodeId(item.NodeId, NamespaceUris);
							}
							Node node = new Node(item);
							InternalWriteLockedAttach(node);
						}
					}
					finally
					{
						m_cacheLock.ExitUpgradeableReadLock();
					}
					nodeCollection[num].ReferenceTable.Add(item.ReferenceTypeId, !item.IsForward, item.NodeId);
				}
			}
			InternalWriteLockedAttach(nodeCollection[num]);
		}
		return nodeCollection;
	}

	public void FetchSuperTypes(ExpandedNodeId nodeId)
	{
		if (!(Find(nodeId) is ILocalNode localNode))
		{
			return;
		}
		ILocalNode localNode2 = localNode;
		while (localNode2 != null)
		{
			ILocalNode localNode3 = null;
			IList<IReference> list = localNode2.References.Find(ReferenceTypeIds.HasSubtype, isInverse: true, includeSubtypes: true, this);
			if (list != null && list.Count > 0)
			{
				localNode3 = Find(list[0].TargetId) as ILocalNode;
			}
			localNode2 = localNode3;
		}
	}

	public IList<INode> FindReferences(ExpandedNodeId nodeId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes)
	{
		IList<INode> list = new List<INode>();
		if (!(Find(nodeId) is Node node))
		{
			return list;
		}
		IList<IReference> source;
		try
		{
			m_cacheLock.EnterReadLock();
			source = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		ExpandedNodeIdCollection nodeIds = new ExpandedNodeIdCollection(source.Select((IReference reference) => reference.TargetId));
		foreach (INode item in Find(nodeIds))
		{
			if (item != null)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public IList<INode> FindReferences(IList<ExpandedNodeId> nodeIds, IList<NodeId> referenceTypeIds, bool isInverse, bool includeSubtypes)
	{
		IList<INode> list = new List<INode>();
		if (nodeIds.Count == 0 || referenceTypeIds.Count == 0)
		{
			return list;
		}
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		foreach (INode item in Find(nodeIds))
		{
			if (!(item is Node node))
			{
				continue;
			}
			foreach (NodeId referenceTypeId in referenceTypeIds)
			{
				IList<IReference> source;
				try
				{
					m_cacheLock.EnterReadLock();
					source = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
				}
				finally
				{
					m_cacheLock.ExitReadLock();
				}
				expandedNodeIdCollection.AddRange(source.Select((IReference reference) => reference.TargetId));
			}
		}
		foreach (INode item2 in Find(expandedNodeIdCollection))
		{
			if (item2 != null)
			{
				list.Add(item2);
			}
		}
		return list;
	}

	public string GetDisplayText(INode node)
	{
		if (node == null)
		{
			return string.Empty;
		}
		if (!(node is Node node2))
		{
			return node.ToString();
		}
		string text = null;
		NodeId modellingRule = node2.ModellingRule;
		IList<IReference> list;
		try
		{
			m_cacheLock.EnterReadLock();
			list = node2.ReferenceTable.Find(ReferenceTypeIds.Aggregates, isInverse: true, includeSubtypes: true, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		foreach (IReference item in list)
		{
			Node node3 = Find(item.TargetId) as Node;
			if (modellingRule == 78u)
			{
				text = GetDisplayText(node3);
				break;
			}
			if (node3 is VariableTypeNode || node3 is ObjectTypeNode)
			{
				text = GetDisplayText(node3);
				break;
			}
		}
		if (text != null)
		{
			return Utils.Format("{0}.{1}", text, node);
		}
		return node.ToString();
	}

	public string GetDisplayText(ExpandedNodeId nodeId)
	{
		if (NodeId.IsNull(nodeId))
		{
			return string.Empty;
		}
		INode node = Find(nodeId);
		if (node != null)
		{
			return GetDisplayText(node);
		}
		return Utils.Format("{0}", nodeId);
	}

	public string GetDisplayText(ReferenceDescription reference)
	{
		if (reference == null || NodeId.IsNull(reference.NodeId))
		{
			return string.Empty;
		}
		INode node = Find(reference.NodeId);
		if (node != null)
		{
			return GetDisplayText(node);
		}
		return reference.ToString();
	}

	public NodeId BuildBrowsePath(ILocalNode node, IList<QualifiedName> browsePath)
	{
		browsePath.Add(node.BrowseName);
		return null;
	}

	private void InternalWriteLockedAttach(ILocalNode node)
	{
		try
		{
			m_cacheLock.EnterWriteLock();
			m_nodes.Attach(node);
		}
		finally
		{
			m_cacheLock.ExitWriteLock();
		}
	}

	public async Task<INode> FindAsync(ExpandedNodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		if (NodeId.IsNull(nodeId))
		{
			return null;
		}
		INode node;
		try
		{
			m_cacheLock.EnterReadLock();
			node = m_nodes.Find(nodeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		if (node != null && node.GetType() != typeof(Node))
		{
			return node;
		}
		try
		{
			return await FetchNodeAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch node from server: NodeId={0}, Reason='{1}'.", nodeId, ex.Message);
			return null;
		}
	}

	public async Task<IList<INode>> FindAsync(IList<ExpandedNodeId> nodeIds, CancellationToken ct = default(CancellationToken))
	{
		if (nodeIds == null || nodeIds.Count == 0)
		{
			return new List<INode>();
		}
		int count = nodeIds.Count;
		IList<INode> nodes = new List<INode>(count);
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		int i;
		for (i = 0; i < count; i++)
		{
			INode node;
			try
			{
				m_cacheLock.EnterReadLock();
				node = m_nodes.Find(nodeIds[i]);
			}
			finally
			{
				m_cacheLock.ExitReadLock();
			}
			if (node != null && node?.GetType() != typeof(Node))
			{
				nodes.Add(node);
				continue;
			}
			nodes.Add(null);
			expandedNodeIdCollection.Add(nodeIds[i]);
		}
		if (expandedNodeIdCollection.Count == 0)
		{
			return nodes;
		}
		IList<Node> list;
		try
		{
			list = await FetchNodesAsync(expandedNodeIdCollection, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch nodes from server: Reason='{0}'.", ex.Message);
			return nodes;
		}
		i = 0;
		foreach (Node item in list)
		{
			for (; i < count && nodes[i] != null; i++)
			{
			}
			if (i < count && nodes[i] == null)
			{
				nodes[i++] = item;
				continue;
			}
			Utils.LogError("Inconsistency fetching nodes from server. Not all nodes could be assigned.");
			break;
		}
		return nodes;
	}

	public async Task<NodeId> FindSuperTypeAsync(ExpandedNodeId typeId, CancellationToken ct)
	{
		if (await FindAsync(typeId, ct).ConfigureAwait(continueOnCapturedContext: false) == null)
		{
			return null;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindSuperType(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public async Task<NodeId> FindSuperTypeAsync(NodeId typeId, CancellationToken ct = default(CancellationToken))
	{
		if (await FindAsync(typeId, ct).ConfigureAwait(continueOnCapturedContext: false) == null)
		{
			return null;
		}
		try
		{
			m_cacheLock.EnterReadLock();
			return m_typeTree.FindSuperType(typeId);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
	}

	public async Task<Node> FetchNodeAsync(ExpandedNodeId nodeId, CancellationToken ct)
	{
		NodeId localId = ExpandedNodeId.ToNodeId(nodeId, m_session.NamespaceUris);
		if (localId == null)
		{
			return null;
		}
		Node source = await m_session.ReadNodeAsync(localId, ct).ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			ReferenceDescriptionCollection referenceDescriptionCollection = await m_session.FetchReferencesAsync(localId, ct).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				m_cacheLock.EnterUpgradeableReadLock();
				foreach (ReferenceDescription item in referenceDescriptionCollection)
				{
					if (!m_nodes.Exists(item.NodeId))
					{
						if (item.NodeId != null && item.NodeId.IsAbsolute)
						{
							item.NodeId = ExpandedNodeId.ToNodeId(item.NodeId, NamespaceUris);
						}
						Node node = new Node(item);
						InternalWriteLockedAttach(node);
					}
					source.ReferenceTable.Add(item.ReferenceTypeId, !item.IsForward, item.NodeId);
				}
			}
			finally
			{
				m_cacheLock.ExitUpgradeableReadLock();
			}
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not fetch references for valid node with NodeId = {0}. Error = {1}", nodeId, ex.Message);
		}
		InternalWriteLockedAttach(source);
		return source;
	}

	public async Task<IList<Node>> FetchNodesAsync(IList<ExpandedNodeId> nodeIds, CancellationToken ct)
	{
		int count = nodeIds.Count;
		if (count == 0)
		{
			return new List<Node>();
		}
		NodeIdCollection localIds = new NodeIdCollection(nodeIds.Select((ExpandedNodeId nodeId) => ExpandedNodeId.ToNodeId(nodeId, m_session.NamespaceUris)));
		(IList<Node>, IList<ServiceResult>) tuple = await m_session.ReadNodesAsync(localIds, NodeClass.Unspecified, optionalAttributes: false, ct).ConfigureAwait(continueOnCapturedContext: false);
		IList<Node> sourceNodes = tuple.Item1;
		IList<ServiceResult> readErrors = tuple.Item2;
		(IList<ReferenceDescriptionCollection>, IList<ServiceResult>) obj = await m_session.FetchReferencesAsync(localIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		IList<ReferenceDescriptionCollection> item = obj.Item1;
		IList<ServiceResult> item2 = obj.Item2;
		for (int num = 0; num < count; num++)
		{
			if (ServiceResult.IsBad(readErrors[num]))
			{
				continue;
			}
			if (!ServiceResult.IsBad(item2[num]))
			{
				foreach (ReferenceDescription item3 in item[num])
				{
					try
					{
						m_cacheLock.EnterUpgradeableReadLock();
						if (!m_nodes.Exists(item3.NodeId))
						{
							if (item3.NodeId != null && item3.NodeId.IsAbsolute)
							{
								item3.NodeId = ExpandedNodeId.ToNodeId(item3.NodeId, NamespaceUris);
							}
							Node node = new Node(item3);
							InternalWriteLockedAttach(node);
						}
					}
					finally
					{
						m_cacheLock.ExitUpgradeableReadLock();
					}
					sourceNodes[num].ReferenceTable.Add(item3.ReferenceTypeId, !item3.IsForward, item3.NodeId);
				}
			}
			InternalWriteLockedAttach(sourceNodes[num]);
		}
		return sourceNodes;
	}

	public async Task<IList<INode>> FindReferencesAsync(ExpandedNodeId nodeId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes, CancellationToken ct)
	{
		IList<INode> targets = new List<INode>();
		if (!(await FindAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false) is Node node))
		{
			return targets;
		}
		IList<IReference> source;
		try
		{
			m_cacheLock.EnterReadLock();
			source = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
		}
		finally
		{
			m_cacheLock.ExitReadLock();
		}
		ExpandedNodeIdCollection nodeIds = new ExpandedNodeIdCollection(source.Select((IReference reference) => reference.TargetId));
		foreach (INode item in await FindAsync(nodeIds, ct).ConfigureAwait(continueOnCapturedContext: false))
		{
			if (item != null)
			{
				targets.Add(item);
			}
		}
		return targets;
	}

	public async Task<IList<INode>> FindReferencesAsync(IList<ExpandedNodeId> nodeIds, IList<NodeId> referenceTypeIds, bool isInverse, bool includeSubtypes, CancellationToken ct)
	{
		IList<INode> targets = new List<INode>();
		if (nodeIds.Count == 0 || referenceTypeIds.Count == 0)
		{
			return targets;
		}
		ExpandedNodeIdCollection targetIds = new ExpandedNodeIdCollection();
		foreach (INode item in await FindAsync(nodeIds, ct).ConfigureAwait(continueOnCapturedContext: false))
		{
			if (!(item is Node node))
			{
				continue;
			}
			foreach (NodeId referenceTypeId in referenceTypeIds)
			{
				IList<IReference> source;
				try
				{
					m_cacheLock.EnterReadLock();
					source = node.ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree);
				}
				finally
				{
					m_cacheLock.ExitReadLock();
				}
				targetIds.AddRange(source.Select((IReference reference) => reference.TargetId));
			}
		}
		foreach (INode item2 in await FindAsync(targetIds, ct).ConfigureAwait(continueOnCapturedContext: false))
		{
			if (item2 != null)
			{
				targets.Add(item2);
			}
		}
		return targets;
	}

	public async Task FetchSuperTypesAsync(ExpandedNodeId nodeId, CancellationToken ct)
	{
		if (!(await FindAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false) is ILocalNode localNode))
		{
			return;
		}
		ILocalNode localNode2 = localNode;
		while (localNode2 != null)
		{
			ILocalNode localNode3 = null;
			IList<IReference> list = localNode2.References.Find(ReferenceTypeIds.HasSubtype, isInverse: true, includeSubtypes: true, this);
			if (list != null && list.Count > 0)
			{
				localNode3 = (await FindAsync(list[0].TargetId, ct).ConfigureAwait(continueOnCapturedContext: false)) as ILocalNode;
			}
			localNode2 = localNode3;
		}
	}
}
