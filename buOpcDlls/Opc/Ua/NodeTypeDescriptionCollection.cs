// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeTypeDescriptionCollection
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
[CollectionDataContract(Name = "ListOfNodeTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeTypeDescription")]
[ComVisible(true)]
public class NodeTypeDescriptionCollection : List<NodeTypeDescription>, ICloneable
{
  public NodeTypeDescriptionCollection()
  {
  }

  public NodeTypeDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public NodeTypeDescriptionCollection(IEnumerable<NodeTypeDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator NodeTypeDescriptionCollection(NodeTypeDescription[] values)
  {
    return values != null ? new NodeTypeDescriptionCollection((IEnumerable<NodeTypeDescription>) values) : new NodeTypeDescriptionCollection();
  }

  public static explicit operator NodeTypeDescription[](NodeTypeDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NodeTypeDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeTypeDescriptionCollection descriptionCollection = new NodeTypeDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((NodeTypeDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
