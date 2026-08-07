// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TimeZoneDataTypeCollection
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
[CollectionDataContract(Name = "ListOfTimeZoneDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TimeZoneDataType")]
[ComVisible(true)]
public class TimeZoneDataTypeCollection : List<TimeZoneDataType>, ICloneable
{
  public TimeZoneDataTypeCollection()
  {
  }

  public TimeZoneDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public TimeZoneDataTypeCollection(IEnumerable<TimeZoneDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator TimeZoneDataTypeCollection(TimeZoneDataType[] values)
  {
    return values != null ? new TimeZoneDataTypeCollection((IEnumerable<TimeZoneDataType>) values) : new TimeZoneDataTypeCollection();
  }

  public static explicit operator TimeZoneDataType[](TimeZoneDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TimeZoneDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TimeZoneDataTypeCollection dataTypeCollection = new TimeZoneDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((TimeZoneDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
