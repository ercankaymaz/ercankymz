// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDVectorCollection
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
[CollectionDataContract(Name = "ListOfThreeDVector", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDVector")]
[ComVisible(true)]
public class ThreeDVectorCollection : List<ThreeDVector>, ICloneable
{
  public ThreeDVectorCollection()
  {
  }

  public ThreeDVectorCollection(int capacity)
    : base(capacity)
  {
  }

  public ThreeDVectorCollection(IEnumerable<ThreeDVector> collection)
    : base(collection)
  {
  }

  public static implicit operator ThreeDVectorCollection(ThreeDVector[] values)
  {
    return values != null ? new ThreeDVectorCollection((IEnumerable<ThreeDVector>) values) : new ThreeDVectorCollection();
  }

  public static explicit operator ThreeDVector[](ThreeDVectorCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ThreeDVectorCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDVectorCollection dvectorCollection = new ThreeDVectorCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dvectorCollection.Add((ThreeDVector) Utils.Clone((object) this[index]));
    return (object) dvectorCollection;
  }
}
