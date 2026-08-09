using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AcknowledgeableConditionState : ConditionState
{
	private const string ConfirmedState_InitializationString = "//////////8VYIkKAgAAAAAADgAAAENvbmZpcm1lZFN0YXRlAQCOIwAvAQAjI44jAAAAFf////8BAQEAAAABACwjAQEAcSMEAAAAFWCJCgIAAAAAAAIAAABJZAEAjyMALgBEjyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQCTIwAuAESTIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAJUjAC4ARJUjAAAVAwIAAABlbgkAAABDb25maXJtZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQCWIwAuAESWIwAAFQMCAAAAZW4LAAAAVW5jb25maXJtZWQAFf////8BAf////8AAAAA";

	private const string Confirm_InitializationString = "//////////8EYYIKBAAAAAAABwAAAENvbmZpcm0BAJkjAC8BAJkjmSMAAAEBAQAAAAEA+QsAAQABIwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCaIwAuAESaIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEFja25vd2xlZGdlYWJsZUNvbmRpdGlvblR5cGVJbnN0YW5jZQEAQQsBAEELQQsAAP////8ZAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD5EwAuAET5EwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD6EwAuAET6EwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA+xMALgBE+xMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPwTAC4ARPwTAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD9EwAuAET9EwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/hMALgBE/hMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAABQALgBEABQAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQABFAAuAEQBFAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAbCsALgBEbCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAbSsALgBEbSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAG8jAC4ARG8jAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEAcCMALgBEcCMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAAhQALgBEAhQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEAcSMALwEAIyNxIwAAABX/////AQECAAAAAQAsIwABAIUjAQAsIwABAI4jAQAAABVgiQoCAAAAAAACAAAASWQBAHIjAC4ARHIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQB6IwAvAQAqI3ojAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAHsjAC4ARHsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAfCMALwEAKiN8IwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQB9IwAuAER9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQB+IwAvAQAqI34jAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAH8jAC4ARH8jAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAgCMALgBEgCMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAIIjAC8BAEQjgiMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAgSMALwEAQyOBIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAgyMALwEARSODIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQjAC4ARIQjAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAQWNrZWRTdGF0ZQEAhSMALwEAIyOFIwAAABX/////AQEBAAAAAQAsIwEBAHEjBAAAABVgiQoCAAAAAAACAAAASWQBAIYjAC4ARIYjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAiiMALgBEiiMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQCMIwAuAESMIwAAFQMCAAAAZW4MAAAAQWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAjSMALgBEjSMAABUDAgAAAGVuDgAAAFVuYWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ29uZmlybWVkU3RhdGUBAI4jAC8BACMjjiMAAAAV/////wEBAQAAAAEALCMBAQBxIwQAAAAVYIkKAgAAAAAAAgAAAElkAQCPIwAuAESPIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAJMjAC4ARJMjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAlSMALgBElSMAABUDAgAAAGVuCQAAAENvbmZpcm1lZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAJYjAC4ARJYjAAAVAwIAAABlbgsAAABVbmNvbmZpcm1lZAAV/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQCXIwAvAQCXI5cjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmCMALgBEmCMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAcAAABDb25maXJtAQCZIwAvAQCZI5kjAAABAQEAAAABAPkLAAEAASMBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmiMALgBEmiMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private TwoStateVariableState m_ackedState;

	private TwoStateVariableState m_confirmedState;

	private AddCommentMethodState m_acknowledgeMethod;

	private AddCommentMethodState m_confirmMethod;

	public ConditionAddCommentEventHandler OnAcknowledge;

	public ConditionAddCommentEventHandler OnConfirm;

	public TwoStateVariableState AckedState
	{
		get
		{
			return m_ackedState;
		}
		set
		{
			if (m_ackedState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_ackedState = value;
		}
	}

	public TwoStateVariableState ConfirmedState
	{
		get
		{
			return m_confirmedState;
		}
		set
		{
			if (m_confirmedState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_confirmedState = value;
		}
	}

	public AddCommentMethodState Acknowledge
	{
		get
		{
			return m_acknowledgeMethod;
		}
		set
		{
			if (m_acknowledgeMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_acknowledgeMethod = value;
		}
	}

	public AddCommentMethodState Confirm
	{
		get
		{
			return m_confirmMethod;
		}
		set
		{
			if (m_confirmMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_confirmMethod = value;
		}
	}

	public AcknowledgeableConditionState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2881u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEFja25vd2xlZGdlYWJsZUNvbmRpdGlvblR5cGVJbnN0YW5jZQEAQQsBAEELQQsAAP////8ZAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD5EwAuAET5EwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD6EwAuAET6EwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA+xMALgBE+xMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPwTAC4ARPwTAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD9EwAuAET9EwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/hMALgBE/hMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAABQALgBEABQAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQABFAAuAEQBFAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAbCsALgBEbCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAbSsALgBEbSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAG8jAC4ARG8jAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEAcCMALgBEcCMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAAhQALgBEAhQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEAcSMALwEAIyNxIwAAABX/////AQECAAAAAQAsIwABAIUjAQAsIwABAI4jAQAAABVgiQoCAAAAAAACAAAASWQBAHIjAC4ARHIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQB6IwAvAQAqI3ojAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAHsjAC4ARHsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAfCMALwEAKiN8IwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQB9IwAuAER9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQB+IwAvAQAqI34jAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAH8jAC4ARH8jAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAgCMALgBEgCMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAIIjAC8BAEQjgiMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAgSMALwEAQyOBIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAgyMALwEARSODIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQjAC4ARIQjAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAQWNrZWRTdGF0ZQEAhSMALwEAIyOFIwAAABX/////AQEBAAAAAQAsIwEBAHEjBAAAABVgiQoCAAAAAAACAAAASWQBAIYjAC4ARIYjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAiiMALgBEiiMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQCMIwAuAESMIwAAFQMCAAAAZW4MAAAAQWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAjSMALgBEjSMAABUDAgAAAGVuDgAAAFVuYWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ29uZmlybWVkU3RhdGUBAI4jAC8BACMjjiMAAAAV/////wEBAQAAAAEALCMBAQBxIwQAAAAVYIkKAgAAAAAAAgAAAElkAQCPIwAuAESPIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAJMjAC4ARJMjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAlSMALgBElSMAABUDAgAAAGVuCQAAAENvbmZpcm1lZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAJYjAC4ARJYjAAAVAwIAAABlbgsAAABVbmNvbmZpcm1lZAAV/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQCXIwAvAQCXI5cjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmCMALgBEmCMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAcAAABDb25maXJtAQCZIwAvAQCZI5kjAAABAQEAAAABAPkLAAEAASMBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmiMALgBEmiMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (ConfirmedState != null)
		{
			ConfirmedState.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAENvbmZpcm1lZFN0YXRlAQCOIwAvAQAjI44jAAAAFf////8BAQEAAAABACwjAQEAcSMEAAAAFWCJCgIAAAAAAAIAAABJZAEAjyMALgBEjyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQCTIwAuAESTIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAJUjAC4ARJUjAAAVAwIAAABlbgkAAABDb25maXJtZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQCWIwAuAESWIwAAFQMCAAAAZW4LAAAAVW5jb25maXJtZWQAFf////8BAf////8AAAAA");
		}
		if (Confirm != null)
		{
			Confirm.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAENvbmZpcm0BAJkjAC8BAJkjmSMAAAEBAQAAAAEA+QsAAQABIwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCaIwAuAESaIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_ackedState != null)
		{
			children.Add(m_ackedState);
		}
		if (m_confirmedState != null)
		{
			children.Add(m_confirmedState);
		}
		if (m_acknowledgeMethod != null)
		{
			children.Add(m_acknowledgeMethod);
		}
		if (m_confirmMethod != null)
		{
			children.Add(m_confirmMethod);
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
		case "AckedState":
			if (createOrReplace && AckedState == null)
			{
				if (replacement == null)
				{
					AckedState = new TwoStateVariableState(this);
				}
				else
				{
					AckedState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = AckedState;
			break;
		case "ConfirmedState":
			if (createOrReplace && ConfirmedState == null)
			{
				if (replacement == null)
				{
					ConfirmedState = new TwoStateVariableState(this);
				}
				else
				{
					ConfirmedState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = ConfirmedState;
			break;
		case "Acknowledge":
			if (createOrReplace && Acknowledge == null)
			{
				if (replacement == null)
				{
					Acknowledge = new AddCommentMethodState(this);
				}
				else
				{
					Acknowledge = (AddCommentMethodState)replacement;
				}
			}
			baseInstanceState = Acknowledge;
			break;
		case "Confirm":
			if (createOrReplace && Confirm == null)
			{
				if (replacement == null)
				{
					Confirm = new AddCommentMethodState(this);
				}
				else
				{
					Confirm = (AddCommentMethodState)replacement;
				}
			}
			baseInstanceState = Confirm;
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
		if (Acknowledge != null)
		{
			Acknowledge.OnCall = OnAcknowledgeCalled;
		}
		if (Confirm != null)
		{
			Confirm.OnCall = OnConfirmCalled;
		}
	}

	public virtual void SetAcknowledgedState(ISystemContext context, bool acknowledged)
	{
		if (acknowledged)
		{
			UpdateStateAfterAcknowledge(context);
		}
		else
		{
			UpdateStateAfterUnacknowledge(context);
		}
	}

	public virtual void SetConfirmedState(ISystemContext context, bool confirmed)
	{
		if (confirmed)
		{
			UpdateStateAfterConfirm(context);
		}
		else
		{
			UpdateStateAfterUnconfirm(context);
		}
	}

	protected override void UpdateEffectiveState(ISystemContext context)
	{
		if (!base.EnabledState.Id.Value)
		{
			base.UpdateEffectiveState(context);
		}
		else if (SupportsConfirm() && !ConfirmedState.Id.Value)
		{
			SetEffectiveSubState(context, ConfirmedState.Value, DateTime.MinValue);
		}
		else if (AckedState != null)
		{
			SetEffectiveSubState(context, AckedState.Value, DateTime.MinValue);
		}
	}

	protected virtual ServiceResult OnAcknowledgeCalled(ISystemContext context, MethodState method, NodeId objectId, byte[] eventId, LocalizedText comment)
	{
		ServiceResult serviceResult = ProcessBeforeAcknowledge(context, eventId, comment);
		if (ServiceResult.IsGood(serviceResult))
		{
			AcknowledgeableConditionState acknowledgeableBranch = GetAcknowledgeableBranch(eventId);
			if (acknowledgeableBranch != null)
			{
				acknowledgeableBranch.OnAcknowledgeCalled(context, method, objectId, eventId, comment);
				if (SupportsConfirm())
				{
					ReplaceBranchEvent(eventId, acknowledgeableBranch);
				}
				else
				{
					RemoveBranchEvent(eventId);
				}
			}
			else
			{
				SetAcknowledgedState(context, acknowledged: true);
				if (SupportsConfirm())
				{
					SetConfirmedState(context, confirmed: false);
				}
			}
			if (CanSetComment(comment))
			{
				SetComment(context, comment, GetCurrentUserId(context));
			}
			UpdateRetainState();
		}
		if (EventsMonitored())
		{
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
			AuditConditionAcknowledgeEventState auditConditionAcknowledgeEventState = new AuditConditionAcknowledgeEventState(null);
			TranslationInfo translationInfo = new TranslationInfo("AuditConditionAcknowledge", "en-US", "The Acknowledge method was called.");
			auditConditionAcknowledgeEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
			auditConditionAcknowledgeEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
			auditConditionAcknowledgeEventState.SetChildValue(context, "SourceName", "Method/Acknowledge", copy: false);
			auditConditionAcknowledgeEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
			auditConditionAcknowledgeEventState.SetChildValue(context, "InputArguments", new object[2] { eventId, comment }, copy: false);
			auditConditionAcknowledgeEventState.SetChildValue(context, "ConditionEventId", eventId, copy: false);
			auditConditionAcknowledgeEventState.SetChildValue(context, "Comment", comment, copy: false);
			ReportEvent(context, auditConditionAcknowledgeEventState);
		}
		return serviceResult;
	}

	protected virtual ServiceResult ProcessBeforeAcknowledge(ISystemContext context, byte[] eventId, LocalizedText comment)
	{
		if (eventId == null)
		{
			return 2157576192u;
		}
		if (!base.EnabledState.Id.Value)
		{
			return 2157510656u;
		}
		if (OnAcknowledge != null)
		{
			try
			{
				return OnAcknowledge(context, this, eventId, comment);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2147549184u, "Unexpected error acknowledging a Condition.");
			}
		}
		return ServiceResult.Good;
	}

	protected virtual void UpdateStateAfterAcknowledge(ISystemContext context)
	{
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateAcknowledged", "en-US", "Acknowledged");
		AckedState.Value = new LocalizedText(translationInfo);
		AckedState.Id.Value = true;
		if (AckedState.TransitionTime != null)
		{
			AckedState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	protected virtual void UpdateStateAfterUnacknowledge(ISystemContext context)
	{
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateUnacknowledged", "en-US", "Unacknowledged");
		AckedState.Value = new LocalizedText(translationInfo);
		AckedState.Id.Value = false;
		if (AckedState.TransitionTime != null)
		{
			AckedState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	protected virtual ServiceResult OnConfirmCalled(ISystemContext context, MethodState method, NodeId objectId, byte[] eventId, LocalizedText comment)
	{
		ServiceResult serviceResult = ProcessBeforeConfirm(context, eventId, comment);
		if (ServiceResult.IsGood(serviceResult))
		{
			AcknowledgeableConditionState acknowledgeableBranch = GetAcknowledgeableBranch(eventId);
			if (acknowledgeableBranch != null)
			{
				acknowledgeableBranch.OnConfirmCalled(context, method, objectId, eventId, comment);
				RemoveBranchEvent(eventId);
			}
			else
			{
				SetConfirmedState(context, confirmed: true);
			}
			if (CanSetComment(comment))
			{
				SetComment(context, comment, GetCurrentUserId(context));
			}
			UpdateRetainState();
		}
		if (EventsMonitored())
		{
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
			AuditConditionConfirmEventState auditConditionConfirmEventState = new AuditConditionConfirmEventState(null);
			TranslationInfo translationInfo = new TranslationInfo("AuditConditionConfirm", "en-US", "The Confirm method was called.");
			auditConditionConfirmEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
			auditConditionConfirmEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
			auditConditionConfirmEventState.SetChildValue(context, "SourceName", "Method/Confirm", copy: false);
			auditConditionConfirmEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
			auditConditionConfirmEventState.SetChildValue(context, "InputArguments", new object[2] { eventId, comment }, copy: false);
			auditConditionConfirmEventState.SetChildValue(context, "ConditionEventId", eventId, copy: false);
			auditConditionConfirmEventState.SetChildValue(context, "Comment", comment, copy: false);
			ReportEvent(context, auditConditionConfirmEventState);
		}
		return serviceResult;
	}

	protected virtual ServiceResult ProcessBeforeConfirm(ISystemContext context, byte[] eventId, LocalizedText comment)
	{
		if (eventId == null)
		{
			return 2157576192u;
		}
		if (!base.EnabledState.Id.Value)
		{
			return 2157510656u;
		}
		if (OnConfirm != null)
		{
			try
			{
				return OnConfirm(context, this, eventId, comment);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2147549184u, "Unexpected error confirming a Condition.");
			}
		}
		return ServiceResult.Good;
	}

	protected virtual void UpdateStateAfterConfirm(ISystemContext context)
	{
		if (ConfirmedState != null)
		{
			TranslationInfo translationInfo = new TranslationInfo("ConditionStateConfirmed", "en-US", "Confirmed");
			ConfirmedState.Value = new LocalizedText(translationInfo);
			ConfirmedState.Id.Value = true;
			if (ConfirmedState.TransitionTime != null)
			{
				ConfirmedState.TransitionTime.Value = DateTime.UtcNow;
			}
			UpdateEffectiveState(context);
		}
	}

	protected virtual void UpdateStateAfterUnconfirm(ISystemContext context)
	{
		if (ConfirmedState != null)
		{
			TranslationInfo translationInfo = new TranslationInfo("ConditionStateUnconfirmed", "en-US", "Unconfirmed");
			ConfirmedState.Value = new LocalizedText(translationInfo);
			ConfirmedState.Id.Value = false;
			if (ConfirmedState.TransitionTime != null)
			{
				ConfirmedState.TransitionTime.Value = DateTime.UtcNow;
			}
			UpdateEffectiveState(context);
		}
	}

	private bool CanSetComment(LocalizedText comment)
	{
		bool result = false;
		if (comment != null)
		{
			result = true;
			bool num = comment.Text == null || comment.Text.Length == 0;
			bool flag = comment.Locale == null || comment.Locale.Length == 0;
			if (num && flag)
			{
				result = false;
			}
		}
		return result;
	}

	public bool SupportsConfirm()
	{
		bool result = false;
		if (ConfirmedState != null && ConfirmedState.Value != null)
		{
			result = true;
		}
		return result;
	}

	private AcknowledgeableConditionState GetAcknowledgeableBranch(byte[] eventId)
	{
		AcknowledgeableConditionState result = null;
		ConditionState branch = GetBranch(eventId);
		if (branch != null)
		{
			object obj = branch as AcknowledgeableConditionState;
			if (obj != null)
			{
				result = (AcknowledgeableConditionState)obj;
			}
		}
		return result;
	}

	protected override bool GetRetainState()
	{
		bool result = false;
		if (base.EnabledState.Id.Value)
		{
			result = base.GetRetainState();
			if (!AckedState.Id.Value)
			{
				result = true;
			}
			else if (SupportsConfirm() && !ConfirmedState.Id.Value)
			{
				result = true;
			}
		}
		return result;
	}
}
