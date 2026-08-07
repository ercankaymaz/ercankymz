// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDOrientationCollection
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
[CollectionDataContract(Name = "ListOfThreeDOrientation", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDOrientation")]
[ComVisible(true)]
public class ThreeDOrientationCollection : List<ThreeDOrientation>, ICloneable
{
  public ThreeDOrientationCollection()
  {
  }

  public ThreeDOrientationCollection(int capacity)
    : base(capacity)
  {
  }

  public ThreeDOrientationCollection(IEnumerable<ThreeDOrientation> collection)
    : base(collection)
  {
  }

  public static implicit operator ThreeDOrientationCollection(ThreeDOrientation[] values)
  {
    return values != null ? new ThreeDOrientationCollection((IEnumerable<ThreeDOrientation>) values) : new ThreeDOrientationCollection();
  }

  public static explicit operator ThreeDOrientation[](ThreeDOrientationCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ThreeDOrientationCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDOrientationCollection dorientationCollection = new ThreeDOrientationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dorientationCollection.Add((ThreeDOrientation) Utils.Clone((object) this[index]));
    return (object) dorientationCollection;
  }
}
