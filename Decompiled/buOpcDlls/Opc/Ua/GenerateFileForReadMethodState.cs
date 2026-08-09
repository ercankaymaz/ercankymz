using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GenerateFileForReadMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHQAAAEdlbmVyYXRlRmlsZUZvclJlYWRNZXRob2RUeXBlAQCzPQAvAQCzPbM9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAtD0ALgBEtD0AAJYBAAAAAQAqAQEeAAAADwAAAEdlbmVyYXRlT3B0aW9ucwAY/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAtT0ALgBEtT0AAJYDAAAAAQAqAQEZAAAACgAAAEZpbGVOb2RlSWQAEf////8AAAAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBASUAAAAWAAAAQ29tcGxldGlvblN0YXRlTWFjaGluZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public GenerateFileForReadMethodStateMethodCallHandler OnCall;

	public GenerateFileForReadMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GenerateFileForReadMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHQAAAEdlbmVyYXRlRmlsZUZvclJlYWRNZXRob2RUeXBlAQCzPQAvAQCzPbM9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAtD0ALgBEtD0AAJYBAAAAAQAqAQEeAAAADwAAAEdlbmVyYXRlT3B0aW9ucwAY/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAtT0ALgBEtT0AAJYDAAAAAQAqAQEZAAAACgAAAEZpbGVOb2RlSWQAEf////8AAAAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBASUAAAAWAAAAQ29tcGxldGlvblN0YXRlTWFjaGluZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		object generateOptions = _inputArguments[0];
		NodeId fileNodeId = (NodeId)_outputArguments[0];
		uint fileHandle = (uint)_outputArguments[1];
		NodeId completionStateMachine = (NodeId)_outputArguments[2];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, generateOptions, ref fileNodeId, ref fileHandle, ref completionStateMachine);
		}
		_outputArguments[0] = fileNodeId;
		_outputArguments[1] = fileHandle;
		_outputArguments[2] = completionStateMachine;
		return result;
	}
}
