// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerOnNetworkCollection
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
[CollectionDataContract(Name = "ListOfServerOnNetwork", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ServerOnNetwork")]
[ComVisible(true)]
public class ServerOnNetworkCollection : List<ServerOnNetwork>, ICloneable
{
  public ServerOnNetworkCollection()
  {
  }

  public ServerOnNetworkCollection(int capacity)
    : base(capacity)
  {
  }

  public ServerOnNetworkCollection(IEnumerable<ServerOnNetwork> collection)
    : base(collection)
  {
  }

  public static implicit operator ServerOnNetworkCollection(ServerOnNetwork[] values)
  {
    return values != null ? new ServerOnNetworkCollection((IEnumerable<ServerOnNetwork>) values) : new ServerOnNetworkCollection();
  }

  public static explicit operator ServerOnNetwork[](ServerOnNetworkCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ServerOnNetworkCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ServerOnNetworkCollection networkCollection = new ServerOnNetworkCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      networkCollection.Add((ServerOnNetwork) Utils.Clone((object) this[index]));
    return (object) networkCollection;
  }
}
