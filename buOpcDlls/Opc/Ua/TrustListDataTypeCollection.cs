// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TrustListDataTypeCollection
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
[CollectionDataContract(Name = "ListOfTrustListDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TrustListDataType")]
[ComVisible(true)]
public class TrustListDataTypeCollection : List<TrustListDataType>, ICloneable
{
  public TrustListDataTypeCollection()
  {
  }

  public TrustListDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public TrustListDataTypeCollection(IEnumerable<TrustListDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator TrustListDataTypeCollection(TrustListDataType[] values)
  {
    return values != null ? new TrustListDataTypeCollection((IEnumerable<TrustListDataType>) values) : new TrustListDataTypeCollection();
  }

  public static explicit operator TrustListDataType[](TrustListDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TrustListDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TrustListDataTypeCollection dataTypeCollection = new TrustListDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((TrustListDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
