using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveDataSetFolderMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHQAAAFJlbW92ZURhdGFTZXRGb2xkZXJNZXRob2RUeXBlAQC3QgAvAQC3QrdCAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMUMALgBEMUMAAJYBAAAAAQAqAQEiAAAAEwAAAERhdGFTZXRGb2xkZXJOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public RemoveDataSetFolderMethodStateMethodCallHandler OnCall;

	public RemoveDataSetFolderMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveDataSetFolderMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHQAAAFJlbW92ZURhdGFTZXRGb2xkZXJNZXRob2RUeXBlAQC3QgAvAQC3QrdCAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMUMALgBEMUMAAJYBAAAAAQAqAQEiAAAAEwAAAERhdGFTZXRGb2xkZXJOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		NodeId dataSetFolderNodeId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, dataSetFolderNodeId);
		}
		return result;
	}
}
