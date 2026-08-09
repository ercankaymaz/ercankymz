using System;
using System.Runtime.InteropServices;

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

	public uint Id
	{
		get
		{
			return m_id;
		}
		set
		{
			m_id = value;
		}
	}

	public bool Created => m_id != 0;

	public ServiceResult Error => m_error;

	public NodeId NodeId => m_nodeId;

	public uint AttributeId => m_attributeId;

	public string IndexRange => m_indexRange;

	public QualifiedName DataEncoding => m_encoding;

	public MonitoringMode MonitoringMode => m_monitoringMode;

	public uint ClientHandle => m_clientHandle;

	public double SamplingInterval => m_samplingInterval;

	public MonitoringFilter Filter => m_filter;

	public MonitoringFilterResult FilterResult => m_filterResult;

	public uint QueueSize => m_queueSize;

	public bool DiscardOldest => m_discardOldest;

	internal MonitoredItemStatus()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_id = 0u;
		m_nodeId = null;
		m_attributeId = 13u;
		m_indexRange = null;
		m_encoding = null;
		m_monitoringMode = MonitoringMode.Disabled;
		m_clientHandle = 0u;
		m_samplingInterval = 0.0;
		m_filter = null;
		m_filterResult = null;
		m_queueSize = 0u;
		m_discardOldest = true;
	}

	public void SetMonitoringMode(MonitoringMode monitoringMode)
	{
		m_monitoringMode = monitoringMode;
	}

	internal void SetResolvePathResult(BrowsePathResult result, ServiceResult error)
	{
		m_error = error;
	}

	internal void SetCreateResult(MonitoredItemCreateRequest request, MonitoredItemCreateResult result, ServiceResult error)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (result == null)
		{
			throw new ArgumentNullException("result");
		}
		m_nodeId = request.ItemToMonitor.NodeId;
		m_attributeId = request.ItemToMonitor.AttributeId;
		m_indexRange = request.ItemToMonitor.IndexRange;
		m_encoding = request.ItemToMonitor.DataEncoding;
		m_monitoringMode = request.MonitoringMode;
		m_clientHandle = request.RequestedParameters.ClientHandle;
		m_samplingInterval = request.RequestedParameters.SamplingInterval;
		m_queueSize = request.RequestedParameters.QueueSize;
		m_discardOldest = request.RequestedParameters.DiscardOldest;
		m_filter = null;
		m_filterResult = null;
		m_error = error;
		if (request.RequestedParameters.Filter != null)
		{
			m_filter = Utils.Clone(request.RequestedParameters.Filter.Body) as MonitoringFilter;
		}
		if (ServiceResult.IsGood(error))
		{
			m_id = result.MonitoredItemId;
			m_samplingInterval = result.RevisedSamplingInterval;
			m_queueSize = result.RevisedQueueSize;
			if (result.FilterResult != null)
			{
				m_filterResult = Utils.Clone(result.FilterResult.Body) as MonitoringFilterResult;
			}
		}
	}

	internal void SetTransferResult(MonitoredItem monitoredItem)
	{
		if (monitoredItem == null)
		{
			throw new ArgumentNullException("monitoredItem");
		}
		m_nodeId = monitoredItem.ResolvedNodeId;
		m_attributeId = monitoredItem.AttributeId;
		m_indexRange = monitoredItem.IndexRange;
		m_encoding = monitoredItem.Encoding;
		m_monitoringMode = monitoredItem.MonitoringMode;
		m_clientHandle = monitoredItem.ClientHandle;
		m_samplingInterval = monitoredItem.SamplingInterval;
		m_queueSize = monitoredItem.QueueSize;
		m_discardOldest = monitoredItem.DiscardOldest;
		m_filter = null;
		m_filterResult = null;
		if (monitoredItem.Filter != null)
		{
			m_filter = Utils.Clone(monitoredItem.Filter) as MonitoringFilter;
		}
	}

	internal void SetModifyResult(MonitoredItemModifyRequest request, MonitoredItemModifyResult result, ServiceResult error)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (result == null)
		{
			throw new ArgumentNullException("result");
		}
		m_error = error;
		if (ServiceResult.IsGood(error))
		{
			m_clientHandle = request.RequestedParameters.ClientHandle;
			m_samplingInterval = request.RequestedParameters.SamplingInterval;
			m_queueSize = request.RequestedParameters.QueueSize;
			m_discardOldest = request.RequestedParameters.DiscardOldest;
			m_filter = null;
			m_filterResult = null;
			if (request.RequestedParameters.Filter != null)
			{
				m_filter = Utils.Clone(request.RequestedParameters.Filter.Body) as MonitoringFilter;
			}
			m_samplingInterval = result.RevisedSamplingInterval;
			m_queueSize = result.RevisedQueueSize;
			if (result.FilterResult != null)
			{
				m_filterResult = Utils.Clone(result.FilterResult.Body) as MonitoringFilterResult;
			}
		}
	}

	internal void SetDeleteResult(ServiceResult error)
	{
		m_id = 0u;
		m_error = error;
	}

	internal void SetError(ServiceResult error)
	{
		m_error = error;
	}
}
