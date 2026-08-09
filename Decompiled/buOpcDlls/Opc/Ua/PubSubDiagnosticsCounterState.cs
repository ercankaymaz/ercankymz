using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubDiagnosticsCounterState : BaseDataVariableState<uint>
{
	private const string TimeFirstChange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFRpbWVGaXJzdENoYW5nZQEAEU0ALgBEEU0AAAAN/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAJAAAAFB1YlN1YkRpYWdub3N0aWNzQ291bnRlclR5cGVJbnN0YW5jZQEADU0BAA1NDU0AAAAH/////wEB/////wQAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEADk0ALgBEDk0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAPTQAuAEQPTQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAQTQAuAEQQTQAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUaW1lRmlyc3RDaGFuZ2UBABFNAC4ARBFNAAAADf////8BAf////8AAAAA";

	private PropertyState<bool> m_active;

	private PropertyState<PubSubDiagnosticsCounterClassification> m_classification;

	private PropertyState<DiagnosticsLevel> m_diagnosticsLevel;

	private PropertyState<DateTime> m_timeFirstChange;

	public PropertyState<bool> Active
	{
		get
		{
			return m_active;
		}
		set
		{
			if (m_active != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_active = value;
		}
	}

	public PropertyState<PubSubDiagnosticsCounterClassification> Classification
	{
		get
		{
			return m_classification;
		}
		set
		{
			if (m_classification != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_classification = value;
		}
	}

	public PropertyState<DiagnosticsLevel> DiagnosticsLevel
	{
		get
		{
			return m_diagnosticsLevel;
		}
		set
		{
			if (m_diagnosticsLevel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_diagnosticsLevel = value;
		}
	}

	public PropertyState<DateTime> TimeFirstChange
	{
		get
		{
			return m_timeFirstChange;
		}
		set
		{
			if (m_timeFirstChange != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_timeFirstChange = value;
		}
	}

	public PubSubDiagnosticsCounterState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19725u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(7u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJAAAAFB1YlN1YkRpYWdub3N0aWNzQ291bnRlclR5cGVJbnN0YW5jZQEADU0BAA1NDU0AAAAH/////wEB/////wQAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEADk0ALgBEDk0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAPTQAuAEQPTQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAQTQAuAEQQTQAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUaW1lRmlyc3RDaGFuZ2UBABFNAC4ARBFNAAAADf////8BAf////8AAAAA");
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
		if (TimeFirstChange != null)
		{
			TimeFirstChange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFRpbWVGaXJzdENoYW5nZQEAEU0ALgBEEU0AAAAN/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_active != null)
		{
			children.Add(m_active);
		}
		if (m_classification != null)
		{
			children.Add(m_classification);
		}
		if (m_diagnosticsLevel != null)
		{
			children.Add(m_diagnosticsLevel);
		}
		if (m_timeFirstChange != null)
		{
			children.Add(m_timeFirstChange);
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
		case "Active":
			if (createOrReplace && Active == null)
			{
				if (replacement == null)
				{
					Active = new PropertyState<bool>(this);
				}
				else
				{
					Active = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Active;
			break;
		case "Classification":
			if (createOrReplace && Classification == null)
			{
				if (replacement == null)
				{
					Classification = new PropertyState<PubSubDiagnosticsCounterClassification>(this);
				}
				else
				{
					Classification = (PropertyState<PubSubDiagnosticsCounterClassification>)replacement;
				}
			}
			baseInstanceState = Classification;
			break;
		case "DiagnosticsLevel":
			if (createOrReplace && DiagnosticsLevel == null)
			{
				if (replacement == null)
				{
					DiagnosticsLevel = new PropertyState<DiagnosticsLevel>(this);
				}
				else
				{
					DiagnosticsLevel = (PropertyState<DiagnosticsLevel>)replacement;
				}
			}
			baseInstanceState = DiagnosticsLevel;
			break;
		case "TimeFirstChange":
			if (createOrReplace && TimeFirstChange == null)
			{
				if (replacement == null)
				{
					TimeFirstChange = new PropertyState<DateTime>(this);
				}
				else
				{
					TimeFirstChange = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = TimeFirstChange;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
