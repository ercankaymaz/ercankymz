using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveIdentityMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUlkZW50aXR5TWV0aG9kVHlwZQEAFj0ALwEAFj0WPQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABc9AC4ARBc9AACWAQAAAAEAKgEBFQAAAAQAAABSdWxlAQASPf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public RemoveIdentityMethodStateMethodCallHandler OnCall;

	public RemoveIdentityMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveIdentityMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUlkZW50aXR5TWV0aG9kVHlwZQEAFj0ALwEAFj0WPQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABc9AC4ARBc9AACWAQAAAAEAKgEBFQAAAAQAAABSdWxlAQASPf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		IdentityMappingRuleType rule = (IdentityMappingRuleType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, rule);
		}
		return result;
	}
}
