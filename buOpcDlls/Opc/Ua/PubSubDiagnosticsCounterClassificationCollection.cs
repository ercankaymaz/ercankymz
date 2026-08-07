// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubDiagnosticsCounterClassificationCollection
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
[CollectionDataContract(Name = "ListOfPubSubDiagnosticsCounterClassification", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubDiagnosticsCounterClassification")]
[ComVisible(true)]
public class PubSubDiagnosticsCounterClassificationCollection : 
  List<PubSubDiagnosticsCounterClassification>,
  ICloneable
{
  public PubSubDiagnosticsCounterClassificationCollection()
  {
  }

  public PubSubDiagnosticsCounterClassificationCollection(int capacity)
    : base(capacity)
  {
  }

  public PubSubDiagnosticsCounterClassificationCollection(
    IEnumerable<PubSubDiagnosticsCounterClassification> collection)
    : base(collection)
  {
  }

  public static implicit operator PubSubDiagnosticsCounterClassificationCollection(
    PubSubDiagnosticsCounterClassification[] values)
  {
    return values != null ? new PubSubDiagnosticsCounterClassificationCollection((IEnumerable<PubSubDiagnosticsCounterClassification>) values) : new PubSubDiagnosticsCounterClassificationCollection();
  }

  public static explicit operator PubSubDiagnosticsCounterClassification[](
    PubSubDiagnosticsCounterClassificationCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (PubSubDiagnosticsCounterClassificationCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    PubSubDiagnosticsCounterClassificationCollection classificationCollection = new PubSubDiagnosticsCounterClassificationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      classificationCollection.Add((PubSubDiagnosticsCounterClassification) Utils.Clone((object) this[index]));
    return (object) classificationCollection;
  }
}
