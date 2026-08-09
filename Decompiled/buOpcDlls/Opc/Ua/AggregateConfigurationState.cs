using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AggregateConfigurationState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEFnZ3JlZ2F0ZUNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBALMrAQCzK7MrAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAtCsALgBEtCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQC1KwAuAES1KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQC2KwAuAES2KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAtysALgBEtysAAAAB/////wEB/////wAAAAA=";

	private PropertyState<bool> m_treatUncertainAsBad;

	private PropertyState<byte> m_percentDataBad;

	private PropertyState<byte> m_percentDataGood;

	private PropertyState<bool> m_useSlopedExtrapolation;

	public PropertyState<bool> TreatUncertainAsBad
	{
		get
		{
			return m_treatUncertainAsBad;
		}
		set
		{
			if (m_treatUncertainAsBad != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_treatUncertainAsBad = value;
		}
	}

	public PropertyState<byte> PercentDataBad
	{
		get
		{
			return m_percentDataBad;
		}
		set
		{
			if (m_percentDataBad != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_percentDataBad = value;
		}
	}

	public PropertyState<byte> PercentDataGood
	{
		get
		{
			return m_percentDataGood;
		}
		set
		{
			if (m_percentDataGood != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_percentDataGood = value;
		}
	}

	public PropertyState<bool> UseSlopedExtrapolation
	{
		get
		{
			return m_useSlopedExtrapolation;
		}
		set
		{
			if (m_useSlopedExtrapolation != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_useSlopedExtrapolation = value;
		}
	}

	public AggregateConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11187u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEFnZ3JlZ2F0ZUNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBALMrAQCzK7MrAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAtCsALgBEtCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQC1KwAuAES1KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQC2KwAuAES2KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAtysALgBEtysAAAAB/////wEB/////wAAAAA=");
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
		if (m_treatUncertainAsBad != null)
		{
			children.Add(m_treatUncertainAsBad);
		}
		if (m_percentDataBad != null)
		{
			children.Add(m_percentDataBad);
		}
		if (m_percentDataGood != null)
		{
			children.Add(m_percentDataGood);
		}
		if (m_useSlopedExtrapolation != null)
		{
			children.Add(m_useSlopedExtrapolation);
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
		case "TreatUncertainAsBad":
			if (createOrReplace && TreatUncertainAsBad == null)
			{
				if (replacement == null)
				{
					TreatUncertainAsBad = new PropertyState<bool>(this);
				}
				else
				{
					TreatUncertainAsBad = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = TreatUncertainAsBad;
			break;
		case "PercentDataBad":
			if (createOrReplace && PercentDataBad == null)
			{
				if (replacement == null)
				{
					PercentDataBad = new PropertyState<byte>(this);
				}
				else
				{
					PercentDataBad = (PropertyState<byte>)replacement;
				}
			}
			baseInstanceState = PercentDataBad;
			break;
		case "PercentDataGood":
			if (createOrReplace && PercentDataGood == null)
			{
				if (replacement == null)
				{
					PercentDataGood = new PropertyState<byte>(this);
				}
				else
				{
					PercentDataGood = (PropertyState<byte>)replacement;
				}
			}
			baseInstanceState = PercentDataGood;
			break;
		case "UseSlopedExtrapolation":
			if (createOrReplace && UseSlopedExtrapolation == null)
			{
				if (replacement == null)
				{
					UseSlopedExtrapolation = new PropertyState<bool>(this);
				}
				else
				{
					UseSlopedExtrapolation = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = UseSlopedExtrapolation;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
