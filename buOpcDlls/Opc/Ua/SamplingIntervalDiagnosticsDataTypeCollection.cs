// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SamplingIntervalDiagnosticsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSamplingIntervalDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SamplingIntervalDiagnosticsDataType")]
[ComVisible(true)]
public class SamplingIntervalDiagnosticsDataTypeCollection : 
  List<SamplingIntervalDiagnosticsDataType>,
  ICloneable
{
  public SamplingIntervalDiagnosticsDataTypeCollection()
  {
  }

  public SamplingIntervalDiagnosticsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SamplingIntervalDiagnosticsDataTypeCollection(
    IEnumerable<SamplingIntervalDiagnosticsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SamplingIntervalDiagnosticsDataTypeCollection(
    SamplingIntervalDiagnosticsDataType[] values)
  {
    return values != null ? new SamplingIntervalDiagnosticsDataTypeCollection((IEnumerable<SamplingIntervalDiagnosticsDataType>) values) : new SamplingIntervalDiagnosticsDataTypeCollection();
  }

  public static explicit operator SamplingIntervalDiagnosticsDataType[](
    SamplingIntervalDiagnosticsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (SamplingIntervalDiagnosticsDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SamplingIntervalDiagnosticsDataTypeCollection dataTypeCollection = new SamplingIntervalDiagnosticsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SamplingIntervalDiagnosticsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
