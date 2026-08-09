using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[ComVisible(true)]
public class TypeTable : ITypeTable
{
	private class TypeInfo
	{
		public bool Deleted;

		public NodeId NodeId;

		public QualifiedName BrowseName;

		public TypeInfo SuperType;

		public NodeId[] Encodings;

		public NodeIdDictionary<TypeInfo> SubTypes;

		public bool IsTypeOf(NodeId nodeId)
		{
			for (TypeInfo superType = SuperType; superType != null; superType = superType.SuperType)
			{
				if (!superType.Deleted && superType.NodeId == nodeId)
				{
					return true;
				}
			}
			return false;
		}

		public void AddSubType(TypeInfo subType)
		{
			if (subType != null)
			{
				if (SubTypes == null)
				{
					SubTypes = new NodeIdDictionary<TypeInfo>();
				}
				SubTypes[subType.NodeId] = subType;
			}
		}

		public void RemoveSubType(NodeId subtypeId)
		{
			if (subtypeId != null && SubTypes != null)
			{
				SubTypes.Remove(subtypeId);
				if (SubTypes.Count == 0)
				{
					SubTypes = null;
				}
			}
		}

		public void GetSubtypes(List<NodeId> nodeIds)
		{
			if (SubTypes != null)
			{
				nodeIds.AddRange(SubTypes.Keys);
			}
		}
	}

	private readonly object m_lock = new object();

	private NamespaceTable m_namespaceUris;

	private SortedDictionary<QualifiedName, TypeInfo> m_referenceTypes;

	private NodeIdDictionary<TypeInfo> m_nodes;

	private NodeIdDictionary<TypeInfo> m_encodings;

	public TypeTable(NamespaceTable namespaceUris)
	{
		m_namespaceUris = namespaceUris;
		m_referenceTypes = new SortedDictionary<QualifiedName, TypeInfo>();
		m_nodes = new NodeIdDictionary<TypeInfo>();
		m_encodings = new NodeIdDictionary<TypeInfo>();
	}

	public bool IsKnown(ExpandedNodeId typeId)
	{
		if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0)
		{
			return false;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, m_namespaceUris);
		if (nodeId == null)
		{
			return false;
		}
		lock (m_lock)
		{
			return m_nodes.ContainsKey(nodeId);
		}
	}

	public bool IsKnown(NodeId typeId)
	{
		if (NodeId.IsNull(typeId))
		{
			return false;
		}
		lock (m_lock)
		{
			return m_nodes.ContainsKey(typeId);
		}
	}

	public NodeId FindSuperType(ExpandedNodeId typeId)
	{
		if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0)
		{
			return NodeId.Null;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, m_namespaceUris);
		if (nodeId == null)
		{
			return NodeId.Null;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(nodeId, out value))
			{
				return NodeId.Null;
			}
			if (value.SuperType != null)
			{
				return value.SuperType.NodeId;
			}
			return NodeId.Null;
		}
	}

	public NodeId FindSuperType(NodeId typeId)
	{
		if (typeId == null)
		{
			return NodeId.Null;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(typeId, out value))
			{
				return NodeId.Null;
			}
			if (value.SuperType != null)
			{
				return value.SuperType.NodeId;
			}
			return NodeId.Null;
		}
	}

	public Task<NodeId> FindSuperTypeAsync(ExpandedNodeId typeId, CancellationToken ct)
	{
		return Task.FromResult(FindSuperType(typeId));
	}

	public Task<NodeId> FindSuperTypeAsync(NodeId typeId, CancellationToken ct)
	{
		return Task.FromResult(FindSuperType(typeId));
	}

	public IList<NodeId> FindSubTypes(ExpandedNodeId typeId)
	{
		List<NodeId> list = new List<NodeId>();
		if (typeId == null)
		{
			return list;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, m_namespaceUris);
		if (nodeId == null)
		{
			return list;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (m_nodes.TryGetValue(nodeId, out value))
			{
				value.GetSubtypes(list);
			}
			return list;
		}
	}

	public bool IsTypeOf(ExpandedNodeId subTypeId, ExpandedNodeId superTypeId)
	{
		if (NodeId.IsNull(subTypeId) || subTypeId.ServerIndex != 0)
		{
			return false;
		}
		if (NodeId.IsNull(superTypeId) || superTypeId.ServerIndex != 0)
		{
			return false;
		}
		if (subTypeId == superTypeId)
		{
			return true;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(subTypeId, m_namespaceUris);
		if (nodeId == null)
		{
			return false;
		}
		NodeId nodeId2 = ExpandedNodeId.ToNodeId(superTypeId, m_namespaceUris);
		if (nodeId2 == null)
		{
			return false;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(nodeId, out value))
			{
				return false;
			}
			return value.IsTypeOf(nodeId2);
		}
	}

	public bool IsTypeOf(NodeId subTypeId, NodeId superTypeId)
	{
		if (subTypeId == null || superTypeId == null)
		{
			return false;
		}
		if (subTypeId == superTypeId)
		{
			return true;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(subTypeId, out value))
			{
				return false;
			}
			return value.IsTypeOf(superTypeId);
		}
	}

	public QualifiedName FindReferenceTypeName(NodeId referenceTypeId)
	{
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(referenceTypeId, out value))
			{
				return null;
			}
			return value.BrowseName;
		}
	}

	public NodeId FindReferenceType(QualifiedName browseName)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_referenceTypes.TryGetValue(browseName, out value))
			{
				return null;
			}
			return value.NodeId;
		}
	}

	public bool IsEncodingOf(ExpandedNodeId encodingId, ExpandedNodeId datatypeId)
	{
		if (NodeId.IsNull(encodingId) || NodeId.IsNull(datatypeId))
		{
			return false;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(encodingId, m_namespaceUris);
		if (nodeId == null)
		{
			return false;
		}
		NodeId nodeId2 = ExpandedNodeId.ToNodeId(datatypeId, m_namespaceUris);
		if (nodeId2 == null)
		{
			return false;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_encodings.TryGetValue(nodeId, out value))
			{
				return false;
			}
			if (nodeId2 == value.NodeId)
			{
				return true;
			}
			for (TypeInfo superType = value.SuperType; superType != null; superType = superType.SuperType)
			{
				if (!superType.Deleted && superType.NodeId == nodeId2)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsEncodingFor(NodeId expectedTypeId, ExtensionObject value)
	{
		if (value == null)
		{
			return false;
		}
		if (IsEncodingOf(value.TypeId, expectedTypeId))
		{
			return true;
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
		NodeId dataTypeId = Opc.Ua.TypeInfo.GetDataTypeId(value);
		if (IsTypeOf(dataTypeId, expectedTypeId))
		{
			return true;
		}
		if (dataTypeId != DataTypeIds.Structure)
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
		NodeId nodeId = ExpandedNodeId.ToNodeId(encodingId, m_namespaceUris);
		if (nodeId == null)
		{
			return NodeId.Null;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_encodings.TryGetValue(nodeId, out value))
			{
				return NodeId.Null;
			}
			return value.NodeId;
		}
	}

	public NodeId FindDataTypeId(NodeId encodingId)
	{
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_encodings.TryGetValue(encodingId, out value))
			{
				return NodeId.Null;
			}
			return value.NodeId;
		}
	}

	public void Clear()
	{
		lock (m_lock)
		{
			m_nodes.Clear();
			m_encodings.Clear();
			m_referenceTypes.Clear();
		}
	}

	public void Add(ILocalNode node)
	{
		if (node == null || NodeId.IsNull(node.NodeId) || (node.NodeClass & (NodeClass)120) == 0)
		{
			return;
		}
		NodeId nodeId = null;
		ExpandedNodeId expandedNodeId = node.References.FindTarget(ReferenceTypeIds.HasSubtype, isInverse: true, includeSubtypes: false, null, 0);
		if (expandedNodeId != null)
		{
			nodeId = ExpandedNodeId.ToNodeId(expandedNodeId, m_namespaceUris);
			if (nodeId == null)
			{
				throw ServiceResultException.Create(2150825984u, "A valid supertype identifier is required.");
			}
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (nodeId != null && !m_nodes.TryGetValue(nodeId, out value))
			{
				throw ServiceResultException.Create(2150825984u, "A valid supertype identifier is required.");
			}
			TypeInfo value2 = null;
			if (!m_nodes.TryGetValue(node.NodeId, out value2))
			{
				value2 = new TypeInfo();
				m_nodes.Add(node.NodeId, value2);
			}
			value2.NodeId = node.NodeId;
			value2.SuperType = value;
			value2.Deleted = false;
			value?.AddSubType(value2);
			if (value2.Encodings != null)
			{
				NodeId[] encodings = value2.Encodings;
				foreach (NodeId key in encodings)
				{
					m_encodings.Remove(key);
				}
			}
			IList<IReference> list = node.References.Find(ReferenceTypeIds.HasEncoding, isInverse: false, includeSubtypes: false, null);
			if (list.Count > 0)
			{
				value2.Encodings = new NodeId[list.Count];
				for (int j = 0; j < list.Count; j++)
				{
					value2.Encodings[j] = ExpandedNodeId.ToNodeId(list[j].TargetId, m_namespaceUris);
					m_encodings[value2.Encodings[j]] = value2;
				}
			}
			if ((node.NodeClass & NodeClass.ReferenceType) != NodeClass.Unspecified)
			{
				if (!QualifiedName.IsNull(value2.BrowseName))
				{
					m_referenceTypes.Remove(value2.BrowseName);
				}
				value2.BrowseName = node.BrowseName;
				m_referenceTypes[node.BrowseName] = value2;
			}
		}
	}

	public void AddSubtype(NodeId subTypeId, NodeId superTypeId)
	{
		AddSubtype(subTypeId, superTypeId, null);
	}

	public void AddReferenceSubtype(NodeId subTypeId, NodeId superTypeId, QualifiedName browseName)
	{
		AddSubtype(subTypeId, superTypeId, browseName);
	}

	public bool AddEncoding(NodeId dataTypeId, ExpandedNodeId encodingId)
	{
		NodeId nodeId = ExpandedNodeId.ToNodeId(encodingId, m_namespaceUris);
		if (nodeId == null)
		{
			return false;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(dataTypeId, out value))
			{
				return false;
			}
			if (value.Encodings == null)
			{
				value.Encodings = new NodeId[1] { nodeId };
			}
			else
			{
				NodeId[] array = new NodeId[value.Encodings.Length + 1];
				Array.Copy(value.Encodings, array, value.Encodings.Length);
				array[array.Length - 1] = nodeId;
				value.Encodings = array;
			}
			m_encodings[nodeId] = value;
			return true;
		}
	}

	private void AddSubtype(NodeId subTypeId, NodeId superTypeId, QualifiedName browseName)
	{
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!NodeId.IsNull(superTypeId) && !m_nodes.TryGetValue(superTypeId, out value))
			{
				throw ServiceResultException.Create(2150825984u, "A valid supertype identifier is required.");
			}
			TypeInfo value2 = null;
			if (!m_nodes.TryGetValue(subTypeId, out value2))
			{
				value2 = new TypeInfo();
				m_nodes.Add(subTypeId, value2);
			}
			value2.NodeId = subTypeId;
			value2.SuperType = value;
			value2.Deleted = false;
			value?.AddSubType(value2);
			if (value2.Encodings != null)
			{
				NodeId[] encodings = value2.Encodings;
				foreach (NodeId key in encodings)
				{
					m_encodings.Remove(key);
				}
			}
			if (!QualifiedName.IsNull(browseName))
			{
				value2.BrowseName = browseName;
				m_referenceTypes[browseName] = value2;
			}
		}
	}

	public void Remove(ExpandedNodeId typeId)
	{
		if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0)
		{
			return;
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, m_namespaceUris);
		if (nodeId == null)
		{
			return;
		}
		lock (m_lock)
		{
			TypeInfo value = null;
			if (!m_nodes.TryGetValue(nodeId, out value))
			{
				return;
			}
			m_nodes.Remove(nodeId);
			value.Deleted = true;
			if (value.SuperType != null)
			{
				value.SuperType.RemoveSubType(nodeId);
			}
			if (value.Encodings != null)
			{
				for (int i = 0; i < value.Encodings.Length; i++)
				{
					m_encodings.Remove(value.Encodings[i]);
				}
			}
			if (!QualifiedName.IsNull(value.BrowseName))
			{
				m_referenceTypes.Remove(value.BrowseName);
			}
		}
	}
}
