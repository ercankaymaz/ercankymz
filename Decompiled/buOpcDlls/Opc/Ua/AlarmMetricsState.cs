using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AlarmMetricsState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAEFsYXJtTWV0cmljc1R5cGVJbnN0YW5jZQEAf0MBAH9Df0MAAP////8JAAAAFWCJCgIAAAAAAAoAAABBbGFybUNvdW50AQCAQwAvAD+AQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBHRgAvAD9HRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNYXhpbXVtQWN0aXZlU3RhdGUBAIFDAC8AP4FDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAE1heGltdW1VbkFjawEAgkMALwA/gkMAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3VycmVudEFsYXJtUmF0ZQEAhEMALwEAfUOEQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAhUMALgBEhUMAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heGltdW1BbGFybVJhdGUBAIZDAC8BAH1DhkMAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABAAAAFJhdGUBAIdDAC4ARIdDAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhpbXVtUmVBbGFybUNvdW50AQCDQwAvAD+DQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQXZlcmFnZUFsYXJtUmF0ZQEAiEMALwEAfUOIQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAiUMALgBEiUMAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQDqSAAvAQDqSOpIAAABAQEAAAABAPkLAAEATwgAAAAA";

	private BaseDataVariableState<uint> m_alarmCount;

	private BaseDataVariableState<DateTime> m_startTime;

	private BaseDataVariableState<double> m_maximumActiveState;

	private BaseDataVariableState<double> m_maximumUnAck;

	private AlarmRateVariableState m_currentAlarmRate;

	private AlarmRateVariableState m_maximumAlarmRate;

	private BaseDataVariableState<uint> m_maximumReAlarmCount;

	private AlarmRateVariableState m_averageAlarmRate;

	private MethodState m_resetMethod;

	public BaseDataVariableState<uint> AlarmCount
	{
		get
		{
			return m_alarmCount;
		}
		set
		{
			if (m_alarmCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_alarmCount = value;
		}
	}

	public BaseDataVariableState<DateTime> StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			if (m_startTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_startTime = value;
		}
	}

	public BaseDataVariableState<double> MaximumActiveState
	{
		get
		{
			return m_maximumActiveState;
		}
		set
		{
			if (m_maximumActiveState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maximumActiveState = value;
		}
	}

	public BaseDataVariableState<double> MaximumUnAck
	{
		get
		{
			return m_maximumUnAck;
		}
		set
		{
			if (m_maximumUnAck != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maximumUnAck = value;
		}
	}

	public AlarmRateVariableState CurrentAlarmRate
	{
		get
		{
			return m_currentAlarmRate;
		}
		set
		{
			if (m_currentAlarmRate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentAlarmRate = value;
		}
	}

	public AlarmRateVariableState MaximumAlarmRate
	{
		get
		{
			return m_maximumAlarmRate;
		}
		set
		{
			if (m_maximumAlarmRate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maximumAlarmRate = value;
		}
	}

	public BaseDataVariableState<uint> MaximumReAlarmCount
	{
		get
		{
			return m_maximumReAlarmCount;
		}
		set
		{
			if (m_maximumReAlarmCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maximumReAlarmCount = value;
		}
	}

	public AlarmRateVariableState AverageAlarmRate
	{
		get
		{
			return m_averageAlarmRate;
		}
		set
		{
			if (m_averageAlarmRate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_averageAlarmRate = value;
		}
	}

	public MethodState Reset
	{
		get
		{
			return m_resetMethod;
		}
		set
		{
			if (m_resetMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resetMethod = value;
		}
	}

	public AlarmMetricsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17279u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGAAAAEFsYXJtTWV0cmljc1R5cGVJbnN0YW5jZQEAf0MBAH9Df0MAAP////8JAAAAFWCJCgIAAAAAAAoAAABBbGFybUNvdW50AQCAQwAvAD+AQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBHRgAvAD9HRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNYXhpbXVtQWN0aXZlU3RhdGUBAIFDAC8AP4FDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAE1heGltdW1VbkFjawEAgkMALwA/gkMAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3VycmVudEFsYXJtUmF0ZQEAhEMALwEAfUOEQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAhUMALgBEhUMAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heGltdW1BbGFybVJhdGUBAIZDAC8BAH1DhkMAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABAAAAFJhdGUBAIdDAC4ARIdDAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhpbXVtUmVBbGFybUNvdW50AQCDQwAvAD+DQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQXZlcmFnZUFsYXJtUmF0ZQEAiEMALwEAfUOIQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAiUMALgBEiUMAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQDqSAAvAQDqSOpIAAABAQEAAAABAPkLAAEATwgAAAAA");
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
		if (m_alarmCount != null)
		{
			children.Add(m_alarmCount);
		}
		if (m_startTime != null)
		{
			children.Add(m_startTime);
		}
		if (m_maximumActiveState != null)
		{
			children.Add(m_maximumActiveState);
		}
		if (m_maximumUnAck != null)
		{
			children.Add(m_maximumUnAck);
		}
		if (m_currentAlarmRate != null)
		{
			children.Add(m_currentAlarmRate);
		}
		if (m_maximumAlarmRate != null)
		{
			children.Add(m_maximumAlarmRate);
		}
		if (m_maximumReAlarmCount != null)
		{
			children.Add(m_maximumReAlarmCount);
		}
		if (m_averageAlarmRate != null)
		{
			children.Add(m_averageAlarmRate);
		}
		if (m_resetMethod != null)
		{
			children.Add(m_resetMethod);
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
		case "AlarmCount":
			if (createOrReplace && AlarmCount == null)
			{
				if (replacement == null)
				{
					AlarmCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					AlarmCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = AlarmCount;
			break;
		case "StartTime":
			if (createOrReplace && StartTime == null)
			{
				if (replacement == null)
				{
					StartTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					StartTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = StartTime;
			break;
		case "MaximumActiveState":
			if (createOrReplace && MaximumActiveState == null)
			{
				if (replacement == null)
				{
					MaximumActiveState = new BaseDataVariableState<double>(this);
				}
				else
				{
					MaximumActiveState = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = MaximumActiveState;
			break;
		case "MaximumUnAck":
			if (createOrReplace && MaximumUnAck == null)
			{
				if (replacement == null)
				{
					MaximumUnAck = new BaseDataVariableState<double>(this);
				}
				else
				{
					MaximumUnAck = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = MaximumUnAck;
			break;
		case "CurrentAlarmRate":
			if (createOrReplace && CurrentAlarmRate == null)
			{
				if (replacement == null)
				{
					CurrentAlarmRate = new AlarmRateVariableState(this);
				}
				else
				{
					CurrentAlarmRate = (AlarmRateVariableState)replacement;
				}
			}
			baseInstanceState = CurrentAlarmRate;
			break;
		case "MaximumAlarmRate":
			if (createOrReplace && MaximumAlarmRate == null)
			{
				if (replacement == null)
				{
					MaximumAlarmRate = new AlarmRateVariableState(this);
				}
				else
				{
					MaximumAlarmRate = (AlarmRateVariableState)replacement;
				}
			}
			baseInstanceState = MaximumAlarmRate;
			break;
		case "MaximumReAlarmCount":
			if (createOrReplace && MaximumReAlarmCount == null)
			{
				if (replacement == null)
				{
					MaximumReAlarmCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaximumReAlarmCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaximumReAlarmCount;
			break;
		case "AverageAlarmRate":
			if (createOrReplace && AverageAlarmRate == null)
			{
				if (replacement == null)
				{
					AverageAlarmRate = new AlarmRateVariableState(this);
				}
				else
				{
					AverageAlarmRate = (AlarmRateVariableState)replacement;
				}
			}
			baseInstanceState = AverageAlarmRate;
			break;
		case "Reset":
			if (createOrReplace && Reset == null)
			{
				if (replacement == null)
				{
					Reset = new MethodState(this);
				}
				else
				{
					Reset = (MethodState)replacement;
				}
			}
			baseInstanceState = Reset;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
