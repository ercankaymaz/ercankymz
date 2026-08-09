using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddExtensionFieldMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAEFkZEV4dGVuc2lvbkZpZWxkTWV0aG9kVHlwZQEAiDwALwEAiDyIPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIk8AC4ARIk8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCKPAAuAESKPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public AddExtensionFieldMethodStateMethodCallHandler OnCall;

	public AddExtensionFieldMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddExtensionFieldMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAEFkZEV4dGVuc2lvbkZpZWxkTWV0aG9kVHlwZQEAiDwALwEAiDyIPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIk8AC4ARIk8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCKPAAuAESKPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		QualifiedName fieldName = (QualifiedName)_inputArguments[0];
		object fieldValue = _inputArguments[1];
		NodeId fieldId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, fieldName, fieldValue, ref fieldId);
		}
		_outputArguments[0] = fieldId;
		return result;
	}
}
