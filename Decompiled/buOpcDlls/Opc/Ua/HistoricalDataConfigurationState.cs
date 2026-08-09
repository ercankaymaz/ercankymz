using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoricalDataConfigurationState : BaseObjectState
{
	private const string AggregateFunctions_InitializationString = "//////////8EYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAA";

	private const string Definition_InitializationString = "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BABQJAC4ARBQJAAAADP////8BAf////8AAAAA";

	private const string MaxTimeInterval_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAAA==";

	private const string MinTimeInterval_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1pblRpbWVJbnRlcnZhbAEAFgkALgBEFgkAAAEAIgH/////AQH/////AAAAAA==";

	private const string ExceptionDeviation_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAEV4Y2VwdGlvbkRldmlhdGlvbgEAFwkALgBEFwkAAAAL/////wEB/////wAAAAA=";

	private const string ExceptionDeviationFormat_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAEV4Y2VwdGlvbkRldmlhdGlvbkZvcm1hdAEAGAkALgBEGAkAAAEAegP/////AQH/////AAAAAA==";

	private const string StartOfArchive_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAA";

	private const string StartOfOnlineArchive_InitializationString = "//////////8VYIkKAgAAAAAAFAAAAFN0YXJ0T2ZPbmxpbmVBcmNoaXZlAQDsLAAuAETsLAAAAQAmAf////8BAf////8AAAAA";

	private const string ServerTimestampSupported_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAFNlcnZlclRpbWVzdGFtcFN1cHBvcnRlZAEAlEoALgBElEoAAAAB/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEhpc3RvcmljYWxEYXRhQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEADgkBAA4JDgkAAP////8LAAAABGCACgEAAAAAABYAAABBZ2dyZWdhdGVDb25maWd1cmF0aW9uAQDzCwAvAQCzK/MLAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAoCsALgBEoCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQChKwAuAEShKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQCiKwAuAESiKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAoysALgBEoysAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAAFWCJCgIAAAAAAAcAAABTdGVwcGVkAQATCQAuAEQTCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARGVmaW5pdGlvbgEAFAkALgBEFAkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAATWluVGltZUludGVydmFsAQAWCQAuAEQWCQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABFeGNlcHRpb25EZXZpYXRpb24BABcJAC4ARBcJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABFeGNlcHRpb25EZXZpYXRpb25Gb3JtYXQBABgJAC4ARBgJAAABAHoD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABTdGFydE9mT25saW5lQXJjaGl2ZQEA7CwALgBE7CwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCUSgAuAESUSgAAAAH/////AQH/////AAAAAA==";

	private AggregateConfigurationState m_aggregateConfiguration;

	private FolderState m_aggregateFunctions;

	private PropertyState<bool> m_stepped;

	private PropertyState<string> m_definition;

	private PropertyState<double> m_maxTimeInterval;

	private PropertyState<double> m_minTimeInterval;

	private PropertyState<double> m_exceptionDeviation;

	private PropertyState<ExceptionDeviationFormat> m_exceptionDeviationFormat;

	private PropertyState<DateTime> m_startOfArchive;

	private PropertyState<DateTime> m_startOfOnlineArchive;

	private PropertyState<bool> m_serverTimestampSupported;

	public AggregateConfigurationState AggregateConfiguration
	{
		get
		{
			return m_aggregateConfiguration;
		}
		set
		{
			if (m_aggregateConfiguration != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_aggregateConfiguration = value;
		}
	}

	public FolderState AggregateFunctions
	{
		get
		{
			return m_aggregateFunctions;
		}
		set
		{
			if (m_aggregateFunctions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_aggregateFunctions = value;
		}
	}

	public PropertyState<bool> Stepped
	{
		get
		{
			return m_stepped;
		}
		set
		{
			if (m_stepped != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_stepped = value;
		}
	}

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

	public PropertyState<double> MaxTimeInterval
	{
		get
		{
			return m_maxTimeInterval;
		}
		set
		{
			if (m_maxTimeInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxTimeInterval = value;
		}
	}

	public PropertyState<double> MinTimeInterval
	{
		get
		{
			return m_minTimeInterval;
		}
		set
		{
			if (m_minTimeInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_minTimeInterval = value;
		}
	}

	public PropertyState<double> ExceptionDeviation
	{
		get
		{
			return m_exceptionDeviation;
		}
		set
		{
			if (m_exceptionDeviation != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_exceptionDeviation = value;
		}
	}

	public PropertyState<ExceptionDeviationFormat> ExceptionDeviationFormat
	{
		get
		{
			return m_exceptionDeviationFormat;
		}
		set
		{
			if (m_exceptionDeviationFormat != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_exceptionDeviationFormat = value;
		}
	}

	public PropertyState<DateTime> StartOfArchive
	{
		get
		{
			return m_startOfArchive;
		}
		set
		{
			if (m_startOfArchive != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_startOfArchive = value;
		}
	}

	public PropertyState<DateTime> StartOfOnlineArchive
	{
		get
		{
			return m_startOfOnlineArchive;
		}
		set
		{
			if (m_startOfOnlineArchive != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_startOfOnlineArchive = value;
		}
	}

	public PropertyState<bool> ServerTimestampSupported
	{
		get
		{
			return m_serverTimestampSupported;
		}
		set
		{
			if (m_serverTimestampSupported != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverTimestampSupported = value;
		}
	}

	public HistoricalDataConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2318u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEhpc3RvcmljYWxEYXRhQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEADgkBAA4JDgkAAP////8LAAAABGCACgEAAAAAABYAAABBZ2dyZWdhdGVDb25maWd1cmF0aW9uAQDzCwAvAQCzK/MLAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAoCsALgBEoCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQChKwAuAEShKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQCiKwAuAESiKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAoysALgBEoysAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAAFWCJCgIAAAAAAAcAAABTdGVwcGVkAQATCQAuAEQTCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARGVmaW5pdGlvbgEAFAkALgBEFAkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAATWluVGltZUludGVydmFsAQAWCQAuAEQWCQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABFeGNlcHRpb25EZXZpYXRpb24BABcJAC4ARBcJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABFeGNlcHRpb25EZXZpYXRpb25Gb3JtYXQBABgJAC4ARBgJAAABAHoD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABTdGFydE9mT25saW5lQXJjaGl2ZQEA7CwALgBE7CwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCUSgAuAESUSgAAAAH/////AQH/////AAAAAA==");
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
		if (AggregateFunctions != null)
		{
			AggregateFunctions.Initialize(context, "//////////8EYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAA");
		}
		if (Definition != null)
		{
			Definition.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BABQJAC4ARBQJAAAADP////8BAf////8AAAAA");
		}
		if (MaxTimeInterval != null)
		{
			MaxTimeInterval.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAAA==");
		}
		if (MinTimeInterval != null)
		{
			MinTimeInterval.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1pblRpbWVJbnRlcnZhbAEAFgkALgBEFgkAAAEAIgH/////AQH/////AAAAAA==");
		}
		if (ExceptionDeviation != null)
		{
			ExceptionDeviation.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAEV4Y2VwdGlvbkRldmlhdGlvbgEAFwkALgBEFwkAAAAL/////wEB/////wAAAAA=");
		}
		if (ExceptionDeviationFormat != null)
		{
			ExceptionDeviationFormat.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAEV4Y2VwdGlvbkRldmlhdGlvbkZvcm1hdAEAGAkALgBEGAkAAAEAegP/////AQH/////AAAAAA==");
		}
		if (StartOfArchive != null)
		{
			StartOfArchive.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAA");
		}
		if (StartOfOnlineArchive != null)
		{
			StartOfOnlineArchive.Initialize(context, "//////////8VYIkKAgAAAAAAFAAAAFN0YXJ0T2ZPbmxpbmVBcmNoaXZlAQDsLAAuAETsLAAAAQAmAf////8BAf////8AAAAA");
		}
		if (ServerTimestampSupported != null)
		{
			ServerTimestampSupported.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAFNlcnZlclRpbWVzdGFtcFN1cHBvcnRlZAEAlEoALgBElEoAAAAB/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_aggregateConfiguration != null)
		{
			children.Add(m_aggregateConfiguration);
		}
		if (m_aggregateFunctions != null)
		{
			children.Add(m_aggregateFunctions);
		}
		if (m_stepped != null)
		{
			children.Add(m_stepped);
		}
		if (m_definition != null)
		{
			children.Add(m_definition);
		}
		if (m_maxTimeInterval != null)
		{
			children.Add(m_maxTimeInterval);
		}
		if (m_minTimeInterval != null)
		{
			children.Add(m_minTimeInterval);
		}
		if (m_exceptionDeviation != null)
		{
			children.Add(m_exceptionDeviation);
		}
		if (m_exceptionDeviationFormat != null)
		{
			children.Add(m_exceptionDeviationFormat);
		}
		if (m_startOfArchive != null)
		{
			children.Add(m_startOfArchive);
		}
		if (m_startOfOnlineArchive != null)
		{
			children.Add(m_startOfOnlineArchive);
		}
		if (m_serverTimestampSupported != null)
		{
			children.Add(m_serverTimestampSupported);
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
		case "AggregateConfiguration":
			if (createOrReplace && AggregateConfiguration == null)
			{
				if (replacement == null)
				{
					AggregateConfiguration = new AggregateConfigurationState(this);
				}
				else
				{
					AggregateConfiguration = (AggregateConfigurationState)replacement;
				}
			}
			baseInstanceState = AggregateConfiguration;
			break;
		case "AggregateFunctions":
			if (createOrReplace && AggregateFunctions == null)
			{
				if (replacement == null)
				{
					AggregateFunctions = new FolderState(this);
				}
				else
				{
					AggregateFunctions = (FolderState)replacement;
				}
			}
			baseInstanceState = AggregateFunctions;
			break;
		case "Stepped":
			if (createOrReplace && Stepped == null)
			{
				if (replacement == null)
				{
					Stepped = new PropertyState<bool>(this);
				}
				else
				{
					Stepped = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Stepped;
			break;
		case "Definition":
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
			break;
		case "MaxTimeInterval":
			if (createOrReplace && MaxTimeInterval == null)
			{
				if (replacement == null)
				{
					MaxTimeInterval = new PropertyState<double>(this);
				}
				else
				{
					MaxTimeInterval = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = MaxTimeInterval;
			break;
		case "MinTimeInterval":
			if (createOrReplace && MinTimeInterval == null)
			{
				if (replacement == null)
				{
					MinTimeInterval = new PropertyState<double>(this);
				}
				else
				{
					MinTimeInterval = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = MinTimeInterval;
			break;
		case "ExceptionDeviation":
			if (createOrReplace && ExceptionDeviation == null)
			{
				if (replacement == null)
				{
					ExceptionDeviation = new PropertyState<double>(this);
				}
				else
				{
					ExceptionDeviation = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ExceptionDeviation;
			break;
		case "ExceptionDeviationFormat":
			if (createOrReplace && ExceptionDeviationFormat == null)
			{
				if (replacement == null)
				{
					ExceptionDeviationFormat = new PropertyState<ExceptionDeviationFormat>(this);
				}
				else
				{
					ExceptionDeviationFormat = (PropertyState<ExceptionDeviationFormat>)replacement;
				}
			}
			baseInstanceState = ExceptionDeviationFormat;
			break;
		case "StartOfArchive":
			if (createOrReplace && StartOfArchive == null)
			{
				if (replacement == null)
				{
					StartOfArchive = new PropertyState<DateTime>(this);
				}
				else
				{
					StartOfArchive = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = StartOfArchive;
			break;
		case "StartOfOnlineArchive":
			if (createOrReplace && StartOfOnlineArchive == null)
			{
				if (replacement == null)
				{
					StartOfOnlineArchive = new PropertyState<DateTime>(this);
				}
				else
				{
					StartOfOnlineArchive = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = StartOfOnlineArchive;
			break;
		case "ServerTimestampSupported":
			if (createOrReplace && ServerTimestampSupported == null)
			{
				if (replacement == null)
				{
					ServerTimestampSupported = new PropertyState<bool>(this);
				}
				else
				{
					ServerTimestampSupported = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = ServerTimestampSupported;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
