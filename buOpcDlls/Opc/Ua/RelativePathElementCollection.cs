// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RelativePathElementCollection
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
[CollectionDataContract(Name = "ListOfRelativePathElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RelativePathElement")]
[ComVisible(true)]
public class RelativePathElementCollection : List<RelativePathElement>, ICloneable
{
  public RelativePathElementCollection()
  {
  }

  public RelativePathElementCollection(int capacity)
    : base(capacity)
  {
  }

  public RelativePathElementCollection(IEnumerable<RelativePathElement> collection)
    : base(collection)
  {
  }

  public static implicit operator RelativePathElementCollection(RelativePathElement[] values)
  {
    return values != null ? new RelativePathElementCollection((IEnumerable<RelativePathElement>) values) : new RelativePathElementCollection();
  }

  public static explicit operator RelativePathElement[](RelativePathElementCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (RelativePathElementCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RelativePathElementCollection elementCollection = new RelativePathElementCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      elementCollection.Add((RelativePathElement) Utils.Clone((object) this[index]));
    return (object) elementCollection;
  }
}
