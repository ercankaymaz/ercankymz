using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CloseAndUpdateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kVXBkYXRlTWV0aG9kVHlwZQEA5DAALwEA5DDkMAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKAxAC4ARKAxAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDlMAAuAETlMAAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public CloseAndUpdateMethodStateMethodCallHandler OnCall;

	public CloseAndUpdateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new CloseAndUpdateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kVXBkYXRlTWV0aG9kVHlwZQEA5DAALwEA5DDkMAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKAxAC4ARKAxAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDlMAAuAETlMAAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		uint fileHandle = (uint)_inputArguments[0];
		bool applyChangesRequired = (bool)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fileHandle, ref applyChangesRequired);
		}
		_outputArguments[0] = applyChangesRequired;
		return result;
	}
}
