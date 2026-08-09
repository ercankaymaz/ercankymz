using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionVariableState : BaseDataVariableState
{
	private const string InitializationString = "//////////8VYIECAgAAAAAAHQAAAENvbmRpdGlvblZhcmlhYmxlVHlwZUluc3RhbmNlAQAqIwEAKiMqIwAAABgBAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABACsjAC4ARCsjAAABACYB/////wEB/////wAAAAA=";

	private PropertyState<DateTime> m_sourceTimestamp;

	public PropertyState<DateTime> SourceTimestamp
	{
		get
		{
			return m_sourceTimestamp;
		}
		set
		{
			if (m_sourceTimestamp != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sourceTimestamp = value;
		}
	}

	public ConditionVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(9002u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAHQAAAENvbmRpdGlvblZhcmlhYmxlVHlwZUluc3RhbmNlAQAqIwEAKiMqIwAAABgBAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABACsjAC4ARCsjAAABACYB/////wEB/////wAAAAA=");
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
		if (m_sourceTimestamp != null)
		{
			children.Add(m_sourceTimestamp);
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
		if (browseName.Name == "SourceTimestamp")
		{
			if (createOrReplace && SourceTimestamp == null)
			{
				if (replacement == null)
				{
					SourceTimestamp = new PropertyState<DateTime>(this);
				}
				else
				{
					SourceTimestamp = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = SourceTimestamp;
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
public class ConditionVariableState<T> : ConditionVariableState
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

	public ConditionVariableState(NodeState parent)
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
