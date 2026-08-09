using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddPublishedEventsTemplateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAJAAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlTWV0aG9kVHlwZQEAiUIALwEAiUKJQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJNCAC4ARJNCAACWBQAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBHAAAAA0AAABFdmVudE5vdGlmaWVyABH/////AAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKgEBFwAAAAYAAABGaWx0ZXIBAEoC/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqkIALgBEqkIAAJYBAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public AddPublishedEventsTemplateMethodStateMethodCallHandler OnCall;

	public AddPublishedEventsTemplateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddPublishedEventsTemplateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAJAAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlTWV0aG9kVHlwZQEAiUIALwEAiUKJQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJNCAC4ARJNCAACWBQAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBHAAAAA0AAABFdmVudE5vdGlmaWVyABH/////AAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKgEBFwAAAAYAAABGaWx0ZXIBAEoC/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqkIALgBEqkIAAJYBAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		DataSetMetaDataType dataSetMetaData = (DataSetMetaDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[1]);
		NodeId eventNotifier = (NodeId)_inputArguments[2];
		SimpleAttributeOperand[] selectedFields = (SimpleAttributeOperand[])ExtensionObject.ToArray(_inputArguments[3], typeof(SimpleAttributeOperand));
		ContentFilter filter = (ContentFilter)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[4]);
		NodeId dataSetNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, name, dataSetMetaData, eventNotifier, selectedFields, filter, ref dataSetNodeId);
		}
		_outputArguments[0] = dataSetNodeId;
		return result;
	}
}
