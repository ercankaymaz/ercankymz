// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReaderGroupMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfReaderGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupMessageDataType")]
[ComVisible(true)]
public class ReaderGroupMessageDataTypeCollection : List<ReaderGroupMessageDataType>, ICloneable
{
  public ReaderGroupMessageDataTypeCollection()
  {
  }

  public ReaderGroupMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ReaderGroupMessageDataTypeCollection(IEnumerable<ReaderGroupMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ReaderGroupMessageDataTypeCollection(
    ReaderGroupMessageDataType[] values)
  {
    return values != null ? new ReaderGroupMessageDataTypeCollection((IEnumerable<ReaderGroupMessageDataType>) values) : new ReaderGroupMessageDataTypeCollection();
  }

  public static explicit operator ReaderGroupMessageDataType[](
    ReaderGroupMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ReaderGroupMessageDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReaderGroupMessageDataTypeCollection dataTypeCollection = new ReaderGroupMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ReaderGroupMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
