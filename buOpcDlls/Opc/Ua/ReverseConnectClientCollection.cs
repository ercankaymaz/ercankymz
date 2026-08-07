// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReverseConnectClientCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfReverseConnectClient", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ReverseConnectClient")]
[ComVisible(true)]
public class ReverseConnectClientCollection : List<ReverseConnectClient>
{
  public ReverseConnectClientCollection()
  {
  }

  public ReverseConnectClientCollection(IEnumerable<ReverseConnectClient> collection)
    : base(collection)
  {
  }

  public ReverseConnectClientCollection(int capacity)
    : base(capacity)
  {
  }
}
