// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReaderGroupTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfReaderGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupTransportDataType")]
[ComVisible(true)]
public class ReaderGroupTransportDataTypeCollection : List<ReaderGroupTransportDataType>, ICloneable
{
  public ReaderGroupTransportDataTypeCollection()
  {
  }

  public ReaderGroupTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ReaderGroupTransportDataTypeCollection(
    IEnumerable<ReaderGroupTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ReaderGroupTransportDataTypeCollection(
    ReaderGroupTransportDataType[] values)
  {
    return values != null ? new ReaderGroupTransportDataTypeCollection((IEnumerable<ReaderGroupTransportDataType>) values) : new ReaderGroupTransportDataTypeCollection();
  }

  public static explicit operator ReaderGroupTransportDataType[](
    ReaderGroupTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ReaderGroupTransportDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReaderGroupTransportDataTypeCollection dataTypeCollection = new ReaderGroupTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ReaderGroupTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
