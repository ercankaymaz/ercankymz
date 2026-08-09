using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AliasNameCategoryState : FolderState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEFsaWFzTmFtZUNhdGVnb3J5VHlwZUluc3RhbmNlAQCgWwEAoFugWwAA/////wEAAAAEYYIKBAAAAAAACQAAAEZpbmRBbGlhcwEAplsALwEAplumWwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKdbAC4ARKdbAACWAgAAAAEAKgEBJQAAABYAAABBbGlhc05hbWVTZWFyY2hQYXR0ZXJuAAz/////AAAAAAABACoBASIAAAATAAAAUmVmZXJlbmNlVHlwZUZpbHRlcgAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqFsALgBEqFsAAJYBAAAAAQAqAQEiAAAADQAAAEFsaWFzTm9kZUxpc3QBAKxbAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private FindAliasMethodState m_findAliasMethod;

	public FindAliasMethodState FindAlias
	{
		get
		{
			return m_findAliasMethod;
		}
		set
		{
			if (m_findAliasMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_findAliasMethod = value;
		}
	}

	public AliasNameCategoryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23456u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEFsaWFzTmFtZUNhdGVnb3J5VHlwZUluc3RhbmNlAQCgWwEAoFugWwAA/////wEAAAAEYYIKBAAAAAAACQAAAEZpbmRBbGlhcwEAplsALwEAplumWwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKdbAC4ARKdbAACWAgAAAAEAKgEBJQAAABYAAABBbGlhc05hbWVTZWFyY2hQYXR0ZXJuAAz/////AAAAAAABACoBASIAAAATAAAAUmVmZXJlbmNlVHlwZUZpbHRlcgAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqFsALgBEqFsAAJYBAAAAAQAqAQEiAAAADQAAAEFsaWFzTm9kZUxpc3QBAKxbAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_findAliasMethod != null)
		{
			children.Add(m_findAliasMethod);
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
		if (browseName.Name == "FindAlias")
		{
			if (createOrReplace && FindAlias == null)
			{
				if (replacement == null)
				{
					FindAlias = new FindAliasMethodState(this);
				}
				else
				{
					FindAlias = (FindAliasMethodState)replacement;
				}
			}
			baseInstanceState = FindAlias;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
