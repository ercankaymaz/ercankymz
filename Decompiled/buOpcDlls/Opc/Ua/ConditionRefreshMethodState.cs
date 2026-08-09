using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionRefreshMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAENvbmRpdGlvblJlZnJlc2hNZXRob2RUeXBlAQAvIwAvAQAvIy8jAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMCMALgBEMCMAAJYBAAAAAQAqAQFWAAAADgAAAFN1YnNjcmlwdGlvbklkAQAgAf////8AAAAAAwAAAAAvAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBzdWJzY3JpcHRpb24gdG8gcmVmcmVzaC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public ConditionRefreshMethodStateMethodCallHandler OnCall;

	public ConditionRefreshMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new ConditionRefreshMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAENvbmRpdGlvblJlZnJlc2hNZXRob2RUeXBlAQAvIwAvAQAvIy8jAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMCMALgBEMCMAAJYBAAAAAQAqAQFWAAAADgAAAFN1YnNjcmlwdGlvbklkAQAgAf////8AAAAAAwAAAAAvAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBzdWJzY3JpcHRpb24gdG8gcmVmcmVzaC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		uint subscriptionId = (uint)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, subscriptionId);
		}
		return result;
	}
}
