using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddPublishedDataItemsMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAHwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc01ldGhvZFR5cGUBAKU4AC8BAKU4pTgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCmOAAuAESmOAAAlgQAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCnOAAuAESnOAAAlgMAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public AddPublishedDataItemsMethodStateMethodCallHandler OnCall;

	public AddPublishedDataItemsMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new AddPublishedDataItemsMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAHwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc01ldGhvZFR5cGUBAKU4AC8BAKU4pTgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCmOAAuAESmOAAAlgQAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCnOAAuAESnOAAAlgMAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		string[] fieldNameAliases = (string[])_inputArguments[1];
		ushort[] fieldFlags = (ushort[])_inputArguments[2];
		PublishedVariableDataType[] variablesToAdd = (PublishedVariableDataType[])ExtensionObject.ToArray(_inputArguments[3], typeof(PublishedVariableDataType));
		NodeId dataSetNodeId = (NodeId)_outputArguments[0];
		ConfigurationVersionDataType configurationVersion = (ConfigurationVersionDataType)_outputArguments[1];
		StatusCode[] addResults = (StatusCode[])_outputArguments[2];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, name, fieldNameAliases, fieldFlags, variablesToAdd, ref dataSetNodeId, ref configurationVersion, ref addResults);
		}
		_outputArguments[0] = dataSetNodeId;
		_outputArguments[1] = configurationVersion;
		_outputArguments[2] = addResults;
		return result;
	}
}
