// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TargetVariablesDataTypeCollection
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
[CollectionDataContract(Name = "ListOfTargetVariablesDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TargetVariablesDataType")]
[ComVisible(true)]
public class TargetVariablesDataTypeCollection : List<TargetVariablesDataType>, ICloneable
{
  public TargetVariablesDataTypeCollection()
  {
  }

  public TargetVariablesDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public TargetVariablesDataTypeCollection(IEnumerable<TargetVariablesDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator TargetVariablesDataTypeCollection(TargetVariablesDataType[] values)
  {
    return values != null ? new TargetVariablesDataTypeCollection((IEnumerable<TargetVariablesDataType>) values) : new TargetVariablesDataTypeCollection();
  }

  public static explicit operator TargetVariablesDataType[](TargetVariablesDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TargetVariablesDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TargetVariablesDataTypeCollection dataTypeCollection = new TargetVariablesDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((TargetVariablesDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
