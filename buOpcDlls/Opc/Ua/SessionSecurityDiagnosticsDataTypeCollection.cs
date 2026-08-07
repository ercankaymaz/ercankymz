// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionSecurityDiagnosticsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSessionSecurityDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SessionSecurityDiagnosticsDataType")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsDataTypeCollection : 
  List<SessionSecurityDiagnosticsDataType>,
  ICloneable
{
  public SessionSecurityDiagnosticsDataTypeCollection()
  {
  }

  public SessionSecurityDiagnosticsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SessionSecurityDiagnosticsDataTypeCollection(
    IEnumerable<SessionSecurityDiagnosticsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SessionSecurityDiagnosticsDataTypeCollection(
    SessionSecurityDiagnosticsDataType[] values)
  {
    return values != null ? new SessionSecurityDiagnosticsDataTypeCollection((IEnumerable<SessionSecurityDiagnosticsDataType>) values) : new SessionSecurityDiagnosticsDataTypeCollection();
  }

  public static explicit operator SessionSecurityDiagnosticsDataType[](
    SessionSecurityDiagnosticsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (SessionSecurityDiagnosticsDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SessionSecurityDiagnosticsDataTypeCollection dataTypeCollection = new SessionSecurityDiagnosticsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SessionSecurityDiagnosticsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
