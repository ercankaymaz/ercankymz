// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriterGroupTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriterGroupTransportDataType")]
[ComVisible(true)]
public class WriterGroupTransportDataTypeCollection : List<WriterGroupTransportDataType>, ICloneable
{
  public WriterGroupTransportDataTypeCollection()
  {
  }

  public WriterGroupTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public WriterGroupTransportDataTypeCollection(
    IEnumerable<WriterGroupTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator WriterGroupTransportDataTypeCollection(
    WriterGroupTransportDataType[] values)
  {
    return values != null ? new WriterGroupTransportDataTypeCollection((IEnumerable<WriterGroupTransportDataType>) values) : new WriterGroupTransportDataTypeCollection();
  }

  public static explicit operator WriterGroupTransportDataType[](
    WriterGroupTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (WriterGroupTransportDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriterGroupTransportDataTypeCollection dataTypeCollection = new WriterGroupTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((WriterGroupTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
