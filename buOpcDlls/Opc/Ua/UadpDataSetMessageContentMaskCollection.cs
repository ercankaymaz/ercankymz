// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetMessageContentMaskCollection
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
[CollectionDataContract(Name = "ListOfUadpDataSetMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetMessageContentMask")]
[ComVisible(true)]
public class UadpDataSetMessageContentMaskCollection : 
  List<UadpDataSetMessageContentMask>,
  ICloneable
{
  public UadpDataSetMessageContentMaskCollection()
  {
  }

  public UadpDataSetMessageContentMaskCollection(int capacity)
    : base(capacity)
  {
  }

  public UadpDataSetMessageContentMaskCollection(
    IEnumerable<UadpDataSetMessageContentMask> collection)
    : base(collection)
  {
  }

  public static implicit operator UadpDataSetMessageContentMaskCollection(
    UadpDataSetMessageContentMask[] values)
  {
    return values != null ? new UadpDataSetMessageContentMaskCollection((IEnumerable<UadpDataSetMessageContentMask>) values) : new UadpDataSetMessageContentMaskCollection();
  }

  public static explicit operator UadpDataSetMessageContentMask[](
    UadpDataSetMessageContentMaskCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (UadpDataSetMessageContentMaskCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpDataSetMessageContentMaskCollection contentMaskCollection = new UadpDataSetMessageContentMaskCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      contentMaskCollection.Add((UadpDataSetMessageContentMask) Utils.Clone((object) this[index]));
    return (object) contentMaskCollection;
  }
}
