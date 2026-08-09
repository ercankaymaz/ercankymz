using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubGroupTypeRemoveReaderMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAJQAAAFB1YlN1Ykdyb3VwVHlwZVJlbW92ZVJlYWRlck1ldGhvZFR5cGUBACE5AC8BACE5ITkAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAiOQAuAEQiOQAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFJlYWRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public PubSubGroupTypeRemoveReaderMethodStateMethodCallHandler OnCall;

	public PubSubGroupTypeRemoveReaderMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubGroupTypeRemoveReaderMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAJQAAAFB1YlN1Ykdyb3VwVHlwZVJlbW92ZVJlYWRlck1ldGhvZFR5cGUBACE5AC8BACE5ITkAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAiOQAuAEQiOQAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFJlYWRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		NodeId dataSetReaderNodeId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, dataSetReaderNodeId);
		}
		return result;
	}
}
