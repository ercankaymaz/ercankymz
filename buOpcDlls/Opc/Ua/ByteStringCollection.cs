// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ByteStringCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfByteString", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ByteString")]
[ComVisible(true)]
public class ByteStringCollection : List<byte[]>, ICloneable
{
  public ByteStringCollection()
  {
  }

  public ByteStringCollection(int capacity)
    : base(capacity)
  {
  }

  public ByteStringCollection(IEnumerable<byte[]> collection)
    : base(collection)
  {
  }

  public static ByteStringCollection ToByteStringCollection(byte[][] values)
  {
    return values != null ? new ByteStringCollection((IEnumerable<byte[]>) values) : new ByteStringCollection();
  }

  public static implicit operator ByteStringCollection(byte[][] values)
  {
    return ByteStringCollection.ToByteStringCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ByteStringCollection stringCollection = new ByteStringCollection(this.Count);
    foreach (byte[] numArray in (List<byte[]>) this)
      stringCollection.Add((byte[]) Utils.Clone((object) numArray));
    return (object) stringCollection;
  }
}
