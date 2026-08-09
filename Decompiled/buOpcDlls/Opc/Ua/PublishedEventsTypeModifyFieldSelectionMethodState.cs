using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedEventsTypeModifyFieldSelectionMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAMQAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVNb2RpZnlGaWVsZFNlbGVjdGlvbk1ldGhvZFR5cGUBAM46AC8BAM46zjoAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDPOgAuAETPOgAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ48AC4ARJ48AACWAQAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public PublishedEventsTypeModifyFieldSelectionMethodStateMethodCallHandler OnCall;

	public PublishedEventsTypeModifyFieldSelectionMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PublishedEventsTypeModifyFieldSelectionMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAMQAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVNb2RpZnlGaWVsZFNlbGVjdGlvbk1ldGhvZFR5cGUBAM46AC8BAM46zjoAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDPOgAuAETPOgAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ48AC4ARJ48AACWAQAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		ConfigurationVersionDataType configurationVersion = (ConfigurationVersionDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		string[] fieldNameAliases = (string[])_inputArguments[1];
		bool[] promotedFields = (bool[])_inputArguments[2];
		SimpleAttributeOperand[] selectedFields = (SimpleAttributeOperand[])ExtensionObject.ToArray(_inputArguments[3], typeof(SimpleAttributeOperand));
		ConfigurationVersionDataType newConfigurationVersion = (ConfigurationVersionDataType)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, fieldNameAliases, promotedFields, selectedFields, ref newConfigurationVersion);
		}
		_outputArguments[0] = newConfigurationVersion;
		return result;
	}
}
