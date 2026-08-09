using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionState : BaseEventState
{
	private const string ConditionSubClassId_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string ConditionSubClassName_InitializationString = "//////////8XYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAENvbmRpdGlvblR5cGVJbnN0YW5jZQEA3goBAN4K3goAAP////8XAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAZDwAuAEQZDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQAaDwAuAEQaDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAGw8ALgBEGw8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABwPAC4ARBwPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAdDwAuAEQdDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAHg8ALgBEHg8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAIA8ALgBEIA8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAhDwAuAEQhDwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaCsALgBEaCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaSsALgBEaSsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAMSMALgBEMSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQAyIwAuAEQyIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQAiDwAuAEQiDwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQAzIwAvAQAjIzMjAAAAFf////8BAf////8GAAAAFWCJCgIAAAAAAAIAAABJZAEANCMALgBENCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQA3IwAuAEQ3IwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADgjAC4ARDgjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQA5IwAuAEQ5IwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBADojAC4ARDojAAAVAwIAAABlbgcAAABFbmFibGVkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAOyMALgBEOyMAABUDAgAAAGVuCAAAAERpc2FibGVkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAPCMALwEAKiM8IwAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQA9IwAuAEQ9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAD4jAC8BACojPiMAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAPyMALgBEPyMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAQCMALwEAKiNAIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBBIwAuAERBIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEIjAC4AREIjAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQBEIwAvAQBEI0QjAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAEMjAC8BAEMjQyMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAEUjAC8BAEUjRSMAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBGIwAuAERGIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<NodeId> m_conditionClassId;

	private PropertyState<LocalizedText> m_conditionClassName;

	private PropertyState<NodeId[]> m_conditionSubClassId;

	private PropertyState<LocalizedText[]> m_conditionSubClassName;

	private PropertyState<string> m_conditionName;

	private PropertyState<NodeId> m_branchId;

	private PropertyState<bool> m_retain;

	private TwoStateVariableState m_enabledState;

	private ConditionVariableState<StatusCode> m_quality;

	private ConditionVariableState<ushort> m_lastSeverity;

	private ConditionVariableState<LocalizedText> m_comment;

	private PropertyState<string> m_clientUserId;

	private MethodState m_disableMethod;

	private MethodState m_enableMethod;

	private AddCommentMethodState m_addCommentMethod;

	public ConditionEnableEventHandler OnEnableDisable;

	public ConditionAddCommentEventHandler OnAddComment;

	private bool m_autoReportStateChanges;

	protected Dictionary<string, ConditionState> m_branches;

	public PropertyState<NodeId> ConditionClassId
	{
		get
		{
			return m_conditionClassId;
		}
		set
		{
			if (m_conditionClassId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionClassId = value;
		}
	}

	public PropertyState<LocalizedText> ConditionClassName
	{
		get
		{
			return m_conditionClassName;
		}
		set
		{
			if (m_conditionClassName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionClassName = value;
		}
	}

	public PropertyState<NodeId[]> ConditionSubClassId
	{
		get
		{
			return m_conditionSubClassId;
		}
		set
		{
			if (m_conditionSubClassId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionSubClassId = value;
		}
	}

	public PropertyState<LocalizedText[]> ConditionSubClassName
	{
		get
		{
			return m_conditionSubClassName;
		}
		set
		{
			if (m_conditionSubClassName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionSubClassName = value;
		}
	}

	public PropertyState<string> ConditionName
	{
		get
		{
			return m_conditionName;
		}
		set
		{
			if (m_conditionName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionName = value;
		}
	}

	public PropertyState<NodeId> BranchId
	{
		get
		{
			return m_branchId;
		}
		set
		{
			if (m_branchId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_branchId = value;
		}
	}

	public PropertyState<bool> Retain
	{
		get
		{
			return m_retain;
		}
		set
		{
			if (m_retain != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_retain = value;
		}
	}

	public TwoStateVariableState EnabledState
	{
		get
		{
			return m_enabledState;
		}
		set
		{
			if (m_enabledState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enabledState = value;
		}
	}

	public ConditionVariableState<StatusCode> Quality
	{
		get
		{
			return m_quality;
		}
		set
		{
			if (m_quality != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_quality = value;
		}
	}

	public ConditionVariableState<ushort> LastSeverity
	{
		get
		{
			return m_lastSeverity;
		}
		set
		{
			if (m_lastSeverity != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastSeverity = value;
		}
	}

	public ConditionVariableState<LocalizedText> Comment
	{
		get
		{
			return m_comment;
		}
		set
		{
			if (m_comment != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_comment = value;
		}
	}

	public PropertyState<string> ClientUserId
	{
		get
		{
			return m_clientUserId;
		}
		set
		{
			if (m_clientUserId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientUserId = value;
		}
	}

	public MethodState Disable
	{
		get
		{
			return m_disableMethod;
		}
		set
		{
			if (m_disableMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_disableMethod = value;
		}
	}

	public MethodState Enable
	{
		get
		{
			return m_enableMethod;
		}
		set
		{
			if (m_enableMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enableMethod = value;
		}
	}

	public AddCommentMethodState AddComment
	{
		get
		{
			return m_addCommentMethod;
		}
		set
		{
			if (m_addCommentMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addCommentMethod = value;
		}
	}

	public bool AutoReportStateChanges
	{
		get
		{
			return m_autoReportStateChanges;
		}
		set
		{
			m_autoReportStateChanges = value;
		}
	}

	public ConditionState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2782u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFQAAAENvbmRpdGlvblR5cGVJbnN0YW5jZQEA3goBAN4K3goAAP////8XAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAZDwAuAEQZDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQAaDwAuAEQaDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAGw8ALgBEGw8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABwPAC4ARBwPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAdDwAuAEQdDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAHg8ALgBEHg8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAIA8ALgBEIA8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAhDwAuAEQhDwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaCsALgBEaCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaSsALgBEaSsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAMSMALgBEMSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQAyIwAuAEQyIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQAiDwAuAEQiDwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQAzIwAvAQAjIzMjAAAAFf////8BAf////8GAAAAFWCJCgIAAAAAAAIAAABJZAEANCMALgBENCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQA3IwAuAEQ3IwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADgjAC4ARDgjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQA5IwAuAEQ5IwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBADojAC4ARDojAAAVAwIAAABlbgcAAABFbmFibGVkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAOyMALgBEOyMAABUDAgAAAGVuCAAAAERpc2FibGVkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAPCMALwEAKiM8IwAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQA9IwAuAEQ9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAD4jAC8BACojPiMAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAPyMALgBEPyMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAQCMALwEAKiNAIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBBIwAuAERBIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEIjAC4AREIjAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQBEIwAvAQBEI0QjAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAEMjAC8BAEMjQyMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAEUjAC8BAEUjRSMAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBGIwAuAERGIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (ConditionSubClassId != null)
		{
			ConditionSubClassId.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (ConditionSubClassName != null)
		{
			ConditionSubClassName.Initialize(context, "//////////8XYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_conditionClassId != null)
		{
			children.Add(m_conditionClassId);
		}
		if (m_conditionClassName != null)
		{
			children.Add(m_conditionClassName);
		}
		if (m_conditionSubClassId != null)
		{
			children.Add(m_conditionSubClassId);
		}
		if (m_conditionSubClassName != null)
		{
			children.Add(m_conditionSubClassName);
		}
		if (m_conditionName != null)
		{
			children.Add(m_conditionName);
		}
		if (m_branchId != null)
		{
			children.Add(m_branchId);
		}
		if (m_retain != null)
		{
			children.Add(m_retain);
		}
		if (m_enabledState != null)
		{
			children.Add(m_enabledState);
		}
		if (m_quality != null)
		{
			children.Add(m_quality);
		}
		if (m_lastSeverity != null)
		{
			children.Add(m_lastSeverity);
		}
		if (m_comment != null)
		{
			children.Add(m_comment);
		}
		if (m_clientUserId != null)
		{
			children.Add(m_clientUserId);
		}
		if (m_disableMethod != null)
		{
			children.Add(m_disableMethod);
		}
		if (m_enableMethod != null)
		{
			children.Add(m_enableMethod);
		}
		if (m_addCommentMethod != null)
		{
			children.Add(m_addCommentMethod);
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
		case "ConditionClassId":
			if (createOrReplace && ConditionClassId == null)
			{
				if (replacement == null)
				{
					ConditionClassId = new PropertyState<NodeId>(this);
				}
				else
				{
					ConditionClassId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = ConditionClassId;
			break;
		case "ConditionClassName":
			if (createOrReplace && ConditionClassName == null)
			{
				if (replacement == null)
				{
					ConditionClassName = new PropertyState<LocalizedText>(this);
				}
				else
				{
					ConditionClassName = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = ConditionClassName;
			break;
		case "ConditionSubClassId":
			if (createOrReplace && ConditionSubClassId == null)
			{
				if (replacement == null)
				{
					ConditionSubClassId = new PropertyState<NodeId[]>(this);
				}
				else
				{
					ConditionSubClassId = (PropertyState<NodeId[]>)replacement;
				}
			}
			baseInstanceState = ConditionSubClassId;
			break;
		case "ConditionSubClassName":
			if (createOrReplace && ConditionSubClassName == null)
			{
				if (replacement == null)
				{
					ConditionSubClassName = new PropertyState<LocalizedText[]>(this);
				}
				else
				{
					ConditionSubClassName = (PropertyState<LocalizedText[]>)replacement;
				}
			}
			baseInstanceState = ConditionSubClassName;
			break;
		case "ConditionName":
			if (createOrReplace && ConditionName == null)
			{
				if (replacement == null)
				{
					ConditionName = new PropertyState<string>(this);
				}
				else
				{
					ConditionName = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ConditionName;
			break;
		case "BranchId":
			if (createOrReplace && BranchId == null)
			{
				if (replacement == null)
				{
					BranchId = new PropertyState<NodeId>(this);
				}
				else
				{
					BranchId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = BranchId;
			break;
		case "Retain":
			if (createOrReplace && Retain == null)
			{
				if (replacement == null)
				{
					Retain = new PropertyState<bool>(this);
				}
				else
				{
					Retain = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Retain;
			break;
		case "EnabledState":
			if (createOrReplace && EnabledState == null)
			{
				if (replacement == null)
				{
					EnabledState = new TwoStateVariableState(this);
				}
				else
				{
					EnabledState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = EnabledState;
			break;
		case "Quality":
			if (createOrReplace && Quality == null)
			{
				if (replacement == null)
				{
					Quality = new ConditionVariableState<StatusCode>(this);
				}
				else
				{
					Quality = (ConditionVariableState<StatusCode>)replacement;
				}
			}
			baseInstanceState = Quality;
			break;
		case "LastSeverity":
			if (createOrReplace && LastSeverity == null)
			{
				if (replacement == null)
				{
					LastSeverity = new ConditionVariableState<ushort>(this);
				}
				else
				{
					LastSeverity = (ConditionVariableState<ushort>)replacement;
				}
			}
			baseInstanceState = LastSeverity;
			break;
		case "Comment":
			if (createOrReplace && Comment == null)
			{
				if (replacement == null)
				{
					Comment = new ConditionVariableState<LocalizedText>(this);
				}
				else
				{
					Comment = (ConditionVariableState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = Comment;
			break;
		case "ClientUserId":
			if (createOrReplace && ClientUserId == null)
			{
				if (replacement == null)
				{
					ClientUserId = new PropertyState<string>(this);
				}
				else
				{
					ClientUserId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ClientUserId;
			break;
		case "Disable":
			if (createOrReplace && Disable == null)
			{
				if (replacement == null)
				{
					Disable = new MethodState(this);
				}
				else
				{
					Disable = (MethodState)replacement;
				}
			}
			baseInstanceState = Disable;
			break;
		case "Enable":
			if (createOrReplace && Enable == null)
			{
				if (replacement == null)
				{
					Enable = new MethodState(this);
				}
				else
				{
					Enable = (MethodState)replacement;
				}
			}
			baseInstanceState = Enable;
			break;
		case "AddComment":
			if (createOrReplace && AddComment == null)
			{
				if (replacement == null)
				{
					AddComment = new AddCommentMethodState(this);
				}
				else
				{
					AddComment = (AddCommentMethodState)replacement;
				}
			}
			baseInstanceState = AddComment;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	protected override void OnAfterCreate(ISystemContext context, NodeState node)
	{
		base.OnAfterCreate(context, node);
		if (Enable != null)
		{
			Enable.OnCallMethod = OnEnableCalled;
		}
		if (Disable != null)
		{
			Disable.OnCallMethod = OnDisableCalled;
		}
		if (AddComment != null)
		{
			AddComment.OnCall = OnAddCommentCalled;
		}
	}

	public virtual void SetEffectiveSubState(ISystemContext context, LocalizedText displayName, DateTime transitionTime)
	{
		if (EnabledState.EffectiveDisplayName != null)
		{
			EnabledState.EffectiveDisplayName.Value = displayName;
		}
		if (EnabledState.EffectiveTransitionTime != null)
		{
			if (transitionTime != DateTime.MinValue)
			{
				EnabledState.EffectiveTransitionTime.Value = transitionTime;
			}
			else
			{
				EnabledState.EffectiveTransitionTime.Value = DateTime.UtcNow;
			}
		}
	}

	public virtual void SetEnableState(ISystemContext context, bool enabled)
	{
		if (enabled)
		{
			UpdateStateAfterEnable(context);
		}
		else
		{
			UpdateStateAfterDisable(context);
		}
	}

	public virtual void SetSeverity(ISystemContext context, EventSeverity severity)
	{
		LastSeverity.Value = base.Severity.Value;
		base.Severity.Value = (ushort)severity;
		if (LastSeverity.SourceTimestamp != null)
		{
			LastSeverity.SourceTimestamp.Value = DateTime.UtcNow;
		}
	}

	public virtual void SetComment(ISystemContext context, LocalizedText comment, string clientUserId)
	{
		if (Comment != null)
		{
			Comment.Value = comment;
			Comment.SourceTimestamp.Value = DateTime.UtcNow;
			if (ClientUserId != null)
			{
				ClientUserId.Value = clientUserId;
			}
		}
	}

	public virtual ConditionState CreateBranch(ISystemContext context, NodeId branchId)
	{
		ConditionState result = null;
		object obj = Activator.CreateInstance(GetType(), this);
		if (obj != null)
		{
			ConditionState conditionState = (ConditionState)obj;
			conditionState.Initialize(context, this);
			conditionState.BranchId.Value = branchId;
			conditionState.AutoReportStateChanges = AutoReportStateChanges;
			conditionState.ReportStateChange(context, ignoreDisabledState: false);
			string key = Utils.ToHexString(conditionState.EventId.Value);
			GetBranches().Add(key, conditionState);
			result = conditionState;
		}
		return result;
	}

	public Dictionary<string, ConditionState> GetBranches()
	{
		if (m_branches == null)
		{
			m_branches = new Dictionary<string, ConditionState>();
		}
		return m_branches;
	}

	public virtual ConditionState GetEventByEventId(byte[] eventId)
	{
		ConditionState conditionState = null;
		if (Enumerable.SequenceEqual(base.EventId.Value, eventId))
		{
			return this;
		}
		return GetBranch(eventId);
	}

	public ConditionState GetBranch(byte[] eventId)
	{
		ConditionState result = null;
		foreach (ConditionState value in GetBranches().Values)
		{
			if (Enumerable.SequenceEqual(value.EventId.Value, eventId))
			{
				result = value;
				break;
			}
		}
		return result;
	}

	protected void ReplaceBranchEvent(byte[] originalEventId, ConditionState alarm)
	{
		string key = Utils.ToHexString(originalEventId);
		string key2 = Utils.ToHexString(alarm.EventId.Value);
		Dictionary<string, ConditionState> branches = GetBranches();
		branches.Remove(key);
		branches.Add(key2, alarm);
	}

	protected void RemoveBranchEvent(byte[] eventId)
	{
		string key = Utils.ToHexString(eventId);
		GetBranches().Remove(key);
	}

	public void ClearBranches()
	{
		GetBranches().Clear();
	}

	protected virtual void UpdateRetainState()
	{
		bool retainState = GetRetainState();
		if (Retain.Value != retainState)
		{
			Retain.Value = retainState;
		}
	}

	protected virtual bool GetRetainState()
	{
		bool result = false;
		if (EnabledState.Id.Value)
		{
			foreach (ConditionState value in GetBranches().Values)
			{
				value.UpdateRetainState();
				if (value.Retain.Value)
				{
					result = true;
				}
			}
		}
		return result;
	}

	public virtual int GetBranchCount()
	{
		return GetBranches().Count;
	}

	public bool EventsMonitored()
	{
		bool areEventsMonitored = base.AreEventsMonitored;
		if (IsBranch())
		{
			areEventsMonitored = base.Parent.AreEventsMonitored;
		}
		return areEventsMonitored;
	}

	public override void ConditionRefresh(ISystemContext context, List<IFilterTarget> events, bool includeChildren)
	{
		if (!Retain.Value)
		{
			return;
		}
		foreach (ConditionState value in GetBranches().Values)
		{
			value.ConditionRefresh(context, events, includeChildren);
		}
		events.Add(this);
	}

	protected void ReportStateChange(ISystemContext context, bool ignoreDisabledState)
	{
		if ((ignoreDisabledState || EnabledState.Id.Value) && AutoReportStateChanges)
		{
			base.EventId.Value = Guid.NewGuid().ToByteArray();
			base.Time.Value = DateTime.UtcNow;
			base.ReceiveTime.Value = base.Time.Value;
			ClearChangeMasks(context, includeChildren: true);
			if (EventsMonitored())
			{
				InstanceStateSnapshot instanceStateSnapshot = new InstanceStateSnapshot();
				instanceStateSnapshot.Initialize(context, this);
				ReportEvent(context, instanceStateSnapshot);
			}
		}
	}

	protected virtual void UpdateEffectiveState(ISystemContext context)
	{
		SetEffectiveSubState(context, EnabledState.Value, DateTime.MinValue);
	}

	protected virtual ServiceResult OnAddCommentCalled(ISystemContext context, MethodState method, NodeId objectId, byte[] eventId, LocalizedText comment)
	{
		ServiceResult serviceResult = ProcessBeforeAddComment(context, eventId, comment);
		if (ServiceResult.IsGood(serviceResult))
		{
			string currentUserId = GetCurrentUserId(context);
			GetBranch(eventId)?.OnAddCommentCalled(context, method, objectId, eventId, comment);
			SetComment(context, comment, currentUserId);
		}
		if (EventsMonitored())
		{
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
			AuditConditionCommentEventState auditConditionCommentEventState = new AuditConditionCommentEventState(null);
			TranslationInfo translationInfo = new TranslationInfo("AuditConditionComment", "en-US", "The AddComment method was called.");
			auditConditionCommentEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
			auditConditionCommentEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
			auditConditionCommentEventState.SetChildValue(context, "SourceName", "Method/AddComment", copy: false);
			auditConditionCommentEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
			auditConditionCommentEventState.SetChildValue(context, "InputArguments", new object[2] { eventId, comment }, copy: false);
			auditConditionCommentEventState.SetChildValue(context, "ConditionEventId", eventId, copy: false);
			auditConditionCommentEventState.SetChildValue(context, "Comment", comment, copy: false);
			ReportEvent(context, auditConditionCommentEventState);
		}
		return serviceResult;
	}

	protected string GetCurrentUserId(ISystemContext context)
	{
		if (context is IOperationContext { UserIdentity: not null } operationContext)
		{
			return operationContext.UserIdentity.DisplayName;
		}
		return null;
	}

	protected virtual ServiceResult ProcessBeforeAddComment(ISystemContext context, byte[] eventId, LocalizedText comment)
	{
		if (eventId == null)
		{
			return 2157576192u;
		}
		if (!EnabledState.Id.Value)
		{
			return 2157510656u;
		}
		if (OnAddComment != null)
		{
			try
			{
				return OnAddComment(context, this, eventId, comment);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2147549184u, "Unexpected error adding a comment to a Condition.");
			}
		}
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnEnableCalled(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		ServiceResult serviceResult = ProcessBeforeEnableDisable(context, enabling: true);
		if (ServiceResult.IsGood(serviceResult))
		{
			foreach (ConditionState value in GetBranches().Values)
			{
				value.OnEnableCalled(context, method, inputArguments, outputArguments);
			}
			UpdateStateAfterEnable(context);
		}
		if (base.AreEventsMonitored)
		{
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
			AuditConditionEnableEventState auditConditionEnableEventState = new AuditConditionEnableEventState(null);
			TranslationInfo translationInfo = new TranslationInfo("AuditConditionEnable", "en-US", "The Enable method was called.");
			auditConditionEnableEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
			auditConditionEnableEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
			auditConditionEnableEventState.SetChildValue(context, "SourceName", "Method/Enable", copy: false);
			auditConditionEnableEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
			ReportEvent(context, auditConditionEnableEventState);
		}
		return serviceResult;
	}

	protected virtual ServiceResult OnDisableCalled(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		ServiceResult serviceResult = ProcessBeforeEnableDisable(context, enabling: false);
		if (ServiceResult.IsGood(serviceResult))
		{
			foreach (ConditionState value in GetBranches().Values)
			{
				value.OnDisableCalled(context, method, inputArguments, outputArguments);
			}
			UpdateStateAfterDisable(context);
		}
		if (base.AreEventsMonitored)
		{
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: true);
			}
			AuditConditionEnableEventState auditConditionEnableEventState = new AuditConditionEnableEventState(null);
			TranslationInfo translationInfo = new TranslationInfo("AuditConditionEnable", "en-US", "The Disable method was called.");
			auditConditionEnableEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
			auditConditionEnableEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
			auditConditionEnableEventState.SetChildValue(context, "SourceName", "Method/Disable", copy: false);
			auditConditionEnableEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
			ReportEvent(context, auditConditionEnableEventState);
		}
		return serviceResult;
	}

	protected virtual ServiceResult ProcessBeforeEnableDisable(ISystemContext context, bool enabling)
	{
		if (enabling && EnabledState.Id.Value)
		{
			return 2160852992u;
		}
		if (!enabling && !EnabledState.Id.Value)
		{
			return 2157445120u;
		}
		if (OnEnableDisable != null)
		{
			try
			{
				return OnEnableDisable(context, this, enabling);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2147549184u, "Unexpected error enabling or disabling a Condition.");
			}
		}
		return ServiceResult.Good;
	}

	protected virtual void UpdateStateAfterEnable(ISystemContext context)
	{
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateEnabled", "en-US", "Enabled");
		Retain.Value = true;
		EnabledState.Value = new LocalizedText(translationInfo);
		EnabledState.Id.Value = true;
		if (EnabledState.TransitionTime != null)
		{
			EnabledState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	protected virtual void UpdateStateAfterDisable(ISystemContext context)
	{
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateDisabled", "en-US", "Disabled");
		Retain.Value = false;
		EnabledState.Value = new LocalizedText(translationInfo);
		EnabledState.Id.Value = false;
		if (EnabledState.TransitionTime != null)
		{
			EnabledState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	protected bool IsBranch()
	{
		return !BranchId.Value.IsNullNodeId;
	}
}
