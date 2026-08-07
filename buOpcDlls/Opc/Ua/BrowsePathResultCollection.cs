// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePathResultCollection
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
[CollectionDataContract(Name = "ListOfBrowsePathResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePathResult")]
[ComVisible(true)]
public class BrowsePathResultCollection : List<BrowsePathResult>, ICloneable
{
  public BrowsePathResultCollection()
  {
  }

  public BrowsePathResultCollection(int capacity)
    : base(capacity)
  {
  }

  public BrowsePathResultCollection(IEnumerable<BrowsePathResult> collection)
    : base(collection)
  {
  }

  public static implicit operator BrowsePathResultCollection(BrowsePathResult[] values)
  {
    return values != null ? new BrowsePathResultCollection((IEnumerable<BrowsePathResult>) values) : new BrowsePathResultCollection();
  }

  public static explicit operator BrowsePathResult[](BrowsePathResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (BrowsePathResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePathResultCollection resultCollection = new BrowsePathResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((BrowsePathResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
