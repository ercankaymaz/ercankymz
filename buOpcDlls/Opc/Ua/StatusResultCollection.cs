// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusResultCollection
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
[CollectionDataContract(Name = "ListOfStatusResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StatusResult")]
[ComVisible(true)]
public class StatusResultCollection : List<StatusResult>, ICloneable
{
  public StatusResultCollection()
  {
  }

  public StatusResultCollection(int capacity)
    : base(capacity)
  {
  }

  public StatusResultCollection(IEnumerable<StatusResult> collection)
    : base(collection)
  {
  }

  public static implicit operator StatusResultCollection(StatusResult[] values)
  {
    return values != null ? new StatusResultCollection((IEnumerable<StatusResult>) values) : new StatusResultCollection();
  }

  public static explicit operator StatusResult[](StatusResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (StatusResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StatusResultCollection resultCollection = new StatusResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((StatusResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
