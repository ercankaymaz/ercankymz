// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiagnosticsLevelCollection
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
[CollectionDataContract(Name = "ListOfDiagnosticsLevel", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DiagnosticsLevel")]
[ComVisible(true)]
public class DiagnosticsLevelCollection : List<DiagnosticsLevel>, ICloneable
{
  public DiagnosticsLevelCollection()
  {
  }

  public DiagnosticsLevelCollection(int capacity)
    : base(capacity)
  {
  }

  public DiagnosticsLevelCollection(IEnumerable<DiagnosticsLevel> collection)
    : base(collection)
  {
  }

  public static implicit operator DiagnosticsLevelCollection(DiagnosticsLevel[] values)
  {
    return values != null ? new DiagnosticsLevelCollection((IEnumerable<DiagnosticsLevel>) values) : new DiagnosticsLevelCollection();
  }

  public static explicit operator DiagnosticsLevel[](DiagnosticsLevelCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DiagnosticsLevelCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DiagnosticsLevelCollection diagnosticsLevelCollection = new DiagnosticsLevelCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      diagnosticsLevelCollection.Add((DiagnosticsLevel) Utils.Clone((object) this[index]));
    return (object) diagnosticsLevelCollection;
  }
}
