using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SamplingIntervalDiagnosticsState : BaseDataVariableState<SamplingIntervalDiagnosticsDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAJwAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc1R5cGVJbnN0YW5jZQEAdQgBAHUIdQgAAAEAWAP/////AQH/////BAAAABVgiQoCAAAAAAAQAAAAU2FtcGxpbmdJbnRlcnZhbAEAdggALwA/dggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAU2FtcGxlZE1vbml0b3JlZEl0ZW1zQ291bnQBALEtAC8AP7EtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABNYXhTYW1wbGVkTW9uaXRvcmVkSXRlbXNDb3VudAEAsi0ALwA/si0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAIwAAAERpc2FibGVkTW9uaXRvcmVkSXRlbXNTYW1wbGluZ0NvdW50AQCzLQAvAD+zLQAAAAf/////AQH/////AAAAAA==";

	private BaseDataVariableState<double> m_samplingInterval;

	private BaseDataVariableState<uint> m_sampledMonitoredItemsCount;

	private BaseDataVariableState<uint> m_maxSampledMonitoredItemsCount;

	private BaseDataVariableState<uint> m_disabledMonitoredItemsSamplingCount;

	public BaseDataVariableState<double> SamplingInterval
	{
		get
		{
			return m_samplingInterval;
		}
		set
		{
			if (m_samplingInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_samplingInterval = value;
		}
	}

	public BaseDataVariableState<uint> SampledMonitoredItemsCount
	{
		get
		{
			return m_sampledMonitoredItemsCount;
		}
		set
		{
			if (m_sampledMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sampledMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<uint> MaxSampledMonitoredItemsCount
	{
		get
		{
			return m_maxSampledMonitoredItemsCount;
		}
		set
		{
			if (m_maxSampledMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxSampledMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<uint> DisabledMonitoredItemsSamplingCount
	{
		get
		{
			return m_disabledMonitoredItemsSamplingCount;
		}
		set
		{
			if (m_disabledMonitoredItemsSamplingCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_disabledMonitoredItemsSamplingCount = value;
		}
	}

	public SamplingIntervalDiagnosticsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2165u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(856u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJwAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc1R5cGVJbnN0YW5jZQEAdQgBAHUIdQgAAAEAWAP/////AQH/////BAAAABVgiQoCAAAAAAAQAAAAU2FtcGxpbmdJbnRlcnZhbAEAdggALwA/dggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAU2FtcGxlZE1vbml0b3JlZEl0ZW1zQ291bnQBALEtAC8AP7EtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABNYXhTYW1wbGVkTW9uaXRvcmVkSXRlbXNDb3VudAEAsi0ALwA/si0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAIwAAAERpc2FibGVkTW9uaXRvcmVkSXRlbXNTYW1wbGluZ0NvdW50AQCzLQAvAD+zLQAAAAf/////AQH/////AAAAAA==");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_samplingInterval != null)
		{
			children.Add(m_samplingInterval);
		}
		if (m_sampledMonitoredItemsCount != null)
		{
			children.Add(m_sampledMonitoredItemsCount);
		}
		if (m_maxSampledMonitoredItemsCount != null)
		{
			children.Add(m_maxSampledMonitoredItemsCount);
		}
		if (m_disabledMonitoredItemsSamplingCount != null)
		{
			children.Add(m_disabledMonitoredItemsSamplingCount);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "SamplingInterval":
			if (createOrReplace && SamplingInterval == null)
			{
				if (replacement == null)
				{
					SamplingInterval = new BaseDataVariableState<double>(this);
				}
				else
				{
					SamplingInterval = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = SamplingInterval;
			break;
		case "SampledMonitoredItemsCount":
			if (createOrReplace && SampledMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					SampledMonitoredItemsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SampledMonitoredItemsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SampledMonitoredItemsCount;
			break;
		case "MaxSampledMonitoredItemsCount":
			if (createOrReplace && MaxSampledMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					MaxSampledMonitoredItemsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxSampledMonitoredItemsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxSampledMonitoredItemsCount;
			break;
		case "DisabledMonitoredItemsSamplingCount":
			if (createOrReplace && DisabledMonitoredItemsSamplingCount == null)
			{
				if (replacement == null)
				{
					DisabledMonitoredItemsSamplingCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					DisabledMonitoredItemsSamplingCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = DisabledMonitoredItemsSamplingCount;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
