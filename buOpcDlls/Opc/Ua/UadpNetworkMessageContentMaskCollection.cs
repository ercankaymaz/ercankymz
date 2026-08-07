// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpNetworkMessageContentMaskCollection
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
[CollectionDataContract(Name = "ListOfUadpNetworkMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpNetworkMessageContentMask")]
[ComVisible(true)]
public class UadpNetworkMessageContentMaskCollection : 
  List<UadpNetworkMessageContentMask>,
  ICloneable
{
  public UadpNetworkMessageContentMaskCollection()
  {
  }

  public UadpNetworkMessageContentMaskCollection(int capacity)
    : base(capacity)
  {
  }

  public UadpNetworkMessageContentMaskCollection(
    IEnumerable<UadpNetworkMessageContentMask> collection)
    : base(collection)
  {
  }

  public static implicit operator UadpNetworkMessageContentMaskCollection(
    UadpNetworkMessageContentMask[] values)
  {
    return values != null ? new UadpNetworkMessageContentMaskCollection((IEnumerable<UadpNetworkMessageContentMask>) values) : new UadpNetworkMessageContentMaskCollection();
  }

  public static explicit operator UadpNetworkMessageContentMask[](
    UadpNetworkMessageContentMaskCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (UadpNetworkMessageContentMaskCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpNetworkMessageContentMaskCollection contentMaskCollection = new UadpNetworkMessageContentMaskCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      contentMaskCollection.Add((UadpNetworkMessageContentMask) Utils.Clone((object) this[index]));
    return (object) contentMaskCollection;
  }
}
