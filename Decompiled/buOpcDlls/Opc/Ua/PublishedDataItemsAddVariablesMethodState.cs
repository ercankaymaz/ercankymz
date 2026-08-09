using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedDataItemsAddVariablesMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAKAAAAFB1Ymxpc2hlZERhdGFJdGVtc0FkZFZhcmlhYmxlc01ldGhvZFR5cGUBAOQ4AC8BAOQ45DgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDlOAAuAETlOAAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOY4AC4AROY4AACWAgAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBAR0AAAAKAAAAQWRkUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	public PublishedDataItemsAddVariablesMethodStateMethodCallHandler OnCall;

	public PublishedDataItemsAddVariablesMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new PublishedDataItemsAddVariablesMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAKAAAAFB1Ymxpc2hlZERhdGFJdGVtc0FkZFZhcmlhYmxlc01ldGhvZFR5cGUBAOQ4AC8BAOQ45DgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDlOAAuAETlOAAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOY4AC4AROY4AACWAgAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBAR0AAAAKAAAAQWRkUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		PublishedVariableDataType[] variablesToAdd = (PublishedVariableDataType[])ExtensionObject.ToArray(_inputArguments[3], typeof(PublishedVariableDataType));
		ConfigurationVersionDataType newConfigurationVersion = (ConfigurationVersionDataType)_outputArguments[0];
		StatusCode[] addResults = (StatusCode[])_outputArguments[1];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, fieldNameAliases, promotedFields, variablesToAdd, ref newConfigurationVersion, ref addResults);
		}
		_outputArguments[0] = newConfigurationVersion;
		_outputArguments[1] = addResults;
		return result;
	}
}
