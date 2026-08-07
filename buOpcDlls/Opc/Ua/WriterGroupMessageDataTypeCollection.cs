// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriterGroupMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriterGroupMessageDataType")]
[ComVisible(true)]
public class WriterGroupMessageDataTypeCollection : List<WriterGroupMessageDataType>, ICloneable
{
  public WriterGroupMessageDataTypeCollection()
  {
  }

  public WriterGroupMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public WriterGroupMessageDataTypeCollection(IEnumerable<WriterGroupMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator WriterGroupMessageDataTypeCollection(
    WriterGroupMessageDataType[] values)
  {
    return values != null ? new WriterGroupMessageDataTypeCollection((IEnumerable<WriterGroupMessageDataType>) values) : new WriterGroupMessageDataTypeCollection();
  }

  public static explicit operator WriterGroupMessageDataType[](
    WriterGroupMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (WriterGroupMessageDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriterGroupMessageDataTypeCollection dataTypeCollection = new WriterGroupMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((WriterGroupMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
