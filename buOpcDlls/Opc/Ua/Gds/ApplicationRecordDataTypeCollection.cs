// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.ApplicationRecordDataTypeCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfApplicationRecordDataType", Namespace = "http://opcfoundation.org/UA/GDS/Types.xsd", ItemName = "ApplicationRecordDataType")]
[ComVisible(true)]
public class ApplicationRecordDataTypeCollection : List<ApplicationRecordDataType>, ICloneable
{
  public ApplicationRecordDataTypeCollection()
  {
  }

  public ApplicationRecordDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ApplicationRecordDataTypeCollection(IEnumerable<ApplicationRecordDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ApplicationRecordDataTypeCollection(
    ApplicationRecordDataType[] values)
  {
    return values != null ? new ApplicationRecordDataTypeCollection((IEnumerable<ApplicationRecordDataType>) values) : new ApplicationRecordDataTypeCollection();
  }

  public static explicit operator ApplicationRecordDataType[](
    ApplicationRecordDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ApplicationRecordDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ApplicationRecordDataTypeCollection dataTypeCollection = new ApplicationRecordDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ApplicationRecordDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
