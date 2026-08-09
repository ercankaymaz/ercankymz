using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetRejectedListMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAEdldFJlamVjdGVkTGlzdE1ldGhvZFR5cGUBAOUxAC8BAOUx5TEAAAEB/////wEAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA5jEALgBE5jEAAJYBAAAAAQAqAQEfAAAADAAAAENlcnRpZmljYXRlcwAPAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public GetRejectedListMethodStateMethodCallHandler OnCall;

	public GetRejectedListMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GetRejectedListMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAEdldFJlamVjdGVkTGlzdE1ldGhvZFR5cGUBAOUxAC8BAOUx5TEAAAEB/////wEAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA5jEALgBE5jEAAJYBAAAAAQAqAQEfAAAADAAAAENlcnRpZmljYXRlcwAPAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		byte[][] certificates = (byte[][])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, ref certificates);
		}
		_outputArguments[0] = certificates;
		return result;
	}
}
