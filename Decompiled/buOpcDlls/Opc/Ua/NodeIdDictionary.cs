using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeIdDictionary<T> : IDictionary<NodeId, T>, ICollection<KeyValuePair<NodeId, T>>, IEnumerable<KeyValuePair<NodeId, T>>, IEnumerable
{
	private class DictionarySet
	{
		public SortedDictionary<string, T> String;

		public SortedDictionary<Guid, T> Guid;

		public SortedDictionary<ByteKey, T> Opaque;
	}

	private struct ByteKey(byte[] bytes) : IEquatable<ByteKey>, IComparable<ByteKey>
	{
		public byte[] Bytes = bytes;

		public bool Equals(ByteKey other)
		{
			if (other.Bytes == null || Bytes == null)
			{
				if (other.Bytes == null)
				{
					return Bytes == null;
				}
				return false;
			}
			if (other.Bytes.Length != Bytes.Length)
			{
				return false;
			}
			for (int i = 0; i < other.Bytes.Length; i++)
			{
				if (other.Bytes[i] != Bytes[i])
				{
					return false;
				}
			}
			return false;
		}

		public int CompareTo(ByteKey other)
		{
			if (other.Bytes == null || Bytes == null)
			{
				if (other.Bytes != null)
				{
					return -1;
				}
				return 1;
			}
			if (other.Bytes.Length != Bytes.Length)
			{
				if (other.Bytes.Length >= Bytes.Length)
				{
					return -1;
				}
				return 1;
			}
			for (int i = 0; i < other.Bytes.Length; i++)
			{
				if (other.Bytes[i] != Bytes[i])
				{
					if (other.Bytes[i] >= Bytes[i])
					{
						return -1;
					}
					return 1;
				}
			}
			return 0;
		}
	}

	private class Enumerator : IEnumerator<KeyValuePair<NodeId, T>>, IDisposable, IEnumerator
	{
		private NodeIdDictionary<T> m_dictionary;

		private ushort m_namespaceIndex;

		private IdType m_idType;

		private IDictionaryEnumerator m_enumerator;

		private ulong m_version;

		public KeyValuePair<NodeId, T> Current
		{
			get
			{
				CheckVersion();
				if (m_enumerator == null)
				{
					throw new InvalidOperationException("The enumerator is positioned before the first element of the collection or after the last element.");
				}
				NodeId key = null;
				switch (m_idType)
				{
				case IdType.Numeric:
				{
					ulong num = (ulong)m_enumerator.Key;
					key = new NodeId((uint)(num & 0xFFFFFFFFu), (ushort)((num >> 32) & 0xFFFF));
					break;
				}
				case IdType.String:
					key = new NodeId((string)m_enumerator.Key, m_namespaceIndex);
					break;
				case IdType.Guid:
					key = new NodeId((Guid)m_enumerator.Key, m_namespaceIndex);
					break;
				case IdType.Opaque:
					key = new NodeId(((ByteKey)m_enumerator.Key).Bytes, m_namespaceIndex);
					break;
				}
				return new KeyValuePair<NodeId, T>(key, (T)m_enumerator.Value);
			}
		}

		object IEnumerator.Current => Current;

		public Enumerator(NodeIdDictionary<T> dictionary)
		{
			m_dictionary = dictionary;
			m_version = dictionary.m_version;
			m_idType = IdType.Numeric;
			m_namespaceIndex = 0;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public bool MoveNext()
		{
			CheckVersion();
			if (m_enumerator == null)
			{
				m_enumerator = m_dictionary.m_numericIds.GetEnumerator();
				m_idType = IdType.Numeric;
				m_namespaceIndex = 0;
			}
			if (m_enumerator.MoveNext())
			{
				return true;
			}
			while (m_dictionary.m_dictionarySets != null && m_namespaceIndex < m_dictionary.m_dictionarySets.Length)
			{
				if (m_idType == IdType.Numeric)
				{
					m_idType = IdType.String;
					IDictionary<string, T> stringDictionary = m_dictionary.GetStringDictionary(m_namespaceIndex, create: false);
					if (stringDictionary != null)
					{
						ReleaseEnumerator();
						m_enumerator = (IDictionaryEnumerator)stringDictionary.GetEnumerator();
						if (m_enumerator.MoveNext())
						{
							return true;
						}
					}
				}
				if (m_idType == IdType.String)
				{
					m_idType = IdType.Guid;
					IDictionary<Guid, T> guidDictionary = m_dictionary.GetGuidDictionary(m_namespaceIndex, create: false);
					if (guidDictionary != null)
					{
						ReleaseEnumerator();
						m_enumerator = (IDictionaryEnumerator)guidDictionary.GetEnumerator();
						if (m_enumerator.MoveNext())
						{
							return true;
						}
					}
				}
				if (m_idType == IdType.Guid)
				{
					m_idType = IdType.Opaque;
					IDictionary<ByteKey, T> opaqueDictionary = m_dictionary.GetOpaqueDictionary(m_namespaceIndex, create: false);
					if (opaqueDictionary != null)
					{
						ReleaseEnumerator();
						m_enumerator = (IDictionaryEnumerator)opaqueDictionary.GetEnumerator();
						if (m_enumerator.MoveNext())
						{
							return true;
						}
					}
				}
				m_idType = IdType.Numeric;
				m_namespaceIndex++;
			}
			ReleaseEnumerator();
			return false;
		}

		public void Reset()
		{
			CheckVersion();
			ReleaseEnumerator();
			m_idType = IdType.Numeric;
			m_namespaceIndex = 0;
		}

		private void ReleaseEnumerator()
		{
			if (m_enumerator != null)
			{
				if (m_enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
				m_enumerator = null;
			}
		}

		private void CheckVersion()
		{
			if (m_version != m_dictionary.m_version)
			{
				throw new InvalidOperationException("The dictionary was modified after the enumerator was created.");
			}
		}
	}

	private DictionarySet[] m_dictionarySets;

	private SortedDictionary<ulong, T> m_numericIds;

	private ulong m_version;

	public ICollection<NodeId> Keys
	{
		get
		{
			List<NodeId> list = new List<NodeId>();
			foreach (ulong key in m_numericIds.Keys)
			{
				list.Add(new NodeId((uint)(key & 0xFFFFFFFFu), (ushort)((key >> 32) & 0xFFFF)));
			}
			if (m_dictionarySets == null)
			{
				return list;
			}
			for (ushort num = 0; num < (ushort)m_dictionarySets.Length; num++)
			{
				DictionarySet dictionarySet = m_dictionarySets[num];
				if (dictionarySet != null)
				{
					if (dictionarySet.String != null)
					{
						foreach (string key2 in dictionarySet.String.Keys)
						{
							list.Add(new NodeId(key2, num));
						}
					}
					if (dictionarySet.Guid != null)
					{
						foreach (Guid key3 in dictionarySet.Guid.Keys)
						{
							list.Add(new NodeId(key3, num));
						}
					}
					if (dictionarySet.Opaque != null)
					{
						foreach (ByteKey key4 in dictionarySet.Opaque.Keys)
						{
							list.Add(new NodeId(key4.Bytes, num));
						}
					}
				}
			}
			return list;
		}
	}

	public ICollection<T> Values
	{
		get
		{
			List<T> list = new List<T>();
			list.AddRange(m_numericIds.Values);
			if (m_dictionarySets == null)
			{
				return list;
			}
			for (int i = 0; i < m_dictionarySets.Length; i++)
			{
				DictionarySet dictionarySet = m_dictionarySets[i];
				if (dictionarySet != null)
				{
					if (dictionarySet.String != null)
					{
						list.AddRange(dictionarySet.String.Values);
					}
					if (dictionarySet.Guid != null)
					{
						list.AddRange(dictionarySet.Guid.Values);
					}
					if (dictionarySet.Opaque != null)
					{
						list.AddRange(dictionarySet.Opaque.Values);
					}
				}
			}
			return list;
		}
	}

	public T this[NodeId key]
	{
		get
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			switch (key.IdType)
			{
			case IdType.Numeric:
			{
				ulong num = (ulong)key.NamespaceIndex << 32;
				num += (uint)key.Identifier;
				return m_numericIds[num];
			}
			case IdType.String:
			{
				IDictionary<string, T> stringDictionary = GetStringDictionary(key.NamespaceIndex, create: false);
				if (stringDictionary != null)
				{
					return stringDictionary[(string)key.Identifier];
				}
				break;
			}
			case IdType.Guid:
			{
				IDictionary<Guid, T> guidDictionary = GetGuidDictionary(key.NamespaceIndex, create: false);
				if (guidDictionary != null)
				{
					return guidDictionary[(Guid)key.Identifier];
				}
				break;
			}
			case IdType.Opaque:
			{
				IDictionary<ByteKey, T> opaqueDictionary = GetOpaqueDictionary(key.NamespaceIndex, create: false);
				if (opaqueDictionary != null)
				{
					return opaqueDictionary[new ByteKey((byte[])key.Identifier)];
				}
				break;
			}
			}
			throw new KeyNotFoundException();
		}
		set
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			m_version++;
			switch (key.IdType)
			{
			case IdType.Numeric:
			{
				ulong num = (ulong)key.NamespaceIndex << 32;
				num += (uint)key.Identifier;
				m_numericIds[num] = value;
				break;
			}
			case IdType.String:
				GetStringDictionary(key.NamespaceIndex, create: true)[(string)key.Identifier] = value;
				break;
			case IdType.Guid:
				GetGuidDictionary(key.NamespaceIndex, create: true)[(Guid)key.Identifier] = value;
				break;
			case IdType.Opaque:
				GetOpaqueDictionary(key.NamespaceIndex, create: true)[new ByteKey((byte[])key.Identifier)] = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("key", "key.IdType");
			}
		}
	}

	public int Count
	{
		get
		{
			int num = m_numericIds.Count;
			if (m_dictionarySets == null)
			{
				return num;
			}
			for (int i = 0; i < m_dictionarySets.Length; i++)
			{
				DictionarySet dictionarySet = m_dictionarySets[i];
				if (dictionarySet != null)
				{
					if (dictionarySet.String != null)
					{
						num += dictionarySet.String.Count;
					}
					if (dictionarySet.Guid != null)
					{
						num += dictionarySet.Guid.Count;
					}
					if (dictionarySet.Opaque != null)
					{
						num += dictionarySet.Opaque.Count;
					}
				}
			}
			return num;
		}
	}

	public bool IsReadOnly => false;

	public NodeIdDictionary()
	{
		m_version = 0uL;
		m_numericIds = new SortedDictionary<ulong, T>();
	}

	public void Add(NodeId key, T value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		m_version++;
		switch (key.IdType)
		{
		case IdType.Numeric:
		{
			ulong num = (ulong)key.NamespaceIndex << 32;
			num += (uint)key.Identifier;
			m_numericIds.Add(num, value);
			break;
		}
		case IdType.String:
			GetStringDictionary(key.NamespaceIndex, create: true).Add((string)key.Identifier, value);
			break;
		case IdType.Guid:
			GetGuidDictionary(key.NamespaceIndex, create: true).Add((Guid)key.Identifier, value);
			break;
		case IdType.Opaque:
			GetOpaqueDictionary(key.NamespaceIndex, create: true).Add(new ByteKey((byte[])key.Identifier), value);
			break;
		default:
			throw new ArgumentOutOfRangeException("key", "key.IdType");
		}
	}

	public bool ContainsKey(NodeId key)
	{
		if (key == null)
		{
			return false;
		}
		switch (key.IdType)
		{
		case IdType.Numeric:
		{
			ulong num = (ulong)key.NamespaceIndex << 32;
			num += (uint)key.Identifier;
			return m_numericIds.ContainsKey(num);
		}
		case IdType.String:
		{
			IDictionary<string, T> stringDictionary = GetStringDictionary(key.NamespaceIndex, create: false);
			if (stringDictionary != null)
			{
				return stringDictionary.ContainsKey((string)key.Identifier);
			}
			break;
		}
		case IdType.Guid:
		{
			IDictionary<Guid, T> guidDictionary = GetGuidDictionary(key.NamespaceIndex, create: false);
			if (guidDictionary != null)
			{
				return guidDictionary.ContainsKey((Guid)key.Identifier);
			}
			break;
		}
		case IdType.Opaque:
		{
			IDictionary<ByteKey, T> opaqueDictionary = GetOpaqueDictionary(key.NamespaceIndex, create: false);
			if (opaqueDictionary != null)
			{
				return opaqueDictionary.ContainsKey(new ByteKey((byte[])key.Identifier));
			}
			break;
		}
		}
		return false;
	}

	public bool Remove(NodeId key)
	{
		if (key == null)
		{
			return false;
		}
		m_version++;
		switch (key.IdType)
		{
		case IdType.Numeric:
		{
			ulong num = (ulong)key.NamespaceIndex << 32;
			num += (uint)key.Identifier;
			return m_numericIds.Remove(num);
		}
		case IdType.String:
		{
			IDictionary<string, T> stringDictionary = GetStringDictionary(key.NamespaceIndex, create: false);
			if (stringDictionary != null)
			{
				return stringDictionary.Remove((string)key.Identifier);
			}
			break;
		}
		case IdType.Guid:
		{
			IDictionary<Guid, T> guidDictionary = GetGuidDictionary(key.NamespaceIndex, create: false);
			if (guidDictionary != null)
			{
				return guidDictionary.Remove((Guid)key.Identifier);
			}
			break;
		}
		case IdType.Opaque:
		{
			IDictionary<ByteKey, T> opaqueDictionary = GetOpaqueDictionary(key.NamespaceIndex, create: false);
			if (opaqueDictionary != null)
			{
				return opaqueDictionary.Remove(new ByteKey((byte[])key.Identifier));
			}
			break;
		}
		}
		return false;
	}

	public bool TryGetValue(NodeId key, out T value)
	{
		value = default(T);
		if (key == null)
		{
			return false;
		}
		switch (key.IdType)
		{
		case IdType.Numeric:
		{
			ulong num = (ulong)key.NamespaceIndex << 32;
			num += (uint)key.Identifier;
			return m_numericIds.TryGetValue(num, out value);
		}
		case IdType.String:
		{
			IDictionary<string, T> stringDictionary = GetStringDictionary(key.NamespaceIndex, create: false);
			if (stringDictionary != null)
			{
				return stringDictionary.TryGetValue((string)key.Identifier, out value);
			}
			break;
		}
		case IdType.Guid:
		{
			IDictionary<Guid, T> guidDictionary = GetGuidDictionary(key.NamespaceIndex, create: false);
			if (guidDictionary != null)
			{
				return guidDictionary.TryGetValue((Guid)key.Identifier, out value);
			}
			break;
		}
		case IdType.Opaque:
		{
			IDictionary<ByteKey, T> opaqueDictionary = GetOpaqueDictionary(key.NamespaceIndex, create: false);
			if (opaqueDictionary != null)
			{
				return opaqueDictionary.TryGetValue(new ByteKey((byte[])key.Identifier), out value);
			}
			break;
		}
		}
		return false;
	}

	public void Add(KeyValuePair<NodeId, T> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		m_version++;
		m_numericIds.Clear();
		m_dictionarySets = null;
	}

	public bool Contains(KeyValuePair<NodeId, T> item)
	{
		if (!TryGetValue(item.Key, out var value))
		{
			return false;
		}
		return object.Equals(value, item.Value);
	}

	public void CopyTo(KeyValuePair<NodeId, T>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || array.Length <= arrayIndex)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex < 0 || array.Length <= arrayIndex");
		}
		foreach (KeyValuePair<ulong, T> numericId in m_numericIds)
		{
			CheckCopyTo(array, arrayIndex);
			array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId((uint)(numericId.Key & 0xFFFFFFFFu), (ushort)((numericId.Key >> 32) & 0xFFFF)), numericId.Value);
		}
		if (m_dictionarySets == null)
		{
			return;
		}
		for (int i = 0; i < m_dictionarySets.Length; i++)
		{
			DictionarySet dictionarySet = m_dictionarySets[i];
			if (dictionarySet == null)
			{
				continue;
			}
			if (dictionarySet.String != null)
			{
				foreach (KeyValuePair<string, T> item in dictionarySet.String)
				{
					CheckCopyTo(array, arrayIndex);
					array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(item.Key, (ushort)i), item.Value);
				}
			}
			if (dictionarySet.Guid != null)
			{
				foreach (KeyValuePair<Guid, T> item2 in dictionarySet.Guid)
				{
					CheckCopyTo(array, arrayIndex);
					array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(item2.Key, (ushort)i), item2.Value);
				}
			}
			if (dictionarySet.Opaque == null)
			{
				continue;
			}
			foreach (KeyValuePair<ByteKey, T> item3 in dictionarySet.Opaque)
			{
				CheckCopyTo(array, arrayIndex);
				array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(item3.Key.Bytes, (ushort)i), item3.Value);
			}
		}
	}

	private static void CheckCopyTo(KeyValuePair<NodeId, T>[] array, int arrayIndex)
	{
		if (arrayIndex >= array.Length)
		{
			throw new ArgumentException("Not enough space in array.", "array");
		}
	}

	public bool Remove(KeyValuePair<NodeId, T> item)
	{
		return Remove(item.Key);
	}

	public IEnumerator<KeyValuePair<NodeId, T>> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private DictionarySet GetDictionarySet(ushort namespaceIndex, bool create)
	{
		if (m_dictionarySets == null || m_dictionarySets.Length <= namespaceIndex)
		{
			if (!create)
			{
				return null;
			}
			DictionarySet[] array = new DictionarySet[namespaceIndex + 1];
			if (m_dictionarySets != null)
			{
				Array.Copy(m_dictionarySets, array, m_dictionarySets.Length);
			}
			m_dictionarySets = array;
		}
		DictionarySet dictionarySet = m_dictionarySets[namespaceIndex];
		if (dictionarySet == null)
		{
			if (!create)
			{
				return null;
			}
			dictionarySet = (m_dictionarySets[namespaceIndex] = new DictionarySet());
		}
		return dictionarySet;
	}

	private IDictionary<string, T> GetStringDictionary(ushort namespaceIndex, bool create)
	{
		DictionarySet dictionarySet = GetDictionarySet(namespaceIndex, create);
		if (dictionarySet == null)
		{
			return null;
		}
		IDictionary<string, T> dictionary = dictionarySet.String;
		if (dictionary == null)
		{
			if (!create)
			{
				return null;
			}
			dictionary = (dictionarySet.String = new SortedDictionary<string, T>());
		}
		return dictionary;
	}

	private IDictionary<Guid, T> GetGuidDictionary(ushort namespaceIndex, bool create)
	{
		DictionarySet dictionarySet = GetDictionarySet(namespaceIndex, create);
		if (dictionarySet == null)
		{
			return null;
		}
		IDictionary<Guid, T> dictionary = dictionarySet.Guid;
		if (dictionary == null)
		{
			if (!create)
			{
				return null;
			}
			dictionary = (dictionarySet.Guid = new SortedDictionary<Guid, T>());
		}
		return dictionary;
	}

	private IDictionary<ByteKey, T> GetOpaqueDictionary(ushort namespaceIndex, bool create)
	{
		DictionarySet dictionarySet = GetDictionarySet(namespaceIndex, create);
		if (dictionarySet == null)
		{
			return null;
		}
		IDictionary<ByteKey, T> dictionary = dictionarySet.Opaque;
		if (dictionary == null)
		{
			if (!create)
			{
				return null;
			}
			dictionary = (dictionarySet.Opaque = new SortedDictionary<ByteKey, T>());
		}
		return dictionary;
	}
}
