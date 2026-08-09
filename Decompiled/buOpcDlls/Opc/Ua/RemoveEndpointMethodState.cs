using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RemoveEndpointMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUVuZHBvaW50TWV0aG9kVHlwZQEAPj8ALwEAPj8+PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD8/AC4ARD8/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public RemoveEndpointMethodStateMethodCallHandler OnCall;

	public RemoveEndpointMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new RemoveEndpointMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUVuZHBvaW50TWV0aG9kVHlwZQEAPj8ALwEAPj8+PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD8/AC4ARD8/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
