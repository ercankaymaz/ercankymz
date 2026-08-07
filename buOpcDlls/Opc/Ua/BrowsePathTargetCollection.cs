// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePathTargetCollection
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
[CollectionDataContract(Name = "ListOfBrowsePathTarget", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePathTarget")]
[ComVisible(true)]
public class BrowsePathTargetCollection : List<BrowsePathTarget>, ICloneable
{
  public BrowsePathTargetCollection()
  {
  }

  public BrowsePathTargetCollection(int capacity)
    : base(capacity)
  {
  }

  public BrowsePathTargetCollection(IEnumerable<BrowsePathTarget> collection)
    : base(collection)
  {
  }

  public static implicit operator BrowsePathTargetCollection(BrowsePathTarget[] values)
  {
    return values != null ? new BrowsePathTargetCollection((IEnumerable<BrowsePathTarget>) values) : new BrowsePathTargetCollection();
  }

  public static explicit operator BrowsePathTarget[](BrowsePathTargetCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (BrowsePathTargetCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePathTargetCollection targetCollection = new BrowsePathTargetCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      targetCollection.Add((BrowsePathTarget) Utils.Clone((object) this[index]));
    return (object) targetCollection;
  }
}
