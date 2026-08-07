// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetMessageContentMaskCollection
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
[CollectionDataContract(Name = "ListOfJsonDataSetMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetMessageContentMask")]
[ComVisible(true)]
public class JsonDataSetMessageContentMaskCollection : 
  List<JsonDataSetMessageContentMask>,
  ICloneable
{
  public JsonDataSetMessageContentMaskCollection()
  {
  }

  public JsonDataSetMessageContentMaskCollection(int capacity)
    : base(capacity)
  {
  }

  public JsonDataSetMessageContentMaskCollection(
    IEnumerable<JsonDataSetMessageContentMask> collection)
    : base(collection)
  {
  }

  public static implicit operator JsonDataSetMessageContentMaskCollection(
    JsonDataSetMessageContentMask[] values)
  {
    return values != null ? new JsonDataSetMessageContentMaskCollection((IEnumerable<JsonDataSetMessageContentMask>) values) : new JsonDataSetMessageContentMaskCollection();
  }

  public static explicit operator JsonDataSetMessageContentMask[](
    JsonDataSetMessageContentMaskCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (JsonDataSetMessageContentMaskCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonDataSetMessageContentMaskCollection contentMaskCollection = new JsonDataSetMessageContentMaskCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      contentMaskCollection.Add((JsonDataSetMessageContentMask) Utils.Clone((object) this[index]));
    return (object) contentMaskCollection;
  }
}
