using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SelectionListState : BaseDataVariableState
{
	private const string SelectionDescriptions_InitializationString = "//////////8XYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string RestrictToList_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFJlc3RyaWN0VG9MaXN0AQC4PwAuAES4PwAAAAH/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIECAgAAAAAAGQAAAFNlbGVjdGlvbkxpc3RUeXBlSW5zdGFuY2UBALU/AQC1P7U/AAAAGAEB/////wMAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAOBEAC4AROBEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAAUmVzdHJpY3RUb0xpc3QBALg/AC4ARLg/AAAAAf////8BAf////8AAAAA";

	private PropertyState<object[]> m_selections;

	private PropertyState<LocalizedText[]> m_selectionDescriptions;

	private PropertyState<bool> m_restrictToList;

	public PropertyState<object[]> Selections
	{
		get
		{
			return m_selections;
		}
		set
		{
			if (m_selections != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_selections = value;
		}
	}

	public PropertyState<LocalizedText[]> SelectionDescriptions
	{
		get
		{
			return m_selectionDescriptions;
		}
		set
		{
			if (m_selectionDescriptions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_selectionDescriptions = value;
		}
	}

	public PropertyState<bool> RestrictToList
	{
		get
		{
			return m_restrictToList;
		}
		set
		{
			if (m_restrictToList != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_restrictToList = value;
		}
	}

	public SelectionListState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(16309u, "http://opcfoundation.org/UA/", namespaceUris);
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
		Initialize(context, "//////////8VYIECAgAAAAAAGQAAAFNlbGVjdGlvbkxpc3RUeXBlSW5zdGFuY2UBALU/AQC1P7U/AAAAGAEB/////wMAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAOBEAC4AROBEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAAUmVzdHJpY3RUb0xpc3QBALg/AC4ARLg/AAAAAf////8BAf////8AAAAA");
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
		if (SelectionDescriptions != null)
		{
			SelectionDescriptions.Initialize(context, "//////////8XYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (RestrictToList != null)
		{
			RestrictToList.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFJlc3RyaWN0VG9MaXN0AQC4PwAuAES4PwAAAAH/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_selections != null)
		{
			children.Add(m_selections);
		}
		if (m_selectionDescriptions != null)
		{
			children.Add(m_selectionDescriptions);
		}
		if (m_restrictToList != null)
		{
			children.Add(m_restrictToList);
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
		case "Selections":
			if (createOrReplace && Selections == null)
			{
				if (replacement == null)
				{
					Selections = new PropertyState<object[]>(this);
				}
				else
				{
					Selections = (PropertyState<object[]>)replacement;
				}
			}
			baseInstanceState = Selections;
			break;
		case "SelectionDescriptions":
			if (createOrReplace && SelectionDescriptions == null)
			{
				if (replacement == null)
				{
					SelectionDescriptions = new PropertyState<LocalizedText[]>(this);
				}
				else
				{
					SelectionDescriptions = (PropertyState<LocalizedText[]>)replacement;
				}
			}
			baseInstanceState = SelectionDescriptions;
			break;
		case "RestrictToList":
			if (createOrReplace && RestrictToList == null)
			{
				if (replacement == null)
				{
					RestrictToList = new PropertyState<bool>(this);
				}
				else
				{
					RestrictToList = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = RestrictToList;
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
public class SelectionListState<T> : SelectionListState
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

	public SelectionListState(NodeState parent)
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
