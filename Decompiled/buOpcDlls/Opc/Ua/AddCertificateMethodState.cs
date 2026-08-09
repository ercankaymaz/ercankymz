using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddCertificateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAEFkZENlcnRpZmljYXRlTWV0aG9kVHlwZQEA5jAALwEA5jDmMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOcwAC4AROcwAACWAgAAAAEAKgEBGgAAAAsAAABDZXJ0aWZpY2F0ZQAP/////wAAAAAAAQAqAQEjAAAAFAAAAElzVHJ1c3RlZENlcnRpZmljYXRlAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public AddCertificateMethodStateMethodCallHandler OnCall;

	public AddCertificateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddCertificateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAEFkZENlcnRpZmljYXRlTWV0aG9kVHlwZQEA5jAALwEA5jDmMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOcwAC4AROcwAACWAgAAAAEAKgEBGgAAAAsAAABDZXJ0aWZpY2F0ZQAP/////wAAAAAAAQAqAQEjAAAAFAAAAElzVHJ1c3RlZENlcnRpZmljYXRlAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		byte[] certificate = (byte[])_inputArguments[0];
		bool isTrustedCertificate = (bool)_inputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, certificate, isTrustedCertificate);
		}
		return result;
	}
}
