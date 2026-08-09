using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAADgAAAE9wZW5NZXRob2RUeXBlAQDaLQAvAQDaLdotAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA2y0ALgBE2y0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBANwtAC4ARNwtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public OpenMethodStateMethodCallHandler OnCall;

	public OpenMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new OpenMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAADgAAAE9wZW5NZXRob2RUeXBlAQDaLQAvAQDaLdotAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA2y0ALgBE2y0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBANwtAC4ARNwtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		byte mode = (byte)_inputArguments[0];
		uint fileHandle = (uint)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, mode, ref fileHandle);
		}
		_outputArguments[0] = fileHandle;
		return result;
	}
}
