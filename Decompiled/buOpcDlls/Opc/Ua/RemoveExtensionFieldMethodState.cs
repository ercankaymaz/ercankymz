using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveExtensionFieldMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHgAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkTWV0aG9kVHlwZQEAizwALwEAizyLPAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIw8AC4ARIw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public RemoveExtensionFieldMethodStateMethodCallHandler OnCall;

	public RemoveExtensionFieldMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveExtensionFieldMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHgAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkTWV0aG9kVHlwZQEAizwALwEAizyLPAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIw8AC4ARIw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		NodeId fieldId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fieldId);
		}
		return result;
	}
}
