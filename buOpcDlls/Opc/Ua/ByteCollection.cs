// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ByteCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfByte", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Byte")]
[ComVisible(true)]
public class ByteCollection : List<byte>, ICloneable
{
  public ByteCollection()
  {
  }

  public ByteCollection(int capacity)
    : base(capacity)
  {
  }

  public ByteCollection(IEnumerable<byte> collection)
    : base(collection)
  {
  }

  public static ByteCollection ToByteCollection(byte[] values)
  {
    return values != null ? new ByteCollection((IEnumerable<byte>) values) : new ByteCollection();
  }

  public static implicit operator ByteCollection(byte[] values)
  {
    return ByteCollection.ToByteCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new ByteCollection((IEnumerable<byte>) this);
}
