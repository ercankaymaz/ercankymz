using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddRoleMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAEQAAAEFkZFJvbGVNZXRob2RUeXBlAQCCPgAvAQCCPoI+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgz4ALgBEgz4AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCEPgAuAESEPgAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public AddRoleMethodStateMethodCallHandler OnCall;

	public AddRoleMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddRoleMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAEFkZFJvbGVNZXRob2RUeXBlAQCCPgAvAQCCPoI+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgz4ALgBEgz4AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCEPgAuAESEPgAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		string roleName = (string)_inputArguments[0];
		string namespaceUri = (string)_inputArguments[1];
		NodeId roleNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, roleName, namespaceUri, ref roleNodeId);
		}
		_outputArguments[0] = roleNodeId;
		return result;
	}
}
