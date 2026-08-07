// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeIdCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfNodeId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeId")]
[ComVisible(true)]
public class NodeIdCollection : List<NodeId>, ICloneable
{
  public NodeIdCollection()
  {
  }

  public NodeIdCollection(IEnumerable<NodeId> collection)
    : base(collection)
  {
  }

  public NodeIdCollection(int capacity)
    : base(capacity)
  {
  }

  public static NodeIdCollection ToNodeIdCollection(NodeId[] values)
  {
    return values != null ? new NodeIdCollection((IEnumerable<NodeId>) values) : new NodeIdCollection();
  }

  public static implicit operator NodeIdCollection(NodeId[] values)
  {
    return NodeIdCollection.ToNodeIdCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeIdCollection nodeIdCollection = new NodeIdCollection(this.Count);
    foreach (NodeId nodeId in (List<NodeId>) this)
      nodeIdCollection.Add((NodeId) Utils.Clone((object) nodeId));
    return (object) nodeIdCollection;
  }
}
