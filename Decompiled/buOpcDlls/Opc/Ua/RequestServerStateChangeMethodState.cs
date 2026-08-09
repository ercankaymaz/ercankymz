using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RequestServerStateChangeMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAIgAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZU1ldGhvZFR5cGUBAFgyAC8BAFgyWDIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBZMgAuAERZMgAAlgUAAAABACoBARYAAAAFAAAAU3RhdGUBAFQD/////wAAAAAAAQAqAQEiAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUADf////8AAAAAAAEAKgEBIgAAABMAAABTZWNvbmRzVGlsbFNodXRkb3duAAf/////AAAAAAABACoBARUAAAAGAAAAUmVhc29uABX/////AAAAAAABACoBARYAAAAHAAAAUmVzdGFydAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public RequestServerStateChangeMethodStateMethodCallHandler OnCall;

	public RequestServerStateChangeMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RequestServerStateChangeMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAIgAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZU1ldGhvZFR5cGUBAFgyAC8BAFgyWDIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBZMgAuAERZMgAAlgUAAAABACoBARYAAAAFAAAAU3RhdGUBAFQD/////wAAAAAAAQAqAQEiAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUADf////8AAAAAAAEAKgEBIgAAABMAAABTZWNvbmRzVGlsbFNodXRkb3duAAf/////AAAAAAABACoBARUAAAAGAAAAUmVhc29uABX/////AAAAAAABACoBARYAAAAHAAAAUmVzdGFydAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		ServerState state = (ServerState)_inputArguments[0];
		DateTime estimatedReturnTime = (DateTime)_inputArguments[1];
		uint secondsTillShutdown = (uint)_inputArguments[2];
		LocalizedText reason = (LocalizedText)_inputArguments[3];
		bool restart = (bool)_inputArguments[4];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, state, estimatedReturnTime, secondsTillShutdown, reason, restart);
		}
		return result;
	}
}
