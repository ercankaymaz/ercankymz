// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetReaderMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfJsonDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetReaderMessageDataType")]
[ComVisible(true)]
public class JsonDataSetReaderMessageDataTypeCollection : 
  List<JsonDataSetReaderMessageDataType>,
  ICloneable
{
  public JsonDataSetReaderMessageDataTypeCollection()
  {
  }

  public JsonDataSetReaderMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public JsonDataSetReaderMessageDataTypeCollection(
    IEnumerable<JsonDataSetReaderMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator JsonDataSetReaderMessageDataTypeCollection(
    JsonDataSetReaderMessageDataType[] values)
  {
    return values != null ? new JsonDataSetReaderMessageDataTypeCollection((IEnumerable<JsonDataSetReaderMessageDataType>) values) : new JsonDataSetReaderMessageDataTypeCollection();
  }

  public static explicit operator JsonDataSetReaderMessageDataType[](
    JsonDataSetReaderMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (JsonDataSetReaderMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonDataSetReaderMessageDataTypeCollection dataTypeCollection = new JsonDataSetReaderMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((JsonDataSetReaderMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
