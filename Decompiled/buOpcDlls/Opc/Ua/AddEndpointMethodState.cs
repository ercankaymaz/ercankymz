using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddEndpointMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFQAAAEFkZEVuZHBvaW50TWV0aG9kVHlwZQEAPD8ALwEAPD88PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD0/AC4ARD0/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public AddEndpointMethodStateMethodCallHandler OnCall;

	public AddEndpointMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddEndpointMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAEFkZEVuZHBvaW50TWV0aG9kVHlwZQEAPD8ALwEAPD88PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD0/AC4ARD0/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		EndpointType endpoint = (EndpointType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, endpoint);
		}
		return result;
	}
}
