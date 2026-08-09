using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenWithMasksMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFwAAAE9wZW5XaXRoTWFza3NNZXRob2RUeXBlAQDhMAAvAQDhMOEwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4jAALgBE4jAAAJYBAAAAAQAqAQEUAAAABQAAAE1hc2tzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjMAAuAETjMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public OpenWithMasksMethodStateMethodCallHandler OnCall;

	public OpenWithMasksMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new OpenWithMasksMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFwAAAE9wZW5XaXRoTWFza3NNZXRob2RUeXBlAQDhMAAvAQDhMOEwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4jAALgBE4jAAAJYBAAAAAQAqAQEUAAAABQAAAE1hc2tzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjMAAuAETjMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		uint masks = (uint)_inputArguments[0];
		uint fileHandle = (uint)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, masks, ref fileHandle);
		}
		_outputArguments[0] = fileHandle;
		return result;
	}
}
