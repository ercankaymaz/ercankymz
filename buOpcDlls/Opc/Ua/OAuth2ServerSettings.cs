// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OAuth2ServerSettings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OAuth2ServerSettings
{
  [DataMember(Order = 1)]
  public string ApplicationUri { get; set; }

  [DataMember(Order = 2)]
  public string ResourceId { get; set; }

  [DataMember(Order = 3)]
  public StringCollection Scopes { get; set; }
}
