// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExclusiveLimitStateMachineState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ExclusiveLimitStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEV4Y2x1c2l2ZUxpbWl0U3RhdGVNYWNoaW5lVHlwZUluc3RhbmNlAQBmJAEAZiRmJAAA/////wEAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEAZyQALwEAyApnJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAGgkAC4ARGgkAAAAEf////8BAf////8AAAAA";
  private FiniteStateMachineState.ElementInfo[] s_StateTable = new FiniteStateMachineState.ElementInfo[4]
  {
    new FiniteStateMachineState.ElementInfo(9329U, "HighHigh", 1U),
    new FiniteStateMachineState.ElementInfo(9331U, "High", 2U),
    new FiniteStateMachineState.ElementInfo(9333U, "Low", 3U),
    new FiniteStateMachineState.ElementInfo(9335U, "LowLow", 4U)
  };
  private FiniteStateMachineState.ElementInfo[] s_TransitionTable = new FiniteStateMachineState.ElementInfo[4]
  {
    new FiniteStateMachineState.ElementInfo(9339U, "HighHighToHigh", 1U),
    new FiniteStateMachineState.ElementInfo(9340U, "HighToHighHigh", 2U),
    new FiniteStateMachineState.ElementInfo(9337U, "LowLowToLow", 3U),
    new FiniteStateMachineState.ElementInfo(9338U, "LowToLowLow", 4U)
  };
  private uint[,] s_TransitionMappings = new uint[4, 4]
  {
    {
      9339U,
      9329U,
      9331U,
      0U
    },
    {
      9340U,
      9331U,
      9329U,
      0U
    },
    {
      9337U,
      9335U,
      9333U,
      0U
    },
    {
      9338U,
      9333U,
      9335U,
      0U
    }
  };

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 9318U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEV4Y2x1c2l2ZUxpbWl0U3RhdGVNYWNoaW5lVHlwZUluc3RhbmNlAQBmJAEAZiRmJAAA/////wEAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEAZyQALwEAyApnJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAGgkAC4ARGgkAAAAEf////8BAf////8AAAAA");
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

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    this.UpdateStateVariable(context, 9331U, this.CurrentState);
    this.UpdateTransitionVariable(context, 0U, this.LastTransition);
  }

  protected override FiniteStateMachineState.ElementInfo[] StateTable => this.s_StateTable;

  protected override FiniteStateMachineState.ElementInfo[] TransitionTable
  {
    get => this.s_TransitionTable;
  }

  protected override uint[,] TransitionMappings => this.s_TransitionMappings;
}
