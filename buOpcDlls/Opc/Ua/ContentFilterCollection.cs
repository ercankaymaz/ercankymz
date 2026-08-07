// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterCollection
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
[CollectionDataContract(Name = "ListOfContentFilter", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilter")]
[ComVisible(true)]
public class ContentFilterCollection : List<ContentFilter>, ICloneable
{
  public ContentFilterCollection()
  {
  }

  public ContentFilterCollection(int capacity)
    : base(capacity)
  {
  }

  public ContentFilterCollection(IEnumerable<ContentFilter> collection)
    : base(collection)
  {
  }

  public static implicit operator ContentFilterCollection(ContentFilter[] values)
  {
    return values != null ? new ContentFilterCollection((IEnumerable<ContentFilter>) values) : new ContentFilterCollection();
  }

  public static explicit operator ContentFilter[](ContentFilterCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ContentFilterCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterCollection filterCollection = new ContentFilterCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      filterCollection.Add((ContentFilter) Utils.Clone((object) this[index]));
    return (object) filterCollection;
  }
}
