using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class IReferenceDictionary<T> : IDictionary<IReference, T>, ICollection<KeyValuePair<IReference, T>>, IEnumerable<KeyValuePair<IReference, T>>, IEnumerable
{
	private class ReferenceTypeEntry
	{
		public NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> ForwardTargets;

		public Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> ForwardExternalTargets;

		public NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> InverseTargets;

		public Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> InverseExternalTargets;

		public bool IsEmpty
		{
			get
			{
				if (ForwardTargets != null && ForwardTargets.Count > 0)
				{
					return false;
				}
				if (ForwardExternalTargets != null && ForwardExternalTargets.Count > 0)
				{
					return false;
				}
				if (InverseTargets != null && InverseTargets.Count > 0)
				{
					return false;
				}
				if (InverseExternalTargets != null && InverseExternalTargets.Count > 0)
				{
					return false;
				}
				return true;
			}
		}
	}

	private NodeIdDictionary<ReferenceTypeEntry> m_references;

	private LinkedList<KeyValuePair<IReference, T>> m_list;

	private ulong m_version;

	public ICollection<IReference> Keys
	{
		get
		{
			List<IReference> list = new List<IReference>();
			for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				list.Add(linkedListNode.Value.Key);
			}
			return list;
		}
	}

	public ICollection<T> Values
	{
		get
		{
			List<T> list = new List<T>();
			for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				list.Add(linkedListNode.Value.Value);
			}
			return list;
		}
	}

	public T this[IReference key]
	{
		get
		{
			ValidateReference(key, throwOnError: true);
			if (!TryGetEntry(key, out var value))
			{
				throw new KeyNotFoundException();
			}
			return value.Value;
		}
		set
		{
			Add(key, value, replace: true);
		}
	}

	public int Count => m_list.Count;

	public bool IsReadOnly => false;

	public IReferenceDictionary()
	{
		m_version = 0uL;
		m_references = new NodeIdDictionary<ReferenceTypeEntry>();
		m_list = new LinkedList<KeyValuePair<IReference, T>>();
	}

	public bool ContainsKey(IReference reference, ITypeTable typeTree)
	{
		if (typeTree == null)
		{
			throw new ArgumentNullException("typeTree");
		}
		if (!ValidateReference(reference, throwOnError: false))
		{
			return false;
		}
		foreach (KeyValuePair<NodeId, ReferenceTypeEntry> reference2 in m_references)
		{
			if (typeTree.IsTypeOf(reference2.Key, reference.ReferenceTypeId) && ContainsKey(reference2.Value, reference))
			{
				return true;
			}
		}
		return false;
	}

	public IList<IReference> Find(NodeId referenceTypeId, bool isInverse)
	{
		List<IReference> list = new List<IReference>();
		if (NodeId.IsNull(referenceTypeId))
		{
			return list;
		}
		ReferenceTypeEntry value = null;
		if (!m_references.TryGetValue(referenceTypeId, out value))
		{
			return list;
		}
		Find(value, isInverse, list);
		return list;
	}

	public IList<IReference> Find(NodeId referenceTypeId, bool isInverse, ITypeTable typeTree)
	{
		if (typeTree == null)
		{
			throw new ArgumentNullException("typeTree");
		}
		List<IReference> list = new List<IReference>();
		if (NodeId.IsNull(referenceTypeId))
		{
			return list;
		}
		foreach (KeyValuePair<NodeId, ReferenceTypeEntry> reference in m_references)
		{
			if (typeTree.IsTypeOf(reference.Key, referenceTypeId))
			{
				Find(reference.Value, isInverse, list);
			}
		}
		return list;
	}

	public IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId)
	{
		List<IReference> list = new List<IReference>();
		if (NodeId.IsNull(targetId))
		{
			return list;
		}
		for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			if (linkedListNode.Value.Key.TargetId == targetId)
			{
				list.Add(linkedListNode.Value.Key);
			}
		}
		return list;
	}

	public bool RemoveAll(NodeId referenceTypeId, bool isInverse)
	{
		if (NodeId.IsNull(referenceTypeId))
		{
			return false;
		}
		ReferenceTypeEntry value = null;
		if (!m_references.TryGetValue(referenceTypeId, out value))
		{
			return false;
		}
		if (isInverse)
		{
			if (value.InverseTargets != null)
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value2 in value.InverseTargets.Values)
				{
					if (m_list == value2.List)
					{
						m_list.Remove(value2);
					}
					value.InverseTargets = null;
				}
			}
			if (value.InverseExternalTargets != null)
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value3 in value.InverseExternalTargets.Values)
				{
					if (m_list == value3.List)
					{
						m_list.Remove(value3);
					}
				}
				value.InverseExternalTargets = null;
			}
		}
		else
		{
			if (value.ForwardTargets != null)
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value4 in value.ForwardTargets.Values)
				{
					if (m_list == value4.List)
					{
						m_list.Remove(value4);
					}
				}
				value.ForwardTargets = null;
			}
			if (value.ForwardExternalTargets != null)
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value5 in value.ForwardExternalTargets.Values)
				{
					if (m_list == value5.List)
					{
						m_list.Remove(value5);
					}
				}
				value.ForwardExternalTargets = null;
			}
		}
		if (value.IsEmpty)
		{
			m_references.Remove(referenceTypeId);
		}
		return true;
	}

	public void Add(IReference key, T value)
	{
		Add(key, value, replace: false);
	}

	public bool ContainsKey(IReference key)
	{
		if (!TryGetEntry(key, out var _))
		{
			return false;
		}
		return true;
	}

	public bool Remove(IReference key)
	{
		if (!ValidateReference(key, throwOnError: false))
		{
			return false;
		}
		m_version++;
		ReferenceTypeEntry value = null;
		if (!m_references.TryGetValue(key.ReferenceTypeId, out value))
		{
			return false;
		}
		if (key.TargetId.IsAbsolute)
		{
			Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = null;
			dictionary = ((!key.IsInverse) ? value.ForwardExternalTargets : value.InverseExternalTargets);
			if (dictionary == null)
			{
				return false;
			}
			if (!dictionary.TryGetValue(key.TargetId, out var value2))
			{
				return false;
			}
			m_list.Remove(value2);
			dictionary.Remove(key.TargetId);
		}
		else
		{
			NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = null;
			nodeIdDictionary = ((!key.IsInverse) ? value.ForwardTargets : value.InverseTargets);
			if (nodeIdDictionary == null)
			{
				return false;
			}
			if (!nodeIdDictionary.TryGetValue((NodeId)key.TargetId, out var value3))
			{
				return false;
			}
			m_list.Remove(value3);
			nodeIdDictionary.Remove((NodeId)key.TargetId);
		}
		if (value.IsEmpty)
		{
			m_references.Remove(key.ReferenceTypeId);
		}
		return true;
	}

	public bool TryGetValue(IReference key, out T value)
	{
		value = default(T);
		if (!TryGetEntry(key, out var value2))
		{
			return false;
		}
		value = value2.Value;
		return true;
	}

	public void Add(KeyValuePair<IReference, T> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		m_version++;
		m_references.Clear();
		m_list.Clear();
	}

	public bool Contains(KeyValuePair<IReference, T> item)
	{
		if (!TryGetEntry(item.Key, out var value))
		{
			return false;
		}
		return object.Equals(value.Value, item.Value);
	}

	public void CopyTo(KeyValuePair<IReference, T>[] array, int arrayIndex)
	{
		m_list.CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<IReference, T> item)
	{
		return Remove(item.Key);
	}

	public IEnumerator<KeyValuePair<IReference, T>> GetEnumerator()
	{
		return m_list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private static bool ValidateReference(IReference key, bool throwOnError)
	{
		if (key == null)
		{
			if (throwOnError)
			{
				throw new ArgumentNullException("key", "IReference must not be null.");
			}
			return false;
		}
		if (NodeId.IsNull(key.ReferenceTypeId))
		{
			if (throwOnError)
			{
				throw new ArgumentNullException("key", "IReference does not have a valid ReferenceTypeId.");
			}
			return false;
		}
		if (NodeId.IsNull(key.TargetId))
		{
			if (throwOnError)
			{
				throw new ArgumentNullException("key", "IReference does not have a valid TargetId.");
			}
			return false;
		}
		return true;
	}

	private bool TryGetEntry(IReference key, out KeyValuePair<IReference, T> value)
	{
		value = default(KeyValuePair<IReference, T>);
		if (!ValidateReference(key, throwOnError: false))
		{
			return false;
		}
		ReferenceTypeEntry value2 = null;
		if (!m_references.TryGetValue(key.ReferenceTypeId, out value2))
		{
			return false;
		}
		if (key.TargetId.IsAbsolute)
		{
			Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = null;
			dictionary = ((!key.IsInverse) ? value2.ForwardExternalTargets : value2.InverseExternalTargets);
			if (dictionary == null)
			{
				return false;
			}
			if (dictionary.TryGetValue(key.TargetId, out var value3))
			{
				value = value3.Value;
				return true;
			}
		}
		else
		{
			NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = null;
			nodeIdDictionary = ((!key.IsInverse) ? value2.ForwardTargets : value2.InverseTargets);
			if (nodeIdDictionary == null)
			{
				return false;
			}
			if (nodeIdDictionary.TryGetValue((NodeId)key.TargetId, out var value4))
			{
				value = value4.Value;
				return true;
			}
		}
		return false;
	}

	private void Add(IReference key, T value, bool replace)
	{
		ValidateReference(key, throwOnError: true);
		m_version++;
		ReferenceTypeEntry value2 = null;
		if (!m_references.TryGetValue(key.ReferenceTypeId, out value2))
		{
			value2 = new ReferenceTypeEntry();
			m_references.Add(key.ReferenceTypeId, value2);
		}
		if (key.TargetId.IsAbsolute)
		{
			Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = null;
			if (key.IsInverse)
			{
				if (value2.InverseExternalTargets == null)
				{
					value2.InverseExternalTargets = new Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>();
				}
				dictionary = value2.InverseExternalTargets;
			}
			else
			{
				if (value2.ForwardExternalTargets == null)
				{
					value2.ForwardExternalTargets = new Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>();
				}
				dictionary = value2.ForwardExternalTargets;
			}
			LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = new LinkedListNode<KeyValuePair<IReference, T>>(new KeyValuePair<IReference, T>(key, value));
			LinkedListNode<KeyValuePair<IReference, T>> value3 = null;
			if (!dictionary.TryGetValue(key.TargetId, out value3))
			{
				value3 = linkedListNode;
				m_list.AddLast(linkedListNode);
			}
			else
			{
				if (!replace)
				{
					throw new ArgumentException("Key already exists in dictionary.", "key");
				}
				m_list.AddAfter(value3, linkedListNode);
				m_list.Remove(value3);
			}
			dictionary[key.TargetId] = linkedListNode;
			return;
		}
		NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = null;
		if (key.IsInverse)
		{
			if (value2.InverseTargets == null)
			{
				value2.InverseTargets = new NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>();
			}
			nodeIdDictionary = value2.InverseTargets;
		}
		else
		{
			if (value2.ForwardTargets == null)
			{
				value2.ForwardTargets = new NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>();
			}
			nodeIdDictionary = value2.ForwardTargets;
		}
		NodeId key2 = (NodeId)key.TargetId;
		LinkedListNode<KeyValuePair<IReference, T>> linkedListNode2 = new LinkedListNode<KeyValuePair<IReference, T>>(new KeyValuePair<IReference, T>(key, value));
		LinkedListNode<KeyValuePair<IReference, T>> value4 = null;
		if (!nodeIdDictionary.TryGetValue(key2, out value4))
		{
			value4 = linkedListNode2;
			m_list.AddLast(linkedListNode2);
		}
		else
		{
			if (!replace)
			{
				throw new ArgumentException("Key already exists in dictionary.", "key");
			}
			m_list.AddAfter(value4, linkedListNode2);
			m_list.Remove(value4);
		}
		nodeIdDictionary[key2] = linkedListNode2;
	}

	private static bool ContainsKey(ReferenceTypeEntry entry, IReference reference)
	{
		if (reference.TargetId.IsAbsolute)
		{
			Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = null;
			return ((!reference.IsInverse) ? entry.ForwardExternalTargets : entry.InverseExternalTargets)?.ContainsKey(reference.TargetId) ?? false;
		}
		NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = null;
		return ((!reference.IsInverse) ? entry.ForwardTargets : entry.InverseTargets)?.ContainsKey((NodeId)reference.TargetId) ?? false;
	}

	private static void Find(ReferenceTypeEntry entry, bool isInverse, List<IReference> hits)
	{
		if (isInverse)
		{
			if (entry.InverseTargets != null)
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value in entry.InverseTargets.Values)
				{
					hits.Add(value.Value.Key);
				}
			}
			if (entry.InverseExternalTargets == null)
			{
				return;
			}
			{
				foreach (LinkedListNode<KeyValuePair<IReference, T>> value2 in entry.InverseExternalTargets.Values)
				{
					hits.Add(value2.Value.Key);
				}
				return;
			}
		}
		if (entry.ForwardTargets != null)
		{
			foreach (LinkedListNode<KeyValuePair<IReference, T>> value3 in entry.ForwardTargets.Values)
			{
				hits.Add(value3.Value.Key);
			}
		}
		if (entry.ForwardExternalTargets == null)
		{
			return;
		}
		foreach (LinkedListNode<KeyValuePair<IReference, T>> value4 in entry.ForwardExternalTargets.Values)
		{
			hits.Add(value4.Value.Key);
		}
	}
}
