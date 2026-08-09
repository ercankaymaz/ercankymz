using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddPublishedDataItemsTemplateMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAJwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlTWV0aG9kVHlwZQEAhkIALwEAhkKGQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIdCAC4ARIdCAACWAwAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiEIALgBEiEIAAJYCAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public AddPublishedDataItemsTemplateMethodStateMethodCallHandler OnCall;

	public AddPublishedDataItemsTemplateMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddPublishedDataItemsTemplateMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAJwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlTWV0aG9kVHlwZQEAhkIALwEAhkKGQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIdCAC4ARIdCAACWAwAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiEIALgBEiEIAAJYCAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		PublishedVariableDataType[] variablesToAdd = (PublishedVariableDataType[])ExtensionObject.ToArray(_inputArguments[2], typeof(PublishedVariableDataType));
		NodeId dataSetNodeId = (NodeId)_outputArguments[0];
		StatusCode[] addResults = (StatusCode[])_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, name, dataSetMetaData, variablesToAdd, ref dataSetNodeId, ref addResults);
		}
		_outputArguments[0] = dataSetNodeId;
		_outputArguments[1] = addResults;
		return result;
	}
}
