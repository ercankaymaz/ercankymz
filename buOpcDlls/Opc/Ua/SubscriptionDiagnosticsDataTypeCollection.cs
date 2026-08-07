// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionDiagnosticsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSubscriptionDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscriptionDiagnosticsDataType")]
[ComVisible(true)]
public class SubscriptionDiagnosticsDataTypeCollection : 
  List<SubscriptionDiagnosticsDataType>,
  ICloneable
{
  public SubscriptionDiagnosticsDataTypeCollection()
  {
  }

  public SubscriptionDiagnosticsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SubscriptionDiagnosticsDataTypeCollection(
    IEnumerable<SubscriptionDiagnosticsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SubscriptionDiagnosticsDataTypeCollection(
    SubscriptionDiagnosticsDataType[] values)
  {
    return values != null ? new SubscriptionDiagnosticsDataTypeCollection((IEnumerable<SubscriptionDiagnosticsDataType>) values) : new SubscriptionDiagnosticsDataTypeCollection();
  }

  public static explicit operator SubscriptionDiagnosticsDataType[](
    SubscriptionDiagnosticsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (SubscriptionDiagnosticsDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SubscriptionDiagnosticsDataTypeCollection dataTypeCollection = new SubscriptionDiagnosticsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SubscriptionDiagnosticsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
