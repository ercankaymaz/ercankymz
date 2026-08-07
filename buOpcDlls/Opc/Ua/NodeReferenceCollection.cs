// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeReferenceCollection
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
[CollectionDataContract(Name = "ListOfNodeReference", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeReference")]
[ComVisible(true)]
public class NodeReferenceCollection : List<NodeReference>, ICloneable
{
  public NodeReferenceCollection()
  {
  }

  public NodeReferenceCollection(int capacity)
    : base(capacity)
  {
  }

  public NodeReferenceCollection(IEnumerable<NodeReference> collection)
    : base(collection)
  {
  }

  public static implicit operator NodeReferenceCollection(NodeReference[] values)
  {
    return values != null ? new NodeReferenceCollection((IEnumerable<NodeReference>) values) : new NodeReferenceCollection();
  }

  public static explicit operator NodeReference[](NodeReferenceCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NodeReferenceCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeReferenceCollection referenceCollection = new NodeReferenceCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      referenceCollection.Add((NodeReference) Utils.Clone((object) this[index]));
    return (object) referenceCollection;
  }
}
