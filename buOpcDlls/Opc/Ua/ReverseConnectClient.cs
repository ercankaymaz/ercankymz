// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReverseConnectClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectClient
{
  public ReverseConnectClient() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.Enabled = true;

  [DataMember(Order = 10)]
  public string EndpointUrl { get; set; }

  [DataMember(Order = 20)]
  public int Timeout { get; set; }

  [DataMember(Order = 30)]
  public int MaxSessionCount { get; set; }

  [DataMember(Order = 40)]
  public bool Enabled { get; set; } = true;
}
