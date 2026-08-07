// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReverseConnectClientConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectClientConfiguration
{
  public ReverseConnectClientConfiguration() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
  }

  [DataMember(Order = 10, IsRequired = false)]
  public ReverseConnectClientEndpointCollection ClientEndpoints { get; set; }

  [DataMember(Order = 20, IsRequired = false)]
  public int HoldTime { get; set; } = 15000;

  [DataMember(Order = 30, IsRequired = false)]
  public int WaitTimeout { get; set; } = 20000;
}
