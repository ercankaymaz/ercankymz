// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OrientationCollection
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
[CollectionDataContract(Name = "ListOfOrientation", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Orientation")]
[ComVisible(true)]
public class OrientationCollection : List<Orientation>, ICloneable
{
  public OrientationCollection()
  {
  }

  public OrientationCollection(int capacity)
    : base(capacity)
  {
  }

  public OrientationCollection(IEnumerable<Orientation> collection)
    : base(collection)
  {
  }

  public static implicit operator OrientationCollection(Orientation[] values)
  {
    return values != null ? new OrientationCollection((IEnumerable<Orientation>) values) : new OrientationCollection();
  }

  public static explicit operator Orientation[](OrientationCollection values) => values?.ToArray();

  public object Clone() => (object) (OrientationCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OrientationCollection orientationCollection = new OrientationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      orientationCollection.Add((Orientation) Utils.Clone((object) this[index]));
    return (object) orientationCollection;
  }
}
