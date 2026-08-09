using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
	private const string ProgramDiagnostic_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAFByb2dyYW1EaWFnbm9zdGljAQBfCQAvAQAXPF8JAAABAOFd/////wEB/////wwAAAAVYIkKAgAAAAAADwAAAENyZWF0ZVNlc3Npb25JZAEAAA8ALwA/AA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENyZWF0ZUNsaWVudE5hbWUBAAEPAC8APwEPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABYAAABJbnZvY2F0aW9uQ3JlYXRpb25UaW1lAQACDwAvAD8CDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0VHJhbnNpdGlvblRpbWUBAAMPAC4ARAMPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RNZXRob2RDYWxsAQAEDwAvAD8EDwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAATGFzdE1ldGhvZFNlc3Npb25JZAEABQ8ALwA/BQ8AAAAR/////wEB/////wAAAAAXYIkKAgAAAAAAGAAAAExhc3RNZXRob2RJbnB1dEFyZ3VtZW50cwEABg8ALwA/Bg8AAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABkAAABMYXN0TWV0aG9kT3V0cHV0QXJndW1lbnRzAQAHDwAvAD8HDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAExhc3RNZXRob2RJbnB1dFZhbHVlcwEAvjoALwA/vjoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAATGFzdE1ldGhvZE91dHB1dFZhbHVlcwEAwDoALwA/wDoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdE1ldGhvZENhbGxUaW1lAQAIDwAvAD8IDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABMYXN0TWV0aG9kUmV0dXJuU3RhdHVzAQAJDwAvAD8JDwAAABP/////AQH/////AAAAAA==";

	private const string FinalResultData_InitializationString = "//////////8EYIAKAQAAAAAADwAAAEZpbmFsUmVzdWx0RGF0YQEACg8ALwA6Cg8AAP////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFByb2dyYW1TdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAFcJAQBXCVcJAAD/////BwAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQD2DgAvAQDICvYOAAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEA9w4ALgBE9w4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA+Q4ALgBE+Q4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQD7DgAvAQDPCvsOAAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEA/A4ALgBE/A4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA/g4ALgBE/g4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD/DgAuAET/DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAFkJAC4ARFkJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQBaCQAuAERaCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQBbCQAuAERbCQAAAAb/////AQH/////AAAAABVgiQoCAAAAAAARAAAAUHJvZ3JhbURpYWdub3N0aWMBAF8JAC8BABc8XwkAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAADwAvAD8ADwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAAQ8ALwA/AQ8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBAAIPAC8APwIPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAAw8ALgBEAw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBAAQPAC8APwQPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAFDwAvAD8FDwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAGDwAvAD8GDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAAcPAC8APwcPAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQC+OgAvAD++OgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQDAOgAvAD/AOgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBAAgPAC8APwgPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBAAkPAC8APwkPAAAAE/////8BAf////8AAAAABGCACgEAAAAAAA8AAABGaW5hbFJlc3VsdERhdGEBAAoPAC8AOgoPAAD/////AAAAAA==";

	private PropertyState<bool> m_deletable;

	private PropertyState<bool> m_autoDelete;

	private PropertyState<int> m_recycleCount;

	private ProgramDiagnostic2State m_programDiagnostic;

	private BaseObjectState m_finalResultData;

	private ElementInfo[] s_StateTable = new ElementInfo[4]
	{
		new ElementInfo(2400u, "Ready", 1u),
		new ElementInfo(2402u, "Running", 2u),
		new ElementInfo(2404u, "Suspended", 3u),
		new ElementInfo(2406u, "Halted", 4u)
	};

	private ElementInfo[] s_TransitionTable = new ElementInfo[9]
	{
		new ElementInfo(2408u, "HaltedToReady", 1u),
		new ElementInfo(2410u, "ReadyToRunning", 2u),
		new ElementInfo(2412u, "RunningToHalted", 3u),
		new ElementInfo(2414u, "RunningToReady", 4u),
		new ElementInfo(2416u, "RunningToSuspended", 5u),
		new ElementInfo(2418u, "SuspendedToRunning", 6u),
		new ElementInfo(2420u, "SuspendedToHalted", 7u),
		new ElementInfo(2422u, "SuspendedToReady", 8u),
		new ElementInfo(2424u, "ReadyToHalted", 9u)
	};

	private uint[,] s_TransitionMappings = new uint[9, 4]
	{
		{ 2408u, 2406u, 2400u, 1u },
		{ 2410u, 2400u, 2402u, 1u },
		{ 2412u, 2402u, 2406u, 1u },
		{ 2414u, 2402u, 2400u, 1u },
		{ 2416u, 2402u, 2404u, 1u },
		{ 2418u, 2404u, 2402u, 1u },
		{ 2420u, 2404u, 2406u, 1u },
		{ 2422u, 2404u, 2400u, 1u },
		{ 2424u, 2400u, 2406u, 1u }
	};

	private uint[,] s_CauseMappings = new uint[8, 3]
	{
		{ 2430u, 2406u, 2408u },
		{ 2426u, 2400u, 2410u },
		{ 2427u, 2402u, 2416u },
		{ 2430u, 2402u, 2414u },
		{ 2429u, 2402u, 2412u },
		{ 2428u, 2404u, 2418u },
		{ 2430u, 2404u, 2422u },
		{ 2429u, 2404u, 2420u }
	};

	public PropertyState<bool> Deletable
	{
		get
		{
			return m_deletable;
		}
		set
		{
			if (m_deletable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deletable = value;
		}
	}

	public PropertyState<bool> AutoDelete
	{
		get
		{
			return m_autoDelete;
		}
		set
		{
			if (m_autoDelete != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_autoDelete = value;
		}
	}

	public PropertyState<int> RecycleCount
	{
		get
		{
			return m_recycleCount;
		}
		set
		{
			if (m_recycleCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_recycleCount = value;
		}
	}

	public ProgramDiagnostic2State ProgramDiagnostic
	{
		get
		{
			return m_programDiagnostic;
		}
		set
		{
			if (m_programDiagnostic != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_programDiagnostic = value;
		}
	}

	public BaseObjectState FinalResultData
	{
		get
		{
			return m_finalResultData;
		}
		set
		{
			if (m_finalResultData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_finalResultData = value;
		}
	}

	protected override ElementInfo[] StateTable => s_StateTable;

	protected override ElementInfo[] TransitionTable => s_TransitionTable;

	protected override uint[,] TransitionMappings => s_TransitionMappings;

	protected override uint[,] CauseMappings => s_CauseMappings;

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2391u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFByb2dyYW1TdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAFcJAQBXCVcJAAD/////BwAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQD2DgAvAQDICvYOAAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEA9w4ALgBE9w4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA+Q4ALgBE+Q4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQD7DgAvAQDPCvsOAAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEA/A4ALgBE/A4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA/g4ALgBE/g4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD/DgAuAET/DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAFkJAC4ARFkJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQBaCQAuAERaCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQBbCQAuAERbCQAAAAb/////AQH/////AAAAABVgiQoCAAAAAAARAAAAUHJvZ3JhbURpYWdub3N0aWMBAF8JAC8BABc8XwkAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAADwAvAD8ADwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAAQ8ALwA/AQ8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBAAIPAC8APwIPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAAw8ALgBEAw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBAAQPAC8APwQPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAFDwAvAD8FDwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAGDwAvAD8GDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAAcPAC8APwcPAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQC+OgAvAD++OgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQDAOgAvAD/AOgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBAAgPAC8APwgPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBAAkPAC8APwkPAAAAE/////8BAf////8AAAAABGCACgEAAAAAAA8AAABGaW5hbFJlc3VsdERhdGEBAAoPAC8AOgoPAAD/////AAAAAA==");
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
		if (ProgramDiagnostic != null)
		{
			ProgramDiagnostic.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAFByb2dyYW1EaWFnbm9zdGljAQBfCQAvAQAXPF8JAAABAOFd/////wEB/////wwAAAAVYIkKAgAAAAAADwAAAENyZWF0ZVNlc3Npb25JZAEAAA8ALwA/AA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENyZWF0ZUNsaWVudE5hbWUBAAEPAC8APwEPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABYAAABJbnZvY2F0aW9uQ3JlYXRpb25UaW1lAQACDwAvAD8CDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0VHJhbnNpdGlvblRpbWUBAAMPAC4ARAMPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RNZXRob2RDYWxsAQAEDwAvAD8EDwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAATGFzdE1ldGhvZFNlc3Npb25JZAEABQ8ALwA/BQ8AAAAR/////wEB/////wAAAAAXYIkKAgAAAAAAGAAAAExhc3RNZXRob2RJbnB1dEFyZ3VtZW50cwEABg8ALwA/Bg8AAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABkAAABMYXN0TWV0aG9kT3V0cHV0QXJndW1lbnRzAQAHDwAvAD8HDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAExhc3RNZXRob2RJbnB1dFZhbHVlcwEAvjoALwA/vjoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAATGFzdE1ldGhvZE91dHB1dFZhbHVlcwEAwDoALwA/wDoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdE1ldGhvZENhbGxUaW1lAQAIDwAvAD8IDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABMYXN0TWV0aG9kUmV0dXJuU3RhdHVzAQAJDwAvAD8JDwAAABP/////AQH/////AAAAAA==");
		}
		if (FinalResultData != null)
		{
			FinalResultData.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAEZpbmFsUmVzdWx0RGF0YQEACg8ALwA6Cg8AAP////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_deletable != null)
		{
			children.Add(m_deletable);
		}
		if (m_autoDelete != null)
		{
			children.Add(m_autoDelete);
		}
		if (m_recycleCount != null)
		{
			children.Add(m_recycleCount);
		}
		if (m_programDiagnostic != null)
		{
			children.Add(m_programDiagnostic);
		}
		if (m_finalResultData != null)
		{
			children.Add(m_finalResultData);
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
		case "Deletable":
			if (createOrReplace && Deletable == null)
			{
				if (replacement == null)
				{
					Deletable = new PropertyState<bool>(this);
				}
				else
				{
					Deletable = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Deletable;
			break;
		case "AutoDelete":
			if (createOrReplace && AutoDelete == null)
			{
				if (replacement == null)
				{
					AutoDelete = new PropertyState<bool>(this);
				}
				else
				{
					AutoDelete = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = AutoDelete;
			break;
		case "RecycleCount":
			if (createOrReplace && RecycleCount == null)
			{
				if (replacement == null)
				{
					RecycleCount = new PropertyState<int>(this);
				}
				else
				{
					RecycleCount = (PropertyState<int>)replacement;
				}
			}
			baseInstanceState = RecycleCount;
			break;
		case "ProgramDiagnostic":
			if (createOrReplace && ProgramDiagnostic == null)
			{
				if (replacement == null)
				{
					ProgramDiagnostic = new ProgramDiagnostic2State(this);
				}
				else
				{
					ProgramDiagnostic = (ProgramDiagnostic2State)replacement;
				}
			}
			baseInstanceState = ProgramDiagnostic;
			break;
		case "FinalResultData":
			if (createOrReplace && FinalResultData == null)
			{
				if (replacement == null)
				{
					FinalResultData = new BaseObjectState(this);
				}
				else
				{
					FinalResultData = (BaseObjectState)replacement;
				}
			}
			baseInstanceState = FinalResultData;
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
		UpdateStateVariable(context, 2400u, base.CurrentState);
		UpdateTransitionVariable(context, 0u, base.LastTransition);
	}

	protected override AuditUpdateStateEventState CreateAuditEvent(ISystemContext context, MethodState causeMethod, uint causeId)
	{
		return new ProgramTransitionAuditEventState(null);
	}

	protected override void UpdateAuditEvent(ISystemContext context, MethodState causeMethod, IList<object> inputArguments, uint causeId, AuditUpdateStateEventState e, ServiceResult result)
	{
		base.UpdateAuditEvent(context, causeMethod, inputArguments, causeId, e, result);
		if (ServiceResult.IsGood(result) && e is ProgramTransitionAuditEventState programTransitionAuditEventState)
		{
			programTransitionAuditEventState.SetChildValue(context, "Transition", base.LastTransition, copy: false);
		}
	}

	protected override TransitionEventState CreateTransitionEvent(ISystemContext context, uint transitionId, uint causeId)
	{
		if (TransitionHasEffect(context, transitionId))
		{
			return new ProgramTransitionEventState(null);
		}
		return null;
	}

	protected ServiceResult IsStartExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2426u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected ServiceResult IsStartUserExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2426u, checkUserAccessRights: true);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnStart(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		return DoCause(context, method, 2426u, inputArguments, outputArguments);
	}

	protected ServiceResult IsSuspendExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2427u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected ServiceResult IsSuspendUserExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2427u, checkUserAccessRights: true);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnSuspend(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		return DoCause(context, method, 2427u, inputArguments, outputArguments);
	}

	protected ServiceResult IsResumeExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2428u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected ServiceResult IsResumeUserExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2428u, checkUserAccessRights: true);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnResume(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		return DoCause(context, method, 2428u, inputArguments, outputArguments);
	}

	protected ServiceResult IsHaltExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2429u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected ServiceResult IsHaltUserExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2429u, checkUserAccessRights: true);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnHalt(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		return DoCause(context, method, 2429u, inputArguments, outputArguments);
	}

	protected ServiceResult IsResetExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2430u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected ServiceResult IsResetUserExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = IsCausePermitted(context, 2430u, checkUserAccessRights: true);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnReset(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		return DoCause(context, method, 2430u, inputArguments, outputArguments);
	}
}
