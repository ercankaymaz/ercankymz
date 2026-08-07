// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Node")]
[ComVisible(true)]
public class NodeCollection : List<Node>, ICloneable
{
  public NodeCollection()
  {
  }

  public NodeCollection(int capacity)
    : base(capacity)
  {
  }

  public NodeCollection(IEnumerable<Node> collection)
    : base(collection)
  {
  }

  public static implicit operator NodeCollection(Node[] values)
  {
    return values != null ? new NodeCollection((IEnumerable<Node>) values) : new NodeCollection();
  }

  public static explicit operator Node[](NodeCollection values) => values?.ToArray();

  public object Clone() => (object) (NodeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeCollection nodeCollection = new NodeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      nodeCollection.Add((Node) Utils.Clone((object) this[index]));
    return (object) nodeCollection;
  }
}
