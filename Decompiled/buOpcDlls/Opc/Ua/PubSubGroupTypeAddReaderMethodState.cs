using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubGroupTypeAddReaderMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAIgAAAFB1YlN1Ykdyb3VwVHlwZUFkZFJlYWRlck1ldGhvZFR5cGUBAF9SAC8BAF9SX1IAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBgUgAuAERgUgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEABz3/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBhUgAuAERhUgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFJlYWRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public PubSubGroupTypeAddReaderMethodStateMethodCallHandler OnCall;

	public PubSubGroupTypeAddReaderMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubGroupTypeAddReaderMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAIgAAAFB1YlN1Ykdyb3VwVHlwZUFkZFJlYWRlck1ldGhvZFR5cGUBAF9SAC8BAF9SX1IAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBgUgAuAERgUgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEABz3/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBhUgAuAERhUgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFJlYWRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		DataSetReaderDataType configuration = (DataSetReaderDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		NodeId dataSetReaderNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configuration, ref dataSetReaderNodeId);
		}
		_outputArguments[0] = dataSetReaderNodeId;
		return result;
	}
}
