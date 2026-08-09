using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveSecurityGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHQAAAFJlbW92ZVNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBtPAAvAQBtPG08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbjwALgBEbjwAAJYBAAAAAQAqAQEiAAAAEwAAAFNlY3VyaXR5R3JvdXBOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public RemoveSecurityGroupMethodStateMethodCallHandler OnCall;

	public RemoveSecurityGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveSecurityGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHQAAAFJlbW92ZVNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBtPAAvAQBtPG08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbjwALgBEbjwAAJYBAAAAAQAqAQEiAAAAEwAAAFNlY3VyaXR5R3JvdXBOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		NodeId securityGroupNodeId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, securityGroupNodeId);
		}
		return result;
	}
}
