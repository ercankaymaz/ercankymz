// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetWriterMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfJsonDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetWriterMessageDataType")]
[ComVisible(true)]
public class JsonDataSetWriterMessageDataTypeCollection : 
  List<JsonDataSetWriterMessageDataType>,
  ICloneable
{
  public JsonDataSetWriterMessageDataTypeCollection()
  {
  }

  public JsonDataSetWriterMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public JsonDataSetWriterMessageDataTypeCollection(
    IEnumerable<JsonDataSetWriterMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator JsonDataSetWriterMessageDataTypeCollection(
    JsonDataSetWriterMessageDataType[] values)
  {
    return values != null ? new JsonDataSetWriterMessageDataTypeCollection((IEnumerable<JsonDataSetWriterMessageDataType>) values) : new JsonDataSetWriterMessageDataTypeCollection();
  }

  public static explicit operator JsonDataSetWriterMessageDataType[](
    JsonDataSetWriterMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (JsonDataSetWriterMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonDataSetWriterMessageDataTypeCollection dataTypeCollection = new JsonDataSetWriterMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((JsonDataSetWriterMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
