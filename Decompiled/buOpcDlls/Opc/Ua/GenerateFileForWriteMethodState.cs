using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GenerateFileForWriteMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHgAAAEdlbmVyYXRlRmlsZUZvcldyaXRlTWV0aG9kVHlwZQEAtj0ALwEAtj22PQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOg/AC4AROg/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBALc9AC4ARLc9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public GenerateFileForWriteMethodStateMethodCallHandler OnCall;

	public GenerateFileForWriteMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new GenerateFileForWriteMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHgAAAEdlbmVyYXRlRmlsZUZvcldyaXRlTWV0aG9kVHlwZQEAtj0ALwEAtj22PQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOg/AC4AROg/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBALc9AC4ARLc9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		object generateOptions = _inputArguments[0];
		NodeId fileNodeId = (NodeId)_outputArguments[0];
		uint fileHandle = (uint)_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, generateOptions, ref fileNodeId, ref fileHandle);
		}
		_outputArguments[0] = fileNodeId;
		_outputArguments[1] = fileHandle;
		return result;
	}
}
