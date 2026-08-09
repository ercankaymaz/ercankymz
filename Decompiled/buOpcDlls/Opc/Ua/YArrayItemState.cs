using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class YArrayItemState : ArrayItemState
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAFgAAAFlBcnJheUl0ZW1UeXBlSW5zdGFuY2UBAP0uAQD9Lv0uAAAAGAEAAAABAAAAAAAAAAEB/////wUAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAAEvAC4ARAEvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAAIvAC4ARAIvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQADLwAuAEQDLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEABC8ALgBEBC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAFLwAuAEQFLwAAAQAvL/////8BAf////8AAAAA";

	private PropertyState<AxisInformation> m_xAxisDefinition;

	public PropertyState<AxisInformation> XAxisDefinition
	{
		get
		{
			return m_xAxisDefinition;
		}
		set
		{
			if (m_xAxisDefinition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_xAxisDefinition = value;
		}
	}

	public YArrayItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12029u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 2;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAFgAAAFlBcnJheUl0ZW1UeXBlSW5zdGFuY2UBAP0uAQD9Lv0uAAAAGAEAAAABAAAAAAAAAAEB/////wUAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAAEvAC4ARAEvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAAIvAC4ARAIvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQADLwAuAEQDLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEABC8ALgBEBC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAFLwAuAEQFLwAAAQAvL/////8BAf////8AAAAA");
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
		if (m_xAxisDefinition != null)
		{
			children.Add(m_xAxisDefinition);
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
		if (browseName.Name == "XAxisDefinition")
		{
			if (createOrReplace && XAxisDefinition == null)
			{
				if (replacement == null)
				{
					XAxisDefinition = new PropertyState<AxisInformation>(this);
				}
				else
				{
					XAxisDefinition = (PropertyState<AxisInformation>)replacement;
				}
			}
			baseInstanceState = XAxisDefinition;
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
public class YArrayItemState<T> : YArrayItemState
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

	public YArrayItemState(NodeState parent)
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
