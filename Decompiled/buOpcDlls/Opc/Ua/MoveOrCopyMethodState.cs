using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MoveOrCopyMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFAAAAE1vdmVPckNvcHlNZXRob2RUeXBlAQAmNAAvAQAmNCY0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJzQALgBEJzQAAJYEAAAAAQAqAQEhAAAAEgAAAE9iamVjdFRvTW92ZU9yQ29weQAR/////wAAAAAAAQAqAQEeAAAADwAAAFRhcmdldERpcmVjdG9yeQAR/////wAAAAAAAQAqAQEZAAAACgAAAENyZWF0ZUNvcHkAAf////8AAAAAAAEAKgEBFgAAAAcAAABOZXdOYW1lAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAoNAAuAEQoNAAAlgEAAAABACoBARgAAAAJAAAATmV3Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public MoveOrCopyMethodStateMethodCallHandler OnCall;

	public MoveOrCopyMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new MoveOrCopyMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAE1vdmVPckNvcHlNZXRob2RUeXBlAQAmNAAvAQAmNCY0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJzQALgBEJzQAAJYEAAAAAQAqAQEhAAAAEgAAAE9iamVjdFRvTW92ZU9yQ29weQAR/////wAAAAAAAQAqAQEeAAAADwAAAFRhcmdldERpcmVjdG9yeQAR/////wAAAAAAAQAqAQEZAAAACgAAAENyZWF0ZUNvcHkAAf////8AAAAAAAEAKgEBFgAAAAcAAABOZXdOYW1lAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAoNAAuAEQoNAAAlgEAAAABACoBARgAAAAJAAAATmV3Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		NodeId objectToMoveOrCopy = (NodeId)_inputArguments[0];
		NodeId targetDirectory = (NodeId)_inputArguments[1];
		bool createCopy = (bool)_inputArguments[2];
		string newName = (string)_inputArguments[3];
		NodeId newNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, objectToMoveOrCopy, targetDirectory, createCopy, newName, ref newNodeId);
		}
		_outputArguments[0] = newNodeId;
		return result;
	}
}
