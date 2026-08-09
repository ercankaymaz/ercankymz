using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ArrayItemState : DataItemState
{
	private const string InstrumentRange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAEFycmF5SXRlbVR5cGVJbnN0YW5jZQEA9S4BAPUu9S4AAAAYAAAAAAEB/////wUAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEA+S4ALgBE+S4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEA+i4ALgBE+i4AAAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAVGl0bGUBAPsuAC4ARPsuAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBeGlzU2NhbGVUeXBlAQD8LgAuAET8LgAAAQAtL/////8BAf////8AAAAA";

	private PropertyState<Range> m_instrumentRange;

	private PropertyState<Range> m_eURange;

	private PropertyState<EUInformation> m_engineeringUnits;

	private PropertyState<LocalizedText> m_title;

	private PropertyState<AxisScaleEnumeration> m_axisScaleType;

	public PropertyState<Range> InstrumentRange
	{
		get
		{
			return m_instrumentRange;
		}
		set
		{
			if (m_instrumentRange != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_instrumentRange = value;
		}
	}

	public PropertyState<Range> EURange
	{
		get
		{
			return m_eURange;
		}
		set
		{
			if (m_eURange != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eURange = value;
		}
	}

	public PropertyState<EUInformation> EngineeringUnits
	{
		get
		{
			return m_engineeringUnits;
		}
		set
		{
			if (m_engineeringUnits != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_engineeringUnits = value;
		}
	}

	public PropertyState<LocalizedText> Title
	{
		get
		{
			return m_title;
		}
		set
		{
			if (m_title != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_title = value;
		}
	}

	public PropertyState<AxisScaleEnumeration> AxisScaleType
	{
		get
		{
			return m_axisScaleType;
		}
		set
		{
			if (m_axisScaleType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_axisScaleType = value;
		}
	}

	public ArrayItemState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12021u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 0;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAEFycmF5SXRlbVR5cGVJbnN0YW5jZQEA9S4BAPUu9S4AAAAYAAAAAAEB/////wUAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEA+S4ALgBE+S4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEA+i4ALgBE+i4AAAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAVGl0bGUBAPsuAC4ARPsuAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBeGlzU2NhbGVUeXBlAQD8LgAuAET8LgAAAQAtL/////8BAf////8AAAAA");
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
		if (InstrumentRange != null)
		{
			InstrumentRange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_instrumentRange != null)
		{
			children.Add(m_instrumentRange);
		}
		if (m_eURange != null)
		{
			children.Add(m_eURange);
		}
		if (m_engineeringUnits != null)
		{
			children.Add(m_engineeringUnits);
		}
		if (m_title != null)
		{
			children.Add(m_title);
		}
		if (m_axisScaleType != null)
		{
			children.Add(m_axisScaleType);
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
		case "InstrumentRange":
			if (createOrReplace && InstrumentRange == null)
			{
				if (replacement == null)
				{
					InstrumentRange = new PropertyState<Range>(this);
				}
				else
				{
					InstrumentRange = (PropertyState<Range>)replacement;
				}
			}
			baseInstanceState = InstrumentRange;
			break;
		case "EURange":
			if (createOrReplace && EURange == null)
			{
				if (replacement == null)
				{
					EURange = new PropertyState<Range>(this);
				}
				else
				{
					EURange = (PropertyState<Range>)replacement;
				}
			}
			baseInstanceState = EURange;
			break;
		case "EngineeringUnits":
			if (createOrReplace && EngineeringUnits == null)
			{
				if (replacement == null)
				{
					EngineeringUnits = new PropertyState<EUInformation>(this);
				}
				else
				{
					EngineeringUnits = (PropertyState<EUInformation>)replacement;
				}
			}
			baseInstanceState = EngineeringUnits;
			break;
		case "Title":
			if (createOrReplace && Title == null)
			{
				if (replacement == null)
				{
					Title = new PropertyState<LocalizedText>(this);
				}
				else
				{
					Title = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = Title;
			break;
		case "AxisScaleType":
			if (createOrReplace && AxisScaleType == null)
			{
				if (replacement == null)
				{
					AxisScaleType = new PropertyState<AxisScaleEnumeration>(this);
				}
				else
				{
					AxisScaleType = (PropertyState<AxisScaleEnumeration>)replacement;
				}
			}
			baseInstanceState = AxisScaleType;
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
public class ArrayItemState<T> : ArrayItemState
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

	public ArrayItemState(NodeState parent)
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
