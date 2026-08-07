// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscoveryServerConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class DiscoveryServerConfiguration : ServerBaseConfiguration
{
  private LocalizedTextCollection m_serverNames;
  private string m_discoveryServerCacheFile;
  private ServerRegistrationCollection m_serverRegistrations;

  public DiscoveryServerConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_serverNames = new LocalizedTextCollection();
    this.m_serverRegistrations = new ServerRegistrationCollection();
  }

  [OnDeserializing]
  public new void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
  public LocalizedTextCollection ServerNames
  {
    get => this.m_serverNames;
    set
    {
      this.m_serverNames = value;
      if (this.m_serverNames != null)
        return;
      this.m_serverNames = new LocalizedTextCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 3)]
  public string DiscoveryServerCacheFile
  {
    get => this.m_discoveryServerCacheFile;
    set => this.m_discoveryServerCacheFile = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
  public ServerRegistrationCollection ServerRegistrations
  {
    get => this.m_serverRegistrations;
    set => this.m_serverRegistrations = value;
  }
}
