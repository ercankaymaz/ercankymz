// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterElementResultCollection
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
[CollectionDataContract(Name = "ListOfContentFilterElementResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilterElementResult")]
[ComVisible(true)]
public class ContentFilterElementResultCollection : List<ContentFilterElementResult>, ICloneable
{
  public ContentFilterElementResultCollection()
  {
  }

  public ContentFilterElementResultCollection(int capacity)
    : base(capacity)
  {
  }

  public ContentFilterElementResultCollection(IEnumerable<ContentFilterElementResult> collection)
    : base(collection)
  {
  }

  public static implicit operator ContentFilterElementResultCollection(
    ContentFilterElementResult[] values)
  {
    return values != null ? new ContentFilterElementResultCollection((IEnumerable<ContentFilterElementResult>) values) : new ContentFilterElementResultCollection();
  }

  public static explicit operator ContentFilterElementResult[](
    ContentFilterElementResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ContentFilterElementResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterElementResultCollection resultCollection = new ContentFilterElementResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((ContentFilterElementResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
