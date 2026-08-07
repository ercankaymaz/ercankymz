// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerSecurityPolicyCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfServerSecurityPolicy", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ServerSecurityPolicy")]
[ComVisible(true)]
public class ServerSecurityPolicyCollection : List<ServerSecurityPolicy>
{
  public ServerSecurityPolicyCollection()
  {
  }

  public ServerSecurityPolicyCollection(IEnumerable<ServerSecurityPolicy> collection)
    : base(collection)
  {
  }

  public ServerSecurityPolicyCollection(int capacity)
    : base(capacity)
  {
  }
}
