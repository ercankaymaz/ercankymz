using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RoleSetState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAEwAAAFJvbGVTZXRUeXBlSW5zdGFuY2UBAPc8AQD3PPc8AAD/////AgAAAARhggoEAAAAAAAHAAAAQWRkUm9sZQEAfT4ALwEAfT59PgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH4+AC4ARH4+AACWAgAAAAEAKgEBFwAAAAgAAABSb2xlTmFtZQAM/////wAAAAAAAQAqAQEbAAAADAAAAE5hbWVzcGFjZVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAfz4ALgBEfz4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABSZW1vdmVSb2xlAQCAPgAvAQCAPoA+AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgT4ALgBEgT4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private AddRoleMethodState m_addRoleMethod;

	private RemoveRoleMethodState m_removeRoleMethod;

	public AddRoleMethodState AddRole
	{
		get
		{
			return m_addRoleMethod;
		}
		set
		{
			if (m_addRoleMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addRoleMethod = value;
		}
	}

	public RemoveRoleMethodState RemoveRole
	{
		get
		{
			return m_removeRoleMethod;
		}
		set
		{
			if (m_removeRoleMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeRoleMethod = value;
		}
	}

	public RoleSetState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15607u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAEwAAAFJvbGVTZXRUeXBlSW5zdGFuY2UBAPc8AQD3PPc8AAD/////AgAAAARhggoEAAAAAAAHAAAAQWRkUm9sZQEAfT4ALwEAfT59PgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH4+AC4ARH4+AACWAgAAAAEAKgEBFwAAAAgAAABSb2xlTmFtZQAM/////wAAAAAAAQAqAQEbAAAADAAAAE5hbWVzcGFjZVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAfz4ALgBEfz4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABSZW1vdmVSb2xlAQCAPgAvAQCAPoA+AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgT4ALgBEgT4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_addRoleMethod != null)
		{
			children.Add(m_addRoleMethod);
		}
		if (m_removeRoleMethod != null)
		{
			children.Add(m_removeRoleMethod);
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
		string name = browseName.Name;
		if (!(name == "AddRole"))
		{
			if (name == "RemoveRole")
			{
				if (createOrReplace && RemoveRole == null)
				{
					if (replacement == null)
					{
						RemoveRole = new RemoveRoleMethodState(this);
					}
					else
					{
						RemoveRole = (RemoveRoleMethodState)replacement;
					}
				}
				baseInstanceState = RemoveRole;
			}
		}
		else
		{
			if (createOrReplace && AddRole == null)
			{
				if (replacement == null)
				{
					AddRole = new AddRoleMethodState(this);
				}
				else
				{
					AddRole = (AddRoleMethodState)replacement;
				}
			}
			baseInstanceState = AddRole;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
