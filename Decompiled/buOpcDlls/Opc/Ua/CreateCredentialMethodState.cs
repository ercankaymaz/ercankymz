using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateCredentialMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAENyZWF0ZUNyZWRlbnRpYWxNZXRob2RUeXBlAQCQOwAvAQCQO5A7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAlTsALgBElTsAAJYDAAAAAQAqAQEaAAAACwAAAFJlc291cmNlVXJpAAz/////AAAAAAABACoBARkAAAAKAAAAUHJvZmlsZVVyaQAM/////wAAAAAAAQAqAQEfAAAADAAAAEVuZHBvaW50VXJscwAMAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFdEAC4ARFdEAACWAQAAAAEAKgEBHwAAABAAAABDcmVkZW50aWFsTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public CreateCredentialMethodStateMethodCallHandler OnCall;

	public CreateCredentialMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new CreateCredentialMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAENyZWF0ZUNyZWRlbnRpYWxNZXRob2RUeXBlAQCQOwAvAQCQO5A7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAlTsALgBElTsAAJYDAAAAAQAqAQEaAAAACwAAAFJlc291cmNlVXJpAAz/////AAAAAAABACoBARkAAAAKAAAAUHJvZmlsZVVyaQAM/////wAAAAAAAQAqAQEfAAAADAAAAEVuZHBvaW50VXJscwAMAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFdEAC4ARFdEAACWAQAAAAEAKgEBHwAAABAAAABDcmVkZW50aWFsTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string resourceUri = (string)_inputArguments[0];
		string profileUri = (string)_inputArguments[1];
		string[] endpointUrls = (string[])_inputArguments[2];
		NodeId credentialNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, resourceUri, profileUri, endpointUrls, ref credentialNodeId);
		}
		_outputArguments[0] = credentialNodeId;
		return result;
	}
}
