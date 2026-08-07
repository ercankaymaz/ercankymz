// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteNodesItemCollection
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
[CollectionDataContract(Name = "ListOfDeleteNodesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DeleteNodesItem")]
[ComVisible(true)]
public class DeleteNodesItemCollection : List<DeleteNodesItem>, ICloneable
{
  public DeleteNodesItemCollection()
  {
  }

  public DeleteNodesItemCollection(int capacity)
    : base(capacity)
  {
  }

  public DeleteNodesItemCollection(IEnumerable<DeleteNodesItem> collection)
    : base(collection)
  {
  }

  public static implicit operator DeleteNodesItemCollection(DeleteNodesItem[] values)
  {
    return values != null ? new DeleteNodesItemCollection((IEnumerable<DeleteNodesItem>) values) : new DeleteNodesItemCollection();
  }

  public static explicit operator DeleteNodesItem[](DeleteNodesItemCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DeleteNodesItemCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteNodesItemCollection nodesItemCollection = new DeleteNodesItemCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      nodesItemCollection.Add((DeleteNodesItem) Utils.Clone((object) this[index]));
    return (object) nodesItemCollection;
  }
}
