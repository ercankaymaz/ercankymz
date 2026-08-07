// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallMethodResultCollection
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
[CollectionDataContract(Name = "ListOfCallMethodResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CallMethodResult")]
[ComVisible(true)]
public class CallMethodResultCollection : List<CallMethodResult>, ICloneable
{
  public CallMethodResultCollection()
  {
  }

  public CallMethodResultCollection(int capacity)
    : base(capacity)
  {
  }

  public CallMethodResultCollection(IEnumerable<CallMethodResult> collection)
    : base(collection)
  {
  }

  public static implicit operator CallMethodResultCollection(CallMethodResult[] values)
  {
    return values != null ? new CallMethodResultCollection((IEnumerable<CallMethodResult>) values) : new CallMethodResultCollection();
  }

  public static explicit operator CallMethodResult[](CallMethodResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (CallMethodResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CallMethodResultCollection resultCollection = new CallMethodResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((CallMethodResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
