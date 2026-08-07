// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DateTimeCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDateTime", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DateTime")]
[ComVisible(true)]
public class DateTimeCollection : List<DateTime>, ICloneable
{
  public DateTimeCollection()
  {
  }

  public DateTimeCollection(int capacity)
    : base(capacity)
  {
  }

  public DateTimeCollection(IEnumerable<DateTime> collection)
    : base(collection)
  {
  }

  public static DateTimeCollection ToDateTimeCollection(DateTime[] values)
  {
    return values != null ? new DateTimeCollection((IEnumerable<DateTime>) values) : new DateTimeCollection();
  }

  public static implicit operator DateTimeCollection(DateTime[] values)
  {
    return DateTimeCollection.ToDateTimeCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return (object) new DateTimeCollection((IEnumerable<DateTime>) this);
  }
}
