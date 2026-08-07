// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceCollection
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
public class ReferenceCollection : 
  IReferenceCollection,
  ICollection<IReference>,
  IEnumerable<IReference>,
  IEnumerable,
  IFormattable
{
  private IReferenceDictionary<object> m_references;

  public ReferenceCollection() => this.m_references = new IReferenceDictionary<object>();

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return Utils.Format("References {0}", (object) this.m_references.Count);
  }

  public void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    this.m_references[(IReference) new ReferenceNode(referenceTypeId, isInverse, targetId)] = (object) null;
  }

  public bool Remove(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    return this.m_references.Remove((IReference) new ReferenceNode(referenceTypeId, isInverse, targetId));
  }

  public bool RemoveAll(NodeId referenceTypeId, bool isInverse)
  {
    return this.m_references.RemoveAll(referenceTypeId, isInverse);
  }

  public bool Exists(
    NodeId referenceTypeId,
    bool isInverse,
    ExpandedNodeId targetId,
    bool includeSubtypes,
    ITypeTable typeTree)
  {
    ReferenceNode key = new ReferenceNode(referenceTypeId, isInverse, targetId);
    if (this.m_references.ContainsKey((IReference) key))
      return true;
    return includeSubtypes && typeTree != null && this.m_references.ContainsKey((IReference) key, typeTree);
  }

  public IList<IReference> Find(
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    ITypeTable typeTree)
  {
    return includeSubtypes && typeTree != null ? this.m_references.Find(referenceTypeId, isInverse, typeTree) : this.m_references.Find(referenceTypeId, isInverse);
  }

  public ExpandedNodeId FindTarget(
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    ITypeTable typeTree,
    int index)
  {
    IList<IReference> referenceList = !includeSubtypes || typeTree == null ? this.m_references.Find(referenceTypeId, isInverse) : this.m_references.Find(referenceTypeId, isInverse, typeTree);
    return index >= 0 && index < referenceList.Count ? referenceList[index].TargetId : (ExpandedNodeId) null;
  }

  public IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId)
  {
    return this.m_references.FindReferencesToTarget(targetId);
  }

  public int Count => this.m_references.Count;

  public bool IsReadOnly => false;

  public void Add(IReference item) => this.m_references.Add(item, (object) null);

  public bool Remove(IReference item) => this.m_references.Remove(item);

  public void Clear() => this.m_references.Clear();

  public bool Contains(IReference item) => this.m_references.ContainsKey(item);

  public void CopyTo(IReference[] array, int arrayIndex)
  {
    if (array == null)
      throw new ArgumentNullException(nameof (array));
    if (arrayIndex < 0 || arrayIndex >= array.Length)
      throw new ArgumentOutOfRangeException(nameof (arrayIndex), "arrayIndex < 0 || arrayIndex >= array.Length");
    KeyValuePair<IReference, object>[] array1 = new KeyValuePair<IReference, object>[array.Length - arrayIndex];
    this.m_references.CopyTo(array1, 0);
    for (int index = 0; index < array1.Length; ++index)
      array[arrayIndex + index] = array1[index].Key;
  }

  public IEnumerator<IReference> GetEnumerator() => this.m_references.Keys.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
