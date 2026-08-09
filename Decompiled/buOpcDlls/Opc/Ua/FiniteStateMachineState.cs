using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FiniteStateMachineState : StateMachineState
{
	protected sealed class ElementInfo
	{
		private uint m_id;

		private string m_name;

		private uint m_number;

		public uint Id => m_id;

		public string Name => m_name;

		public uint Number => m_number;

		public ElementInfo(uint id, string name, uint number)
		{
			m_id = id;
			m_name = name;
			m_number = number;
		}
	}

	private const string LastTransition_InitializationString = "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDVCgAvAQDPCtUKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAlA4ALgBElA4AAAAR/////wEB/////wAAAAA=";

	private const string AvailableStates_InitializationString = "//////////8XYIkKAgAAAAAADwAAAEF2YWlsYWJsZVN0YXRlcwEA40QALwA/40QAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string AvailableTransitions_InitializationString = "//////////8XYIkKAgAAAAAAFAAAAEF2YWlsYWJsZVRyYW5zaXRpb25zAQDkRAAvAD/kRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEZpbml0ZVN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA0woBANMK0woAAP////8EAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANQKAC8BAMgK1AoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCQDgAuAESQDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANUKAC8BAM8K1QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCUDgAuAESUDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAQXZhaWxhYmxlU3RhdGVzAQDjRAAvAD/jRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABBdmFpbGFibGVUcmFuc2l0aW9ucwEA5EQALwA/5EQAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private BaseDataVariableState<NodeId[]> m_availableStates;

	private BaseDataVariableState<NodeId[]> m_availableTransitions;

	public StateMachineTransitionHandler OnCheckUserPermission;

	public StateMachineTransitionHandler OnBeforeTransition;

	public StateMachineTransitionHandler OnAfterTransition;

	private ushort m_elementNamespaceIndex;

	private FiniteStateVariableState m_lastState;

	private uint m_causeId;

	private bool m_suppressTransitionEvents;

	public new FiniteStateVariableState CurrentState
	{
		get
		{
			return (FiniteStateVariableState)base.CurrentState;
		}
		set
		{
			base.CurrentState = value;
		}
	}

	public new FiniteTransitionVariableState LastTransition
	{
		get
		{
			return (FiniteTransitionVariableState)base.LastTransition;
		}
		set
		{
			base.LastTransition = value;
		}
	}

	public BaseDataVariableState<NodeId[]> AvailableStates
	{
		get
		{
			return m_availableStates;
		}
		set
		{
			if (m_availableStates != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_availableStates = value;
		}
	}

	public BaseDataVariableState<NodeId[]> AvailableTransitions
	{
		get
		{
			return m_availableTransitions;
		}
		set
		{
			if (m_availableTransitions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_availableTransitions = value;
		}
	}

	protected ushort ElementNamespaceIndex
	{
		get
		{
			return m_elementNamespaceIndex;
		}
		set
		{
			m_elementNamespaceIndex = value;
		}
	}

	protected virtual string ElementNamespaceUri => "http://opcfoundation.org/UA/";

	protected virtual ElementInfo[] StateTable => null;

	protected virtual ElementInfo[] TransitionTable => null;

	protected virtual uint[,] TransitionMappings => null;

	protected virtual uint[,] CauseMappings => null;

	protected FiniteStateVariableState LastState
	{
		get
		{
			return m_lastState;
		}
		set
		{
			m_lastState = value;
		}
	}

	public bool SuppressTransitionEvents
	{
		get
		{
			return m_suppressTransitionEvents;
		}
		set
		{
			m_suppressTransitionEvents = value;
		}
	}

	public FiniteStateMachineState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2771u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEZpbml0ZVN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA0woBANMK0woAAP////8EAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANQKAC8BAMgK1AoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCQDgAuAESQDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANUKAC8BAM8K1QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCUDgAuAESUDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAQXZhaWxhYmxlU3RhdGVzAQDjRAAvAD/jRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABBdmFpbGFibGVUcmFuc2l0aW9ucwEA5EQALwA/5EQAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (LastTransition != null)
		{
			LastTransition.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDVCgAvAQDPCtUKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAlA4ALgBElA4AAAAR/////wEB/////wAAAAA=");
		}
		if (AvailableStates != null)
		{
			AvailableStates.Initialize(context, "//////////8XYIkKAgAAAAAADwAAAEF2YWlsYWJsZVN0YXRlcwEA40QALwA/40QAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (AvailableTransitions != null)
		{
			AvailableTransitions.Initialize(context, "//////////8XYIkKAgAAAAAAFAAAAEF2YWlsYWJsZVRyYW5zaXRpb25zAQDkRAAvAD/kRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_availableStates != null)
		{
			children.Add(m_availableStates);
		}
		if (m_availableTransitions != null)
		{
			children.Add(m_availableTransitions);
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
		case "CurrentState":
			if (createOrReplace && CurrentState == null)
			{
				if (replacement == null)
				{
					CurrentState = new FiniteStateVariableState(this);
				}
				else
				{
					CurrentState = (FiniteStateVariableState)replacement;
				}
			}
			baseInstanceState = CurrentState;
			break;
		case "LastTransition":
			if (createOrReplace && LastTransition == null)
			{
				if (replacement == null)
				{
					LastTransition = new FiniteTransitionVariableState(this);
				}
				else
				{
					LastTransition = (FiniteTransitionVariableState)replacement;
				}
			}
			baseInstanceState = LastTransition;
			break;
		case "AvailableStates":
			if (createOrReplace && AvailableStates == null)
			{
				if (replacement == null)
				{
					AvailableStates = new BaseDataVariableState<NodeId[]>(this);
				}
				else
				{
					AvailableStates = (BaseDataVariableState<NodeId[]>)replacement;
				}
			}
			baseInstanceState = AvailableStates;
			break;
		case "AvailableTransitions":
			if (createOrReplace && AvailableTransitions == null)
			{
				if (replacement == null)
				{
					AvailableTransitions = new BaseDataVariableState<NodeId[]>(this);
				}
				else
				{
					AvailableTransitions = (BaseDataVariableState<NodeId[]>)replacement;
				}
			}
			baseInstanceState = AvailableTransitions;
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
		int index = context.NamespaceUris.GetIndex(ElementNamespaceUri);
		if (index >= 0)
		{
			ElementNamespaceIndex = (ushort)index;
		}
	}

	protected uint GetCurrentStateId()
	{
		if (CurrentState == null || CurrentState.Id == null || CurrentState.Value == null)
		{
			return 0u;
		}
		NodeId value = CurrentState.Id.Value;
		if (ElementNamespaceIndex != value.NamespaceIndex || value.IdType != IdType.Numeric)
		{
			return 0u;
		}
		return (uint)value.Identifier;
	}

	protected virtual uint GetNewStateForTransition(ISystemContext context, uint transitionId)
	{
		uint currentStateId = GetCurrentStateId();
		if (currentStateId == 0)
		{
			return 0u;
		}
		uint[,] transitionMappings = TransitionMappings;
		if (transitionMappings == null)
		{
			return 0u;
		}
		int length = transitionMappings.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (transitionMappings[i, 0] == transitionId && transitionMappings[i, 1] == currentStateId)
			{
				return transitionMappings[i, 2];
			}
		}
		return 0u;
	}

	protected virtual bool TransitionHasEffect(ISystemContext context, uint transitionId)
	{
		uint[,] transitionMappings = TransitionMappings;
		if (transitionMappings == null)
		{
			return false;
		}
		int length = transitionMappings.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (transitionMappings[i, 0] == transitionId)
			{
				return transitionMappings[i, 3] != 0;
			}
		}
		return false;
	}

	protected virtual uint GetTransitionForCause(ISystemContext context, uint causeId)
	{
		uint currentStateId = GetCurrentStateId();
		if (currentStateId == 0)
		{
			return 0u;
		}
		uint[,] causeMappings = CauseMappings;
		if (causeMappings == null)
		{
			return 0u;
		}
		int length = causeMappings.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (causeMappings[i, 0] == causeId && causeMappings[i, 1] == currentStateId)
			{
				return causeMappings[i, 2];
			}
		}
		return 0u;
	}

	protected virtual uint GetTransitionToState(ISystemContext context, uint targetStateId)
	{
		uint currentStateId = GetCurrentStateId();
		if (currentStateId == 0)
		{
			return 0u;
		}
		uint[,] transitionMappings = TransitionMappings;
		if (transitionMappings == null)
		{
			return 0u;
		}
		int length = transitionMappings.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (transitionMappings[i, 1] == currentStateId && transitionMappings[i, 2] == targetStateId)
			{
				return transitionMappings[i, 0];
			}
		}
		return 0u;
	}

	protected void UpdateStateVariable(ISystemContext context, uint stateId, FiniteStateVariableState variable)
	{
		if (variable == null)
		{
			return;
		}
		if (stateId == 0)
		{
			variable.Value = null;
			variable.Id.Value = null;
			if (variable.Number != null)
			{
				variable.Number.Value = 0u;
			}
			return;
		}
		ElementInfo[] stateTable = StateTable;
		if (stateTable == null)
		{
			return;
		}
		foreach (ElementInfo elementInfo in stateTable)
		{
			if (elementInfo.Id == stateId)
			{
				variable.Value = elementInfo.Name;
				variable.Id.Value = new NodeId(elementInfo.Id, ElementNamespaceIndex);
				if (variable.Number != null)
				{
					variable.Number.Value = elementInfo.Number;
				}
				break;
			}
		}
	}

	protected void UpdateTransitionVariable(ISystemContext context, uint transitionId, FiniteTransitionVariableState variable)
	{
		if (variable == null)
		{
			return;
		}
		if (transitionId == 0)
		{
			variable.Value = null;
			variable.Id.Value = null;
			if (variable.TransitionTime != null)
			{
				variable.TransitionTime.Value = DateTime.MinValue;
			}
			if (variable.Number != null)
			{
				variable.Number.Value = 0u;
			}
			return;
		}
		ElementInfo[] transitionTable = TransitionTable;
		if (transitionTable == null)
		{
			return;
		}
		foreach (ElementInfo elementInfo in transitionTable)
		{
			if (elementInfo.Id == transitionId)
			{
				variable.Value = elementInfo.Name;
				variable.Id.Value = new NodeId(elementInfo.Id, ElementNamespaceIndex);
				if (variable.TransitionTime != null)
				{
					variable.TransitionTime.Value = DateTime.UtcNow;
				}
				if (variable.Number != null)
				{
					variable.Number.Value = elementInfo.Number;
				}
				break;
			}
		}
	}

	protected ServiceResult InvokeCallback(StateMachineTransitionHandler callback, ISystemContext context, StateMachineState machine, uint transitionId, uint causeId, IList<object> inputArguments, IList<object> outputArguments)
	{
		if (callback != null)
		{
			try
			{
				return callback(context, this, transitionId, causeId, inputArguments, outputArguments);
			}
			catch (Exception exception)
			{
				return new ServiceResult(exception);
			}
		}
		return ServiceResult.Good;
	}

	public virtual bool IsCausePermitted(ISystemContext context, uint causeId, bool checkUserAccessRights)
	{
		uint transitionForCause = GetTransitionForCause(context, causeId);
		if (transitionForCause == 0)
		{
			return false;
		}
		if (checkUserAccessRights && ServiceResult.IsBad(InvokeCallback(OnCheckUserPermission, context, this, transitionForCause, causeId, null, null)))
		{
			return false;
		}
		return true;
	}

	public virtual void SetState(ISystemContext context, uint newState)
	{
		uint transitionToState = GetTransitionToState(context, newState);
		UpdateStateVariable(context, newState, CurrentState);
		UpdateTransitionVariable(context, transitionToState, LastTransition);
	}

	public virtual ServiceResult DoCause(ISystemContext context, MethodState causeMethod, uint causeId, IList<object> inputArguments, IList<object> outputArguments)
	{
		ServiceResult serviceResult = null;
		try
		{
			uint transitionForCause = GetTransitionForCause(context, causeId);
			if (transitionForCause == 0)
			{
				return 2151481344u;
			}
			serviceResult = InvokeCallback(OnCheckUserPermission, context, this, transitionForCause, causeId, inputArguments, outputArguments);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
			serviceResult = DoTransition(context, transitionForCause, causeId, inputArguments, outputArguments);
			if (ServiceResult.IsBad(serviceResult))
			{
				return serviceResult;
			}
			ClearChangeMasks(context, includeChildren: true);
		}
		finally
		{
			if (base.AreEventsMonitored)
			{
				AuditUpdateStateEventState e = CreateAuditEvent(context, causeMethod, causeId);
				UpdateAuditEvent(context, causeMethod, inputArguments, causeId, e, serviceResult);
				ReportEvent(context, e);
				if (m_causeId != causeId)
				{
					ReportAuditProgramTransitionEvent(context, causeMethod, causeId, inputArguments, serviceResult);
					m_causeId = causeId;
				}
			}
		}
		return serviceResult;
	}

	protected virtual AuditUpdateStateEventState CreateAuditEvent(ISystemContext context, MethodState causeMethod, uint causeId)
	{
		return new AuditUpdateStateEventState(null);
	}

	protected virtual void UpdateAuditEvent(ISystemContext context, MethodState causeMethod, IList<object> inputArguments, uint causeId, AuditUpdateStateEventState e, ServiceResult result)
	{
		TranslationInfo translationInfo = new TranslationInfo("StateTransition", "en-US", "The {0} method called was on the {1} state machine.", causeMethod.DisplayName, GetDisplayPath(3, '.'));
		e.Initialize(context, this, EventSeverity.Medium, new LocalizedText(translationInfo), ServiceResult.IsGood(result), DateTime.UtcNow);
		e.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
		e.SetChildValue(context, "SourceName", "Method/" + causeMethod.BrowseName.Name, copy: false);
		e.SetChildValue(context, "LocalTime", Utils.GetTimeZoneInfo(), copy: false);
		e.SetChildValue(context, "MethodId", causeMethod.NodeId, copy: false);
		e.SetChildValue(context, "InputArguments", inputArguments, copy: false);
		e.SetChildValue(context, "OldStateId", LastState, copy: false);
		e.SetChildValue(context, "NewStateId", CurrentState, copy: false);
	}

	protected virtual void ReportAuditProgramTransitionEvent(ISystemContext context, MethodState causeMethod, uint causeId, IList<object> inputArguments, ServiceResult result)
	{
		try
		{
			AuditProgramTransitionEventState auditProgramTransitionEventState = new AuditProgramTransitionEventState(null);
			UpdateAuditEvent(context, causeMethod, inputArguments, causeId, auditProgramTransitionEventState, result);
			auditProgramTransitionEventState.SetChildValue(context, "TransitionNumber", LastTransition.Number.Value, copy: false);
			ReportEvent(context, auditProgramTransitionEventState);
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Error while reporting AuditProgramTransitionEvent event.");
		}
	}

	public void CauseProcessingCompleted(ISystemContext context, uint causeId)
	{
		uint transitionForCause = GetTransitionForCause(context, causeId);
		if (transitionForCause == 0)
		{
			return;
		}
		uint newStateForTransition = GetNewStateForTransition(context, transitionForCause);
		if (newStateForTransition != 0)
		{
			if (m_lastState == null)
			{
				m_lastState = new FiniteStateVariableState(this);
			}
			m_lastState.SetChildValue(context, null, CurrentState, copy: false);
			UpdateStateVariable(context, newStateForTransition, CurrentState);
			UpdateTransitionVariable(context, transitionForCause, LastTransition);
		}
	}

	public ServiceResult DoTransition(ISystemContext context, uint transitionId, uint causeId, IList<object> inputArguments, IList<object> outputArguments)
	{
		uint newStateForTransition = GetNewStateForTransition(context, transitionId);
		if (newStateForTransition == 0)
		{
			return 2151481344u;
		}
		if (causeId != 0 && !IsCausePermitted(context, causeId, checkUserAccessRights: true))
		{
			return 2149515264u;
		}
		ServiceResult serviceResult = InvokeCallback(OnBeforeTransition, context, this, transitionId, causeId, inputArguments, outputArguments);
		if (ServiceResult.IsBad(serviceResult))
		{
			return serviceResult;
		}
		if (m_lastState == null)
		{
			m_lastState = new FiniteStateVariableState(this);
		}
		m_lastState.SetChildValue(context, null, CurrentState, copy: false);
		UpdateStateVariable(context, newStateForTransition, CurrentState);
		UpdateTransitionVariable(context, transitionId, LastTransition);
		InvokeCallback(OnAfterTransition, context, this, transitionId, causeId, inputArguments, outputArguments);
		if (base.AreEventsMonitored && !m_suppressTransitionEvents)
		{
			TransitionEventState transitionEventState = CreateTransitionEvent(context, transitionId, causeId);
			if (transitionEventState != null)
			{
				UpdateTransitionEvent(context, transitionId, causeId, transitionEventState);
				ReportEvent(context, transitionEventState);
			}
		}
		return ServiceResult.Good;
	}

	protected virtual TransitionEventState CreateTransitionEvent(ISystemContext context, uint transitionId, uint causeId)
	{
		if (TransitionHasEffect(context, transitionId))
		{
			return new TransitionEventState(null);
		}
		return null;
	}

	protected virtual void UpdateTransitionEvent(ISystemContext context, uint transitionId, uint causeId, TransitionEventState e)
	{
		TranslationInfo translationInfo = new TranslationInfo("StateTransition", "en-US", "The {0} state machine moved to the {1} state.", GetDisplayPath(3, '.'), CurrentState.Value);
		e.Initialize(context, this, EventSeverity.Medium, new LocalizedText(translationInfo));
		e.SetChildValue(context, "FromState", LastState, copy: false);
		e.SetChildValue(context, "ToState", CurrentState, copy: false);
		e.SetChildValue(context, "Transition", LastTransition, copy: false);
	}
}
