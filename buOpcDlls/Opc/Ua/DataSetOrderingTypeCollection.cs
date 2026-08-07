// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetOrderingTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetOrderingType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetOrderingType")]
[ComVisible(true)]
public class DataSetOrderingTypeCollection : List<DataSetOrderingType>, ICloneable
{
  public DataSetOrderingTypeCollection()
  {
  }

  public DataSetOrderingTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetOrderingTypeCollection(IEnumerable<DataSetOrderingType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetOrderingTypeCollection(DataSetOrderingType[] values)
  {
    return values != null ? new DataSetOrderingTypeCollection((IEnumerable<DataSetOrderingType>) values) : new DataSetOrderingTypeCollection();
  }

  public static explicit operator DataSetOrderingType[](DataSetOrderingTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetOrderingTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetOrderingTypeCollection orderingTypeCollection = new DataSetOrderingTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      orderingTypeCollection.Add((DataSetOrderingType) Utils.Clone((object) this[index]));
    return (object) orderingTypeCollection;
  }
}
