using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateValueDiscreteState : DiscreteItemState
{
	private const string InitializationString = "//////////8VYIECAgAAAAAAIwAAAE11bHRpU3RhdGVWYWx1ZURpc2NyZXRlVHlwZUluc3RhbmNlAQDmKwEA5ivmKwAAABoBAf////8CAAAAF2CJCgIAAAAAAAoAAABFbnVtVmFsdWVzAQDpKwAuAETpKwAAAQCqHQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFZhbHVlQXNUZXh0AQDFLAAuAETFLAAAABX/////AQH/////AAAAAA==";

	private PropertyState<EnumValueType[]> m_enumValues;

	private PropertyState<LocalizedText> m_valueAsText;

	public PropertyState<EnumValueType[]> EnumValues
	{
		get
		{
			return m_enumValues;
		}
		set
		{
			if (m_enumValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enumValues = value;
		}
	}

	public PropertyState<LocalizedText> ValueAsText
	{
		get
		{
			return m_valueAsText;
		}
		set
		{
			if (m_valueAsText != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_valueAsText = value;
		}
	}

	public MultiStateValueDiscreteState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11238u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(26u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -2;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAIwAAAE11bHRpU3RhdGVWYWx1ZURpc2NyZXRlVHlwZUluc3RhbmNlAQDmKwEA5ivmKwAAABoBAf////8CAAAAF2CJCgIAAAAAAAoAAABFbnVtVmFsdWVzAQDpKwAuAETpKwAAAQCqHQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFZhbHVlQXNUZXh0AQDFLAAuAETFLAAAABX/////AQH/////AAAAAA==");
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
		if (m_enumValues != null)
		{
			children.Add(m_enumValues);
		}
		if (m_valueAsText != null)
		{
			children.Add(m_valueAsText);
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
		if (!(name == "EnumValues"))
		{
			if (name == "ValueAsText")
			{
				if (createOrReplace && ValueAsText == null)
				{
					if (replacement == null)
					{
						ValueAsText = new PropertyState<LocalizedText>(this);
					}
					else
					{
						ValueAsText = (PropertyState<LocalizedText>)replacement;
					}
				}
				baseInstanceState = ValueAsText;
			}
		}
		else
		{
			if (createOrReplace && EnumValues == null)
			{
				if (replacement == null)
				{
					EnumValues = new PropertyState<EnumValueType[]>(this);
				}
				else
				{
					EnumValues = (PropertyState<EnumValueType[]>)replacement;
				}
			}
			baseInstanceState = EnumValues;
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
public class MultiStateValueDiscreteState<T> : MultiStateValueDiscreteState
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

	public MultiStateValueDiscreteState(NodeState parent)
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
