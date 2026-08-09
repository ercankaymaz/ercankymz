using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubDiagnosticsState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDdTAEA3UzdTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAN5MAC8AP95MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAN9MAC8BAA1N30wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA4EwALgBE4EwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDhTAAuAEThTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDiTAAuAETiTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQDkTAAvAQANTeRMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAOVMAC4AROVMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA5kwALgBE5kwAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA50wALgBE50wAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOlMAC8BAOlM6UwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQDqTAAvAD/qTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAOtMAC8AOutMAAD/////BgAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEA7EwALwEADU3sTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtTAAuAETtTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5MAC4ARO5MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70wALgBE70wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAPFMAC8BAA1N8UwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA8kwALgBE8kwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDzTAAuAETzTAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAPRMAC4ARPRMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQD2TAAvAQANTfZMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAPdMAC4ARPdMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA+EwALgBE+EwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQD5TAAuAET5TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAPtMAC8BAA1N+0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA/EwALgBE/EwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQD9TAAuAET9TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAP5MAC4ARP5MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAAE0ALwEADU0ATQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQABTQAuAEQBTQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAAJNAC4ARAJNAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAA00ALgBEA00AAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAAVNAC8BAA1NBU0AAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEABk0ALgBEBk0AAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAHTQAuAEQHTQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAAhNAC4ARAhNAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEACk0ALwA6Ck0AAP////8AAAAA";

	private BaseDataVariableState<DiagnosticsLevel> m_diagnosticsLevel;

	private PubSubDiagnosticsCounterState m_totalInformation;

	private PubSubDiagnosticsCounterState m_totalError;

	private MethodState m_resetMethod;

	private BaseDataVariableState<bool> m_subError;

	private BaseObjectState m_counters;

	private BaseObjectState m_liveValues;

	public BaseDataVariableState<DiagnosticsLevel> DiagnosticsLevel
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

	public PubSubDiagnosticsCounterState TotalInformation
	{
		get
		{
			return m_totalInformation;
		}
		set
		{
			if (m_totalInformation != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_totalInformation = value;
		}
	}

	public PubSubDiagnosticsCounterState TotalError
	{
		get
		{
			return m_totalError;
		}
		set
		{
			if (m_totalError != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_totalError = value;
		}
	}

	public MethodState Reset
	{
		get
		{
			return m_resetMethod;
		}
		set
		{
			if (m_resetMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resetMethod = value;
		}
	}

	public BaseDataVariableState<bool> SubError
	{
		get
		{
			return m_subError;
		}
		set
		{
			if (m_subError != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_subError = value;
		}
	}

	public BaseObjectState Counters
	{
		get
		{
			return m_counters;
		}
		set
		{
			if (m_counters != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_counters = value;
		}
	}

	public BaseObjectState LiveValues
	{
		get
		{
			return m_liveValues;
		}
		set
		{
			if (m_liveValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_liveValues = value;
		}
	}

	public PubSubDiagnosticsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19677u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDdTAEA3UzdTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAN5MAC8AP95MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAN9MAC8BAA1N30wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA4EwALgBE4EwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDhTAAuAEThTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDiTAAuAETiTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQDkTAAvAQANTeRMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAOVMAC4AROVMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA5kwALgBE5kwAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA50wALgBE50wAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOlMAC8BAOlM6UwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQDqTAAvAD/qTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAOtMAC8AOutMAAD/////BgAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEA7EwALwEADU3sTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtTAAuAETtTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5MAC4ARO5MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70wALgBE70wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAPFMAC8BAA1N8UwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA8kwALgBE8kwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDzTAAuAETzTAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAPRMAC4ARPRMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQD2TAAvAQANTfZMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAPdMAC4ARPdMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA+EwALgBE+EwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQD5TAAuAET5TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAPtMAC8BAA1N+0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA/EwALgBE/EwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQD9TAAuAET9TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAP5MAC4ARP5MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAAE0ALwEADU0ATQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQABTQAuAEQBTQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAAJNAC4ARAJNAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAA00ALgBEA00AAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAAVNAC8BAA1NBU0AAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEABk0ALgBEBk0AAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAHTQAuAEQHTQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAAhNAC4ARAhNAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEACk0ALwA6Ck0AAP////8AAAAA");
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
		if (m_diagnosticsLevel != null)
		{
			children.Add(m_diagnosticsLevel);
		}
		if (m_totalInformation != null)
		{
			children.Add(m_totalInformation);
		}
		if (m_totalError != null)
		{
			children.Add(m_totalError);
		}
		if (m_resetMethod != null)
		{
			children.Add(m_resetMethod);
		}
		if (m_subError != null)
		{
			children.Add(m_subError);
		}
		if (m_counters != null)
		{
			children.Add(m_counters);
		}
		if (m_liveValues != null)
		{
			children.Add(m_liveValues);
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
		case "DiagnosticsLevel":
			if (createOrReplace && DiagnosticsLevel == null)
			{
				if (replacement == null)
				{
					DiagnosticsLevel = new BaseDataVariableState<DiagnosticsLevel>(this);
				}
				else
				{
					DiagnosticsLevel = (BaseDataVariableState<DiagnosticsLevel>)replacement;
				}
			}
			baseInstanceState = DiagnosticsLevel;
			break;
		case "TotalInformation":
			if (createOrReplace && TotalInformation == null)
			{
				if (replacement == null)
				{
					TotalInformation = new PubSubDiagnosticsCounterState(this);
				}
				else
				{
					TotalInformation = (PubSubDiagnosticsCounterState)replacement;
				}
			}
			baseInstanceState = TotalInformation;
			break;
		case "TotalError":
			if (createOrReplace && TotalError == null)
			{
				if (replacement == null)
				{
					TotalError = new PubSubDiagnosticsCounterState(this);
				}
				else
				{
					TotalError = (PubSubDiagnosticsCounterState)replacement;
				}
			}
			baseInstanceState = TotalError;
			break;
		case "Reset":
			if (createOrReplace && Reset == null)
			{
				if (replacement == null)
				{
					Reset = new MethodState(this);
				}
				else
				{
					Reset = (MethodState)replacement;
				}
			}
			baseInstanceState = Reset;
			break;
		case "SubError":
			if (createOrReplace && SubError == null)
			{
				if (replacement == null)
				{
					SubError = new BaseDataVariableState<bool>(this);
				}
				else
				{
					SubError = (BaseDataVariableState<bool>)replacement;
				}
			}
			baseInstanceState = SubError;
			break;
		case "Counters":
			if (createOrReplace && Counters == null)
			{
				if (replacement == null)
				{
					Counters = new BaseObjectState(this);
				}
				else
				{
					Counters = (BaseObjectState)replacement;
				}
			}
			baseInstanceState = Counters;
			break;
		case "LiveValues":
			if (createOrReplace && LiveValues == null)
			{
				if (replacement == null)
				{
					LiveValues = new BaseObjectState(this);
				}
				else
				{
					LiveValues = (BaseObjectState)replacement;
				}
			}
			baseInstanceState = LiveValues;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
