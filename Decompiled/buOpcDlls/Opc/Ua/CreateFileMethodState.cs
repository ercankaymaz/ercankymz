using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateFileMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFAAAAENyZWF0ZUZpbGVNZXRob2RUeXBlAQAhNAAvAQAhNCE0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAIjQALgBEIjQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAjNAAuAEQjNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public CreateFileMethodStateMethodCallHandler OnCall;

	public CreateFileMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new CreateFileMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAENyZWF0ZUZpbGVNZXRob2RUeXBlAQAhNAAvAQAhNCE0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAIjQALgBEIjQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAjNAAuAEQjNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		string fileName = (string)_inputArguments[0];
		bool requestFileOpen = (bool)_inputArguments[1];
		NodeId fileNodeId = (NodeId)_outputArguments[0];
		uint fileHandle = (uint)_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fileName, requestFileOpen, ref fileNodeId, ref fileHandle);
		}
		_outputArguments[0] = fileNodeId;
		_outputArguments[1] = fileHandle;
		return result;
	}
}
