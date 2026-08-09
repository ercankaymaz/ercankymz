using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BaseAnalogState : DataItemState
{
	private const string InstrumentRange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAAA==";

	private const string EURange_InitializationString = "//////////8VYIkKAgAAAAAABwAAAEVVUmFuZ2UBAKBEAC4ARKBEAAABAHQD/////wEB/////wAAAAA=";

	private const string EngineeringUnits_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAKFEAC4ARKFEAAABAHcD/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIECAgAAAAAAFgAAAEJhc2VBbmFsb2dUeXBlSW5zdGFuY2UBANY7AQDWO9Y7AAAAGgEB/////wMAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEAoEQALgBEoEQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAoUQALgBEoUQAAAEAdwP/////AQH/////AAAAAA==";

	private PropertyState<Range> m_instrumentRange;

	private PropertyState<Range> m_eURange;

	private PropertyState<EUInformation> m_engineeringUnits;

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

	public BaseAnalogState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15318u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(26u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAFgAAAEJhc2VBbmFsb2dUeXBlSW5zdGFuY2UBANY7AQDWO9Y7AAAAGgEB/////wMAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEAoEQALgBEoEQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAoUQALgBEoUQAAAEAdwP/////AQH/////AAAAAA==");
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
			InstrumentRange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAAA==");
		}
		if (EURange != null)
		{
			EURange.Initialize(context, "//////////8VYIkKAgAAAAAABwAAAEVVUmFuZ2UBAKBEAC4ARKBEAAABAHQD/////wEB/////wAAAAA=");
		}
		if (EngineeringUnits != null)
		{
			EngineeringUnits.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAKFEAC4ARKFEAAABAHcD/////wEB/////wAAAAA=");
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
public class BaseAnalogState<T> : BaseAnalogState
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

	public BaseAnalogState(NodeState parent)
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
