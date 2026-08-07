// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UABinaryFileDataTypeCollection
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
[CollectionDataContract(Name = "ListOfUABinaryFileDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UABinaryFileDataType")]
[ComVisible(true)]
public class UABinaryFileDataTypeCollection : List<UABinaryFileDataType>, ICloneable
{
  public UABinaryFileDataTypeCollection()
  {
  }

  public UABinaryFileDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public UABinaryFileDataTypeCollection(IEnumerable<UABinaryFileDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator UABinaryFileDataTypeCollection(UABinaryFileDataType[] values)
  {
    return values != null ? new UABinaryFileDataTypeCollection((IEnumerable<UABinaryFileDataType>) values) : new UABinaryFileDataTypeCollection();
  }

  public static explicit operator UABinaryFileDataType[](UABinaryFileDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (UABinaryFileDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UABinaryFileDataTypeCollection dataTypeCollection = new UABinaryFileDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((UABinaryFileDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
