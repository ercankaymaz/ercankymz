// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesItemCollection
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
[CollectionDataContract(Name = "ListOfAddNodesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddNodesItem")]
[ComVisible(true)]
public class AddNodesItemCollection : List<AddNodesItem>, ICloneable
{
  public AddNodesItemCollection()
  {
  }

  public AddNodesItemCollection(int capacity)
    : base(capacity)
  {
  }

  public AddNodesItemCollection(IEnumerable<AddNodesItem> collection)
    : base(collection)
  {
  }

  public static implicit operator AddNodesItemCollection(AddNodesItem[] values)
  {
    return values != null ? new AddNodesItemCollection((IEnumerable<AddNodesItem>) values) : new AddNodesItemCollection();
  }

  public static explicit operator AddNodesItem[](AddNodesItemCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (AddNodesItemCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddNodesItemCollection nodesItemCollection = new AddNodesItemCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      nodesItemCollection.Add((AddNodesItem) Utils.Clone((object) this[index]));
    return (object) nodesItemCollection;
  }
}
