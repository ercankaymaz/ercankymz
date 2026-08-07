// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterElementCollection
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
[CollectionDataContract(Name = "ListOfContentFilterElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilterElement")]
[ComVisible(true)]
public class ContentFilterElementCollection : List<ContentFilterElement>, ICloneable
{
  public ContentFilterElementCollection()
  {
  }

  public ContentFilterElementCollection(int capacity)
    : base(capacity)
  {
  }

  public ContentFilterElementCollection(IEnumerable<ContentFilterElement> collection)
    : base(collection)
  {
  }

  public static implicit operator ContentFilterElementCollection(ContentFilterElement[] values)
  {
    return values != null ? new ContentFilterElementCollection((IEnumerable<ContentFilterElement>) values) : new ContentFilterElementCollection();
  }

  public static explicit operator ContentFilterElement[](ContentFilterElementCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ContentFilterElementCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterElementCollection elementCollection = new ContentFilterElementCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      elementCollection.Add((ContentFilterElement) Utils.Clone((object) this[index]));
    return (object) elementCollection;
  }
}
