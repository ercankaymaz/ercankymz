using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetSecurityGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEdldFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBZPAAvAQBZPFk8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWjwALgBEWjwAAJYBAAAAAQAqAQEeAAAADwAAAFNlY3VyaXR5R3JvdXBJZAAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAWzwALgBEWzwAAJYBAAAAAQAqAQEiAAAAEwAAAFNlY3VyaXR5R3JvdXBOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public GetSecurityGroupMethodStateMethodCallHandler OnCall;

	public GetSecurityGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GetSecurityGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEdldFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBZPAAvAQBZPFk8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWjwALgBEWjwAAJYBAAAAAQAqAQEeAAAADwAAAFNlY3VyaXR5R3JvdXBJZAAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAWzwALgBEWzwAAJYBAAAAAQAqAQEiAAAAEwAAAFNlY3VyaXR5R3JvdXBOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		string securityGroupId = (string)_inputArguments[0];
		NodeId securityGroupNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, securityGroupId, ref securityGroupNodeId);
		}
		_outputArguments[0] = securityGroupNodeId;
		return result;
	}
}
