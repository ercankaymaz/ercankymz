using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UpdateCertificateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAFVwZGF0ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEAIjEALwEAIjEiMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACMxAC4ARCMxAACWBgAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASUAAAASAAAASXNzdWVyQ2VydGlmaWNhdGVzAA8BAAAAAQAAAAAAAAAAAQAqAQEfAAAAEAAAAFByaXZhdGVLZXlGb3JtYXQADP////8AAAAAAAEAKgEBGQAAAAoAAABQcml2YXRlS2V5AA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAkMQAuAEQkMQAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public UpdateCertificateMethodStateMethodCallHandler OnCall;

	public UpdateCertificateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new UpdateCertificateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAFVwZGF0ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEAIjEALwEAIjEiMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACMxAC4ARCMxAACWBgAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASUAAAASAAAASXNzdWVyQ2VydGlmaWNhdGVzAA8BAAAAAQAAAAAAAAAAAQAqAQEfAAAAEAAAAFByaXZhdGVLZXlGb3JtYXQADP////8AAAAAAAEAKgEBGQAAAAoAAABQcml2YXRlS2V5AA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAkMQAuAEQkMQAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		byte[] certificate = (byte[])_inputArguments[2];
		byte[][] issuerCertificates = (byte[][])_inputArguments[3];
		string privateKeyFormat = (string)_inputArguments[4];
		byte[] privateKey = (byte[])_inputArguments[5];
		bool applyChangesRequired = (bool)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, certificateGroupId, certificateTypeId, certificate, issuerCertificates, privateKeyFormat, privateKey, ref applyChangesRequired);
		}
		_outputArguments[0] = applyChangesRequired;
		return result;
	}
}
