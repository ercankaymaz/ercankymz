// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramConnectionTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDatagramConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DatagramConnectionTransportDataType")]
[ComVisible(true)]
public class DatagramConnectionTransportDataTypeCollection : 
  List<DatagramConnectionTransportDataType>,
  ICloneable
{
  public DatagramConnectionTransportDataTypeCollection()
  {
  }

  public DatagramConnectionTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DatagramConnectionTransportDataTypeCollection(
    IEnumerable<DatagramConnectionTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DatagramConnectionTransportDataTypeCollection(
    DatagramConnectionTransportDataType[] values)
  {
    return values != null ? new DatagramConnectionTransportDataTypeCollection((IEnumerable<DatagramConnectionTransportDataType>) values) : new DatagramConnectionTransportDataTypeCollection();
  }

  public static explicit operator DatagramConnectionTransportDataType[](
    DatagramConnectionTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (DatagramConnectionTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DatagramConnectionTransportDataTypeCollection dataTypeCollection = new DatagramConnectionTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DatagramConnectionTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
