using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ResendDataMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFAAAAFJlc2VuZERhdGFNZXRob2RUeXBlAQBLMgAvAQBLMksyAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDIALgBETDIAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public ResendDataMethodStateMethodCallHandler OnCall;

	public ResendDataMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new ResendDataMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAFJlc2VuZERhdGFNZXRob2RUeXBlAQBLMgAvAQBLMksyAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDIALgBETDIAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
