using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataItemState : BaseDataVariableState
{
	private const string Definition_InitializationString = "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BAD4JAC4ARD4JAAAADP////8BAf////8AAAAA";

	private const string ValuePrecision_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFZhbHVlUHJlY2lzaW9uAQA/CQAuAEQ/CQAAAAv/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIECAgAAAAAAFAAAAERhdGFJdGVtVHlwZUluc3RhbmNlAQA9CQEAPQk9CQAAABgBAf////8CAAAAFWCJCgIAAAAAAAoAAABEZWZpbml0aW9uAQA+CQAuAEQ+CQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVmFsdWVQcmVjaXNpb24BAD8JAC4ARD8JAAAAC/////8BAf////8AAAAA";

	private PropertyState<string> m_definition;

	private PropertyState<double> m_valuePrecision;

	public PropertyState<string> Definition
	{
		get
		{
			return m_definition;
		}
		set
		{
			if (m_definition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_definition = value;
		}
	}

	public PropertyState<double> ValuePrecision
	{
		get
		{
			return m_valuePrecision;
		}
		set
		{
			if (m_valuePrecision != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_valuePrecision = value;
		}
	}

	public DataItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2365u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -2;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAFAAAAERhdGFJdGVtVHlwZUluc3RhbmNlAQA9CQEAPQk9CQAAABgBAf////8CAAAAFWCJCgIAAAAAAAoAAABEZWZpbml0aW9uAQA+CQAuAEQ+CQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVmFsdWVQcmVjaXNpb24BAD8JAC4ARD8JAAAAC/////8BAf////8AAAAA");
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
		if (Definition != null)
		{
			Definition.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BAD4JAC4ARD4JAAAADP////8BAf////8AAAAA");
		}
		if (ValuePrecision != null)
		{
			ValuePrecision.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFZhbHVlUHJlY2lzaW9uAQA/CQAuAEQ/CQAAAAv/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_definition != null)
		{
			children.Add(m_definition);
		}
		if (m_valuePrecision != null)
		{
			children.Add(m_valuePrecision);
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
		if (!(name == "Definition"))
		{
			if (name == "ValuePrecision")
			{
				if (createOrReplace && ValuePrecision == null)
				{
					if (replacement == null)
					{
						ValuePrecision = new PropertyState<double>(this);
					}
					else
					{
						ValuePrecision = (PropertyState<double>)replacement;
					}
				}
				baseInstanceState = ValuePrecision;
			}
		}
		else
		{
			if (createOrReplace && Definition == null)
			{
				if (replacement == null)
				{
					Definition = new PropertyState<string>(this);
				}
				else
				{
					Definition = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = Definition;
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
public class DataItemState<T> : DataItemState
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

	public DataItemState(NodeState parent)
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
