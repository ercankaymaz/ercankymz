// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FrameCollection
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
[CollectionDataContract(Name = "ListOfFrame", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Frame")]
[ComVisible(true)]
public class FrameCollection : List<Frame>, ICloneable
{
  public FrameCollection()
  {
  }

  public FrameCollection(int capacity)
    : base(capacity)
  {
  }

  public FrameCollection(IEnumerable<Frame> collection)
    : base(collection)
  {
  }

  public static implicit operator FrameCollection(Frame[] values)
  {
    return values != null ? new FrameCollection((IEnumerable<Frame>) values) : new FrameCollection();
  }

  public static explicit operator Frame[](FrameCollection values) => values?.ToArray();

  public object Clone() => (object) (FrameCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FrameCollection frameCollection = new FrameCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      frameCollection.Add((Frame) Utils.Clone((object) this[index]));
    return (object) frameCollection;
  }
}
