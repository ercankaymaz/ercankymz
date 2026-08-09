using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class KeyCredentialConfigurationFolderState : FolderState
{
	private const string CreateCredential_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uRm9sZGVyVHlwZUluc3RhbmNlAQBYRAEAWERYRAAA/////wEAAAAEYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private CreateCredentialMethodState m_createCredentialMethod;

	public CreateCredentialMethodState CreateCredential
	{
		get
		{
			return m_createCredentialMethod;
		}
		set
		{
			if (m_createCredentialMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createCredentialMethod = value;
		}
	}

	public KeyCredentialConfigurationFolderState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17496u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALAAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uRm9sZGVyVHlwZUluc3RhbmNlAQBYRAEAWERYRAAA/////wEAAAAEYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (CreateCredential != null)
		{
			CreateCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_createCredentialMethod != null)
		{
			children.Add(m_createCredentialMethod);
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
		if (browseName.Name == "CreateCredential")
		{
			if (createOrReplace && CreateCredential == null)
			{
				if (replacement == null)
				{
					CreateCredential = new CreateCredentialMethodState(this);
				}
				else
				{
					CreateCredential = (CreateCredentialMethodState)replacement;
				}
			}
			baseInstanceState = CreateCredential;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
