using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetReaderTypeCreateDataSetMirrorMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAALgAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlRGF0YVNldE1pcnJvck1ldGhvZFR5cGUBAPNDAC8BAPND80MAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QwAuAET0QwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQD1QwAuAET1QwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public DataSetReaderTypeCreateDataSetMirrorMethodStateMethodCallHandler OnCall;

	public DataSetReaderTypeCreateDataSetMirrorMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new DataSetReaderTypeCreateDataSetMirrorMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAALgAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlRGF0YVNldE1pcnJvck1ldGhvZFR5cGUBAPNDAC8BAPND80MAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QwAuAET0QwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQD1QwAuAET1QwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		string parentNodeName = (string)_inputArguments[0];
		RolePermissionType[] rolePermissions = (RolePermissionType[])ExtensionObject.ToArray(_inputArguments[1], typeof(RolePermissionType));
		NodeId parentNodeId = (NodeId)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, parentNodeName, rolePermissions, ref parentNodeId);
		}
		_outputArguments[0] = parentNodeId;
		return result;
	}
}
