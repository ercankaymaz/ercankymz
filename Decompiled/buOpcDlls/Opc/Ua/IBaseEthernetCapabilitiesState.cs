using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IBaseEthernetCapabilitiesState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAElCYXNlRXRoZXJuZXRDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBAGdeAQBnXmdeAAD/////AQAAABVgiQoCAAAAAAAOAAAAVmxhblRhZ0NhcGFibGUBAGheAC8AP2heAAAAAf////8BAf////8AAAAA";

	private BaseDataVariableState<bool> m_vlanTagCapable;

	public BaseDataVariableState<bool> VlanTagCapable
	{
		get
		{
			return m_vlanTagCapable;
		}
		set
		{
			if (m_vlanTagCapable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_vlanTagCapable = value;
		}
	}

	public IBaseEthernetCapabilitiesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24167u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAElCYXNlRXRoZXJuZXRDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBAGdeAQBnXmdeAAD/////AQAAABVgiQoCAAAAAAAOAAAAVmxhblRhZ0NhcGFibGUBAGheAC8AP2heAAAAAf////8BAf////8AAAAA");
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
		if (m_vlanTagCapable != null)
		{
			children.Add(m_vlanTagCapable);
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
		if (browseName.Name == "VlanTagCapable")
		{
			if (createOrReplace && VlanTagCapable == null)
			{
				if (replacement == null)
				{
					VlanTagCapable = new BaseDataVariableState<bool>(this);
				}
				else
				{
					VlanTagCapable = (BaseDataVariableState<bool>)replacement;
				}
			}
			baseInstanceState = VlanTagCapable;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
