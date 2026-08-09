using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddConnectionMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFwAAAEFkZENvbm5lY3Rpb25NZXRob2RUeXBlAQAzQQAvAQAzQTNBAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATkEALgBETkEAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAAE9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAT0EALgBET0EAAJYBAAAAAQAqAQEbAAAADAAAAENvbm5lY3Rpb25JZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public AddConnectionMethodStateMethodCallHandler OnCall;

	public AddConnectionMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddConnectionMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFwAAAEFkZENvbm5lY3Rpb25NZXRob2RUeXBlAQAzQQAvAQAzQTNBAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATkEALgBETkEAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAAE9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAT0EALgBET0EAAJYBAAAAAQAqAQEbAAAADAAAAENvbm5lY3Rpb25JZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		PubSubConnectionDataType configuration = (PubSubConnectionDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		NodeId connectionId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configuration, ref connectionId);
		}
		_outputArguments[0] = connectionId;
		return result;
	}
}
