// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesResultCollection
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
[CollectionDataContract(Name = "ListOfAddNodesResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddNodesResult")]
[ComVisible(true)]
public class AddNodesResultCollection : List<AddNodesResult>, ICloneable
{
  public AddNodesResultCollection()
  {
  }

  public AddNodesResultCollection(int capacity)
    : base(capacity)
  {
  }

  public AddNodesResultCollection(IEnumerable<AddNodesResult> collection)
    : base(collection)
  {
  }

  public static implicit operator AddNodesResultCollection(AddNodesResult[] values)
  {
    return values != null ? new AddNodesResultCollection((IEnumerable<AddNodesResult>) values) : new AddNodesResultCollection();
  }

  public static explicit operator AddNodesResult[](AddNodesResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (AddNodesResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddNodesResultCollection resultCollection = new AddNodesResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((AddNodesResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
