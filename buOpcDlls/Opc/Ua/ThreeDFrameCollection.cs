// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDFrameCollection
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
[CollectionDataContract(Name = "ListOfThreeDFrame", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDFrame")]
[ComVisible(true)]
public class ThreeDFrameCollection : List<ThreeDFrame>, ICloneable
{
  public ThreeDFrameCollection()
  {
  }

  public ThreeDFrameCollection(int capacity)
    : base(capacity)
  {
  }

  public ThreeDFrameCollection(IEnumerable<ThreeDFrame> collection)
    : base(collection)
  {
  }

  public static implicit operator ThreeDFrameCollection(ThreeDFrame[] values)
  {
    return values != null ? new ThreeDFrameCollection((IEnumerable<ThreeDFrame>) values) : new ThreeDFrameCollection();
  }

  public static explicit operator ThreeDFrame[](ThreeDFrameCollection values) => values?.ToArray();

  public object Clone() => (object) (ThreeDFrameCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDFrameCollection dframeCollection = new ThreeDFrameCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dframeCollection.Add((ThreeDFrame) Utils.Clone((object) this[index]));
    return (object) dframeCollection;
  }
}
