// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadValueIdCollection
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
[CollectionDataContract(Name = "ListOfReadValueId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReadValueId")]
[ComVisible(true)]
public class ReadValueIdCollection : List<ReadValueId>, ICloneable
{
  public ReadValueIdCollection()
  {
  }

  public ReadValueIdCollection(int capacity)
    : base(capacity)
  {
  }

  public ReadValueIdCollection(IEnumerable<ReadValueId> collection)
    : base(collection)
  {
  }

  public static implicit operator ReadValueIdCollection(ReadValueId[] values)
  {
    return values != null ? new ReadValueIdCollection((IEnumerable<ReadValueId>) values) : new ReadValueIdCollection();
  }

  public static explicit operator ReadValueId[](ReadValueIdCollection values) => values?.ToArray();

  public object Clone() => (object) (ReadValueIdCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      valueIdCollection.Add((ReadValueId) Utils.Clone((object) this[index]));
    return (object) valueIdCollection;
  }
}
