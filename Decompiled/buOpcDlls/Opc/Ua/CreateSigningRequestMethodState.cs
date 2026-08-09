using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSigningRequestMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHgAAAENyZWF0ZVNpZ25pbmdSZXF1ZXN0TWV0aG9kVHlwZQEAxTEALwEAxTHFMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAMYxAC4ARMYxAACWBQAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAFN1YmplY3ROYW1lAAz/////AAAAAAABACoBASMAAAAUAAAAUmVnZW5lcmF0ZVByaXZhdGVLZXkAAf////8AAAAAAAEAKgEBFAAAAAUAAABOb25jZQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAxzEALgBExzEAAJYBAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRlUmVxdWVzdAAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public CreateSigningRequestMethodStateMethodCallHandler OnCall;

	public CreateSigningRequestMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new CreateSigningRequestMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHgAAAENyZWF0ZVNpZ25pbmdSZXF1ZXN0TWV0aG9kVHlwZQEAxTEALwEAxTHFMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAMYxAC4ARMYxAACWBQAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAFN1YmplY3ROYW1lAAz/////AAAAAAABACoBASMAAAAUAAAAUmVnZW5lcmF0ZVByaXZhdGVLZXkAAf////8AAAAAAAEAKgEBFAAAAAUAAABOb25jZQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAxzEALgBExzEAAJYBAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRlUmVxdWVzdAAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		NodeId certificateGroupId = (NodeId)_inputArguments[0];
		NodeId certificateTypeId = (NodeId)_inputArguments[1];
		string subjectName = (string)_inputArguments[2];
		bool regeneratePrivateKey = (bool)_inputArguments[3];
		byte[] nonce = (byte[])_inputArguments[4];
		byte[] certificateRequest = (byte[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, certificateGroupId, certificateTypeId, subjectName, regeneratePrivateKey, nonce, ref certificateRequest);
		}
		_outputArguments[0] = certificateRequest;
		return result;
	}
}
