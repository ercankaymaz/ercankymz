using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class KeyCredentialUpdateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHQAAAEtleUNyZWRlbnRpYWxVcGRhdGVNZXRob2RUeXBlAQBZRgAvAQBZRllGAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWkYALgBEWkYAAJYEAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxTZWNyZXQAD/////8AAAAAAAEAKgEBJAAAABUAAABDZXJ0aWZpY2F0ZVRodW1icHJpbnQADP////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public KeyCredentialUpdateMethodStateMethodCallHandler OnCall;

	public KeyCredentialUpdateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new KeyCredentialUpdateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHQAAAEtleUNyZWRlbnRpYWxVcGRhdGVNZXRob2RUeXBlAQBZRgAvAQBZRllGAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWkYALgBEWkYAAJYEAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxTZWNyZXQAD/////8AAAAAAAEAKgEBJAAAABUAAABDZXJ0aWZpY2F0ZVRodW1icHJpbnQADP////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		byte[] credentialSecret = (byte[])_inputArguments[1];
		string certificateThumbprint = (string)_inputArguments[2];
		string securityPolicyUri = (string)_inputArguments[3];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, credentialId, credentialSecret, certificateThumbprint, securityPolicyUri);
		}
		return result;
	}
}
