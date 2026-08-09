using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeTsnVlanTagState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAElJZWVlVHNuVmxhblRhZ1R5cGVJbnN0YW5jZQEAil4BAIpeil4AAP////8CAAAAFWCJCgIAAAAAAAYAAABWbGFuSWQBAIteAC8AP4teAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABQcmlvcml0eUNvZGVQb2ludAEAjF4ALwA/jF4AAAAD/////wEB/////wAAAAA=";

	private BaseDataVariableState<ushort> m_vlanId;

	private BaseDataVariableState<byte> m_priorityCodePoint;

	public BaseDataVariableState<ushort> VlanId
	{
		get
		{
			return m_vlanId;
		}
		set
		{
			if (m_vlanId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_vlanId = value;
		}
	}

	public BaseDataVariableState<byte> PriorityCodePoint
	{
		get
		{
			return m_priorityCodePoint;
		}
		set
		{
			if (m_priorityCodePoint != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priorityCodePoint = value;
		}
	}

	public IIeeeTsnVlanTagState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24202u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAElJZWVlVHNuVmxhblRhZ1R5cGVJbnN0YW5jZQEAil4BAIpeil4AAP////8CAAAAFWCJCgIAAAAAAAYAAABWbGFuSWQBAIteAC8AP4teAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABQcmlvcml0eUNvZGVQb2ludAEAjF4ALwA/jF4AAAAD/////wEB/////wAAAAA=");
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
		if (m_vlanId != null)
		{
			children.Add(m_vlanId);
		}
		if (m_priorityCodePoint != null)
		{
			children.Add(m_priorityCodePoint);
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
		if (!(name == "VlanId"))
		{
			if (name == "PriorityCodePoint")
			{
				if (createOrReplace && PriorityCodePoint == null)
				{
					if (replacement == null)
					{
						PriorityCodePoint = new BaseDataVariableState<byte>(this);
					}
					else
					{
						PriorityCodePoint = (BaseDataVariableState<byte>)replacement;
					}
				}
				baseInstanceState = PriorityCodePoint;
			}
		}
		else
		{
			if (createOrReplace && VlanId == null)
			{
				if (replacement == null)
				{
					VlanId = new BaseDataVariableState<ushort>(this);
				}
				else
				{
					VlanId = (BaseDataVariableState<ushort>)replacement;
				}
			}
			baseInstanceState = VlanId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
