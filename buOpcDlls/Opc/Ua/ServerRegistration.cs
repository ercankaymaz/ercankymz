// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerRegistration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerRegistration
{
  private string m_applicationUri;
  private StringCollection m_alternateDiscoveryUrls;

  public ServerRegistration() => this.Initialize();

  private void Initialize()
  {
    this.m_applicationUri = (string) null;
    this.m_alternateDiscoveryUrls = new StringCollection();
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
  public string ApplicationUri
  {
    get => this.m_applicationUri;
    set => this.m_applicationUri = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
  public StringCollection AlternateDiscoveryUrls
  {
    get => this.m_alternateDiscoveryUrls;
    set
    {
      this.m_alternateDiscoveryUrls = value;
      if (this.m_alternateDiscoveryUrls != null)
        return;
      this.m_alternateDiscoveryUrls = new StringCollection();
    }
  }
}
