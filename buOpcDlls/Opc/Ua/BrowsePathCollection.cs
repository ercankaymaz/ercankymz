// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePathCollection
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
[CollectionDataContract(Name = "ListOfBrowsePath", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePath")]
[ComVisible(true)]
public class BrowsePathCollection : List<BrowsePath>, ICloneable
{
  public BrowsePathCollection()
  {
  }

  public BrowsePathCollection(int capacity)
    : base(capacity)
  {
  }

  public BrowsePathCollection(IEnumerable<BrowsePath> collection)
    : base(collection)
  {
  }

  public static implicit operator BrowsePathCollection(BrowsePath[] values)
  {
    return values != null ? new BrowsePathCollection((IEnumerable<BrowsePath>) values) : new BrowsePathCollection();
  }

  public static explicit operator BrowsePath[](BrowsePathCollection values) => values?.ToArray();

  public object Clone() => (object) (BrowsePathCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePathCollection browsePathCollection = new BrowsePathCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      browsePathCollection.Add((BrowsePath) Utils.Clone((object) this[index]));
    return (object) browsePathCollection;
  }
}
