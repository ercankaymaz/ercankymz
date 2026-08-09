using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubConnectionTypeAddWriterGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAALAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlQWRkV3JpdGVyR3JvdXBNZXRob2RUeXBlAQCZRAAvAQCZRJlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzUQALgBEzUQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAzkQALgBEzkQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public PubSubConnectionTypeAddWriterGroupMethodStateMethodCallHandler OnCall;

	public PubSubConnectionTypeAddWriterGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubConnectionTypeAddWriterGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAALAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlQWRkV3JpdGVyR3JvdXBNZXRob2RUeXBlAQCZRAAvAQCZRJlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzUQALgBEzUQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAzkQALgBEzkQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		WriterGroupDataType configuration = (WriterGroupDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		NodeId groupId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configuration, ref groupId);
		}
		_outputArguments[0] = groupId;
		return result;
	}
}
