using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ShelvedStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNoZWx2ZWRTdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAHELAQBxC3ELAAD/////BQAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDIFwAvAQDICsgXAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyRcALgBEyRcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEAmyMALgBEmyMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAIULAC8BAIULhQsAAAEBAwAAAAA1AQEAdwsANQEBAIELAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAK8LAC4ARK8LAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQCDCwAvAQCDC4MLAAABAQMAAAAANQEBAHwLADUBAQB/CwEA+QsAAQBVKwAAAAAEYYIKBAAAAAAADQAAAE9uZVNob3RTaGVsdmUBAIQLAC8BAIQLhAsAAAEBAwAAAAA1AQEAeAsANQEBAH4LAQD5CwABAFUrAAAAAA==";

	private PropertyState<double> m_unshelveTime;

	private TimedShelveMethodState m_timedShelveMethod;

	private MethodState m_unshelveMethod;

	private MethodState m_oneShotShelveMethod;

	private ElementInfo[] s_StateTable = new ElementInfo[3]
	{
		new ElementInfo(2933u, "OneShotShelve", 1u),
		new ElementInfo(2932u, "TimedShelved", 2u),
		new ElementInfo(2930u, "Unshelved", 3u)
	};

	private ElementInfo[] s_TransitionTable = new ElementInfo[6]
	{
		new ElementInfo(2945u, "OneShotShelvedToTimedShelved", 1u),
		new ElementInfo(2943u, "OneShotShelvedToUnshelved", 2u),
		new ElementInfo(2942u, "TimedShelvedToOneShotShelved", 3u),
		new ElementInfo(2940u, "TimedShelvedToUnshelved", 4u),
		new ElementInfo(2936u, "UnshelvedToOneShotShelved", 5u),
		new ElementInfo(2935u, "UnshelvedToTimedShelved", 6u)
	};

	private uint[,] s_TransitionMappings = new uint[6, 4]
	{
		{ 2945u, 2933u, 2932u, 0u },
		{ 2943u, 2933u, 2930u, 1u },
		{ 2942u, 2932u, 2933u, 0u },
		{ 2940u, 2932u, 2930u, 1u },
		{ 2936u, 2930u, 2933u, 1u },
		{ 2935u, 2930u, 2932u, 1u }
	};

	private uint[,] s_CauseMappings = new uint[6, 3]
	{
		{ 2949u, 2933u, 2945u },
		{ 2947u, 2933u, 2943u },
		{ 2948u, 2932u, 2942u },
		{ 2947u, 2932u, 2940u },
		{ 2948u, 2930u, 2936u },
		{ 2949u, 2930u, 2935u }
	};

	public PropertyState<double> UnshelveTime
	{
		get
		{
			return m_unshelveTime;
		}
		set
		{
			if (m_unshelveTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unshelveTime = value;
		}
	}

	public TimedShelveMethodState TimedShelve
	{
		get
		{
			return m_timedShelveMethod;
		}
		set
		{
			if (m_timedShelveMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_timedShelveMethod = value;
		}
	}

	public MethodState Unshelve
	{
		get
		{
			return m_unshelveMethod;
		}
		set
		{
			if (m_unshelveMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unshelveMethod = value;
		}
	}

	public MethodState OneShotShelve
	{
		get
		{
			return m_oneShotShelveMethod;
		}
		set
		{
			if (m_oneShotShelveMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_oneShotShelveMethod = value;
		}
	}

	protected override ElementInfo[] StateTable => s_StateTable;

	protected override ElementInfo[] TransitionTable => s_TransitionTable;

	protected override uint[,] TransitionMappings => s_TransitionMappings;

	protected override uint[,] CauseMappings => s_CauseMappings;

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2929u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNoZWx2ZWRTdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAHELAQBxC3ELAAD/////BQAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDIFwAvAQDICsgXAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyRcALgBEyRcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEAmyMALgBEmyMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAIULAC8BAIULhQsAAAEBAwAAAAA1AQEAdwsANQEBAIELAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAK8LAC4ARK8LAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQCDCwAvAQCDC4MLAAABAQMAAAAANQEBAHwLADUBAQB/CwEA+QsAAQBVKwAAAAAEYYIKBAAAAAAADQAAAE9uZVNob3RTaGVsdmUBAIQLAC8BAIQLhAsAAAEBAwAAAAA1AQEAeAsANQEBAH4LAQD5CwABAFUrAAAAAA==");
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
		if (m_unshelveTime != null)
		{
			children.Add(m_unshelveTime);
		}
		if (m_timedShelveMethod != null)
		{
			children.Add(m_timedShelveMethod);
		}
		if (m_unshelveMethod != null)
		{
			children.Add(m_unshelveMethod);
		}
		if (m_oneShotShelveMethod != null)
		{
			children.Add(m_oneShotShelveMethod);
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
		case "UnshelveTime":
			if (createOrReplace && UnshelveTime == null)
			{
				if (replacement == null)
				{
					UnshelveTime = new PropertyState<double>(this);
				}
				else
				{
					UnshelveTime = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = UnshelveTime;
			break;
		case "TimedShelve":
			if (createOrReplace && TimedShelve == null)
			{
				if (replacement == null)
				{
					TimedShelve = new TimedShelveMethodState(this);
				}
				else
				{
					TimedShelve = (TimedShelveMethodState)replacement;
				}
			}
			baseInstanceState = TimedShelve;
			break;
		case "Unshelve":
			if (createOrReplace && Unshelve == null)
			{
				if (replacement == null)
				{
					Unshelve = new MethodState(this);
				}
				else
				{
					Unshelve = (MethodState)replacement;
				}
			}
			baseInstanceState = Unshelve;
			break;
		case "OneShotShelve":
			if (createOrReplace && OneShotShelve == null)
			{
				if (replacement == null)
				{
					OneShotShelve = new MethodState(this);
				}
				else
				{
					OneShotShelve = (MethodState)replacement;
				}
			}
			baseInstanceState = OneShotShelve;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	protected override void OnAfterCreate(ISystemContext context, NodeState node)
	{
		base.OnAfterCreate(context, node);
		UpdateStateVariable(context, 2930u, base.CurrentState);
		UpdateTransitionVariable(context, 0u, base.LastTransition);
	}
}
