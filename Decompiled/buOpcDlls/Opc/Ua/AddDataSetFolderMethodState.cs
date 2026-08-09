using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddDataSetFolderMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEFkZERhdGFTZXRGb2xkZXJNZXRob2RUeXBlAQCrQgAvAQCrQqtCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEArEIALgBErEIAAJYBAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAK1CAC4ARK1CAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0Rm9sZGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public AddDataSetFolderMethodStateMethodCallHandler OnCall;

	public AddDataSetFolderMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddDataSetFolderMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEFkZERhdGFTZXRGb2xkZXJNZXRob2RUeXBlAQCrQgAvAQCrQqtCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEArEIALgBErEIAAJYBAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAK1CAC4ARK1CAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0Rm9sZGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string name = (string)_inputArguments[0];
		NodeId dataSetFolderNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, name, ref dataSetFolderNodeId);
		}
		_outputArguments[0] = dataSetFolderNodeId;
		return result;
	}
}
