using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TargetVariablesTypeAddTargetVariablesMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAALwAAAFRhcmdldFZhcmlhYmxlc1R5cGVBZGRUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAROwAvAQAROxE7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAEjsALgBEEjsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEzsALgBEEzsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public TargetVariablesTypeAddTargetVariablesMethodStateMethodCallHandler OnCall;

	public TargetVariablesTypeAddTargetVariablesMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new TargetVariablesTypeAddTargetVariablesMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAALwAAAFRhcmdldFZhcmlhYmxlc1R5cGVBZGRUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAROwAvAQAROxE7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAEjsALgBEEjsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEzsALgBEEzsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		FieldTargetDataType[] targetVariablesToAdd = (FieldTargetDataType[])ExtensionObject.ToArray(_inputArguments[1], typeof(FieldTargetDataType));
		StatusCode[] addResults = (StatusCode[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, targetVariablesToAdd, ref addResults);
		}
		_outputArguments[0] = addResults;
		return result;
	}
}
