// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExpandedNodeIdCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfExpandedNodeId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ExpandedNodeId")]
[ComVisible(true)]
public class ExpandedNodeIdCollection : List<ExpandedNodeId>, ICloneable
{
  public ExpandedNodeIdCollection()
  {
  }

  public ExpandedNodeIdCollection(IEnumerable<ExpandedNodeId> collection)
    : base(collection)
  {
  }

  public ExpandedNodeIdCollection(int capacity)
    : base(capacity)
  {
  }

  public static ExpandedNodeIdCollection ToExpandedNodeIdCollection(ExpandedNodeId[] values)
  {
    return values != null ? new ExpandedNodeIdCollection((IEnumerable<ExpandedNodeId>) values) : new ExpandedNodeIdCollection();
  }

  public static implicit operator ExpandedNodeIdCollection(ExpandedNodeId[] values)
  {
    return ExpandedNodeIdCollection.ToExpandedNodeIdCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ExpandedNodeIdCollection nodeIdCollection = new ExpandedNodeIdCollection(this.Count);
    foreach (ExpandedNodeId expandedNodeId in (List<ExpandedNodeId>) this)
      nodeIdCollection.Add((ExpandedNodeId) Utils.Clone((object) expandedNodeId));
    return (object) nodeIdCollection;
  }
}
