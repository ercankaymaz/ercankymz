// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeIdDictionary`1
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
public class NodeIdDictionary<T> : 
  IDictionary<NodeId, T>,
  ICollection<KeyValuePair<NodeId, T>>,
  IEnumerable<KeyValuePair<NodeId, T>>,
  IEnumerable
{
  private NodeIdDictionary<T>.DictionarySet[] m_dictionarySets;
  private SortedDictionary<ulong, T> m_numericIds;
  private ulong m_version;

  public NodeIdDictionary()
  {
    this.m_version = 0UL;
    this.m_numericIds = new SortedDictionary<ulong, T>();
  }

  public void Add(NodeId key, T value)
  {
    if (key == (object) null)
      throw new ArgumentNullException(nameof (key));
    ++this.m_version;
    switch (key.IdType)
    {
      case IdType.Numeric:
        this.m_numericIds.Add(((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier, value);
        break;
      case IdType.String:
        this.GetStringDictionary(key.NamespaceIndex, true).Add((string) key.Identifier, value);
        break;
      case IdType.Guid:
        this.GetGuidDictionary(key.NamespaceIndex, true).Add((Guid) key.Identifier, value);
        break;
      case IdType.Opaque:
        this.GetOpaqueDictionary(key.NamespaceIndex, true).Add(new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier), value);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof (key), "key.IdType");
    }
  }

  public bool ContainsKey(NodeId key)
  {
    if (key == (object) null)
      return false;
    switch (key.IdType)
    {
      case IdType.Numeric:
        return this.m_numericIds.ContainsKey(((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier);
      case IdType.String:
        IDictionary<string, T> stringDictionary = this.GetStringDictionary(key.NamespaceIndex, false);
        if (stringDictionary != null)
          return stringDictionary.ContainsKey((string) key.Identifier);
        break;
      case IdType.Guid:
        IDictionary<Guid, T> guidDictionary = this.GetGuidDictionary(key.NamespaceIndex, false);
        if (guidDictionary != null)
          return guidDictionary.ContainsKey((Guid) key.Identifier);
        break;
      case IdType.Opaque:
        IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = this.GetOpaqueDictionary(key.NamespaceIndex, false);
        if (opaqueDictionary != null)
          return opaqueDictionary.ContainsKey(new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier));
        break;
    }
    return false;
  }

  public ICollection<NodeId> Keys
  {
    get
    {
      List<NodeId> keys = new List<NodeId>();
      foreach (ulong key in this.m_numericIds.Keys)
        keys.Add(new NodeId((uint) (key & (ulong) uint.MaxValue), (ushort) (key >> 32 /*0x20*/ & (ulong) ushort.MaxValue)));
      if (this.m_dictionarySets == null)
        return (ICollection<NodeId>) keys;
      for (ushort namespaceIndex = 0; (int) namespaceIndex < (int) (ushort) this.m_dictionarySets.Length; ++namespaceIndex)
      {
        NodeIdDictionary<T>.DictionarySet dictionarySet = this.m_dictionarySets[(int) namespaceIndex];
        if (dictionarySet != null)
        {
          if (dictionarySet.String != null)
          {
            foreach (string key in dictionarySet.String.Keys)
              keys.Add(new NodeId(key, namespaceIndex));
          }
          if (dictionarySet.Guid != null)
          {
            foreach (Guid key in dictionarySet.Guid.Keys)
              keys.Add(new NodeId(key, namespaceIndex));
          }
          if (dictionarySet.Opaque != null)
          {
            foreach (NodeIdDictionary<T>.ByteKey key in dictionarySet.Opaque.Keys)
              keys.Add(new NodeId(key.Bytes, namespaceIndex));
          }
        }
      }
      return (ICollection<NodeId>) keys;
    }
  }

  public bool Remove(NodeId key)
  {
    if (key == (object) null)
      return false;
    ++this.m_version;
    switch (key.IdType)
    {
      case IdType.Numeric:
        return this.m_numericIds.Remove(((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier);
      case IdType.String:
        IDictionary<string, T> stringDictionary = this.GetStringDictionary(key.NamespaceIndex, false);
        if (stringDictionary != null)
          return stringDictionary.Remove((string) key.Identifier);
        break;
      case IdType.Guid:
        IDictionary<Guid, T> guidDictionary = this.GetGuidDictionary(key.NamespaceIndex, false);
        if (guidDictionary != null)
          return guidDictionary.Remove((Guid) key.Identifier);
        break;
      case IdType.Opaque:
        IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = this.GetOpaqueDictionary(key.NamespaceIndex, false);
        if (opaqueDictionary != null)
          return opaqueDictionary.Remove(new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier));
        break;
    }
    return false;
  }

  public bool TryGetValue(NodeId key, out T value)
  {
    value = default (T);
    if (key == (object) null)
      return false;
    switch (key.IdType)
    {
      case IdType.Numeric:
        return this.m_numericIds.TryGetValue(((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier, out value);
      case IdType.String:
        IDictionary<string, T> stringDictionary = this.GetStringDictionary(key.NamespaceIndex, false);
        if (stringDictionary != null)
          return stringDictionary.TryGetValue((string) key.Identifier, out value);
        break;
      case IdType.Guid:
        IDictionary<Guid, T> guidDictionary = this.GetGuidDictionary(key.NamespaceIndex, false);
        if (guidDictionary != null)
          return guidDictionary.TryGetValue((Guid) key.Identifier, out value);
        break;
      case IdType.Opaque:
        IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = this.GetOpaqueDictionary(key.NamespaceIndex, false);
        if (opaqueDictionary != null)
          return opaqueDictionary.TryGetValue(new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier), out value);
        break;
    }
    return false;
  }

  public ICollection<T> Values
  {
    get
    {
      List<T> values = new List<T>();
      values.AddRange((IEnumerable<T>) this.m_numericIds.Values);
      if (this.m_dictionarySets == null)
        return (ICollection<T>) values;
      for (int index = 0; index < this.m_dictionarySets.Length; ++index)
      {
        NodeIdDictionary<T>.DictionarySet dictionarySet = this.m_dictionarySets[index];
        if (dictionarySet != null)
        {
          if (dictionarySet.String != null)
            values.AddRange((IEnumerable<T>) dictionarySet.String.Values);
          if (dictionarySet.Guid != null)
            values.AddRange((IEnumerable<T>) dictionarySet.Guid.Values);
          if (dictionarySet.Opaque != null)
            values.AddRange((IEnumerable<T>) dictionarySet.Opaque.Values);
        }
      }
      return (ICollection<T>) values;
    }
  }

  public T this[NodeId key]
  {
    get
    {
      if (key == (object) null)
        throw new ArgumentNullException(nameof (key));
      switch (key.IdType)
      {
        case IdType.Numeric:
          return this.m_numericIds[((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier];
        case IdType.String:
          IDictionary<string, T> stringDictionary = this.GetStringDictionary(key.NamespaceIndex, false);
          if (stringDictionary != null)
            return stringDictionary[(string) key.Identifier];
          break;
        case IdType.Guid:
          IDictionary<Guid, T> guidDictionary = this.GetGuidDictionary(key.NamespaceIndex, false);
          if (guidDictionary != null)
            return guidDictionary[(Guid) key.Identifier];
          break;
        case IdType.Opaque:
          IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = this.GetOpaqueDictionary(key.NamespaceIndex, false);
          if (opaqueDictionary != null)
            return opaqueDictionary[new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier)];
          break;
      }
      throw new KeyNotFoundException();
    }
    set
    {
      if (key == (object) null)
        throw new ArgumentNullException(nameof (key));
      ++this.m_version;
      switch (key.IdType)
      {
        case IdType.Numeric:
          this.m_numericIds[((ulong) key.NamespaceIndex << 32 /*0x20*/) + (ulong) (uint) key.Identifier] = value;
          break;
        case IdType.String:
          this.GetStringDictionary(key.NamespaceIndex, true)[(string) key.Identifier] = value;
          break;
        case IdType.Guid:
          this.GetGuidDictionary(key.NamespaceIndex, true)[(Guid) key.Identifier] = value;
          break;
        case IdType.Opaque:
          this.GetOpaqueDictionary(key.NamespaceIndex, true)[new NodeIdDictionary<T>.ByteKey((byte[]) key.Identifier)] = value;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof (key), "key.IdType");
      }
    }
  }

  public void Add(KeyValuePair<NodeId, T> item) => this.Add(item.Key, item.Value);

  public void Clear()
  {
    ++this.m_version;
    this.m_numericIds.Clear();
    this.m_dictionarySets = (NodeIdDictionary<T>.DictionarySet[]) null;
  }

  public bool Contains(KeyValuePair<NodeId, T> item)
  {
    T objA;
    return this.TryGetValue(item.Key, out objA) && object.Equals((object) objA, (object) item.Value);
  }

  public void CopyTo(KeyValuePair<NodeId, T>[] array, int arrayIndex)
  {
    if (array == null)
      throw new ArgumentNullException(nameof (array));
    if (arrayIndex < 0 || array.Length <= arrayIndex)
      throw new ArgumentOutOfRangeException(nameof (arrayIndex), "arrayIndex < 0 || array.Length <= arrayIndex");
    foreach (KeyValuePair<ulong, T> numericId in this.m_numericIds)
    {
      NodeIdDictionary<T>.CheckCopyTo(array, arrayIndex);
      array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId((uint) (numericId.Key & (ulong) uint.MaxValue), (ushort) (numericId.Key >> 32 /*0x20*/ & (ulong) ushort.MaxValue)), numericId.Value);
    }
    if (this.m_dictionarySets == null)
      return;
    for (int namespaceIndex = 0; namespaceIndex < this.m_dictionarySets.Length; ++namespaceIndex)
    {
      NodeIdDictionary<T>.DictionarySet dictionarySet = this.m_dictionarySets[namespaceIndex];
      if (dictionarySet != null)
      {
        if (dictionarySet.String != null)
        {
          foreach (KeyValuePair<string, T> keyValuePair in dictionarySet.String)
          {
            NodeIdDictionary<T>.CheckCopyTo(array, arrayIndex);
            array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(keyValuePair.Key, (ushort) namespaceIndex), keyValuePair.Value);
          }
        }
        if (dictionarySet.Guid != null)
        {
          foreach (KeyValuePair<Guid, T> keyValuePair in dictionarySet.Guid)
          {
            NodeIdDictionary<T>.CheckCopyTo(array, arrayIndex);
            array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(keyValuePair.Key, (ushort) namespaceIndex), keyValuePair.Value);
          }
        }
        if (dictionarySet.Opaque != null)
        {
          foreach (KeyValuePair<NodeIdDictionary<T>.ByteKey, T> keyValuePair in dictionarySet.Opaque)
          {
            NodeIdDictionary<T>.CheckCopyTo(array, arrayIndex);
            array[arrayIndex++] = new KeyValuePair<NodeId, T>(new NodeId(keyValuePair.Key.Bytes, (ushort) namespaceIndex), keyValuePair.Value);
          }
        }
      }
    }
  }

  private static void CheckCopyTo(KeyValuePair<NodeId, T>[] array, int arrayIndex)
  {
    if (arrayIndex >= array.Length)
      throw new ArgumentException("Not enough space in array.", nameof (array));
  }

  public int Count
  {
    get
    {
      int count = this.m_numericIds.Count;
      if (this.m_dictionarySets == null)
        return count;
      for (int index = 0; index < this.m_dictionarySets.Length; ++index)
      {
        NodeIdDictionary<T>.DictionarySet dictionarySet = this.m_dictionarySets[index];
        if (dictionarySet != null)
        {
          if (dictionarySet.String != null)
            count += dictionarySet.String.Count;
          if (dictionarySet.Guid != null)
            count += dictionarySet.Guid.Count;
          if (dictionarySet.Opaque != null)
            count += dictionarySet.Opaque.Count;
        }
      }
      return count;
    }
  }

  public bool IsReadOnly => false;

  public bool Remove(KeyValuePair<NodeId, T> item) => this.Remove(item.Key);

  public IEnumerator<KeyValuePair<NodeId, T>> GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<NodeId, T>>) new NodeIdDictionary<T>.Enumerator(this);
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  private NodeIdDictionary<T>.DictionarySet GetDictionarySet(ushort namespaceIndex, bool create)
  {
    if (this.m_dictionarySets == null || this.m_dictionarySets.Length <= (int) namespaceIndex)
    {
      if (!create)
        return (NodeIdDictionary<T>.DictionarySet) null;
      NodeIdDictionary<T>.DictionarySet[] destinationArray = new NodeIdDictionary<T>.DictionarySet[(int) namespaceIndex + 1];
      if (this.m_dictionarySets != null)
        Array.Copy((Array) this.m_dictionarySets, (Array) destinationArray, this.m_dictionarySets.Length);
      this.m_dictionarySets = destinationArray;
    }
    NodeIdDictionary<T>.DictionarySet dictionarySet = this.m_dictionarySets[(int) namespaceIndex];
    if (dictionarySet == null)
    {
      if (!create)
        return (NodeIdDictionary<T>.DictionarySet) null;
      this.m_dictionarySets[(int) namespaceIndex] = dictionarySet = new NodeIdDictionary<T>.DictionarySet();
    }
    return dictionarySet;
  }

  private IDictionary<string, T> GetStringDictionary(ushort namespaceIndex, bool create)
  {
    NodeIdDictionary<T>.DictionarySet dictionarySet = this.GetDictionarySet(namespaceIndex, create);
    if (dictionarySet == null)
      return (IDictionary<string, T>) null;
    IDictionary<string, T> stringDictionary = (IDictionary<string, T>) dictionarySet.String;
    if (stringDictionary == null)
    {
      if (!create)
        return (IDictionary<string, T>) null;
      stringDictionary = (IDictionary<string, T>) (dictionarySet.String = new SortedDictionary<string, T>());
    }
    return stringDictionary;
  }

  private IDictionary<Guid, T> GetGuidDictionary(ushort namespaceIndex, bool create)
  {
    NodeIdDictionary<T>.DictionarySet dictionarySet = this.GetDictionarySet(namespaceIndex, create);
    if (dictionarySet == null)
      return (IDictionary<Guid, T>) null;
    IDictionary<Guid, T> guidDictionary = (IDictionary<Guid, T>) dictionarySet.Guid;
    if (guidDictionary == null)
    {
      if (!create)
        return (IDictionary<Guid, T>) null;
      guidDictionary = (IDictionary<Guid, T>) (dictionarySet.Guid = new SortedDictionary<Guid, T>());
    }
    return guidDictionary;
  }

  private IDictionary<NodeIdDictionary<T>.ByteKey, T> GetOpaqueDictionary(
    ushort namespaceIndex,
    bool create)
  {
    NodeIdDictionary<T>.DictionarySet dictionarySet = this.GetDictionarySet(namespaceIndex, create);
    if (dictionarySet == null)
      return (IDictionary<NodeIdDictionary<T>.ByteKey, T>) null;
    IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = (IDictionary<NodeIdDictionary<T>.ByteKey, T>) dictionarySet.Opaque;
    if (opaqueDictionary == null)
    {
      if (!create)
        return (IDictionary<NodeIdDictionary<T>.ByteKey, T>) null;
      opaqueDictionary = (IDictionary<NodeIdDictionary<T>.ByteKey, T>) (dictionarySet.Opaque = new SortedDictionary<NodeIdDictionary<T>.ByteKey, T>());
    }
    return opaqueDictionary;
  }

  private class DictionarySet
  {
    public SortedDictionary<string, T> String;
    public SortedDictionary<Guid, T> Guid;
    public SortedDictionary<NodeIdDictionary<T>.ByteKey, T> Opaque;
  }

  private struct ByteKey(byte[] bytes) : 
    IEquatable<NodeIdDictionary<T>.ByteKey>,
    IComparable<NodeIdDictionary<T>.ByteKey>
  {
    public byte[] Bytes = bytes;

    public bool Equals(NodeIdDictionary<T>.ByteKey other)
    {
      if (other.Bytes != null && this.Bytes != null)
      {
        if (other.Bytes.Length != this.Bytes.Length)
          return false;
        int index = 0;
        while (index < other.Bytes.Length && (int) other.Bytes[index] == (int) this.Bytes[index])
          ++index;
        return false;
      }
      return other.Bytes == null && this.Bytes == null;
    }

    public int CompareTo(NodeIdDictionary<T>.ByteKey other)
    {
      if (other.Bytes != null && this.Bytes != null)
      {
        if (other.Bytes.Length != this.Bytes.Length)
          return other.Bytes.Length >= this.Bytes.Length ? -1 : 1;
        for (int index = 0; index < other.Bytes.Length; ++index)
        {
          if ((int) other.Bytes[index] != (int) this.Bytes[index])
            return (int) other.Bytes[index] >= (int) this.Bytes[index] ? -1 : 1;
        }
        return 0;
      }
      return other.Bytes != null ? -1 : 1;
    }
  }

  private class Enumerator : IEnumerator<KeyValuePair<NodeId, T>>, IDisposable, IEnumerator
  {
    private NodeIdDictionary<T> m_dictionary;
    private ushort m_namespaceIndex;
    private IdType m_idType;
    private IDictionaryEnumerator m_enumerator;
    private ulong m_version;

    public Enumerator(NodeIdDictionary<T> dictionary)
    {
      this.m_dictionary = dictionary;
      this.m_version = dictionary.m_version;
      this.m_idType = IdType.Numeric;
      this.m_namespaceIndex = (ushort) 0;
    }

    public KeyValuePair<NodeId, T> Current
    {
      get
      {
        this.CheckVersion();
        if (this.m_enumerator == null)
          throw new InvalidOperationException("The enumerator is positioned before the first element of the collection or after the last element.");
        NodeId key1 = (NodeId) null;
        switch (this.m_idType)
        {
          case IdType.Numeric:
            ulong key2 = (ulong) this.m_enumerator.Key;
            key1 = new NodeId((uint) (key2 & (ulong) uint.MaxValue), (ushort) (key2 >> 32 /*0x20*/ & (ulong) ushort.MaxValue));
            break;
          case IdType.String:
            key1 = new NodeId((string) this.m_enumerator.Key, this.m_namespaceIndex);
            break;
          case IdType.Guid:
            key1 = new NodeId((Guid) this.m_enumerator.Key, this.m_namespaceIndex);
            break;
          case IdType.Opaque:
            key1 = new NodeId(((NodeIdDictionary<T>.ByteKey) this.m_enumerator.Key).Bytes, this.m_namespaceIndex);
            break;
        }
        return new KeyValuePair<NodeId, T>(key1, (T) this.m_enumerator.Value);
      }
    }

    public void Dispose() => this.Dispose(true);

    protected virtual void Dispose(bool disposing)
    {
    }

    object IEnumerator.Current => (object) this.Current;

    public bool MoveNext()
    {
      this.CheckVersion();
      if (this.m_enumerator == null)
      {
        this.m_enumerator = (IDictionaryEnumerator) this.m_dictionary.m_numericIds.GetEnumerator();
        this.m_idType = IdType.Numeric;
        this.m_namespaceIndex = (ushort) 0;
      }
      if (this.m_enumerator.MoveNext())
        return true;
      for (; this.m_dictionary.m_dictionarySets != null && (int) this.m_namespaceIndex < this.m_dictionary.m_dictionarySets.Length; ++this.m_namespaceIndex)
      {
        if (this.m_idType == IdType.Numeric)
        {
          this.m_idType = IdType.String;
          IDictionary<string, T> stringDictionary = this.m_dictionary.GetStringDictionary(this.m_namespaceIndex, false);
          if (stringDictionary != null)
          {
            this.ReleaseEnumerator();
            this.m_enumerator = (IDictionaryEnumerator) stringDictionary.GetEnumerator();
            if (this.m_enumerator.MoveNext())
              return true;
          }
        }
        if (this.m_idType == IdType.String)
        {
          this.m_idType = IdType.Guid;
          IDictionary<Guid, T> guidDictionary = this.m_dictionary.GetGuidDictionary(this.m_namespaceIndex, false);
          if (guidDictionary != null)
          {
            this.ReleaseEnumerator();
            this.m_enumerator = (IDictionaryEnumerator) guidDictionary.GetEnumerator();
            if (this.m_enumerator.MoveNext())
              return true;
          }
        }
        if (this.m_idType == IdType.Guid)
        {
          this.m_idType = IdType.Opaque;
          IDictionary<NodeIdDictionary<T>.ByteKey, T> opaqueDictionary = this.m_dictionary.GetOpaqueDictionary(this.m_namespaceIndex, false);
          if (opaqueDictionary != null)
          {
            this.ReleaseEnumerator();
            this.m_enumerator = (IDictionaryEnumerator) opaqueDictionary.GetEnumerator();
            if (this.m_enumerator.MoveNext())
              return true;
          }
        }
        this.m_idType = IdType.Numeric;
      }
      this.ReleaseEnumerator();
      return false;
    }

    public void Reset()
    {
      this.CheckVersion();
      this.ReleaseEnumerator();
      this.m_idType = IdType.Numeric;
      this.m_namespaceIndex = (ushort) 0;
    }

    private void ReleaseEnumerator()
    {
      if (this.m_enumerator == null)
        return;
      if (this.m_enumerator is IDisposable enumerator)
        enumerator.Dispose();
      this.m_enumerator = (IDictionaryEnumerator) null;
    }

    private void CheckVersion()
    {
      if ((long) this.m_version != (long) this.m_dictionary.m_version)
        throw new InvalidOperationException("The dictionary was modified after the enumerator was created.");
    }
  }
}
