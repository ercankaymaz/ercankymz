using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DialogResponseMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAERpYWxvZ1Jlc3BvbnNlTWV0aG9kVHlwZQEARyMALwEARyNHIwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEgjAC4AREgjAACWAQAAAAEAKgEBTAAAABAAAABTZWxlY3RlZFJlc3BvbnNlAAb/////AAAAAAMAAAAAJQAAAFRoZSByZXNwb25zZSB0byB0aGUgZGlhbG9nIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public DialogResponseMethodStateMethodCallHandler OnCall;

	public DialogResponseMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new DialogResponseMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAERpYWxvZ1Jlc3BvbnNlTWV0aG9kVHlwZQEARyMALwEARyNHIwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEgjAC4AREgjAACWAQAAAAEAKgEBTAAAABAAAABTZWxlY3RlZFJlc3BvbnNlAAb/////AAAAAAMAAAAAJQAAAFRoZSByZXNwb25zZSB0byB0aGUgZGlhbG9nIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		int selectedResponse = (int)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, selectedResponse);
		}
		return result;
	}
}
