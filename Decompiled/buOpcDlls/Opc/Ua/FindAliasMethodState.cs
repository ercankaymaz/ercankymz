using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindAliasMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAEwAAAEZpbmRBbGlhc01ldGhvZFR5cGUBAKlbAC8BAKlbqVsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCqWwAuAESqWwAAlgIAAAABACoBASUAAAAWAAAAQWxpYXNOYW1lU2VhcmNoUGF0dGVybgAM/////wAAAAAAAQAqAQEiAAAAEwAAAFJlZmVyZW5jZVR5cGVGaWx0ZXIAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKtbAC4ARKtbAACWAQAAAAEAKgEBIgAAAA0AAABBbGlhc05vZGVMaXN0AQCsWwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public FindAliasMethodStateMethodCallHandler OnCall;

	public FindAliasMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new FindAliasMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAEZpbmRBbGlhc01ldGhvZFR5cGUBAKlbAC8BAKlbqVsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCqWwAuAESqWwAAlgIAAAABACoBASUAAAAWAAAAQWxpYXNOYW1lU2VhcmNoUGF0dGVybgAM/////wAAAAAAAQAqAQEiAAAAEwAAAFJlZmVyZW5jZVR5cGVGaWx0ZXIAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKtbAC4ARKtbAACWAQAAAAEAKgEBIgAAAA0AAABBbGlhc05vZGVMaXN0AQCsWwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string aliasNameSearchPattern = (string)_inputArguments[0];
		NodeId referenceTypeFilter = (NodeId)_inputArguments[1];
		AliasNameDataType[] aliasNodeList = (AliasNameDataType[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, aliasNameSearchPattern, referenceTypeFilter, ref aliasNodeList);
		}
		_outputArguments[0] = aliasNodeList;
		return result;
	}
}
