using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveApplicationMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUFwcGxpY2F0aW9uTWV0aG9kVHlwZQEAOj8ALwEAOj86PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADs/AC4ARDs/AACWAQAAAAEAKgEBHQAAAA4AAABBcHBsaWNhdGlvblVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public RemoveApplicationMethodStateMethodCallHandler OnCall;

	public RemoveApplicationMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveApplicationMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUFwcGxpY2F0aW9uTWV0aG9kVHlwZQEAOj8ALwEAOj86PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADs/AC4ARDs/AACWAQAAAAEAKgEBHQAAAA4AAABBcHBsaWNhdGlvblVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		string applicationUri = (string)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, applicationUri);
		}
		return result;
	}
}
