// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OAuth2Credential
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OAuth2Credential
{
  public OAuth2Credential() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
  }

  [DataMember(Order = 1)]
  public string AuthorityUrl { get; set; }

  [DataMember(Order = 2)]
  public string GrantType { get; set; }

  [DataMember(Order = 3)]
  public string ClientId { get; set; }

  [DataMember(Order = 4)]
  public string ClientSecret { get; set; }

  [DataMember(Order = 5)]
  public string RedirectUrl { get; set; }

  [DataMember(Order = 6)]
  public string TokenEndpoint { get; set; }

  [DataMember(Order = 7)]
  public string AuthorizationEndpoint { get; set; }

  [DataMember(Order = 8)]
  public OAuth2ServerSettingsCollection Servers { get; set; }

  public OAuth2ServerSettings SelectedServer { get; set; }
}
