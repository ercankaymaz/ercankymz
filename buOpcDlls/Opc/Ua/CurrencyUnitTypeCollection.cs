// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CurrencyUnitTypeCollection
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
[CollectionDataContract(Name = "ListOfCurrencyUnitType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CurrencyUnitType")]
[ComVisible(true)]
public class CurrencyUnitTypeCollection : List<CurrencyUnitType>, ICloneable
{
  public CurrencyUnitTypeCollection()
  {
  }

  public CurrencyUnitTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public CurrencyUnitTypeCollection(IEnumerable<CurrencyUnitType> collection)
    : base(collection)
  {
  }

  public static implicit operator CurrencyUnitTypeCollection(CurrencyUnitType[] values)
  {
    return values != null ? new CurrencyUnitTypeCollection((IEnumerable<CurrencyUnitType>) values) : new CurrencyUnitTypeCollection();
  }

  public static explicit operator CurrencyUnitType[](CurrencyUnitTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (CurrencyUnitTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CurrencyUnitTypeCollection unitTypeCollection = new CurrencyUnitTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      unitTypeCollection.Add((CurrencyUnitType) Utils.Clone((object) this[index]));
    return (object) unitTypeCollection;
  }
}
