using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionRefresh2MethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAENvbmRpdGlvblJlZnJlc2gyTWV0aG9kVHlwZQEAcjIALwEAcjJyMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMyAC4ARHMyAACWAgAAAAEAKgEBVgAAAA4AAABTdWJzY3JpcHRpb25JZAEAIAH/////AAAAAAMAAAAALwAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgc3Vic2NyaXB0aW9uIHRvIHJlZnJlc2guAQAqAQFZAAAADwAAAE1vbml0b3JlZEl0ZW1JZAEAIAH/////AAAAAAMAAAAAMQAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgbW9uaXRvcmVkIGl0ZW0gdG8gcmVmcmVzaC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public ConditionRefresh2MethodStateMethodCallHandler OnCall;

	public ConditionRefresh2MethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new ConditionRefresh2MethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAENvbmRpdGlvblJlZnJlc2gyTWV0aG9kVHlwZQEAcjIALwEAcjJyMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMyAC4ARHMyAACWAgAAAAEAKgEBVgAAAA4AAABTdWJzY3JpcHRpb25JZAEAIAH/////AAAAAAMAAAAALwAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgc3Vic2NyaXB0aW9uIHRvIHJlZnJlc2guAQAqAQFZAAAADwAAAE1vbml0b3JlZEl0ZW1JZAEAIAH/////AAAAAAMAAAAAMQAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgbW9uaXRvcmVkIGl0ZW0gdG8gcmVmcmVzaC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		uint subscriptionId = (uint)_inputArguments[0];
		uint monitoredItemId = (uint)_inputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, subscriptionId, monitoredItemId);
		}
		return result;
	}
}
