// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpWriterGroupMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfUadpWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpWriterGroupMessageDataType")]
[ComVisible(true)]
public class UadpWriterGroupMessageDataTypeCollection : 
  List<UadpWriterGroupMessageDataType>,
  ICloneable
{
  public UadpWriterGroupMessageDataTypeCollection()
  {
  }

  public UadpWriterGroupMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public UadpWriterGroupMessageDataTypeCollection(
    IEnumerable<UadpWriterGroupMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator UadpWriterGroupMessageDataTypeCollection(
    UadpWriterGroupMessageDataType[] values)
  {
    return values != null ? new UadpWriterGroupMessageDataTypeCollection((IEnumerable<UadpWriterGroupMessageDataType>) values) : new UadpWriterGroupMessageDataTypeCollection();
  }

  public static explicit operator UadpWriterGroupMessageDataType[](
    UadpWriterGroupMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (UadpWriterGroupMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpWriterGroupMessageDataTypeCollection dataTypeCollection = new UadpWriterGroupMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((UadpWriterGroupMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
