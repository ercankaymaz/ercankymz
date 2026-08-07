// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetReaderMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfUadpDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetReaderMessageDataType")]
[ComVisible(true)]
public class UadpDataSetReaderMessageDataTypeCollection : 
  List<UadpDataSetReaderMessageDataType>,
  ICloneable
{
  public UadpDataSetReaderMessageDataTypeCollection()
  {
  }

  public UadpDataSetReaderMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public UadpDataSetReaderMessageDataTypeCollection(
    IEnumerable<UadpDataSetReaderMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator UadpDataSetReaderMessageDataTypeCollection(
    UadpDataSetReaderMessageDataType[] values)
  {
    return values != null ? new UadpDataSetReaderMessageDataTypeCollection((IEnumerable<UadpDataSetReaderMessageDataType>) values) : new UadpDataSetReaderMessageDataTypeCollection();
  }

  public static explicit operator UadpDataSetReaderMessageDataType[](
    UadpDataSetReaderMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (UadpDataSetReaderMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpDataSetReaderMessageDataTypeCollection dataTypeCollection = new UadpDataSetReaderMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((UadpDataSetReaderMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
