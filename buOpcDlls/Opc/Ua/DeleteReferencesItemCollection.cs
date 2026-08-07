// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteReferencesItemCollection
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
[CollectionDataContract(Name = "ListOfDeleteReferencesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DeleteReferencesItem")]
[ComVisible(true)]
public class DeleteReferencesItemCollection : List<DeleteReferencesItem>, ICloneable
{
  public DeleteReferencesItemCollection()
  {
  }

  public DeleteReferencesItemCollection(int capacity)
    : base(capacity)
  {
  }

  public DeleteReferencesItemCollection(IEnumerable<DeleteReferencesItem> collection)
    : base(collection)
  {
  }

  public static implicit operator DeleteReferencesItemCollection(DeleteReferencesItem[] values)
  {
    return values != null ? new DeleteReferencesItemCollection((IEnumerable<DeleteReferencesItem>) values) : new DeleteReferencesItemCollection();
  }

  public static explicit operator DeleteReferencesItem[](DeleteReferencesItemCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DeleteReferencesItemCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteReferencesItemCollection referencesItemCollection = new DeleteReferencesItemCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      referencesItemCollection.Add((DeleteReferencesItem) Utils.Clone((object) this[index]));
    return (object) referencesItemCollection;
  }
}
