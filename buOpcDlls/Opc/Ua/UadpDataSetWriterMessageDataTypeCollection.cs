// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetWriterMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfUadpDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetWriterMessageDataType")]
[ComVisible(true)]
public class UadpDataSetWriterMessageDataTypeCollection : 
  List<UadpDataSetWriterMessageDataType>,
  ICloneable
{
  public UadpDataSetWriterMessageDataTypeCollection()
  {
  }

  public UadpDataSetWriterMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public UadpDataSetWriterMessageDataTypeCollection(
    IEnumerable<UadpDataSetWriterMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator UadpDataSetWriterMessageDataTypeCollection(
    UadpDataSetWriterMessageDataType[] values)
  {
    return values != null ? new UadpDataSetWriterMessageDataTypeCollection((IEnumerable<UadpDataSetWriterMessageDataType>) values) : new UadpDataSetWriterMessageDataTypeCollection();
  }

  public static explicit operator UadpDataSetWriterMessageDataType[](
    UadpDataSetWriterMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (UadpDataSetWriterMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpDataSetWriterMessageDataTypeCollection dataTypeCollection = new UadpDataSetWriterMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((UadpDataSetWriterMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
