using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OptionSetState : BaseDataVariableState
{
	private const string BitMask_InitializationString = "//////////8XYIkKAgAAAAAABwAAAEJpdE1hc2sBALUtAC4ARLUtAAAAAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAE9wdGlvblNldFR5cGVJbnN0YW5jZQEA3ywBAN8s3ywAAAAY/////wEB/////wIAAAAXYIkKAgAAAAAADwAAAE9wdGlvblNldFZhbHVlcwEA4CwALgBE4CwAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAHAAAAQml0TWFzawEAtS0ALgBEtS0AAAABAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<LocalizedText[]> m_optionSetValues;

	private PropertyState<bool[]> m_bitMask;

	public PropertyState<LocalizedText[]> OptionSetValues
	{
		get
		{
			return m_optionSetValues;
		}
		set
		{
			if (m_optionSetValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_optionSetValues = value;
		}
	}

	public PropertyState<bool[]> BitMask
	{
		get
		{
			return m_bitMask;
		}
		set
		{
			if (m_bitMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_bitMask = value;
		}
	}

	public OptionSetState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11487u, "http://opcfoundation.org/UA/", namespaceUris);
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
		Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAE9wdGlvblNldFR5cGVJbnN0YW5jZQEA3ywBAN8s3ywAAAAY/////wEB/////wIAAAAXYIkKAgAAAAAADwAAAE9wdGlvblNldFZhbHVlcwEA4CwALgBE4CwAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAHAAAAQml0TWFzawEAtS0ALgBEtS0AAAABAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (BitMask != null)
		{
			BitMask.Initialize(context, "//////////8XYIkKAgAAAAAABwAAAEJpdE1hc2sBALUtAC4ARLUtAAAAAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_optionSetValues != null)
		{
			children.Add(m_optionSetValues);
		}
		if (m_bitMask != null)
		{
			children.Add(m_bitMask);
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
		if (!(name == "OptionSetValues"))
		{
			if (name == "BitMask")
			{
				if (createOrReplace && BitMask == null)
				{
					if (replacement == null)
					{
						BitMask = new PropertyState<bool[]>(this);
					}
					else
					{
						BitMask = (PropertyState<bool[]>)replacement;
					}
				}
				baseInstanceState = BitMask;
			}
		}
		else
		{
			if (createOrReplace && OptionSetValues == null)
			{
				if (replacement == null)
				{
					OptionSetValues = new PropertyState<LocalizedText[]>(this);
				}
				else
				{
					OptionSetValues = (PropertyState<LocalizedText[]>)replacement;
				}
			}
			baseInstanceState = OptionSetValues;
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
public class OptionSetState<T> : OptionSetState
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

	public OptionSetState(NodeState parent)
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
