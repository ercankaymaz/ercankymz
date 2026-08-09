using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubGroupTypeRemoveWriterMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAJQAAAFB1YlN1Ykdyb3VwVHlwZVJlbW92ZVdyaXRlck1ldGhvZFR5cGUBAB85AC8BAB85HzkAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAgOQAuAEQgOQAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public PubSubGroupTypeRemoveWriterMethodStateMethodCallHandler OnCall;

	public PubSubGroupTypeRemoveWriterMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubGroupTypeRemoveWriterMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAJQAAAFB1YlN1Ykdyb3VwVHlwZVJlbW92ZVdyaXRlck1ldGhvZFR5cGUBAB85AC8BAB85HzkAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAgOQAuAEQgOQAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		NodeId dataSetWriterNodeId = (NodeId)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, dataSetWriterNodeId);
		}
		return result;
	}
}
