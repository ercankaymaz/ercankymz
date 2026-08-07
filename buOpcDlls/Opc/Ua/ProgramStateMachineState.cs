// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramStateMachineState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
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
  private FiniteStateMachineState.ElementInfo[] s_StateTable = new FiniteStateMachineState.ElementInfo[4]
  {
    new FiniteStateMachineState.ElementInfo(2400U, "Ready", 1U),
    new FiniteStateMachineState.ElementInfo(2402U, "Running", 2U),
    new FiniteStateMachineState.ElementInfo(2404U, "Suspended", 3U),
    new FiniteStateMachineState.ElementInfo(2406U, "Halted", 4U)
  };
  private FiniteStateMachineState.ElementInfo[] s_TransitionTable = new FiniteStateMachineState.ElementInfo[9]
  {
    new FiniteStateMachineState.ElementInfo(2408U, "HaltedToReady", 1U),
    new FiniteStateMachineState.ElementInfo(2410U, "ReadyToRunning", 2U),
    new FiniteStateMachineState.ElementInfo(2412U, "RunningToHalted", 3U),
    new FiniteStateMachineState.ElementInfo(2414U, "RunningToReady", 4U),
    new FiniteStateMachineState.ElementInfo(2416U, "RunningToSuspended", 5U),
    new FiniteStateMachineState.ElementInfo(2418U, "SuspendedToRunning", 6U),
    new FiniteStateMachineState.ElementInfo(2420U, "SuspendedToHalted", 7U),
    new FiniteStateMachineState.ElementInfo(2422U, "SuspendedToReady", 8U),
    new FiniteStateMachineState.ElementInfo(2424U, "ReadyToHalted", 9U)
  };
  private uint[,] s_TransitionMappings = new uint[9, 4]
  {
    {
      2408U,
      2406U,
      2400U,
      1U
    },
    {
      2410U,
      2400U,
      2402U,
      1U
    },
    {
      2412U,
      2402U,
      2406U,
      1U
    },
    {
      2414U,
      2402U,
      2400U,
      1U
    },
    {
      2416U,
      2402U,
      2404U,
      1U
    },
    {
      2418U,
      2404U,
      2402U,
      1U
    },
    {
      2420U,
      2404U,
      2406U,
      1U
    },
    {
      2422U,
      2404U,
      2400U,
      1U
    },
    {
      2424U,
      2400U,
      2406U,
      1U
    }
  };
  private uint[,] s_CauseMappings = new uint[8, 3]
  {
    {
      2430U,
      2406U,
      2408U
    },
    {
      2426U,
      2400U,
      2410U
    },
    {
      2427U,
      2402U,
      2416U
    },
    {
      2430U,
      2402U,
      2414U
    },
    {
      2429U,
      2402U,
      2412U
    },
    {
      2428U,
      2404U,
      2418U
    },
    {
      2430U,
      2404U,
      2422U
    },
    {
      2429U,
      2404U,
      2420U
    }
  };

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2391U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFByb2dyYW1TdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAFcJAQBXCVcJAAD/////BwAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQD2DgAvAQDICvYOAAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEA9w4ALgBE9w4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA+Q4ALgBE+Q4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQD7DgAvAQDPCvsOAAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEA/A4ALgBE/A4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEA/g4ALgBE/g4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD/DgAuAET/DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAFkJAC4ARFkJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQBaCQAuAERaCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQBbCQAuAERbCQAAAAb/////AQH/////AAAAABVgiQoCAAAAAAARAAAAUHJvZ3JhbURpYWdub3N0aWMBAF8JAC8BABc8XwkAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAADwAvAD8ADwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAAQ8ALwA/AQ8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBAAIPAC8APwIPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAAw8ALgBEAw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBAAQPAC8APwQPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAFDwAvAD8FDwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAGDwAvAD8GDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAAcPAC8APwcPAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQC+OgAvAD++OgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQDAOgAvAD/AOgAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBAAgPAC8APwgPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBAAkPAC8APwkPAAAAE/////8BAf////8AAAAABGCACgEAAAAAAA8AAABGaW5hbFJlc3VsdERhdGEBAAoPAC8AOgoPAAD/////AAAAAA==");
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
    if (this.ProgramDiagnostic != null)
      this.ProgramDiagnostic.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAFByb2dyYW1EaWFnbm9zdGljAQBfCQAvAQAXPF8JAAABAOFd/////wEB/////wwAAAAVYIkKAgAAAAAADwAAAENyZWF0ZVNlc3Npb25JZAEAAA8ALwA/AA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENyZWF0ZUNsaWVudE5hbWUBAAEPAC8APwEPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABYAAABJbnZvY2F0aW9uQ3JlYXRpb25UaW1lAQACDwAvAD8CDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0VHJhbnNpdGlvblRpbWUBAAMPAC4ARAMPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RNZXRob2RDYWxsAQAEDwAvAD8EDwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAATGFzdE1ldGhvZFNlc3Npb25JZAEABQ8ALwA/BQ8AAAAR/////wEB/////wAAAAAXYIkKAgAAAAAAGAAAAExhc3RNZXRob2RJbnB1dEFyZ3VtZW50cwEABg8ALwA/Bg8AAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABkAAABMYXN0TWV0aG9kT3V0cHV0QXJndW1lbnRzAQAHDwAvAD8HDwAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAExhc3RNZXRob2RJbnB1dFZhbHVlcwEAvjoALwA/vjoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAATGFzdE1ldGhvZE91dHB1dFZhbHVlcwEAwDoALwA/wDoAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdE1ldGhvZENhbGxUaW1lAQAIDwAvAD8IDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABMYXN0TWV0aG9kUmV0dXJuU3RhdHVzAQAJDwAvAD8JDwAAABP/////AQH/////AAAAAA==");
    if (this.FinalResultData == null)
      return;
    this.FinalResultData.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAEZpbmFsUmVzdWx0RGF0YQEACg8ALwA6Cg8AAP////8AAAAA");
  }

  public PropertyState<bool> Deletable
  {
    get => this.m_deletable;
    set
    {
      if (this.m_deletable != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deletable = value;
    }
  }

  public PropertyState<bool> AutoDelete
  {
    get => this.m_autoDelete;
    set
    {
      if (this.m_autoDelete != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_autoDelete = value;
    }
  }

  public PropertyState<int> RecycleCount
  {
    get => this.m_recycleCount;
    set
    {
      if (this.m_recycleCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_recycleCount = value;
    }
  }

  public ProgramDiagnostic2State ProgramDiagnostic
  {
    get => this.m_programDiagnostic;
    set
    {
      if (this.m_programDiagnostic != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_programDiagnostic = value;
    }
  }

  public BaseObjectState FinalResultData
  {
    get => this.m_finalResultData;
    set
    {
      if (this.m_finalResultData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_finalResultData = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_deletable != null)
      children.Add((BaseInstanceState) this.m_deletable);
    if (this.m_autoDelete != null)
      children.Add((BaseInstanceState) this.m_autoDelete);
    if (this.m_recycleCount != null)
      children.Add((BaseInstanceState) this.m_recycleCount);
    if (this.m_programDiagnostic != null)
      children.Add((BaseInstanceState) this.m_programDiagnostic);
    if (this.m_finalResultData != null)
      children.Add((BaseInstanceState) this.m_finalResultData);
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
      case "Deletable":
        if (createOrReplace && this.Deletable == null)
          this.Deletable = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Deletable;
        break;
      case "AutoDelete":
        if (createOrReplace && this.AutoDelete == null)
          this.AutoDelete = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AutoDelete;
        break;
      case "RecycleCount":
        if (createOrReplace && this.RecycleCount == null)
          this.RecycleCount = replacement != null ? (PropertyState<int>) replacement : new PropertyState<int>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RecycleCount;
        break;
      case "ProgramDiagnostic":
        if (createOrReplace && this.ProgramDiagnostic == null)
          this.ProgramDiagnostic = replacement != null ? (ProgramDiagnostic2State) replacement : new ProgramDiagnostic2State((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ProgramDiagnostic;
        break;
      case "FinalResultData":
        if (createOrReplace && this.FinalResultData == null)
          this.FinalResultData = replacement != null ? (BaseObjectState) replacement : new BaseObjectState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FinalResultData;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    this.UpdateStateVariable(context, 2400U, this.CurrentState);
    this.UpdateTransitionVariable(context, 0U, this.LastTransition);
  }

  protected override FiniteStateMachineState.ElementInfo[] StateTable => this.s_StateTable;

  protected override FiniteStateMachineState.ElementInfo[] TransitionTable
  {
    get => this.s_TransitionTable;
  }

  protected override uint[,] TransitionMappings => this.s_TransitionMappings;

  protected override uint[,] CauseMappings => this.s_CauseMappings;

  protected override AuditUpdateStateEventState CreateAuditEvent(
    ISystemContext context,
    MethodState causeMethod,
    uint causeId)
  {
    return (AuditUpdateStateEventState) new ProgramTransitionAuditEventState((NodeState) null);
  }

  protected override void UpdateAuditEvent(
    ISystemContext context,
    MethodState causeMethod,
    IList<object> inputArguments,
    uint causeId,
    AuditUpdateStateEventState e,
    ServiceResult result)
  {
    base.UpdateAuditEvent(context, causeMethod, inputArguments, causeId, e, result);
    if (!ServiceResult.IsGood(result) || !(e is ProgramTransitionAuditEventState transitionAuditEventState))
      return;
    transitionAuditEventState.SetChildValue(context, (QualifiedName) "Transition", (BaseInstanceState) this.LastTransition, false);
  }

  protected override TransitionEventState CreateTransitionEvent(
    ISystemContext context,
    uint transitionId,
    uint causeId)
  {
    return this.TransitionHasEffect(context, transitionId) ? (TransitionEventState) new ProgramTransitionEventState((NodeState) null) : (TransitionEventState) null;
  }

  protected ServiceResult IsStartExecutable(ISystemContext context, NodeState node, ref bool value)
  {
    value = this.IsCausePermitted(context, 2426U, false);
    return ServiceResult.Good;
  }

  protected ServiceResult IsStartUserExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2426U, true);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnStart(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.DoCause(context, method, 2426U, inputArguments, outputArguments);
  }

  protected ServiceResult IsSuspendExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2427U, false);
    return ServiceResult.Good;
  }

  protected ServiceResult IsSuspendUserExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2427U, true);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnSuspend(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.DoCause(context, method, 2427U, inputArguments, outputArguments);
  }

  protected ServiceResult IsResumeExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2428U, false);
    return ServiceResult.Good;
  }

  protected ServiceResult IsResumeUserExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2428U, true);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnResume(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.DoCause(context, method, 2428U, inputArguments, outputArguments);
  }

  protected ServiceResult IsHaltExecutable(ISystemContext context, NodeState node, ref bool value)
  {
    value = this.IsCausePermitted(context, 2429U, false);
    return ServiceResult.Good;
  }

  protected ServiceResult IsHaltUserExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2429U, true);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnHalt(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.DoCause(context, method, 2429U, inputArguments, outputArguments);
  }

  protected ServiceResult IsResetExecutable(ISystemContext context, NodeState node, ref bool value)
  {
    value = this.IsCausePermitted(context, 2430U, false);
    return ServiceResult.Good;
  }

  protected ServiceResult IsResetUserExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.IsCausePermitted(context, 2430U, true);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnReset(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.DoCause(context, method, 2430U, inputArguments, outputArguments);
  }
}
