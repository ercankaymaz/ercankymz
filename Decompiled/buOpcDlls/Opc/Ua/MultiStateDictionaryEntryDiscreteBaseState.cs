using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDictionaryEntryDiscreteBaseState : MultiStateValueDiscreteState
{
	private const string ValueAsDictionaryEntries_InitializationString = "//////////8XYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAi0oALgBEi0oAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIECAgAAAAAAMQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZUJhc2VUeXBlSW5zdGFuY2UBAIVKAQCFSoVKAAAAGgEB/////wQAAAAXYIkKAgAAAAAACgAAAEVudW1WYWx1ZXMBAIhKAC4ARIhKAAABAKodAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAVmFsdWVBc1RleHQBAIlKAC4ARIlKAAAAFf////8BAf////8AAAAAF2CJCgIAAAAAABUAAABFbnVtRGljdGlvbmFyeUVudHJpZXMBAIpKAC4ARIpKAAAAEQIAAAACAAAAAAAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABgAAABWYWx1ZUFzRGljdGlvbmFyeUVudHJpZXMBAItKAC4ARItKAAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState m_enumDictionaryEntries;

	private PropertyState<NodeId[]> m_valueAsDictionaryEntries;

	public PropertyState EnumDictionaryEntries
	{
		get
		{
			return m_enumDictionaryEntries;
		}
		set
		{
			if (m_enumDictionaryEntries != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enumDictionaryEntries = value;
		}
	}

	public PropertyState<NodeId[]> ValueAsDictionaryEntries
	{
		get
		{
			return m_valueAsDictionaryEntries;
		}
		set
		{
			if (m_valueAsDictionaryEntries != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_valueAsDictionaryEntries = value;
		}
	}

	public MultiStateDictionaryEntryDiscreteBaseState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19077u, "http://opcfoundation.org/UA/", namespaceUris);
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
		Initialize(context, "//////////8VYIECAgAAAAAAMQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZUJhc2VUeXBlSW5zdGFuY2UBAIVKAQCFSoVKAAAAGgEB/////wQAAAAXYIkKAgAAAAAACgAAAEVudW1WYWx1ZXMBAIhKAC4ARIhKAAABAKodAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAVmFsdWVBc1RleHQBAIlKAC4ARIlKAAAAFf////8BAf////8AAAAAF2CJCgIAAAAAABUAAABFbnVtRGljdGlvbmFyeUVudHJpZXMBAIpKAC4ARIpKAAAAEQIAAAACAAAAAAAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABgAAABWYWx1ZUFzRGljdGlvbmFyeUVudHJpZXMBAItKAC4ARItKAAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (ValueAsDictionaryEntries != null)
		{
			ValueAsDictionaryEntries.Initialize(context, "//////////8XYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAi0oALgBEi0oAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_enumDictionaryEntries != null)
		{
			children.Add(m_enumDictionaryEntries);
		}
		if (m_valueAsDictionaryEntries != null)
		{
			children.Add(m_valueAsDictionaryEntries);
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
		if (!(name == "EnumDictionaryEntries"))
		{
			if (name == "ValueAsDictionaryEntries")
			{
				if (createOrReplace && ValueAsDictionaryEntries == null)
				{
					if (replacement == null)
					{
						ValueAsDictionaryEntries = new PropertyState<NodeId[]>(this);
					}
					else
					{
						ValueAsDictionaryEntries = (PropertyState<NodeId[]>)replacement;
					}
				}
				baseInstanceState = ValueAsDictionaryEntries;
			}
		}
		else
		{
			if (createOrReplace && EnumDictionaryEntries == null)
			{
				if (replacement == null)
				{
					EnumDictionaryEntries = new PropertyState(this);
				}
				else
				{
					EnumDictionaryEntries = (PropertyState)replacement;
				}
			}
			baseInstanceState = EnumDictionaryEntries;
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
public class MultiStateDictionaryEntryDiscreteBaseState<T> : MultiStateDictionaryEntryDiscreteBaseState
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

	public MultiStateDictionaryEntryDiscreteBaseState(NodeState parent)
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
