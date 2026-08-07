// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiagnosticInfoCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDiagnosticInfo", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DiagnosticInfo")]
[ComVisible(true)]
public class DiagnosticInfoCollection : List<DiagnosticInfo>, ICloneable
{
  public DiagnosticInfoCollection()
  {
  }

  public DiagnosticInfoCollection(IEnumerable<DiagnosticInfo> collection)
    : base(collection)
  {
  }

  public DiagnosticInfoCollection(int capacity)
    : base(capacity)
  {
  }

  public static DiagnosticInfoCollection ToDiagnosticInfoCollection(DiagnosticInfo[] values)
  {
    return values != null ? new DiagnosticInfoCollection((IEnumerable<DiagnosticInfo>) values) : new DiagnosticInfoCollection();
  }

  public static implicit operator DiagnosticInfoCollection(DiagnosticInfo[] values)
  {
    return DiagnosticInfoCollection.ToDiagnosticInfoCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection(this.Count);
    foreach (DiagnosticInfo diagnosticInfo in (List<DiagnosticInfo>) this)
      diagnosticInfoCollection.Add((DiagnosticInfo) Utils.Clone((object) diagnosticInfo));
    return (object) diagnosticInfoCollection;
  }
}
