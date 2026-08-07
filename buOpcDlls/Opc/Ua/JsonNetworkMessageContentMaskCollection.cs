// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonNetworkMessageContentMaskCollection
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
[CollectionDataContract(Name = "ListOfJsonNetworkMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonNetworkMessageContentMask")]
[ComVisible(true)]
public class JsonNetworkMessageContentMaskCollection : 
  List<JsonNetworkMessageContentMask>,
  ICloneable
{
  public JsonNetworkMessageContentMaskCollection()
  {
  }

  public JsonNetworkMessageContentMaskCollection(int capacity)
    : base(capacity)
  {
  }

  public JsonNetworkMessageContentMaskCollection(
    IEnumerable<JsonNetworkMessageContentMask> collection)
    : base(collection)
  {
  }

  public static implicit operator JsonNetworkMessageContentMaskCollection(
    JsonNetworkMessageContentMask[] values)
  {
    return values != null ? new JsonNetworkMessageContentMaskCollection((IEnumerable<JsonNetworkMessageContentMask>) values) : new JsonNetworkMessageContentMaskCollection();
  }

  public static explicit operator JsonNetworkMessageContentMask[](
    JsonNetworkMessageContentMaskCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (JsonNetworkMessageContentMaskCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonNetworkMessageContentMaskCollection contentMaskCollection = new JsonNetworkMessageContentMaskCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      contentMaskCollection.Add((JsonNetworkMessageContentMask) Utils.Clone((object) this[index]));
    return (object) contentMaskCollection;
  }
}
