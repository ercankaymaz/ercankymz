// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.MonitoredItemStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemStatus
{
  private uint m_id;
  private ServiceResult m_error;
  private NodeId m_nodeId;
  private uint m_attributeId;
  private string m_indexRange;
  private QualifiedName m_encoding;
  private MonitoringMode m_monitoringMode;
  private uint m_clientHandle;
  private double m_samplingInterval;
  private MonitoringFilter m_filter;
  private MonitoringFilterResult m_filterResult;
  private uint m_queueSize;
  private bool m_discardOldest;

  internal MonitoredItemStatus() => this.Initialize();

  private void Initialize()
  {
    this.m_id = 0U;
    this.m_nodeId = (NodeId) null;
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
    this.m_encoding = (QualifiedName) null;
    this.m_monitoringMode = MonitoringMode.Disabled;
    this.m_clientHandle = 0U;
    this.m_samplingInterval = 0.0;
    this.m_filter = (MonitoringFilter) null;
    this.m_filterResult = (MonitoringFilterResult) null;
    this.m_queueSize = 0U;
    this.m_discardOldest = true;
  }

  public uint Id
  {
    get => this.m_id;
    set => this.m_id = value;
  }

  public bool Created => this.m_id > 0U;

  public ServiceResult Error => this.m_error;

  public NodeId NodeId => this.m_nodeId;

  public uint AttributeId => this.m_attributeId;

  public string IndexRange => this.m_indexRange;

  public QualifiedName DataEncoding => this.m_encoding;

  public MonitoringMode MonitoringMode => this.m_monitoringMode;

  public uint ClientHandle => this.m_clientHandle;

  public double SamplingInterval => this.m_samplingInterval;

  public MonitoringFilter Filter => this.m_filter;

  public MonitoringFilterResult FilterResult => this.m_filterResult;

  public uint QueueSize => this.m_queueSize;

  public bool DiscardOldest => this.m_discardOldest;

  public void SetMonitoringMode(MonitoringMode monitoringMode)
  {
    this.m_monitoringMode = monitoringMode;
  }

  internal void SetResolvePathResult(BrowsePathResult result, ServiceResult error)
  {
    this.m_error = error;
  }

  internal void SetCreateResult(
    MonitoredItemCreateRequest request,
    MonitoredItemCreateResult result,
    ServiceResult error)
  {
    if (request == null)
      throw new ArgumentNullException(nameof (request));
    if (result == null)
      throw new ArgumentNullException(nameof (result));
    this.m_nodeId = request.ItemToMonitor.NodeId;
    this.m_attributeId = request.ItemToMonitor.AttributeId;
    this.m_indexRange = request.ItemToMonitor.IndexRange;
    this.m_encoding = request.ItemToMonitor.DataEncoding;
    this.m_monitoringMode = request.MonitoringMode;
    this.m_clientHandle = request.RequestedParameters.ClientHandle;
    this.m_samplingInterval = request.RequestedParameters.SamplingInterval;
    this.m_queueSize = request.RequestedParameters.QueueSize;
    this.m_discardOldest = request.RequestedParameters.DiscardOldest;
    this.m_filter = (MonitoringFilter) null;
    this.m_filterResult = (MonitoringFilterResult) null;
    this.m_error = error;
    if (request.RequestedParameters.Filter != null)
      this.m_filter = Utils.Clone(request.RequestedParameters.Filter.Body) as MonitoringFilter;
    if (!ServiceResult.IsGood(error))
      return;
    this.m_id = result.MonitoredItemId;
    this.m_samplingInterval = result.RevisedSamplingInterval;
    this.m_queueSize = result.RevisedQueueSize;
    if (result.FilterResult == null)
      return;
    this.m_filterResult = Utils.Clone(result.FilterResult.Body) as MonitoringFilterResult;
  }

  internal void SetTransferResult(MonitoredItem monitoredItem)
  {
    this.m_nodeId = monitoredItem != null ? monitoredItem.ResolvedNodeId : throw new ArgumentNullException(nameof (monitoredItem));
    this.m_attributeId = monitoredItem.AttributeId;
    this.m_indexRange = monitoredItem.IndexRange;
    this.m_encoding = monitoredItem.Encoding;
    this.m_monitoringMode = monitoredItem.MonitoringMode;
    this.m_clientHandle = monitoredItem.ClientHandle;
    this.m_samplingInterval = (double) monitoredItem.SamplingInterval;
    this.m_queueSize = monitoredItem.QueueSize;
    this.m_discardOldest = monitoredItem.DiscardOldest;
    this.m_filter = (MonitoringFilter) null;
    this.m_filterResult = (MonitoringFilterResult) null;
    if (monitoredItem.Filter == null)
      return;
    this.m_filter = Utils.Clone((object) monitoredItem.Filter) as MonitoringFilter;
  }

  internal void SetModifyResult(
    MonitoredItemModifyRequest request,
    MonitoredItemModifyResult result,
    ServiceResult error)
  {
    if (request == null)
      throw new ArgumentNullException(nameof (request));
    if (result == null)
      throw new ArgumentNullException(nameof (result));
    this.m_error = error;
    if (!ServiceResult.IsGood(error))
      return;
    this.m_clientHandle = request.RequestedParameters.ClientHandle;
    this.m_samplingInterval = request.RequestedParameters.SamplingInterval;
    this.m_queueSize = request.RequestedParameters.QueueSize;
    this.m_discardOldest = request.RequestedParameters.DiscardOldest;
    this.m_filter = (MonitoringFilter) null;
    this.m_filterResult = (MonitoringFilterResult) null;
    if (request.RequestedParameters.Filter != null)
      this.m_filter = Utils.Clone(request.RequestedParameters.Filter.Body) as MonitoringFilter;
    this.m_samplingInterval = result.RevisedSamplingInterval;
    this.m_queueSize = result.RevisedQueueSize;
    if (result.FilterResult == null)
      return;
    this.m_filterResult = Utils.Clone(result.FilterResult.Body) as MonitoringFilterResult;
  }

  internal void SetDeleteResult(ServiceResult error)
  {
    this.m_id = 0U;
    this.m_error = error;
  }

  internal void SetError(ServiceResult error) => this.m_error = error;
}
