using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubGroupTypeAddWriterMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAIgAAAFB1YlN1Ykdyb3VwVHlwZUFkZFdyaXRlck1ldGhvZFR5cGUBAEpGAC8BAEpGSkYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBLRgAuAERLRgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEA7Tz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBMRgAuAERMRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public PubSubGroupTypeAddWriterMethodStateMethodCallHandler OnCall;

	public PubSubGroupTypeAddWriterMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubGroupTypeAddWriterMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAIgAAAFB1YlN1Ykdyb3VwVHlwZUFkZFdyaXRlck1ldGhvZFR5cGUBAEpGAC8BAEpGSkYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBLRgAuAERLRgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEA7Tz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBMRgAuAERMRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		DataSetWriterDataType configuration = (DataSetWriterDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		NodeId dataSetWriterNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configuration, ref dataSetWriterNodeId);
		}
		_outputArguments[0] = dataSetWriterNodeId;
		return result;
	}
}
