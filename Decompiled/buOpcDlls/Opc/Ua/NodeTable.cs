using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeTable : INodeTable, IEnumerable<INode>, IEnumerable
{
	private class RemoteNode : INode
	{
		private ExpandedNodeId m_nodeId;

		private NodeClass m_nodeClass;

		private QualifiedName m_browseName;

		private LocalizedText m_displayName;

		private ExpandedNodeId m_typeDefinitionId;

		private int m_refs;

		public ExpandedNodeId TypeDefinitionId
		{
			get
			{
				return m_typeDefinitionId;
			}
			internal set
			{
				m_typeDefinitionId = value;
			}
		}

		public ExpandedNodeId NodeId => m_nodeId;

		public NodeClass NodeClass
		{
			get
			{
				return m_nodeClass;
			}
			internal set
			{
				m_nodeClass = value;
			}
		}

		public QualifiedName BrowseName
		{
			get
			{
				return m_browseName;
			}
			internal set
			{
				m_browseName = value;
			}
		}

		public LocalizedText DisplayName
		{
			get
			{
				return m_displayName;
			}
			internal set
			{
				m_displayName = value;
			}
		}

		public RemoteNode(INodeTable owner, ExpandedNodeId nodeId)
		{
			m_nodeId = nodeId;
			m_refs = 0;
			m_nodeClass = NodeClass.Unspecified;
			m_browseName = new QualifiedName("(Unknown)");
			m_displayName = new LocalizedText(m_browseName.Name);
			m_typeDefinitionId = null;
		}

		public int AddRef()
		{
			return ++m_refs;
		}

		public int Release()
		{
			if (m_refs == 0)
			{
				throw new InvalidOperationException("Cannot decrement reference count below zero.");
			}
			return --m_refs;
		}
	}

	private NodeIdDictionary<ILocalNode> m_localNodes;

	private SortedDictionary<ExpandedNodeId, RemoteNode> m_remoteNodes;

	private NamespaceTable m_namespaceUris;

	private StringTable m_serverUris;

	private TypeTable m_typeTree;

	public NamespaceTable NamespaceUris => m_namespaceUris;

	public StringTable ServerUris => m_serverUris;

	public ITypeTable TypeTree => m_typeTree;

	public int Count => m_localNodes.Count + m_remoteNodes.Count;

	public NodeTable(NamespaceTable namespaceUris, StringTable serverUris, TypeTable typeTree)
	{
		m_namespaceUris = namespaceUris;
		m_serverUris = serverUris;
		m_typeTree = typeTree;
		m_localNodes = new NodeIdDictionary<ILocalNode>();
		m_remoteNodes = new SortedDictionary<ExpandedNodeId, RemoteNode>();
	}

	public bool Exists(ExpandedNodeId nodeId)
	{
		return InternalFind(nodeId) != null;
	}

	public INode Find(ExpandedNodeId nodeId)
	{
		return InternalFind(nodeId);
	}

	public INode Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes, QualifiedName browseName)
	{
		INode node = InternalFind(sourceId);
		if (node == null)
		{
			return null;
		}
		if (!(node is ILocalNode localNode))
		{
			return null;
		}
		foreach (IReference item in localNode.References.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree))
		{
			INode node2 = InternalFind(item.TargetId);
			if (node2 != null)
			{
				if (browseName == null)
				{
					return node2;
				}
				if (browseName == node2.BrowseName)
				{
					return node2;
				}
			}
		}
		return null;
	}

	public IList<INode> Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes)
	{
		IList<INode> list = new List<INode>();
		INode node = InternalFind(sourceId);
		if (node == null)
		{
			return list;
		}
		if (!(node is ILocalNode localNode))
		{
			return list;
		}
		foreach (IReference item in localNode.References.Find(referenceTypeId, isInverse, includeSubtypes, m_typeTree))
		{
			INode node2 = InternalFind(item.TargetId);
			if (node2 != null)
			{
				list.Add(node2);
			}
		}
		return list;
	}

	public IEnumerator<INode> GetEnumerator()
	{
		List<INode> list = new List<INode>(Count);
		foreach (ILocalNode value in m_localNodes.Values)
		{
			list.Add(value);
		}
		foreach (RemoteNode value2 in m_remoteNodes.Values)
		{
			list.Add(value2);
		}
		return list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public List<Node> Import(NodeSet nodeSet, IDictionary<NodeId, IList<IReference>> externalReferences)
	{
		List<Node> list = new List<Node>();
		if (nodeSet == null)
		{
			return list;
		}
		foreach (Node node3 in nodeSet.Nodes)
		{
			if (node3 == null || NodeId.IsNull(node3.NodeId))
			{
				continue;
			}
			Node node = nodeSet.Copy(node3, m_namespaceUris, m_serverUris);
			if (QualifiedName.IsNull(node.BrowseName))
			{
				node.BrowseName = new QualifiedName(node.NodeId.ToString(), 1);
			}
			if (LocalizedText.IsNullOrEmpty(node.DisplayName))
			{
				node.DisplayName = new LocalizedText(node.BrowseName.Name);
			}
			foreach (ReferenceNode reference in node.References)
			{
				if (NodeId.IsNull(reference.ReferenceTypeId) || NodeId.IsNull(reference.TargetId))
				{
					continue;
				}
				ExpandedNodeId targetId = reference.TargetId;
				if (NodeId.IsNull(targetId))
				{
					continue;
				}
				node.ReferenceTable.Add(reference.ReferenceTypeId, reference.IsInverse, targetId);
				if (targetId.ServerIndex != 0)
				{
					RemoteNode remoteNode = Find(targetId) as RemoteNode;
					if (remoteNode == null)
					{
						remoteNode = new RemoteNode(this, targetId);
						InternalAdd(remoteNode);
					}
					remoteNode.AddRef();
				}
			}
			node.References.Clear();
			InternalAdd(node);
			list.Add(node);
		}
		foreach (Node item in list)
		{
			if (item == null || NodeId.IsNull(item.NodeId))
			{
				continue;
			}
			foreach (IReference item2 in item.ReferenceTable)
			{
				if (!(Find(item2.TargetId) is Node node2))
				{
					if (item2.TargetId.ServerIndex != 0 || externalReferences == null)
					{
						continue;
					}
					NodeId nodeId = ExpandedNodeId.ToNodeId(item2.TargetId, m_namespaceUris);
					if (!(nodeId == null))
					{
						IList<IReference> value = null;
						if (!externalReferences.TryGetValue(nodeId, out value))
						{
							value = (externalReferences[nodeId] = new List<IReference>());
						}
						ReferenceNode referenceNode = new ReferenceNode();
						referenceNode.ReferenceTypeId = item2.ReferenceTypeId;
						referenceNode.IsInverse = !item2.IsInverse;
						referenceNode.TargetId = item.NodeId;
						value.Add(referenceNode);
					}
				}
				else if (item2.ReferenceTypeId != ReferenceTypeIds.HasTypeDefinition && item2.ReferenceTypeId != ReferenceTypeIds.HasModellingRule)
				{
					node2.ReferenceTable.Add(item2.ReferenceTypeId, !item2.IsInverse, item.NodeId);
				}
			}
			if (m_typeTree != null)
			{
				m_typeTree.Add(item);
			}
		}
		return list;
	}

	public INode Import(ReferenceDescription reference)
	{
		INode node = Find(reference.NodeId);
		if (node == null)
		{
			if (reference.NodeId.ServerIndex != 0)
			{
				RemoteNode remoteNode = new RemoteNode(this, reference.NodeId);
				InternalAdd(remoteNode);
				node = remoteNode;
			}
			else
			{
				Node node2 = new Node();
				node2.NodeId = ExpandedNodeId.ToNodeId(reference.NodeId, m_namespaceUris);
				InternalAdd(node2);
				node = node2;
			}
		}
		if (node is Node node3)
		{
			node3.NodeClass = reference.NodeClass;
			node3.BrowseName = reference.BrowseName;
			node3.DisplayName = reference.DisplayName;
			if (!NodeId.IsNull(reference.TypeDefinition))
			{
				node3.ReferenceTable.Add(ReferenceTypeIds.HasTypeDefinition, isInverse: false, reference.TypeDefinition);
			}
			return node3;
		}
		if (node is RemoteNode remoteNode2)
		{
			remoteNode2.NodeClass = reference.NodeClass;
			remoteNode2.BrowseName = reference.BrowseName;
			remoteNode2.DisplayName = reference.DisplayName;
			remoteNode2.TypeDefinitionId = reference.TypeDefinition;
			return remoteNode2;
		}
		return null;
	}

	public void Attach(ILocalNode node)
	{
		if (Exists(node.NodeId))
		{
			Remove(node.NodeId);
		}
		if (node is Node node2 && node2.References.Count > 0 && node2.ReferenceTable.Count == 0)
		{
			foreach (ReferenceNode reference in node.References)
			{
				if (NodeId.IsNull(reference.ReferenceTypeId) || NodeId.IsNull(reference.TargetId))
				{
					continue;
				}
				node.References.Add(reference.ReferenceTypeId, reference.IsInverse, reference.TargetId);
				if (reference.TargetId.ServerIndex != 0)
				{
					RemoteNode remoteNode = Find(reference.TargetId) as RemoteNode;
					if (remoteNode == null)
					{
						remoteNode = new RemoteNode(this, reference.TargetId);
						InternalAdd(remoteNode);
					}
					remoteNode.AddRef();
				}
			}
			node.References.Clear();
		}
		InternalAdd(node);
		foreach (IReference reference2 in node.References)
		{
			if (Find(reference2.TargetId) is ILocalNode localNode && reference2.ReferenceTypeId != ReferenceTypeIds.HasTypeDefinition && reference2.ReferenceTypeId != ReferenceTypeIds.HasModellingRule)
			{
				localNode.References.Add(reference2.ReferenceTypeId, !reference2.IsInverse, node.NodeId);
			}
		}
		if (m_typeTree != null)
		{
			m_typeTree.Add(node);
		}
	}

	public bool Remove(ExpandedNodeId nodeId)
	{
		INode node = Find(nodeId);
		if (node == null)
		{
			return false;
		}
		if (!(node is ILocalNode localNode))
		{
			return false;
		}
		foreach (IReference reference in localNode.References)
		{
			INode node2 = InternalFind(reference.TargetId);
			if (node2 == null)
			{
				continue;
			}
			if (node2 is RemoteNode remoteNode)
			{
				if (remoteNode.Release() == 0)
				{
					InternalRemove(remoteNode);
				}
			}
			else if (node2 is ILocalNode localNode2)
			{
				localNode2.References.Remove(reference.ReferenceTypeId, reference.IsInverse, localNode.NodeId);
			}
		}
		InternalRemove(localNode);
		return true;
	}

	public void Clear()
	{
		m_localNodes.Clear();
		m_remoteNodes.Clear();
	}

	private void InternalAdd(ILocalNode node)
	{
		if (node != null && !(node.NodeId == null))
		{
			m_localNodes.Add(node.NodeId, node);
		}
	}

	private void InternalRemove(ILocalNode node)
	{
		if (node != null && !(node.NodeId == null))
		{
			m_localNodes.Remove(node.NodeId);
		}
	}

	private void InternalAdd(RemoteNode node)
	{
		if (node != null && !(node.NodeId == null))
		{
			m_remoteNodes[node.NodeId] = node;
		}
	}

	private void InternalRemove(RemoteNode node)
	{
		if (node != null && !(node.NodeId == null))
		{
			m_remoteNodes.Remove(node.NodeId);
		}
	}

	private INode InternalFind(ExpandedNodeId nodeId)
	{
		if (nodeId == null)
		{
			return null;
		}
		if (nodeId.ServerIndex != 0)
		{
			RemoteNode value = null;
			if (m_remoteNodes.TryGetValue(nodeId, out value))
			{
				return value;
			}
			return null;
		}
		NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId, m_namespaceUris);
		if (nodeId2 == null)
		{
			return null;
		}
		ILocalNode value2 = null;
		if (m_localNodes.TryGetValue(nodeId2, out value2))
		{
			return value2;
		}
		return null;
	}
}
