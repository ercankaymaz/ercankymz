using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TimedShelveMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAFQAAAFRpbWVkU2hlbHZlTWV0aG9kVHlwZQEA1hcALwEA1hfWFwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANcXAC4ARNcXAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public TimedShelveMethodStateMethodCallHandler OnCall;

	public TimedShelveMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new TimedShelveMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAFRpbWVkU2hlbHZlTWV0aG9kVHlwZQEA1hcALwEA1hfWFwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANcXAC4ARNcXAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		double shelvingTime = (double)_inputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, shelvingTime);
		}
		return result;
	}
}
