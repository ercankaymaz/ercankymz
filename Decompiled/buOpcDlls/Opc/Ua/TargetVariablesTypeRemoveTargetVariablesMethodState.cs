using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TargetVariablesTypeRemoveTargetVariablesMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAMgAAAFRhcmdldFZhcmlhYmxlc1R5cGVSZW1vdmVUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAUOwAvAQAUOxQ7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFTsALgBEFTsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAWOwAuAEQWOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public TargetVariablesTypeRemoveTargetVariablesMethodStateMethodCallHandler OnCall;

	public TargetVariablesTypeRemoveTargetVariablesMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new TargetVariablesTypeRemoveTargetVariablesMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAMgAAAFRhcmdldFZhcmlhYmxlc1R5cGVSZW1vdmVUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAUOwAvAQAUOxQ7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFTsALgBEFTsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAWOwAuAEQWOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		uint[] targetsToRemove = (uint[])_inputArguments[1];
		StatusCode[] removeResults = (StatusCode[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, targetsToRemove, ref removeResults);
		}
		_outputArguments[0] = removeResults;
		return result;
	}
}
