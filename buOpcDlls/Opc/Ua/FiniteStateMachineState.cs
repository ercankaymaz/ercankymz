// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FiniteStateMachineState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FiniteStateMachineState(NodeState parent) : StateMachineState(parent)
{
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2771U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEZpbml0ZVN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA0woBANMK0woAAP////8EAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANQKAC8BAMgK1AoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCQDgAuAESQDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANUKAC8BAM8K1QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCUDgAuAESUDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAQXZhaWxhYmxlU3RhdGVzAQDjRAAvAD/jRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABBdmFpbGFibGVUcmFuc2l0aW9ucwEA5EQALwA/5EQAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.LastTransition != null)
      this.LastTransition.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDVCgAvAQDPCtUKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAlA4ALgBElA4AAAAR/////wEB/////wAAAAA=");
    if (this.AvailableStates != null)
      this.AvailableStates.Initialize(context, "//////////8XYIkKAgAAAAAADwAAAEF2YWlsYWJsZVN0YXRlcwEA40QALwA/40QAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.AvailableTransitions == null)
      return;
    this.AvailableTransitions.Initialize(context, "//////////8XYIkKAgAAAAAAFAAAAEF2YWlsYWJsZVRyYW5zaXRpb25zAQDkRAAvAD/kRAAAABEBAAAAAQAAAAAAAAABAf////8AAAAA");
  }

  public FiniteStateVariableState CurrentState
  {
    get => (FiniteStateVariableState) base.CurrentState;
    set => this.CurrentState = (StateVariableState) value;
  }

  public FiniteTransitionVariableState LastTransition
  {
    get => (FiniteTransitionVariableState) base.LastTransition;
    set => this.LastTransition = (TransitionVariableState) value;
  }

  public BaseDataVariableState<NodeId[]> AvailableStates
  {
    get => this.m_availableStates;
    set
    {
      if (this.m_availableStates != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_availableStates = value;
    }
  }

  public BaseDataVariableState<NodeId[]> AvailableTransitions
  {
    get => this.m_availableTransitions;
    set
    {
      if (this.m_availableTransitions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_availableTransitions = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_availableStates != null)
      children.Add((BaseInstanceState) this.m_availableStates);
    if (this.m_availableTransitions != null)
      children.Add((BaseInstanceState) this.m_availableTransitions);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    switch (browseName.Name)
    {
      case "CurrentState":
        if (createOrReplace && this.CurrentState == null)
          this.CurrentState = replacement != null ? (FiniteStateVariableState) replacement : new FiniteStateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CurrentState;
        break;
      case "LastTransition":
        if (createOrReplace && this.LastTransition == null)
          this.LastTransition = replacement != null ? (FiniteTransitionVariableState) replacement : new FiniteTransitionVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.LastTransition;
        break;
      case "AvailableStates":
        if (createOrReplace && this.AvailableStates == null)
          this.AvailableStates = replacement != null ? (BaseDataVariableState<NodeId[]>) replacement : new BaseDataVariableState<NodeId[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AvailableStates;
        break;
      case "AvailableTransitions":
        if (createOrReplace && this.AvailableTransitions == null)
          this.AvailableTransitions = replacement != null ? (BaseDataVariableState<NodeId[]>) replacement : new BaseDataVariableState<NodeId[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AvailableTransitions;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    int index = context.NamespaceUris.GetIndex(this.ElementNamespaceUri);
    if (index < 0)
      return;
    this.ElementNamespaceIndex = (ushort) index;
  }

  protected ushort ElementNamespaceIndex
  {
    get => this.m_elementNamespaceIndex;
    set => this.m_elementNamespaceIndex = value;
  }

  protected virtual string ElementNamespaceUri => "http://opcfoundation.org/UA/";

  protected virtual FiniteStateMachineState.ElementInfo[] StateTable
  {
    get => (FiniteStateMachineState.ElementInfo[]) null;
  }

  protected virtual FiniteStateMachineState.ElementInfo[] TransitionTable
  {
    get => (FiniteStateMachineState.ElementInfo[]) null;
  }

  protected virtual uint[,] TransitionMappings => (uint[,]) null;

  protected virtual uint[,] CauseMappings => (uint[,]) null;

  protected FiniteStateVariableState LastState
  {
    get => this.m_lastState;
    set => this.m_lastState = value;
  }

  protected uint GetCurrentStateId()
  {
    if (this.CurrentState == null || this.CurrentState.Id == null || this.CurrentState.Value == (LocalizedText) null)
      return 0;
    NodeId nodeId = this.CurrentState.Id.Value;
    return (int) this.ElementNamespaceIndex == (int) nodeId.NamespaceIndex && nodeId.IdType == IdType.Numeric ? (uint) nodeId.Identifier : 0U;
  }

  protected virtual uint GetNewStateForTransition(ISystemContext context, uint transitionId)
  {
    uint currentStateId = this.GetCurrentStateId();
    if (currentStateId == 0U)
      return 0;
    uint[,] transitionMappings = this.TransitionMappings;
    if (transitionMappings == null)
      return 0;
    int length = transitionMappings.GetLength(0);
    for (int index = 0; index < length; ++index)
    {
      if ((int) transitionMappings[index, 0] == (int) transitionId && (int) transitionMappings[index, 1] == (int) currentStateId)
        return transitionMappings[index, 2];
    }
    return 0;
  }

  protected virtual bool TransitionHasEffect(ISystemContext context, uint transitionId)
  {
    uint[,] transitionMappings = this.TransitionMappings;
    if (transitionMappings == null)
      return false;
    int length = transitionMappings.GetLength(0);
    for (int index = 0; index < length; ++index)
    {
      if ((int) transitionMappings[index, 0] == (int) transitionId)
        return transitionMappings[index, 3] > 0U;
    }
    return false;
  }

  protected virtual uint GetTransitionForCause(ISystemContext context, uint causeId)
  {
    uint currentStateId = this.GetCurrentStateId();
    if (currentStateId == 0U)
      return 0;
    uint[,] causeMappings = this.CauseMappings;
    if (causeMappings == null)
      return 0;
    int length = causeMappings.GetLength(0);
    for (int index = 0; index < length; ++index)
    {
      if ((int) causeMappings[index, 0] == (int) causeId && (int) causeMappings[index, 1] == (int) currentStateId)
        return causeMappings[index, 2];
    }
    return 0;
  }

  protected virtual uint GetTransitionToState(ISystemContext context, uint targetStateId)
  {
    uint currentStateId = this.GetCurrentStateId();
    if (currentStateId == 0U)
      return 0;
    uint[,] transitionMappings = this.TransitionMappings;
    if (transitionMappings == null)
      return 0;
    int length = transitionMappings.GetLength(0);
    for (int index = 0; index < length; ++index)
    {
      if ((int) transitionMappings[index, 1] == (int) currentStateId && (int) transitionMappings[index, 2] == (int) targetStateId)
        return transitionMappings[index, 0];
    }
    return 0;
  }

  protected void UpdateStateVariable(
    ISystemContext context,
    uint stateId,
    FiniteStateVariableState variable)
  {
    if (variable == null)
      return;
    if (stateId == 0U)
    {
      variable.Value = (LocalizedText) null;
      variable.Id.Value = (NodeId) null;
      if (variable.Number == null)
        return;
      variable.Number.Value = 0U;
    }
    else
    {
      FiniteStateMachineState.ElementInfo[] stateTable = this.StateTable;
      if (stateTable == null)
        return;
      for (int index = 0; index < stateTable.Length; ++index)
      {
        FiniteStateMachineState.ElementInfo elementInfo = stateTable[index];
        if ((int) elementInfo.Id == (int) stateId)
        {
          variable.Value = (LocalizedText) elementInfo.Name;
          variable.Id.Value = new NodeId(elementInfo.Id, this.ElementNamespaceIndex);
          if (variable.Number == null)
            break;
          variable.Number.Value = elementInfo.Number;
          break;
        }
      }
    }
  }

  protected void UpdateTransitionVariable(
    ISystemContext context,
    uint transitionId,
    FiniteTransitionVariableState variable)
  {
    if (variable == null)
      return;
    if (transitionId == 0U)
    {
      variable.Value = (LocalizedText) null;
      variable.Id.Value = (NodeId) null;
      if (variable.TransitionTime != null)
        variable.TransitionTime.Value = DateTime.MinValue;
      if (variable.Number == null)
        return;
      variable.Number.Value = 0U;
    }
    else
    {
      FiniteStateMachineState.ElementInfo[] transitionTable = this.TransitionTable;
      if (transitionTable == null)
        return;
      for (int index = 0; index < transitionTable.Length; ++index)
      {
        FiniteStateMachineState.ElementInfo elementInfo = transitionTable[index];
        if ((int) elementInfo.Id == (int) transitionId)
        {
          variable.Value = (LocalizedText) elementInfo.Name;
          variable.Id.Value = new NodeId(elementInfo.Id, this.ElementNamespaceIndex);
          if (variable.TransitionTime != null)
            variable.TransitionTime.Value = DateTime.UtcNow;
          if (variable.Number == null)
            break;
          variable.Number.Value = elementInfo.Number;
          break;
        }
      }
    }
  }

  public bool SuppressTransitionEvents
  {
    get => this.m_suppressTransitionEvents;
    set => this.m_suppressTransitionEvents = value;
  }

  protected ServiceResult InvokeCallback(
    StateMachineTransitionHandler callback,
    ISystemContext context,
    StateMachineState machine,
    uint transitionId,
    uint causeId,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    if (callback == null)
      return ServiceResult.Good;
    try
    {
      return callback(context, (StateMachineState) this, transitionId, causeId, inputArguments, outputArguments);
    }
    catch (Exception ex)
    {
      return new ServiceResult(ex);
    }
  }

  public virtual bool IsCausePermitted(
    ISystemContext context,
    uint causeId,
    bool checkUserAccessRights)
  {
    uint transitionForCause = this.GetTransitionForCause(context, causeId);
    return transitionForCause != 0U && (!checkUserAccessRights || !ServiceResult.IsBad(this.InvokeCallback(this.OnCheckUserPermission, context, (StateMachineState) this, transitionForCause, causeId, (IList<object>) null, (IList<object>) null)));
  }

  public virtual void SetState(ISystemContext context, uint newState)
  {
    uint transitionToState = this.GetTransitionToState(context, newState);
    this.UpdateStateVariable(context, newState, this.CurrentState);
    this.UpdateTransitionVariable(context, transitionToState, this.LastTransition);
  }

  public virtual ServiceResult DoCause(
    ISystemContext context,
    MethodState causeMethod,
    uint causeId,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    ServiceResult serviceResult = (ServiceResult) null;
    try
    {
      uint transitionForCause = this.GetTransitionForCause(context, causeId);
      if (transitionForCause == 0U)
        return (ServiceResult) 2151481344U /*0x803D0000*/;
      serviceResult = this.InvokeCallback(this.OnCheckUserPermission, context, (StateMachineState) this, transitionForCause, causeId, inputArguments, outputArguments);
      if (ServiceResult.IsBad(serviceResult))
        return serviceResult;
      serviceResult = this.DoTransition(context, transitionForCause, causeId, inputArguments, outputArguments);
      if (ServiceResult.IsBad(serviceResult))
        return serviceResult;
      this.ClearChangeMasks(context, true);
    }
    finally
    {
      if (this.AreEventsMonitored)
      {
        AuditUpdateStateEventState auditEvent = this.CreateAuditEvent(context, causeMethod, causeId);
        this.UpdateAuditEvent(context, causeMethod, inputArguments, causeId, auditEvent, serviceResult);
        this.ReportEvent(context, (IFilterTarget) auditEvent);
        if ((int) this.m_causeId != (int) causeId)
        {
          this.ReportAuditProgramTransitionEvent(context, causeMethod, causeId, inputArguments, serviceResult);
          this.m_causeId = causeId;
        }
      }
    }
    return serviceResult;
  }

  protected virtual AuditUpdateStateEventState CreateAuditEvent(
    ISystemContext context,
    MethodState causeMethod,
    uint causeId)
  {
    return new AuditUpdateStateEventState((NodeState) null);
  }

  protected virtual void UpdateAuditEvent(
    ISystemContext context,
    MethodState causeMethod,
    IList<object> inputArguments,
    uint causeId,
    AuditUpdateStateEventState e,
    ServiceResult result)
  {
    TranslationInfo translationInfo = new TranslationInfo("StateTransition", "en-US", "The {0} method called was on the {1} state machine.", new object[2]
    {
      (object) causeMethod.DisplayName,
      (object) this.GetDisplayPath(3, '.')
    });
    e.Initialize(context, (NodeState) this, EventSeverity.Medium, new LocalizedText(translationInfo), ServiceResult.IsGood(result), DateTime.UtcNow);
    e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
    e.SetChildValue(context, (QualifiedName) "SourceName", (object) ("Method/" + causeMethod.BrowseName.Name), false);
    e.SetChildValue(context, (QualifiedName) "LocalTime", (object) Utils.GetTimeZoneInfo(), false);
    e.SetChildValue(context, (QualifiedName) "MethodId", (object) causeMethod.NodeId, false);
    e.SetChildValue(context, (QualifiedName) "InputArguments", (object) inputArguments, false);
    e.SetChildValue(context, (QualifiedName) "OldStateId", (BaseInstanceState) this.LastState, false);
    e.SetChildValue(context, (QualifiedName) "NewStateId", (BaseInstanceState) this.CurrentState, false);
  }

  protected virtual void ReportAuditProgramTransitionEvent(
    ISystemContext context,
    MethodState causeMethod,
    uint causeId,
    IList<object> inputArguments,
    ServiceResult result)
  {
    try
    {
      AuditProgramTransitionEventState e = new AuditProgramTransitionEventState((NodeState) null);
      this.UpdateAuditEvent(context, causeMethod, inputArguments, causeId, (AuditUpdateStateEventState) e, result);
      e.SetChildValue(context, (QualifiedName) "TransitionNumber", (object) this.LastTransition.Number.Value, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Error while reporting AuditProgramTransitionEvent event.", objArray);
    }
  }

  public void CauseProcessingCompleted(ISystemContext context, uint causeId)
  {
    uint transitionForCause = this.GetTransitionForCause(context, causeId);
    if (transitionForCause == 0U)
      return;
    uint stateForTransition = this.GetNewStateForTransition(context, transitionForCause);
    if (stateForTransition == 0U)
      return;
    if (this.m_lastState == null)
      this.m_lastState = new FiniteStateVariableState((NodeState) this);
    this.m_lastState.SetChildValue(context, (QualifiedName) null, (BaseInstanceState) this.CurrentState, false);
    this.UpdateStateVariable(context, stateForTransition, this.CurrentState);
    this.UpdateTransitionVariable(context, transitionForCause, this.LastTransition);
  }

  public ServiceResult DoTransition(
    ISystemContext context,
    uint transitionId,
    uint causeId,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    uint stateForTransition = this.GetNewStateForTransition(context, transitionId);
    if (stateForTransition == 0U)
      return (ServiceResult) 2151481344U /*0x803D0000*/;
    if (causeId != 0U && !this.IsCausePermitted(context, causeId, true))
      return (ServiceResult) 2149515264U /*0x801F0000*/;
    ServiceResult status = this.InvokeCallback(this.OnBeforeTransition, context, (StateMachineState) this, transitionId, causeId, inputArguments, outputArguments);
    if (ServiceResult.IsBad(status))
      return status;
    if (this.m_lastState == null)
      this.m_lastState = new FiniteStateVariableState((NodeState) this);
    this.m_lastState.SetChildValue(context, (QualifiedName) null, (BaseInstanceState) this.CurrentState, false);
    this.UpdateStateVariable(context, stateForTransition, this.CurrentState);
    this.UpdateTransitionVariable(context, transitionId, this.LastTransition);
    this.InvokeCallback(this.OnAfterTransition, context, (StateMachineState) this, transitionId, causeId, inputArguments, outputArguments);
    if (this.AreEventsMonitored && !this.m_suppressTransitionEvents)
    {
      TransitionEventState transitionEvent = this.CreateTransitionEvent(context, transitionId, causeId);
      if (transitionEvent != null)
      {
        this.UpdateTransitionEvent(context, transitionId, causeId, transitionEvent);
        this.ReportEvent(context, (IFilterTarget) transitionEvent);
      }
    }
    return ServiceResult.Good;
  }

  protected virtual TransitionEventState CreateTransitionEvent(
    ISystemContext context,
    uint transitionId,
    uint causeId)
  {
    return this.TransitionHasEffect(context, transitionId) ? new TransitionEventState((NodeState) null) : (TransitionEventState) null;
  }

  protected virtual void UpdateTransitionEvent(
    ISystemContext context,
    uint transitionId,
    uint causeId,
    TransitionEventState e)
  {
    TranslationInfo translationInfo = new TranslationInfo("StateTransition", "en-US", "The {0} state machine moved to the {1} state.", new object[2]
    {
      (object) this.GetDisplayPath(3, '.'),
      (object) this.CurrentState.Value
    });
    e.Initialize(context, (NodeState) this, EventSeverity.Medium, new LocalizedText(translationInfo));
    e.SetChildValue(context, (QualifiedName) "FromState", (BaseInstanceState) this.LastState, false);
    e.SetChildValue(context, (QualifiedName) "ToState", (BaseInstanceState) this.CurrentState, false);
    e.SetChildValue(context, (QualifiedName) "Transition", (BaseInstanceState) this.LastTransition, false);
  }

  protected sealed class ElementInfo
  {
    private uint m_id;
    private string m_name;
    private uint m_number;

    public ElementInfo(uint id, string name, uint number)
    {
      this.m_id = id;
      this.m_name = name;
      this.m_number = number;
    }

    public uint Id => this.m_id;

    public string Name => this.m_name;

    public uint Number => this.m_number;
  }
}
