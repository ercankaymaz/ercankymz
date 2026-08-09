using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetMonitoredItemsMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAEdldE1vbml0b3JlZEl0ZW1zTWV0aG9kVHlwZQEA5ywALwEA5yznLAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgsAC4AROgsAACWAQAAAAEAKgEBHQAAAA4AAABTdWJzY3JpcHRpb25JZAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6SwALgBE6SwAAJYCAAAAAQAqAQEgAAAADQAAAFNlcnZlckhhbmRsZXMABwEAAAABAAAAAAAAAAABACoBASAAAAANAAAAQ2xpZW50SGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public GetMonitoredItemsMethodStateMethodCallHandler OnCall;

	public GetMonitoredItemsMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GetMonitoredItemsMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAEdldE1vbml0b3JlZEl0ZW1zTWV0aG9kVHlwZQEA5ywALwEA5yznLAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgsAC4AROgsAACWAQAAAAEAKgEBHQAAAA4AAABTdWJzY3JpcHRpb25JZAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6SwALgBE6SwAAJYCAAAAAQAqAQEgAAAADQAAAFNlcnZlckhhbmRsZXMABwEAAAABAAAAAAAAAAABACoBASAAAAANAAAAQ2xpZW50SGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		InitializeOptionalChildren(context);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	protected override ServiceResult Call(ISystemContext _context, NodeId _objectId, IList<object> _inputArguments, IList<object> _outputArguments)
	{
		if (OnCall == null)
		{
			return base.Call(_context, _objectId, _inputArguments, _outputArguments);
		}
		ServiceResult result = null;
		uint subscriptionId = (uint)_inputArguments[0];
		uint[] serverHandles = (uint[])_outputArguments[0];
		uint[] clientHandles = (uint[])_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, subscriptionId, ref serverHandles, ref clientHandles);
		}
		_outputArguments[0] = serverHandles;
		_outputArguments[1] = clientHandles;
		return result;
	}
}
