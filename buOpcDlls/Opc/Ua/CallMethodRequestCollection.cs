// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallMethodRequestCollection
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
[CollectionDataContract(Name = "ListOfCallMethodRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CallMethodRequest")]
[ComVisible(true)]
public class CallMethodRequestCollection : List<CallMethodRequest>, ICloneable
{
  public CallMethodRequestCollection()
  {
  }

  public CallMethodRequestCollection(int capacity)
    : base(capacity)
  {
  }

  public CallMethodRequestCollection(IEnumerable<CallMethodRequest> collection)
    : base(collection)
  {
  }

  public static implicit operator CallMethodRequestCollection(CallMethodRequest[] values)
  {
    return values != null ? new CallMethodRequestCollection((IEnumerable<CallMethodRequest>) values) : new CallMethodRequestCollection();
  }

  public static explicit operator CallMethodRequest[](CallMethodRequestCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (CallMethodRequestCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CallMethodRequestCollection requestCollection = new CallMethodRequestCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      requestCollection.Add((CallMethodRequest) Utils.Clone((object) this[index]));
    return (object) requestCollection;
  }
}
