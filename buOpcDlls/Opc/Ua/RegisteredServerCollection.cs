// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisteredServerCollection
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
[CollectionDataContract(Name = "ListOfRegisteredServer", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RegisteredServer")]
[ComVisible(true)]
public class RegisteredServerCollection : List<RegisteredServer>, ICloneable
{
  public RegisteredServerCollection()
  {
  }

  public RegisteredServerCollection(int capacity)
    : base(capacity)
  {
  }

  public RegisteredServerCollection(IEnumerable<RegisteredServer> collection)
    : base(collection)
  {
  }

  public static implicit operator RegisteredServerCollection(RegisteredServer[] values)
  {
    return values != null ? new RegisteredServerCollection((IEnumerable<RegisteredServer>) values) : new RegisteredServerCollection();
  }

  public static explicit operator RegisteredServer[](RegisteredServerCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (RegisteredServerCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisteredServerCollection serverCollection = new RegisteredServerCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      serverCollection.Add((RegisteredServer) Utils.Clone((object) this[index]));
    return (object) serverCollection;
  }
}
