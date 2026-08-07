// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StringCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfString", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "String")]
[ComVisible(true)]
public class StringCollection : List<string>, ICloneable
{
  public StringCollection()
  {
  }

  public StringCollection(int capacity)
    : base(capacity)
  {
  }

  public StringCollection(IEnumerable<string> collection)
    : base(collection)
  {
  }

  public static StringCollection ToStringCollection(string[] values)
  {
    return values != null ? new StringCollection((IEnumerable<string>) values) : new StringCollection();
  }

  public static implicit operator StringCollection(string[] values)
  {
    return StringCollection.ToStringCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new StringCollection((IEnumerable<string>) this);
}
