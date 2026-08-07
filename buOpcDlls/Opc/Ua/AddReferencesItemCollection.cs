// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddReferencesItemCollection
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
[CollectionDataContract(Name = "ListOfAddReferencesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddReferencesItem")]
[ComVisible(true)]
public class AddReferencesItemCollection : List<AddReferencesItem>, ICloneable
{
  public AddReferencesItemCollection()
  {
  }

  public AddReferencesItemCollection(int capacity)
    : base(capacity)
  {
  }

  public AddReferencesItemCollection(IEnumerable<AddReferencesItem> collection)
    : base(collection)
  {
  }

  public static implicit operator AddReferencesItemCollection(AddReferencesItem[] values)
  {
    return values != null ? new AddReferencesItemCollection((IEnumerable<AddReferencesItem>) values) : new AddReferencesItemCollection();
  }

  public static explicit operator AddReferencesItem[](AddReferencesItemCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (AddReferencesItemCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddReferencesItemCollection referencesItemCollection = new AddReferencesItemCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      referencesItemCollection.Add((AddReferencesItem) Utils.Clone((object) this[index]));
    return (object) referencesItemCollection;
  }
}
