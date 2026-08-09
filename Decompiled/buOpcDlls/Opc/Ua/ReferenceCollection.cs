using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ReferenceCollection : IReferenceCollection, ICollection<IReference>, IEnumerable<IReference>, IEnumerable, IFormattable
{
	private IReferenceDictionary<object> m_references;

	public int Count => m_references.Count;

	public bool IsReadOnly => false;

	public ReferenceCollection()
	{
		m_references = new IReferenceDictionary<object>();
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format != null)
		{
			throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
		}
		return Utils.Format("References {0}", m_references.Count);
	}

	public void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		m_references[new ReferenceNode(referenceTypeId, isInverse, targetId)] = null;
	}

	public bool Remove(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		return m_references.Remove(new ReferenceNode(referenceTypeId, isInverse, targetId));
	}

	public bool RemoveAll(NodeId referenceTypeId, bool isInverse)
	{
		return m_references.RemoveAll(referenceTypeId, isInverse);
	}

	public bool Exists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId, bool includeSubtypes, ITypeTable typeTree)
	{
		ReferenceNode referenceNode = new ReferenceNode(referenceTypeId, isInverse, targetId);
		if (m_references.ContainsKey(referenceNode))
		{
			return true;
		}
		if (!includeSubtypes || typeTree == null)
		{
			return false;
		}
		return m_references.ContainsKey(referenceNode, typeTree);
	}

	public IList<IReference> Find(NodeId referenceTypeId, bool isInverse, bool includeSubtypes, ITypeTable typeTree)
	{
		if (!includeSubtypes || typeTree == null)
		{
			return m_references.Find(referenceTypeId, isInverse);
		}
		return m_references.Find(referenceTypeId, isInverse, typeTree);
	}

	public ExpandedNodeId FindTarget(NodeId referenceTypeId, bool isInverse, bool includeSubtypes, ITypeTable typeTree, int index)
	{
		IList<IReference> list = null;
		list = ((includeSubtypes && typeTree != null) ? m_references.Find(referenceTypeId, isInverse, typeTree) : m_references.Find(referenceTypeId, isInverse));
		if (index >= 0 && index < list.Count)
		{
			return list[index].TargetId;
		}
		return null;
	}

	public IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId)
	{
		return m_references.FindReferencesToTarget(targetId);
	}

	public void Add(IReference item)
	{
		m_references.Add(item, null);
	}

	public bool Remove(IReference item)
	{
		return m_references.Remove(item);
	}

	public void Clear()
	{
		m_references.Clear();
	}

	public bool Contains(IReference item)
	{
		return m_references.ContainsKey(item);
	}

	public void CopyTo(IReference[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex < 0 || arrayIndex >= array.Length");
		}
		KeyValuePair<IReference, object>[] array2 = new KeyValuePair<IReference, object>[array.Length - arrayIndex];
		m_references.CopyTo(array2, 0);
		for (int i = 0; i < array2.Length; i++)
		{
			array[arrayIndex + i] = array2[i].Key;
		}
	}

	public IEnumerator<IReference> GetEnumerator()
	{
		return m_references.Keys.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
