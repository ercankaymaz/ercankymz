using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SecurityGroupFolderState : FolderState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNlY3VyaXR5R3JvdXBGb2xkZXJUeXBlSW5zdGFuY2UBAFw8AQBcPFw8AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAZTwALwEAZTxlPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGY8AC4ARGY8AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBnPAAuAERnPAAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAGg8AC8BAGg8aDwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBpPAAuAERpPAAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private AddSecurityGroupMethodState m_addSecurityGroupMethod;

	private RemoveSecurityGroupMethodState m_removeSecurityGroupMethod;

	public AddSecurityGroupMethodState AddSecurityGroup
	{
		get
		{
			return m_addSecurityGroupMethod;
		}
		set
		{
			if (m_addSecurityGroupMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addSecurityGroupMethod = value;
		}
	}

	public RemoveSecurityGroupMethodState RemoveSecurityGroup
	{
		get
		{
			return m_removeSecurityGroupMethod;
		}
		set
		{
			if (m_removeSecurityGroupMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeSecurityGroupMethod = value;
		}
	}

	public SecurityGroupFolderState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15452u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlY3VyaXR5R3JvdXBGb2xkZXJUeXBlSW5zdGFuY2UBAFw8AQBcPFw8AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAZTwALwEAZTxlPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGY8AC4ARGY8AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBnPAAuAERnPAAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAGg8AC8BAGg8aDwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBpPAAuAERpPAAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_addSecurityGroupMethod != null)
		{
			children.Add(m_addSecurityGroupMethod);
		}
		if (m_removeSecurityGroupMethod != null)
		{
			children.Add(m_removeSecurityGroupMethod);
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
		if (!(name == "AddSecurityGroup"))
		{
			if (name == "RemoveSecurityGroup")
			{
				if (createOrReplace && RemoveSecurityGroup == null)
				{
					if (replacement == null)
					{
						RemoveSecurityGroup = new RemoveSecurityGroupMethodState(this);
					}
					else
					{
						RemoveSecurityGroup = (RemoveSecurityGroupMethodState)replacement;
					}
				}
				baseInstanceState = RemoveSecurityGroup;
			}
		}
		else
		{
			if (createOrReplace && AddSecurityGroup == null)
			{
				if (replacement == null)
				{
					AddSecurityGroup = new AddSecurityGroupMethodState(this);
				}
				else
				{
					AddSecurityGroup = (AddSecurityGroupMethodState)replacement;
				}
			}
			baseInstanceState = AddSecurityGroup;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
