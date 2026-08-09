using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetEncryptingKeyMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEdldEVuY3J5cHRpbmdLZXlNZXRob2RUeXBlAQB7RAAvAQB7RHtEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfEQALgBEfEQAAJYCAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEpAAAAGgAAAFJlcXVlc3RlZFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB9RAAuAER9RAAAlgIAAAABACoBARgAAAAJAAAAUHVibGljS2V5AA//////AAAAAAABACoBAScAAAAYAAAAUmV2aXNlZFNlY3VyaXR5UG9saWN5VXJpABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public GetEncryptingKeyMethodStateMethodCallHandler OnCall;

	public GetEncryptingKeyMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GetEncryptingKeyMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEdldEVuY3J5cHRpbmdLZXlNZXRob2RUeXBlAQB7RAAvAQB7RHtEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfEQALgBEfEQAAJYCAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEpAAAAGgAAAFJlcXVlc3RlZFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB9RAAuAER9RAAAlgIAAAABACoBARgAAAAJAAAAUHVibGljS2V5AA//////AAAAAAABACoBAScAAAAYAAAAUmV2aXNlZFNlY3VyaXR5UG9saWN5VXJpABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string credentialId = (string)_inputArguments[0];
		string requestedSecurityPolicyUri = (string)_inputArguments[1];
		byte[] publicKey = (byte[])_outputArguments[0];
		NodeId revisedSecurityPolicyUri = (NodeId)_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, credentialId, requestedSecurityPolicyUri, ref publicKey, ref revisedSecurityPolicyUri);
		}
		_outputArguments[0] = publicKey;
		_outputArguments[1] = revisedSecurityPolicyUri;
		return result;
	}
}
