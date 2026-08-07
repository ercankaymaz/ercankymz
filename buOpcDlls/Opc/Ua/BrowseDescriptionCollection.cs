// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseDescriptionCollection
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
[CollectionDataContract(Name = "ListOfBrowseDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowseDescription")]
[ComVisible(true)]
public class BrowseDescriptionCollection : List<BrowseDescription>, ICloneable
{
  public BrowseDescriptionCollection()
  {
  }

  public BrowseDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public BrowseDescriptionCollection(IEnumerable<BrowseDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator BrowseDescriptionCollection(BrowseDescription[] values)
  {
    return values != null ? new BrowseDescriptionCollection((IEnumerable<BrowseDescription>) values) : new BrowseDescriptionCollection();
  }

  public static explicit operator BrowseDescription[](BrowseDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (BrowseDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseDescriptionCollection descriptionCollection = new BrowseDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((BrowseDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
