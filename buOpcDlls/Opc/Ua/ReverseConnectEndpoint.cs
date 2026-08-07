// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReverseConnectEndpoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectEndpoint
{
  private bool m_enabled;
  private string m_serverUri;
  private string m_thumbprint;

  public ReverseConnectEndpoint() => this.Initialize();

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_enabled = false;
    this.m_serverUri = (string) null;
    this.m_thumbprint = (string) null;
  }

  [DataMember(Name = "Enabled", Order = 1, IsRequired = false)]
  public bool Enabled
  {
    get => this.m_enabled;
    set => this.m_enabled = value;
  }

  [DataMember(Name = "ServerUri", Order = 2, IsRequired = false)]
  public string ServerUri
  {
    get => this.m_serverUri;
    set => this.m_serverUri = value;
  }

  [DataMember(Name = "Thumbprint", Order = 3, IsRequired = false)]
  public string Thumbprint
  {
    get => this.m_thumbprint;
    set => this.m_thumbprint = value;
  }
}
