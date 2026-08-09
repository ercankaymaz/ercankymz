using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NDimensionArrayItemState : ArrayItemState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHwAAAE5EaW1lbnNpb25BcnJheUl0ZW1UeXBlSW5zdGFuY2UBACQvAQAkLyQvAAAAGAAAAAABAf////8FAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQAoLwAuAEQoLwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQApLwAuAEQpLwAAAQB3A/////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABUaXRsZQEAKi8ALgBEKi8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEF4aXNTY2FsZVR5cGUBACsvAC4ARCsvAAABAC0v/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAEF4aXNEZWZpbml0aW9uAQAsLwAuAEQsLwAAAQAvLwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<AxisInformation[]> m_axisDefinition;

	public PropertyState<AxisInformation[]> AxisDefinition
	{
		get
		{
			return m_axisDefinition;
		}
		set
		{
			if (m_axisDefinition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_axisDefinition = value;
		}
	}

	public NDimensionArrayItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12068u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 0;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHwAAAE5EaW1lbnNpb25BcnJheUl0ZW1UeXBlSW5zdGFuY2UBACQvAQAkLyQvAAAAGAAAAAABAf////8FAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQAoLwAuAEQoLwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQApLwAuAEQpLwAAAQB3A/////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABUaXRsZQEAKi8ALgBEKi8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEF4aXNTY2FsZVR5cGUBACsvAC4ARCsvAAABAC0v/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAEF4aXNEZWZpbml0aW9uAQAsLwAuAEQsLwAAAQAvLwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_axisDefinition != null)
		{
			children.Add(m_axisDefinition);
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
		if (browseName.Name == "AxisDefinition")
		{
			if (createOrReplace && AxisDefinition == null)
			{
				if (replacement == null)
				{
					AxisDefinition = new PropertyState<AxisInformation[]>(this);
				}
				else
				{
					AxisDefinition = (PropertyState<AxisInformation[]>)replacement;
				}
			}
			baseInstanceState = AxisDefinition;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NDimensionArrayItemState<T> : NDimensionArrayItemState
{
	public new T Value
	{
		get
		{
			return BaseVariableState.CheckTypeBeforeCast<T>(base.Value, throwOnError: true);
		}
		set
		{
			base.Value = value;
		}
	}

	public NDimensionArrayItemState(NodeState parent)
		: base(parent)
	{
		Value = default(T);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Value = default(T);
		base.DataType = TypeInfo.GetDataTypeId(typeof(T));
		base.ValueRank = TypeInfo.GetValueRank(typeof(T));
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}
}
