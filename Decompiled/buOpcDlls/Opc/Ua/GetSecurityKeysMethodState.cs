using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetSecurityKeysMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAEdldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAHI7AC8BAHI7cjsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzOwAuAERzOwAAlgMAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAAPAAAAU3RhcnRpbmdUb2tlbklkAQAgAf////8AAAAAAAEAKgEBIAAAABEAAABSZXF1ZXN0ZWRLZXlDb3VudAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdDsALgBEdDsAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBAR0AAAAMAAAARmlyc3RUb2tlbklkAQAgAf////8AAAAAAAEAKgEBFwAAAAQAAABLZXlzAA8BAAAAAQAAAAAAAAAAAQAqAQEeAAAADQAAAFRpbWVUb05leHRLZXkBACIB/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public GetSecurityKeysMethodStateMethodCallHandler OnCall;

	public GetSecurityKeysMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GetSecurityKeysMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAEdldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAHI7AC8BAHI7cjsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzOwAuAERzOwAAlgMAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAAPAAAAU3RhcnRpbmdUb2tlbklkAQAgAf////8AAAAAAAEAKgEBIAAAABEAAABSZXF1ZXN0ZWRLZXlDb3VudAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdDsALgBEdDsAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBAR0AAAAMAAAARmlyc3RUb2tlbklkAQAgAf////8AAAAAAAEAKgEBFwAAAAQAAABLZXlzAA8BAAAAAQAAAAAAAAAAAQAqAQEeAAAADQAAAFRpbWVUb05leHRLZXkBACIB/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		string securityGroupId = (string)_inputArguments[0];
		uint startingTokenId = (uint)_inputArguments[1];
		uint requestedKeyCount = (uint)_inputArguments[2];
		string securityPolicyUri = (string)_outputArguments[0];
		uint firstTokenId = (uint)_outputArguments[1];
		byte[][] keys = (byte[][])_outputArguments[2];
		double timeToNextKey = (double)_outputArguments[3];
		double keyLifetime = (double)_outputArguments[4];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, securityGroupId, startingTokenId, requestedKeyCount, ref securityPolicyUri, ref firstTokenId, ref keys, ref timeToNextKey, ref keyLifetime);
		}
		_outputArguments[0] = securityPolicyUri;
		_outputArguments[1] = firstTokenId;
		_outputArguments[2] = keys;
		_outputArguments[3] = timeToNextKey;
		_outputArguments[4] = keyLifetime;
		return result;
	}
}
