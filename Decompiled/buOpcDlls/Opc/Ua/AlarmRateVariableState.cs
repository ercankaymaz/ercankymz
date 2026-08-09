using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AlarmRateVariableState : BaseDataVariableState<double>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAEFsYXJtUmF0ZVZhcmlhYmxlVHlwZUluc3RhbmNlAQB9QwEAfUN9QwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAfkMALgBEfkMAAAAF/////wEB/////wAAAAA=";

	private PropertyState<ushort> m_rate;

	public PropertyState<ushort> Rate
	{
		get
		{
			return m_rate;
		}
		set
		{
			if (m_rate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_rate = value;
		}
	}

	public AlarmRateVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17277u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAEFsYXJtUmF0ZVZhcmlhYmxlVHlwZUluc3RhbmNlAQB9QwEAfUN9QwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAfkMALgBEfkMAAAAF/////wEB/////wAAAAA=");
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
		if (m_rate != null)
		{
			children.Add(m_rate);
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
		if (browseName.Name == "Rate")
		{
			if (createOrReplace && Rate == null)
			{
				if (replacement == null)
				{
					Rate = new PropertyState<ushort>(this);
				}
				else
				{
					Rate = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = Rate;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
