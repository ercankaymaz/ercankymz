using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ExclusiveLimitStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEV4Y2x1c2l2ZUxpbWl0U3RhdGVNYWNoaW5lVHlwZUluc3RhbmNlAQBmJAEAZiRmJAAA/////wEAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEAZyQALwEAyApnJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAGgkAC4ARGgkAAAAEf////8BAf////8AAAAA";

	private ElementInfo[] s_StateTable = new ElementInfo[4]
	{
		new ElementInfo(9329u, "HighHigh", 1u),
		new ElementInfo(9331u, "High", 2u),
		new ElementInfo(9333u, "Low", 3u),
		new ElementInfo(9335u, "LowLow", 4u)
	};

	private ElementInfo[] s_TransitionTable = new ElementInfo[4]
	{
		new ElementInfo(9339u, "HighHighToHigh", 1u),
		new ElementInfo(9340u, "HighToHighHigh", 2u),
		new ElementInfo(9337u, "LowLowToLow", 3u),
		new ElementInfo(9338u, "LowToLowLow", 4u)
	};

	private uint[,] s_TransitionMappings = new uint[4, 4]
	{
		{ 9339u, 9329u, 9331u, 0u },
		{ 9340u, 9331u, 9329u, 0u },
		{ 9337u, 9335u, 9333u, 0u },
		{ 9338u, 9333u, 9335u, 0u }
	};

	protected override ElementInfo[] StateTable => s_StateTable;

	protected override ElementInfo[] TransitionTable => s_TransitionTable;

	protected override uint[,] TransitionMappings => s_TransitionMappings;

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(9318u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEV4Y2x1c2l2ZUxpbWl0U3RhdGVNYWNoaW5lVHlwZUluc3RhbmNlAQBmJAEAZiRmJAAA/////wEAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEAZyQALwEAyApnJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAGgkAC4ARGgkAAAAEf////8BAf////8AAAAA");
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

	protected override void OnAfterCreate(ISystemContext context, NodeState node)
	{
		base.OnAfterCreate(context, node);
		UpdateStateVariable(context, 9331u, base.CurrentState);
		UpdateTransitionVariable(context, 0u, base.LastTransition);
	}
}
