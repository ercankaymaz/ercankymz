// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseResultCollection
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
[CollectionDataContract(Name = "ListOfBrowseResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowseResult")]
[ComVisible(true)]
public class BrowseResultCollection : List<BrowseResult>, ICloneable
{
  public BrowseResultCollection()
  {
  }

  public BrowseResultCollection(int capacity)
    : base(capacity)
  {
  }

  public BrowseResultCollection(IEnumerable<BrowseResult> collection)
    : base(collection)
  {
  }

  public static implicit operator BrowseResultCollection(BrowseResult[] values)
  {
    return values != null ? new BrowseResultCollection((IEnumerable<BrowseResult>) values) : new BrowseResultCollection();
  }

  public static explicit operator BrowseResult[](BrowseResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (BrowseResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseResultCollection resultCollection = new BrowseResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((BrowseResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
