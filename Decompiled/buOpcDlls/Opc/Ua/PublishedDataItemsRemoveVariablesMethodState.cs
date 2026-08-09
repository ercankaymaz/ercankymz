using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedDataItemsRemoveVariablesMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAKwAAAFB1Ymxpc2hlZERhdGFJdGVtc1JlbW92ZVZhcmlhYmxlc01ldGhvZFR5cGUBAOc4AC8BAOc45zgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoOAAuAEToOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEkAAAAEQAAAFZhcmlhYmxlc1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6TgALgBE6TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIAAAAA0AAABSZW1vdmVSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public PublishedDataItemsRemoveVariablesMethodStateMethodCallHandler OnCall;

	public PublishedDataItemsRemoveVariablesMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PublishedDataItemsRemoveVariablesMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAKwAAAFB1Ymxpc2hlZERhdGFJdGVtc1JlbW92ZVZhcmlhYmxlc01ldGhvZFR5cGUBAOc4AC8BAOc45zgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoOAAuAEToOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEkAAAAEQAAAFZhcmlhYmxlc1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6TgALgBE6TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIAAAAA0AAABSZW1vdmVSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		ConfigurationVersionDataType configurationVersion = (ConfigurationVersionDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		uint[] variablesToRemove = (uint[])_inputArguments[1];
		ConfigurationVersionDataType newConfigurationVersion = (ConfigurationVersionDataType)_outputArguments[0];
		StatusCode[] removeResults = (StatusCode[])_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, variablesToRemove, ref newConfigurationVersion, ref removeResults);
		}
		_outputArguments[0] = newConfigurationVersion;
		_outputArguments[1] = removeResults;
		return result;
	}
}
