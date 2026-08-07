// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RationalNumberCollection
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
[CollectionDataContract(Name = "ListOfRationalNumber", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RationalNumber")]
[ComVisible(true)]
public class RationalNumberCollection : List<RationalNumber>, ICloneable
{
  public RationalNumberCollection()
  {
  }

  public RationalNumberCollection(int capacity)
    : base(capacity)
  {
  }

  public RationalNumberCollection(IEnumerable<RationalNumber> collection)
    : base(collection)
  {
  }

  public static implicit operator RationalNumberCollection(RationalNumber[] values)
  {
    return values != null ? new RationalNumberCollection((IEnumerable<RationalNumber>) values) : new RationalNumberCollection();
  }

  public static explicit operator RationalNumber[](RationalNumberCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (RationalNumberCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RationalNumberCollection numberCollection = new RationalNumberCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      numberCollection.Add((RationalNumber) Utils.Clone((object) this[index]));
    return (object) numberCollection;
  }
}
