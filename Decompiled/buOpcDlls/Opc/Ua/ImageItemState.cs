using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ImageItemState : ArrayItemState
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAFQAAAEltYWdlSXRlbVR5cGVJbnN0YW5jZQEADy8BAA8vDy8AAAAYAgAAAAIAAAAAAAAAAAAAAAEB/////wYAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBABMvAC4ARBMvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBABQvAC4ARBQvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAVLwAuAEQVLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAFi8ALgBEFi8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAXLwAuAEQXLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BABgvAC4ARBgvAAABAC8v/////wEB/////wAAAAA=";

	private PropertyState<AxisInformation> m_xAxisDefinition;

	private PropertyState<AxisInformation> m_yAxisDefinition;

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

	public PropertyState<AxisInformation> YAxisDefinition
	{
		get
		{
			return m_yAxisDefinition;
		}
		set
		{
			if (m_yAxisDefinition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_yAxisDefinition = value;
		}
	}

	public ImageItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12047u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 3;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAFQAAAEltYWdlSXRlbVR5cGVJbnN0YW5jZQEADy8BAA8vDy8AAAAYAgAAAAIAAAAAAAAAAAAAAAEB/////wYAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBABMvAC4ARBMvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBABQvAC4ARBQvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAVLwAuAEQVLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAFi8ALgBEFi8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAXLwAuAEQXLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BABgvAC4ARBgvAAABAC8v/////wEB/////wAAAAA=");
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
		if (m_yAxisDefinition != null)
		{
			children.Add(m_yAxisDefinition);
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
		if (!(name == "XAxisDefinition"))
		{
			if (name == "YAxisDefinition")
			{
				if (createOrReplace && YAxisDefinition == null)
				{
					if (replacement == null)
					{
						YAxisDefinition = new PropertyState<AxisInformation>(this);
					}
					else
					{
						YAxisDefinition = (PropertyState<AxisInformation>)replacement;
					}
				}
				baseInstanceState = YAxisDefinition;
			}
		}
		else
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
public class ImageItemState<T> : ImageItemState
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

	public ImageItemState(NodeState parent)
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
