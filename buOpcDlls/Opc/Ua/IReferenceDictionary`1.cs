// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IReferenceDictionary`1
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
public class IReferenceDictionary<T> : 
  IDictionary<IReference, T>,
  ICollection<KeyValuePair<IReference, T>>,
  IEnumerable<KeyValuePair<IReference, T>>,
  IEnumerable
{
  private NodeIdDictionary<IReferenceDictionary<T>.ReferenceTypeEntry> m_references;
  private LinkedList<KeyValuePair<IReference, T>> m_list;
  private ulong m_version;

  public IReferenceDictionary()
  {
    this.m_version = 0UL;
    this.m_references = new NodeIdDictionary<IReferenceDictionary<T>.ReferenceTypeEntry>();
    this.m_list = new LinkedList<KeyValuePair<IReference, T>>();
  }

  public bool ContainsKey(IReference reference, ITypeTable typeTree)
  {
    if (typeTree == null)
      throw new ArgumentNullException(nameof (typeTree));
    if (!IReferenceDictionary<T>.ValidateReference(reference, false))
      return false;
    foreach (KeyValuePair<NodeId, IReferenceDictionary<T>.ReferenceTypeEntry> reference1 in this.m_references)
    {
      if (typeTree.IsTypeOf(reference1.Key, reference.ReferenceTypeId) && IReferenceDictionary<T>.ContainsKey(reference1.Value, reference))
        return true;
    }
    return false;
  }

  public IList<IReference> Find(NodeId referenceTypeId, bool isInverse)
  {
    List<IReference> hits = new List<IReference>();
    if (NodeId.IsNull(referenceTypeId))
      return (IList<IReference>) hits;
    IReferenceDictionary<T>.ReferenceTypeEntry entry = (IReferenceDictionary<T>.ReferenceTypeEntry) null;
    if (!this.m_references.TryGetValue(referenceTypeId, out entry))
      return (IList<IReference>) hits;
    IReferenceDictionary<T>.Find(entry, isInverse, hits);
    return (IList<IReference>) hits;
  }

  public IList<IReference> Find(NodeId referenceTypeId, bool isInverse, ITypeTable typeTree)
  {
    if (typeTree == null)
      throw new ArgumentNullException(nameof (typeTree));
    List<IReference> hits = new List<IReference>();
    if (NodeId.IsNull(referenceTypeId))
      return (IList<IReference>) hits;
    foreach (KeyValuePair<NodeId, IReferenceDictionary<T>.ReferenceTypeEntry> reference in this.m_references)
    {
      if (typeTree.IsTypeOf(reference.Key, referenceTypeId))
        IReferenceDictionary<T>.Find(reference.Value, isInverse, hits);
    }
    return (IList<IReference>) hits;
  }

  public IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId)
  {
    List<IReference> referencesToTarget = new List<IReference>();
    if (NodeId.IsNull(targetId))
      return (IList<IReference>) referencesToTarget;
    for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = this.m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
    {
      KeyValuePair<IReference, T> keyValuePair = linkedListNode.Value;
      if (keyValuePair.Key.TargetId == (object) targetId)
      {
        List<IReference> referenceList = referencesToTarget;
        keyValuePair = linkedListNode.Value;
        IReference key = keyValuePair.Key;
        referenceList.Add(key);
      }
    }
    return (IList<IReference>) referencesToTarget;
  }

  public bool RemoveAll(NodeId referenceTypeId, bool isInverse)
  {
    if (NodeId.IsNull(referenceTypeId))
      return false;
    IReferenceDictionary<T>.ReferenceTypeEntry referenceTypeEntry = (IReferenceDictionary<T>.ReferenceTypeEntry) null;
    if (!this.m_references.TryGetValue(referenceTypeId, out referenceTypeEntry))
      return false;
    if (isInverse)
    {
      if (referenceTypeEntry.InverseTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> node in (IEnumerable<LinkedListNode<KeyValuePair<IReference, T>>>) referenceTypeEntry.InverseTargets.Values)
        {
          if (this.m_list == node.List)
            this.m_list.Remove(node);
          referenceTypeEntry.InverseTargets = (NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>) null;
        }
      }
      if (referenceTypeEntry.InverseExternalTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> node in referenceTypeEntry.InverseExternalTargets.Values)
        {
          if (this.m_list == node.List)
            this.m_list.Remove(node);
        }
        referenceTypeEntry.InverseExternalTargets = (Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>) null;
      }
    }
    else
    {
      if (referenceTypeEntry.ForwardTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> node in (IEnumerable<LinkedListNode<KeyValuePair<IReference, T>>>) referenceTypeEntry.ForwardTargets.Values)
        {
          if (this.m_list == node.List)
            this.m_list.Remove(node);
        }
        referenceTypeEntry.ForwardTargets = (NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>) null;
      }
      if (referenceTypeEntry.ForwardExternalTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> node in referenceTypeEntry.ForwardExternalTargets.Values)
        {
          if (this.m_list == node.List)
            this.m_list.Remove(node);
        }
        referenceTypeEntry.ForwardExternalTargets = (Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>) null;
      }
    }
    if (referenceTypeEntry.IsEmpty)
      this.m_references.Remove(referenceTypeId);
    return true;
  }

  public void Add(IReference key, T value) => this.Add(key, value, false);

  public bool ContainsKey(IReference key)
  {
    return this.TryGetEntry(key, out KeyValuePair<IReference, T> _);
  }

  public ICollection<IReference> Keys
  {
    get
    {
      List<IReference> keys = new List<IReference>();
      for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = this.m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        keys.Add(linkedListNode.Value.Key);
      return (ICollection<IReference>) keys;
    }
  }

  public bool Remove(IReference key)
  {
    if (!IReferenceDictionary<T>.ValidateReference(key, false))
      return false;
    ++this.m_version;
    IReferenceDictionary<T>.ReferenceTypeEntry referenceTypeEntry = (IReferenceDictionary<T>.ReferenceTypeEntry) null;
    if (!this.m_references.TryGetValue(key.ReferenceTypeId, out referenceTypeEntry))
      return false;
    if (key.TargetId.IsAbsolute)
    {
      Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = !key.IsInverse ? referenceTypeEntry.ForwardExternalTargets : referenceTypeEntry.InverseExternalTargets;
      LinkedListNode<KeyValuePair<IReference, T>> node;
      if (dictionary == null || !dictionary.TryGetValue(key.TargetId, out node))
        return false;
      this.m_list.Remove(node);
      dictionary.Remove(key.TargetId);
    }
    else
    {
      NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = !key.IsInverse ? referenceTypeEntry.ForwardTargets : referenceTypeEntry.InverseTargets;
      LinkedListNode<KeyValuePair<IReference, T>> node;
      if (nodeIdDictionary == null || !nodeIdDictionary.TryGetValue((NodeId) key.TargetId, out node))
        return false;
      this.m_list.Remove(node);
      nodeIdDictionary.Remove((NodeId) key.TargetId);
    }
    if (referenceTypeEntry.IsEmpty)
      this.m_references.Remove(key.ReferenceTypeId);
    return true;
  }

  public bool TryGetValue(IReference key, out T value)
  {
    value = default (T);
    KeyValuePair<IReference, T> keyValuePair;
    if (!this.TryGetEntry(key, out keyValuePair))
      return false;
    value = keyValuePair.Value;
    return true;
  }

  public ICollection<T> Values
  {
    get
    {
      List<T> values = new List<T>();
      for (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = this.m_list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        values.Add(linkedListNode.Value.Value);
      return (ICollection<T>) values;
    }
  }

  public T this[IReference key]
  {
    get
    {
      IReferenceDictionary<T>.ValidateReference(key, true);
      KeyValuePair<IReference, T> keyValuePair;
      if (!this.TryGetEntry(key, out keyValuePair))
        throw new KeyNotFoundException();
      return keyValuePair.Value;
    }
    set => this.Add(key, value, true);
  }

  public void Add(KeyValuePair<IReference, T> item) => this.Add(item.Key, item.Value);

  public void Clear()
  {
    ++this.m_version;
    this.m_references.Clear();
    this.m_list.Clear();
  }

  public bool Contains(KeyValuePair<IReference, T> item)
  {
    KeyValuePair<IReference, T> keyValuePair;
    return this.TryGetEntry(item.Key, out keyValuePair) && object.Equals((object) keyValuePair.Value, (object) item.Value);
  }

  public void CopyTo(KeyValuePair<IReference, T>[] array, int arrayIndex)
  {
    this.m_list.CopyTo(array, arrayIndex);
  }

  public int Count => this.m_list.Count;

  public bool IsReadOnly => false;

  public bool Remove(KeyValuePair<IReference, T> item) => this.Remove(item.Key);

  public IEnumerator<KeyValuePair<IReference, T>> GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<IReference, T>>) this.m_list.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  private static bool ValidateReference(IReference key, bool throwOnError)
  {
    if (key == null)
    {
      if (throwOnError)
        throw new ArgumentNullException(nameof (key), "IReference must not be null.");
      return false;
    }
    if (NodeId.IsNull(key.ReferenceTypeId))
    {
      if (throwOnError)
        throw new ArgumentNullException(nameof (key), "IReference does not have a valid ReferenceTypeId.");
      return false;
    }
    if (!NodeId.IsNull(key.TargetId))
      return true;
    if (throwOnError)
      throw new ArgumentNullException(nameof (key), "IReference does not have a valid TargetId.");
    return false;
  }

  private bool TryGetEntry(IReference key, out KeyValuePair<IReference, T> value)
  {
    value = new KeyValuePair<IReference, T>();
    if (!IReferenceDictionary<T>.ValidateReference(key, false))
      return false;
    IReferenceDictionary<T>.ReferenceTypeEntry referenceTypeEntry = (IReferenceDictionary<T>.ReferenceTypeEntry) null;
    if (!this.m_references.TryGetValue(key.ReferenceTypeId, out referenceTypeEntry))
      return false;
    if (key.TargetId.IsAbsolute)
    {
      Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = !key.IsInverse ? referenceTypeEntry.ForwardExternalTargets : referenceTypeEntry.InverseExternalTargets;
      LinkedListNode<KeyValuePair<IReference, T>> linkedListNode;
      if (dictionary == null || !dictionary.TryGetValue(key.TargetId, out linkedListNode))
        return false;
      value = linkedListNode.Value;
      return true;
    }
    NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = !key.IsInverse ? referenceTypeEntry.ForwardTargets : referenceTypeEntry.InverseTargets;
    LinkedListNode<KeyValuePair<IReference, T>> linkedListNode1;
    if (nodeIdDictionary == null || !nodeIdDictionary.TryGetValue((NodeId) key.TargetId, out linkedListNode1))
      return false;
    value = linkedListNode1.Value;
    return true;
  }

  private void Add(IReference key, T value, bool replace)
  {
    IReferenceDictionary<T>.ValidateReference(key, true);
    ++this.m_version;
    IReferenceDictionary<T>.ReferenceTypeEntry referenceTypeEntry = (IReferenceDictionary<T>.ReferenceTypeEntry) null;
    if (!this.m_references.TryGetValue(key.ReferenceTypeId, out referenceTypeEntry))
    {
      referenceTypeEntry = new IReferenceDictionary<T>.ReferenceTypeEntry();
      this.m_references.Add(key.ReferenceTypeId, referenceTypeEntry);
    }
    if (key.TargetId.IsAbsolute)
    {
      Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary;
      if (key.IsInverse)
      {
        if (referenceTypeEntry.InverseExternalTargets == null)
          referenceTypeEntry.InverseExternalTargets = new Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>();
        dictionary = referenceTypeEntry.InverseExternalTargets;
      }
      else
      {
        if (referenceTypeEntry.ForwardExternalTargets == null)
          referenceTypeEntry.ForwardExternalTargets = new Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>>();
        dictionary = referenceTypeEntry.ForwardExternalTargets;
      }
      LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = new LinkedListNode<KeyValuePair<IReference, T>>(new KeyValuePair<IReference, T>(key, value));
      LinkedListNode<KeyValuePair<IReference, T>> node = (LinkedListNode<KeyValuePair<IReference, T>>) null;
      if (!dictionary.TryGetValue(key.TargetId, out node))
      {
        this.m_list.AddLast(linkedListNode);
      }
      else
      {
        if (!replace)
          throw new ArgumentException("Key already exists in dictionary.", nameof (key));
        this.m_list.AddAfter(node, linkedListNode);
        this.m_list.Remove(node);
      }
      dictionary[key.TargetId] = linkedListNode;
    }
    else
    {
      NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary;
      if (key.IsInverse)
      {
        if (referenceTypeEntry.InverseTargets == null)
          referenceTypeEntry.InverseTargets = new NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>();
        nodeIdDictionary = referenceTypeEntry.InverseTargets;
      }
      else
      {
        if (referenceTypeEntry.ForwardTargets == null)
          referenceTypeEntry.ForwardTargets = new NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>>();
        nodeIdDictionary = referenceTypeEntry.ForwardTargets;
      }
      NodeId targetId = (NodeId) key.TargetId;
      LinkedListNode<KeyValuePair<IReference, T>> linkedListNode = new LinkedListNode<KeyValuePair<IReference, T>>(new KeyValuePair<IReference, T>(key, value));
      LinkedListNode<KeyValuePair<IReference, T>> node = (LinkedListNode<KeyValuePair<IReference, T>>) null;
      if (!nodeIdDictionary.TryGetValue(targetId, out node))
      {
        node = linkedListNode;
        this.m_list.AddLast(linkedListNode);
      }
      else
      {
        if (!replace)
          throw new ArgumentException("Key already exists in dictionary.", nameof (key));
        this.m_list.AddAfter(node, linkedListNode);
        this.m_list.Remove(node);
      }
      nodeIdDictionary[targetId] = linkedListNode;
    }
  }

  private static bool ContainsKey(
    IReferenceDictionary<T>.ReferenceTypeEntry entry,
    IReference reference)
  {
    if (reference.TargetId.IsAbsolute)
    {
      Dictionary<ExpandedNodeId, LinkedListNode<KeyValuePair<IReference, T>>> dictionary = !reference.IsInverse ? entry.ForwardExternalTargets : entry.InverseExternalTargets;
      return dictionary != null && dictionary.ContainsKey(reference.TargetId);
    }
    NodeIdDictionary<LinkedListNode<KeyValuePair<IReference, T>>> nodeIdDictionary = !reference.IsInverse ? entry.ForwardTargets : entry.InverseTargets;
    return nodeIdDictionary != null && nodeIdDictionary.ContainsKey((NodeId) reference.TargetId);
  }

  private static void Find(
    IReferenceDictionary<T>.ReferenceTypeEntry entry,
    bool isInverse,
    List<IReference> hits)
  {
    if (isInverse)
    {
      if (entry.InverseTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode in (IEnumerable<LinkedListNode<KeyValuePair<IReference, T>>>) entry.InverseTargets.Values)
          hits.Add(linkedListNode.Value.Key);
      }
      if (entry.InverseExternalTargets == null)
        return;
      foreach (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode in entry.InverseExternalTargets.Values)
        hits.Add(linkedListNode.Value.Key);
    }
    else
    {
      if (entry.ForwardTargets != null)
      {
        foreach (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode in (IEnumerable<LinkedListNode<KeyValuePair<IReference, T>>>) entry.ForwardTargets.Values)
          hits.Add(linkedListNode.Value.Key);
      }
      if (entry.ForwardExternalTargets == null)
        return;
      foreach (LinkedListNode<KeyValuePair<IReference, T>> linkedListNode in entry.ForwardExternalTargets.Values)
        hits.Add(linkedListNode.Value.Key);
    }
  }

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
        return (this.ForwardTargets == null || this.ForwardTargets.Count <= 0) && (this.ForwardExternalTargets == null || this.ForwardExternalTargets.Count <= 0) && (this.InverseTargets == null || this.InverseTargets.Count <= 0) && (this.InverseExternalTargets == null || this.InverseExternalTargets.Count <= 0);
      }
    }
  }
}
