using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddPublishedEventsMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHAAAAEFkZFB1Ymxpc2hlZEV2ZW50c01ldGhvZFR5cGUBAKg4AC8BAKg4qDgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCpOAAuAESpOAAAlgYAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEfAAAACgAAAEZpZWxkRmxhZ3MBACA+AQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqOAAuAESqOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public AddPublishedEventsMethodStateMethodCallHandler OnCall;

	public AddPublishedEventsMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddPublishedEventsMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHAAAAEFkZFB1Ymxpc2hlZEV2ZW50c01ldGhvZFR5cGUBAKg4AC8BAKg4qDgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCpOAAuAESpOAAAlgYAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEfAAAACgAAAEZpZWxkRmxhZ3MBACA+AQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqOAAuAESqOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		NodeId eventNotifier = (NodeId)_inputArguments[1];
		string[] fieldNameAliases = (string[])_inputArguments[2];
		ushort[] fieldFlags = (ushort[])_inputArguments[3];
		SimpleAttributeOperand[] selectedFields = (SimpleAttributeOperand[])ExtensionObject.ToArray(_inputArguments[4], typeof(SimpleAttributeOperand));
		ContentFilter filter = (ContentFilter)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[5]);
		ConfigurationVersionDataType configurationVersion = (ConfigurationVersionDataType)_outputArguments[0];
		NodeId dataSetNodeId = (NodeId)_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, name, eventNotifier, fieldNameAliases, fieldFlags, selectedFields, filter, ref configurationVersion, ref dataSetNodeId);
		}
		_outputArguments[0] = configurationVersion;
		_outputArguments[1] = dataSetNodeId;
		return result;
	}
}
