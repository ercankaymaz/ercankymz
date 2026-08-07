// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataValueCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDataValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataValue")]
[ComVisible(true)]
public class DataValueCollection : List<DataValue>, ICloneable
{
  public DataValueCollection()
  {
  }

  public DataValueCollection(IEnumerable<DataValue> collection)
    : base(collection)
  {
  }

  public DataValueCollection(int capacity)
    : base(capacity)
  {
  }

  public static DataValueCollection ToDataValueCollection(DataValue[] values)
  {
    return values != null ? new DataValueCollection((IEnumerable<DataValue>) values) : new DataValueCollection();
  }

  public static implicit operator DataValueCollection(DataValue[] values)
  {
    return DataValueCollection.ToDataValueCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataValueCollection dataValueCollection = new DataValueCollection(this.Count);
    foreach (DataValue dataValue in (List<DataValue>) this)
      dataValueCollection.Add((DataValue) Utils.Clone((object) dataValue));
    return (object) dataValueCollection;
  }
}
