// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ShelvedStateMachineState
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
public class ShelvedStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNoZWx2ZWRTdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAHELAQBxC3ELAAD/////BQAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDIFwAvAQDICsgXAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyRcALgBEyRcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEAmyMALgBEmyMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAIULAC8BAIULhQsAAAEBAwAAAAA1AQEAdwsANQEBAIELAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAK8LAC4ARK8LAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQCDCwAvAQCDC4MLAAABAQMAAAAANQEBAHwLADUBAQB/CwEA+QsAAQBVKwAAAAAEYYIKBAAAAAAADQAAAE9uZVNob3RTaGVsdmUBAIQLAC8BAIQLhAsAAAEBAwAAAAA1AQEAeAsANQEBAH4LAQD5CwABAFUrAAAAAA==";
  private PropertyState<double> m_unshelveTime;
  private TimedShelveMethodState m_timedShelveMethod;
  private MethodState m_unshelveMethod;
  private MethodState m_oneShotShelveMethod;
  private FiniteStateMachineState.ElementInfo[] s_StateTable = new FiniteStateMachineState.ElementInfo[3]
  {
    new FiniteStateMachineState.ElementInfo(2933U, nameof (OneShotShelve), 1U),
    new FiniteStateMachineState.ElementInfo(2932U, "TimedShelved", 2U),
    new FiniteStateMachineState.ElementInfo(2930U, "Unshelved", 3U)
  };
  private FiniteStateMachineState.ElementInfo[] s_TransitionTable = new FiniteStateMachineState.ElementInfo[6]
  {
    new FiniteStateMachineState.ElementInfo(2945U, "OneShotShelvedToTimedShelved", 1U),
    new FiniteStateMachineState.ElementInfo(2943U, "OneShotShelvedToUnshelved", 2U),
    new FiniteStateMachineState.ElementInfo(2942U, "TimedShelvedToOneShotShelved", 3U),
    new FiniteStateMachineState.ElementInfo(2940U, "TimedShelvedToUnshelved", 4U),
    new FiniteStateMachineState.ElementInfo(2936U, "UnshelvedToOneShotShelved", 5U),
    new FiniteStateMachineState.ElementInfo(2935U, "UnshelvedToTimedShelved", 6U)
  };
  private uint[,] s_TransitionMappings = new uint[6, 4]
  {
    {
      2945U,
      2933U,
      2932U,
      0U
    },
    {
      2943U,
      2933U,
      2930U,
      1U
    },
    {
      2942U,
      2932U,
      2933U,
      0U
    },
    {
      2940U,
      2932U,
      2930U,
      1U
    },
    {
      2936U,
      2930U,
      2933U,
      1U
    },
    {
      2935U,
      2930U,
      2932U,
      1U
    }
  };
  private uint[,] s_CauseMappings = new uint[6, 3]
  {
    {
      2949U,
      2933U,
      2945U
    },
    {
      2947U,
      2933U,
      2943U
    },
    {
      2948U,
      2932U,
      2942U
    },
    {
      2947U,
      2932U,
      2940U
    },
    {
      2948U,
      2930U,
      2936U
    },
    {
      2949U,
      2930U,
      2935U
    }
  };

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2929U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNoZWx2ZWRTdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAHELAQBxC3ELAAD/////BQAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDIFwAvAQDICsgXAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyRcALgBEyRcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEAmyMALgBEmyMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAIULAC8BAIULhQsAAAEBAwAAAAA1AQEAdwsANQEBAIELAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAK8LAC4ARK8LAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQCDCwAvAQCDC4MLAAABAQMAAAAANQEBAHwLADUBAQB/CwEA+QsAAQBVKwAAAAAEYYIKBAAAAAAADQAAAE9uZVNob3RTaGVsdmUBAIQLAC8BAIQLhAsAAAEBAwAAAAA1AQEAeAsANQEBAH4LAQD5CwABAFUrAAAAAA==");
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
  }

  public PropertyState<double> UnshelveTime
  {
    get => this.m_unshelveTime;
    set
    {
      if (this.m_unshelveTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unshelveTime = value;
    }
  }

  public TimedShelveMethodState TimedShelve
  {
    get => this.m_timedShelveMethod;
    set
    {
      if (this.m_timedShelveMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_timedShelveMethod = value;
    }
  }

  public MethodState Unshelve
  {
    get => this.m_unshelveMethod;
    set
    {
      if (this.m_unshelveMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unshelveMethod = value;
    }
  }

  public MethodState OneShotShelve
  {
    get => this.m_oneShotShelveMethod;
    set
    {
      if (this.m_oneShotShelveMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_oneShotShelveMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_unshelveTime != null)
      children.Add((BaseInstanceState) this.m_unshelveTime);
    if (this.m_timedShelveMethod != null)
      children.Add((BaseInstanceState) this.m_timedShelveMethod);
    if (this.m_unshelveMethod != null)
      children.Add((BaseInstanceState) this.m_unshelveMethod);
    if (this.m_oneShotShelveMethod != null)
      children.Add((BaseInstanceState) this.m_oneShotShelveMethod);
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
      case "UnshelveTime":
        if (createOrReplace && this.UnshelveTime == null)
          this.UnshelveTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.UnshelveTime;
        break;
      case "TimedShelve":
        if (createOrReplace && this.TimedShelve == null)
          this.TimedShelve = replacement != null ? (TimedShelveMethodState) replacement : new TimedShelveMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TimedShelve;
        break;
      case "Unshelve":
        if (createOrReplace && this.Unshelve == null)
          this.Unshelve = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Unshelve;
        break;
      case "OneShotShelve":
        if (createOrReplace && this.OneShotShelve == null)
          this.OneShotShelve = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OneShotShelve;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    this.UpdateStateVariable(context, 2930U, this.CurrentState);
    this.UpdateTransitionVariable(context, 0U, this.LastTransition);
  }

  protected override FiniteStateMachineState.ElementInfo[] StateTable => this.s_StateTable;

  protected override FiniteStateMachineState.ElementInfo[] TransitionTable
  {
    get => this.s_TransitionTable;
  }

  protected override uint[,] TransitionMappings => this.s_TransitionMappings;

  protected override uint[,] CauseMappings => this.s_CauseMappings;
}
