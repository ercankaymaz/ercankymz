using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddSecurityGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEFkZFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBqPAAvAQBqPGo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAazwALgBEazwAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAGw8AC4ARGw8AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public AddSecurityGroupMethodStateMethodCallHandler OnCall;

	public AddSecurityGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddSecurityGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEFkZFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBqPAAvAQBqPGo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAazwALgBEazwAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAGw8AC4ARGw8AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string securityGroupName = (string)_inputArguments[0];
		double keyLifetime = (double)_inputArguments[1];
		string securityPolicyUri = (string)_inputArguments[2];
		uint maxFutureKeyCount = (uint)_inputArguments[3];
		uint maxPastKeyCount = (uint)_inputArguments[4];
		string securityGroupId = (string)_outputArguments[0];
		NodeId securityGroupNodeId = (NodeId)_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, securityGroupName, keyLifetime, securityPolicyUri, maxFutureKeyCount, maxPastKeyCount, ref securityGroupId, ref securityGroupNodeId);
		}
		_outputArguments[0] = securityGroupId;
		_outputArguments[1] = securityGroupNodeId;
		return result;
	}
}
