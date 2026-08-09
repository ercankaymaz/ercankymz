using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CubeItemState : ArrayItemState
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAFAAAAEN1YmVJdGVtVHlwZUluc3RhbmNlAQAZLwEAGS8ZLwAAABgDAAAAAwAAAAAAAAAAAAAAAAAAAAEB/////wcAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAB0vAC4ARB0vAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAB4vAC4ARB4vAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAfLwAuAEQfLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAIC8ALgBEIC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAhLwAuAEQhLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BACIvAC4ARCIvAAABAC8v/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFpBeGlzRGVmaW5pdGlvbgEAIy8ALgBEIy8AAAEALy//////AQH/////AAAAAA==";

	private PropertyState<AxisInformation> m_xAxisDefinition;

	private PropertyState<AxisInformation> m_yAxisDefinition;

	private PropertyState<AxisInformation> m_zAxisDefinition;

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

	public PropertyState<AxisInformation> ZAxisDefinition
	{
		get
		{
			return m_zAxisDefinition;
		}
		set
		{
			if (m_zAxisDefinition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_zAxisDefinition = value;
		}
	}

	public CubeItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12057u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 4;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAFAAAAEN1YmVJdGVtVHlwZUluc3RhbmNlAQAZLwEAGS8ZLwAAABgDAAAAAwAAAAAAAAAAAAAAAAAAAAEB/////wcAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAB0vAC4ARB0vAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAB4vAC4ARB4vAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAfLwAuAEQfLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAIC8ALgBEIC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAhLwAuAEQhLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BACIvAC4ARCIvAAABAC8v/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFpBeGlzRGVmaW5pdGlvbgEAIy8ALgBEIy8AAAEALy//////AQH/////AAAAAA==");
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
		if (m_zAxisDefinition != null)
		{
			children.Add(m_zAxisDefinition);
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
		switch (browseName.Name)
		{
		case "XAxisDefinition":
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
			break;
		case "YAxisDefinition":
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
			break;
		case "ZAxisDefinition":
			if (createOrReplace && ZAxisDefinition == null)
			{
				if (replacement == null)
				{
					ZAxisDefinition = new PropertyState<AxisInformation>(this);
				}
				else
				{
					ZAxisDefinition = (PropertyState<AxisInformation>)replacement;
				}
			}
			baseInstanceState = ZAxisDefinition;
			break;
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
public class CubeItemState<T> : CubeItemState
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

	public CubeItemState(NodeState parent)
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
