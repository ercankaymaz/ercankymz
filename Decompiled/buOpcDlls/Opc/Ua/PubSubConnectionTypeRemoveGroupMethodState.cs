using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubConnectionTypeRemoveGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAKQAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlUmVtb3ZlR3JvdXBNZXRob2RUeXBlAQAMOQAvAQAMOQw5AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADTkALgBEDTkAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public PubSubConnectionTypeRemoveGroupMethodStateMethodCallHandler OnCall;

	public PubSubConnectionTypeRemoveGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubConnectionTypeRemoveGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAKQAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlUmVtb3ZlR3JvdXBNZXRob2RUeXBlAQAMOQAvAQAMOQw5AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADTkALgBEDTkAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		NodeId groupId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, groupId);
		}
		return result;
	}
}
