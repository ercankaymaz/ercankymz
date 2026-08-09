using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteFileMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFAAAAERlbGV0ZUZpbGVNZXRob2RUeXBlAQAkNAAvAQAkNCQ0AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJTQALgBEJTQAAJYBAAAAAQAqAQEdAAAADgAAAE9iamVjdFRvRGVsZXRlABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public DeleteFileMethodStateMethodCallHandler OnCall;

	public DeleteFileMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new DeleteFileMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAERlbGV0ZUZpbGVNZXRob2RUeXBlAQAkNAAvAQAkNCQ0AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJTQALgBEJTQAAJYBAAAAAQAqAQEdAAAADgAAAE9iamVjdFRvRGVsZXRlABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		NodeId objectToDelete = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, objectToDelete);
		}
		return result;
	}
}
