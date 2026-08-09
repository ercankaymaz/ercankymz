using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveCertificateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEA6DAALwEA6DDoMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOkwAC4AROkwAACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public RemoveCertificateMethodStateMethodCallHandler OnCall;

	public RemoveCertificateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveCertificateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEA6DAALwEA6DDoMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOkwAC4AROkwAACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		string thumbprint = (string)_inputArguments[0];
		bool isTrustedCertificate = (bool)_inputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, thumbprint, isTrustedCertificate);
		}
		return result;
	}
}
