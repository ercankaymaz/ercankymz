using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedDataItemsState : PublishedDataSetState
{
	private const string AddVariables_InitializationString = "//////////8EYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string RemoveVariables_InitializationString = "//////////8EYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFB1Ymxpc2hlZERhdGFJdGVtc1R5cGVJbnN0YW5jZQEAxjgBAMY4xjgAAP////8FAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA0DgALgBE0DgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCFOwAuAESFOwAAAQC7OP////8BAf////8AAAAAF2CJCgIAAAAAAA0AAABQdWJsaXNoZWREYXRhAQDUOAAuAETUOAAAAQDBNwEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<PublishedVariableDataType[]> m_publishedData;

	private PublishedDataItemsAddVariablesMethodState m_addVariablesMethod;

	private PublishedDataItemsRemoveVariablesMethodState m_removeVariablesMethod;

	public PropertyState<PublishedVariableDataType[]> PublishedData
	{
		get
		{
			return m_publishedData;
		}
		set
		{
			if (m_publishedData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishedData = value;
		}
	}

	public PublishedDataItemsAddVariablesMethodState AddVariables
	{
		get
		{
			return m_addVariablesMethod;
		}
		set
		{
			if (m_addVariablesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addVariablesMethod = value;
		}
	}

	public PublishedDataItemsRemoveVariablesMethodState RemoveVariables
	{
		get
		{
			return m_removeVariablesMethod;
		}
		set
		{
			if (m_removeVariablesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeVariablesMethod = value;
		}
	}

	public PublishedDataItemsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14534u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFB1Ymxpc2hlZERhdGFJdGVtc1R5cGVJbnN0YW5jZQEAxjgBAMY4xjgAAP////8FAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA0DgALgBE0DgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCFOwAuAESFOwAAAQC7OP////8BAf////8AAAAAF2CJCgIAAAAAAA0AAABQdWJsaXNoZWREYXRhAQDUOAAuAETUOAAAAQDBNwEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
		if (AddVariables != null)
		{
			AddVariables.Initialize(context, "//////////8EYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (RemoveVariables != null)
		{
			RemoveVariables.Initialize(context, "//////////8EYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_publishedData != null)
		{
			children.Add(m_publishedData);
		}
		if (m_addVariablesMethod != null)
		{
			children.Add(m_addVariablesMethod);
		}
		if (m_removeVariablesMethod != null)
		{
			children.Add(m_removeVariablesMethod);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "PublishedData":
			if (createOrReplace && PublishedData == null)
			{
				if (replacement == null)
				{
					PublishedData = new PropertyState<PublishedVariableDataType[]>(this);
				}
				else
				{
					PublishedData = (PropertyState<PublishedVariableDataType[]>)replacement;
				}
			}
			baseInstanceState = PublishedData;
			break;
		case "AddVariables":
			if (createOrReplace && AddVariables == null)
			{
				if (replacement == null)
				{
					AddVariables = new PublishedDataItemsAddVariablesMethodState(this);
				}
				else
				{
					AddVariables = (PublishedDataItemsAddVariablesMethodState)replacement;
				}
			}
			baseInstanceState = AddVariables;
			break;
		case "RemoveVariables":
			if (createOrReplace && RemoveVariables == null)
			{
				if (replacement == null)
				{
					RemoveVariables = new PublishedDataItemsRemoveVariablesMethodState(this);
				}
				else
				{
					RemoveVariables = (PublishedDataItemsRemoveVariablesMethodState)replacement;
				}
			}
			baseInstanceState = RemoveVariables;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
