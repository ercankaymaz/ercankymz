using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubConnectionAddReaderGroupGroupMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAALQAAAFB1YlN1YkNvbm5lY3Rpb25BZGRSZWFkZXJHcm91cEdyb3VwTWV0aG9kVHlwZQEA3kQALwEA3kTeRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN9EAC4ARN9EAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQCgPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADhFAC4ARDhFAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public PubSubConnectionAddReaderGroupGroupMethodStateMethodCallHandler OnCall;

	public PubSubConnectionAddReaderGroupGroupMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PubSubConnectionAddReaderGroupGroupMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAALQAAAFB1YlN1YkNvbm5lY3Rpb25BZGRSZWFkZXJHcm91cEdyb3VwTWV0aG9kVHlwZQEA3kQALwEA3kTeRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN9EAC4ARN9EAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQCgPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADhFAC4ARDhFAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		ReaderGroupDataType configuration = (ReaderGroupDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		NodeId groupId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configuration, ref groupId);
		}
		_outputArguments[0] = groupId;
		return result;
	}
}
