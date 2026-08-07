// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetFieldContentMaskCollection
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
[CollectionDataContract(Name = "ListOfDataSetFieldContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetFieldContentMask")]
[ComVisible(true)]
public class DataSetFieldContentMaskCollection : List<DataSetFieldContentMask>, ICloneable
{
  public DataSetFieldContentMaskCollection()
  {
  }

  public DataSetFieldContentMaskCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetFieldContentMaskCollection(IEnumerable<DataSetFieldContentMask> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetFieldContentMaskCollection(DataSetFieldContentMask[] values)
  {
    return values != null ? new DataSetFieldContentMaskCollection((IEnumerable<DataSetFieldContentMask>) values) : new DataSetFieldContentMaskCollection();
  }

  public static explicit operator DataSetFieldContentMask[](DataSetFieldContentMaskCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetFieldContentMaskCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetFieldContentMaskCollection contentMaskCollection = new DataSetFieldContentMaskCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      contentMaskCollection.Add((DataSetFieldContentMask) Utils.Clone((object) this[index]));
    return (object) contentMaskCollection;
  }
}
