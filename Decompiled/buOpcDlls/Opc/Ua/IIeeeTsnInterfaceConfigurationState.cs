using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeTsnInterfaceConfigurationState : BaseInterfaceState
{
	private const string InterfaceName_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEludGVyZmFjZU5hbWUBAH5eAC8AP35eAAAADP////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAfF4BAHxefF4AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQB9XgAvAD99XgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAASW50ZXJmYWNlTmFtZQEAfl4ALwA/fl4AAAAM/////wEB/////wAAAAA=";

	private BaseDataVariableState<string> m_macAddress;

	private BaseDataVariableState<string> m_interfaceName;

	public BaseDataVariableState<string> MacAddress
	{
		get
		{
			return m_macAddress;
		}
		set
		{
			if (m_macAddress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_macAddress = value;
		}
	}

	public BaseDataVariableState<string> InterfaceName
	{
		get
		{
			return m_interfaceName;
		}
		set
		{
			if (m_interfaceName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_interfaceName = value;
		}
	}

	public IIeeeTsnInterfaceConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24188u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAfF4BAHxefF4AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQB9XgAvAD99XgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAASW50ZXJmYWNlTmFtZQEAfl4ALwA/fl4AAAAM/////wEB/////wAAAAA=");
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
		if (InterfaceName != null)
		{
			InterfaceName.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEludGVyZmFjZU5hbWUBAH5eAC8AP35eAAAADP////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_macAddress != null)
		{
			children.Add(m_macAddress);
		}
		if (m_interfaceName != null)
		{
			children.Add(m_interfaceName);
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
		if (!(name == "MacAddress"))
		{
			if (name == "InterfaceName")
			{
				if (createOrReplace && InterfaceName == null)
				{
					if (replacement == null)
					{
						InterfaceName = new BaseDataVariableState<string>(this);
					}
					else
					{
						InterfaceName = (BaseDataVariableState<string>)replacement;
					}
				}
				baseInstanceState = InterfaceName;
			}
		}
		else
		{
			if (createOrReplace && MacAddress == null)
			{
				if (replacement == null)
				{
					MacAddress = new BaseDataVariableState<string>(this);
				}
				else
				{
					MacAddress = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = MacAddress;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
