// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonWriterGroupMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfJsonWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonWriterGroupMessageDataType")]
[ComVisible(true)]
public class JsonWriterGroupMessageDataTypeCollection : 
  List<JsonWriterGroupMessageDataType>,
  ICloneable
{
  public JsonWriterGroupMessageDataTypeCollection()
  {
  }

  public JsonWriterGroupMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public JsonWriterGroupMessageDataTypeCollection(
    IEnumerable<JsonWriterGroupMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator JsonWriterGroupMessageDataTypeCollection(
    JsonWriterGroupMessageDataType[] values)
  {
    return values != null ? new JsonWriterGroupMessageDataTypeCollection((IEnumerable<JsonWriterGroupMessageDataType>) values) : new JsonWriterGroupMessageDataTypeCollection();
  }

  public static explicit operator JsonWriterGroupMessageDataType[](
    JsonWriterGroupMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (JsonWriterGroupMessageDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonWriterGroupMessageDataTypeCollection dataTypeCollection = new JsonWriterGroupMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((JsonWriterGroupMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
