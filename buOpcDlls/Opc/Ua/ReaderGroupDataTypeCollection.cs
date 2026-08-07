// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReaderGroupDataTypeCollection
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
[CollectionDataContract(Name = "ListOfReaderGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupDataType")]
[ComVisible(true)]
public class ReaderGroupDataTypeCollection : List<ReaderGroupDataType>, ICloneable
{
  public ReaderGroupDataTypeCollection()
  {
  }

  public ReaderGroupDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ReaderGroupDataTypeCollection(IEnumerable<ReaderGroupDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ReaderGroupDataTypeCollection(ReaderGroupDataType[] values)
  {
    return values != null ? new ReaderGroupDataTypeCollection((IEnumerable<ReaderGroupDataType>) values) : new ReaderGroupDataTypeCollection();
  }

  public static explicit operator ReaderGroupDataType[](ReaderGroupDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ReaderGroupDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReaderGroupDataTypeCollection dataTypeCollection = new ReaderGroupDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ReaderGroupDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
