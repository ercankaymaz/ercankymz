using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ExpressionGuardVariableState : GuardVariableState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAIwAAAEV4cHJlc3Npb25HdWFyZFZhcmlhYmxlVHlwZUluc3RhbmNlAQAYOwEAGDsYOwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAKAAAARXhwcmVzc2lvbgEAGTsALgBEGTsAAAEASgL/////AQH/////AAAAAA==";

	private PropertyState<ContentFilter> m_expression;

	public PropertyState<ContentFilter> Expression
	{
		get
		{
			return m_expression;
		}
		set
		{
			if (m_expression != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_expression = value;
		}
	}

	public ExpressionGuardVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15128u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAIwAAAEV4cHJlc3Npb25HdWFyZFZhcmlhYmxlVHlwZUluc3RhbmNlAQAYOwEAGDsYOwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAKAAAARXhwcmVzc2lvbgEAGTsALgBEGTsAAAEASgL/////AQH/////AAAAAA==");
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
		if (m_expression != null)
		{
			children.Add(m_expression);
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
		if (browseName.Name == "Expression")
		{
			if (createOrReplace && Expression == null)
			{
				if (replacement == null)
				{
					Expression = new PropertyState<ContentFilter>(this);
				}
				else
				{
					Expression = (PropertyState<ContentFilter>)replacement;
				}
			}
			baseInstanceState = Expression;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
