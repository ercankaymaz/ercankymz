using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReadMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAADgAAAFJlYWRNZXRob2RUeXBlAQDfLQAvAQDfLd8tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4C0ALgBE4C0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYAAABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOEtAC4AROEtAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public ReadMethodStateMethodCallHandler OnCall;

	public ReadMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new ReadMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFJlYWRNZXRob2RUeXBlAQDfLQAvAQDfLd8tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4C0ALgBE4C0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYAAABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOEtAC4AROEtAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		int length = (int)_inputArguments[1];
		byte[] data = (byte[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fileHandle, length, ref data);
		}
		_outputArguments[0] = data;
		return result;
	}
}
