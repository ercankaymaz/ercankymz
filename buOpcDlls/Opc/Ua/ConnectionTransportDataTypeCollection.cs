// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConnectionTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ConnectionTransportDataType")]
[ComVisible(true)]
public class ConnectionTransportDataTypeCollection : List<ConnectionTransportDataType>, ICloneable
{
  public ConnectionTransportDataTypeCollection()
  {
  }

  public ConnectionTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ConnectionTransportDataTypeCollection(
    IEnumerable<ConnectionTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ConnectionTransportDataTypeCollection(
    ConnectionTransportDataType[] values)
  {
    return values != null ? new ConnectionTransportDataTypeCollection((IEnumerable<ConnectionTransportDataType>) values) : new ConnectionTransportDataTypeCollection();
  }

  public static explicit operator ConnectionTransportDataType[](
    ConnectionTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ConnectionTransportDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ConnectionTransportDataTypeCollection dataTypeCollection = new ConnectionTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ConnectionTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
