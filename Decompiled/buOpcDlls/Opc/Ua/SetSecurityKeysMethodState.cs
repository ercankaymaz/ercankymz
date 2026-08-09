using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetSecurityKeysMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAFNldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAJJDAC8BAJJDkkMAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCTQwAuAESTQwAAlgcAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHwAAAA4AAABDdXJyZW50VG9rZW5JZAEAIAH/////AAAAAAABACoBARkAAAAKAAAAQ3VycmVudEtleQAP/////wAAAAAAAQAqAQEdAAAACgAAAEZ1dHVyZUtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public SetSecurityKeysMethodStateMethodCallHandler OnCall;

	public SetSecurityKeysMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new SetSecurityKeysMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAFNldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAJJDAC8BAJJDkkMAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCTQwAuAESTQwAAlgcAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHwAAAA4AAABDdXJyZW50VG9rZW5JZAEAIAH/////AAAAAAABACoBARkAAAAKAAAAQ3VycmVudEtleQAP/////wAAAAAAAQAqAQEdAAAACgAAAEZ1dHVyZUtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		string securityPolicyUri = (string)_inputArguments[1];
		uint currentTokenId = (uint)_inputArguments[2];
		byte[] currentKey = (byte[])_inputArguments[3];
		byte[][] futureKeys = (byte[][])_inputArguments[4];
		double timeToNextKey = (double)_inputArguments[5];
		double keyLifetime = (double)_inputArguments[6];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, securityGroupId, securityPolicyUri, currentTokenId, currentKey, futureKeys, timeToNextKey, keyLifetime);
		}
		return result;
	}
}
