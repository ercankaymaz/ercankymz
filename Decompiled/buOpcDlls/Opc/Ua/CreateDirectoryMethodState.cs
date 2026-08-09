using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateDirectoryMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAENyZWF0ZURpcmVjdG9yeU1ldGhvZFR5cGUBAB40AC8BAB40HjQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAfNAAuAEQfNAAAlgEAAAABACoBARwAAAANAAAARGlyZWN0b3J5TmFtZQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAIDQALgBEIDQAAJYBAAAAAQAqAQEeAAAADwAAAERpcmVjdG9yeU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public CreateDirectoryMethodStateMethodCallHandler OnCall;

	public CreateDirectoryMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new CreateDirectoryMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAENyZWF0ZURpcmVjdG9yeU1ldGhvZFR5cGUBAB40AC8BAB40HjQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAfNAAuAEQfNAAAlgEAAAABACoBARwAAAANAAAARGlyZWN0b3J5TmFtZQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAIDQALgBEIDQAAJYBAAAAAQAqAQEeAAAADwAAAERpcmVjdG9yeU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		string directoryName = (string)_inputArguments[0];
		NodeId directoryNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, directoryName, ref directoryNodeId);
		}
		_outputArguments[0] = directoryNodeId;
		return result;
	}
}
