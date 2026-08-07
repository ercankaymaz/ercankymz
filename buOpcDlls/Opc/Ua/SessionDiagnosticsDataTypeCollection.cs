// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionDiagnosticsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSessionDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SessionDiagnosticsDataType")]
[ComVisible(true)]
public class SessionDiagnosticsDataTypeCollection : List<SessionDiagnosticsDataType>, ICloneable
{
  public SessionDiagnosticsDataTypeCollection()
  {
  }

  public SessionDiagnosticsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SessionDiagnosticsDataTypeCollection(IEnumerable<SessionDiagnosticsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SessionDiagnosticsDataTypeCollection(
    SessionDiagnosticsDataType[] values)
  {
    return values != null ? new SessionDiagnosticsDataTypeCollection((IEnumerable<SessionDiagnosticsDataType>) values) : new SessionDiagnosticsDataTypeCollection();
  }

  public static explicit operator SessionDiagnosticsDataType[](
    SessionDiagnosticsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SessionDiagnosticsDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SessionDiagnosticsDataTypeCollection dataTypeCollection = new SessionDiagnosticsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SessionDiagnosticsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
