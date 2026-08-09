using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetPositionMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFQAAAFNldFBvc2l0aW9uTWV0aG9kVHlwZQEA5y0ALwEA5y3nLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgtAC4AROgtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public SetPositionMethodStateMethodCallHandler OnCall;

	public SetPositionMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new SetPositionMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAFNldFBvc2l0aW9uTWV0aG9kVHlwZQEA5y0ALwEA5y3nLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgtAC4AROgtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		ulong position = (ulong)_inputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fileHandle, position);
		}
		return result;
	}
}
