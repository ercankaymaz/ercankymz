// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OperationLimits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OperationLimits
{
  public OperationLimits() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.MaxNodesPerRead = 0U;
    this.MaxNodesPerHistoryReadData = 0U;
    this.MaxNodesPerHistoryReadEvents = 0U;
    this.MaxNodesPerWrite = 0U;
    this.MaxNodesPerHistoryUpdateData = 0U;
    this.MaxNodesPerHistoryUpdateEvents = 0U;
    this.MaxNodesPerMethodCall = 0U;
    this.MaxNodesPerBrowse = 0U;
    this.MaxNodesPerRegisterNodes = 0U;
    this.MaxNodesPerTranslateBrowsePathsToNodeIds = 0U;
    this.MaxNodesPerNodeManagement = 0U;
    this.MaxMonitoredItemsPerCall = 0U;
  }

  [DataMember(Order = 10)]
  public uint MaxNodesPerRead { get; set; }

  [DataMember(Order = 20)]
  public uint MaxNodesPerHistoryReadData { get; set; }

  [DataMember(Order = 30)]
  public uint MaxNodesPerHistoryReadEvents { get; set; }

  [DataMember(Order = 40)]
  public uint MaxNodesPerWrite { get; set; }

  [DataMember(Order = 50)]
  public uint MaxNodesPerHistoryUpdateData { get; set; }

  [DataMember(Order = 60)]
  public uint MaxNodesPerHistoryUpdateEvents { get; set; }

  [DataMember(Order = 70)]
  public uint MaxNodesPerMethodCall { get; set; }

  [DataMember(Order = 80 /*0x50*/)]
  public uint MaxNodesPerBrowse { get; set; }

  [DataMember(Order = 90)]
  public uint MaxNodesPerRegisterNodes { get; set; }

  [DataMember(Order = 100)]
  public uint MaxNodesPerTranslateBrowsePathsToNodeIds { get; set; }

  [DataMember(Order = 110)]
  public uint MaxNodesPerNodeManagement { get; set; }

  [DataMember(Order = 120)]
  public uint MaxMonitoredItemsPerCall { get; set; }
}
