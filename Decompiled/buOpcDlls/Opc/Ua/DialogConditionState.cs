using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DialogConditionState : ConditionState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAERpYWxvZ0NvbmRpdGlvblR5cGVJbnN0YW5jZQEADgsBAA4LDgsAAP////8dAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBcEAAuAERcEAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBdEAAuAERdEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAXhAALgBEXhAAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAF8QAC4ARF8QAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBgEAAuAERgEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAYRAALgBEYRAAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAYxAALgBEYxAAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBkEAAuAERkEAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaisALgBEaisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaysALgBEaysAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAEkjAC4AREkjAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEASiMALgBESiMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAZRAALgBEZRAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEASyMALwEAIyNLIwAAABX/////AQEBAAAAAQAsIwABAF8jAQAAABVgiQoCAAAAAAACAAAASWQBAEwjAC4AREwjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQBUIwAvAQAqI1QjAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFUjAC4ARFUjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAViMALwEAKiNWIwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBXIwAuAERXIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBYIwAvAQAqI1gjAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFkjAC4ARFkjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAWiMALgBEWiMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAFwjAC8BAEQjXCMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAWyMALwEAQyNbIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAXSMALwEARSNdIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAF4jAC4ARF4jAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAARGlhbG9nU3RhdGUBAF8jAC8BACMjXyMAAAAV/////wEBAQAAAAEALCMBAQBLIwQAAAAVYIkKAgAAAAAAAgAAAElkAQBgIwAuAERgIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAGQjAC4ARGQjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZiMALgBEZiMAABUDAgAAAGVuBgAAAEFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcjAC4ARGcjAAAVAwIAAABlbggAAABJbmFjdGl2ZQAV/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFByb21wdAEADwsALgBEDwsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFJlc3BvbnNlT3B0aW9uU2V0AQBoIwAuAERoIwAAABUBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAA8AAABEZWZhdWx0UmVzcG9uc2UBAGkjAC4ARGkjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABPa1Jlc3BvbnNlAQBqIwAuAERqIwAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2FuY2VsUmVzcG9uc2UBAGsjAC4ARGsjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0UmVzcG9uc2UBAGwjAC4ARGwjAAAABv////8BAf////8AAAAABGGCCgQAAAAAAAcAAABSZXNwb25kAQBtIwAvAQBtI20jAAABAQEAAAABAPkLAAEA3yIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbiMALgBEbiMAAJYBAAAAAQAqAQFMAAAAEAAAAFNlbGVjdGVkUmVzcG9uc2UABv////8AAAAAAwAAAAAlAAAAVGhlIHJlc3BvbnNlIHRvIHRoZSBkaWFsb2cgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private TwoStateVariableState m_dialogState;

	private PropertyState<LocalizedText> m_prompt;

	private PropertyState<LocalizedText[]> m_responseOptionSet;

	private PropertyState<int> m_defaultResponse;

	private PropertyState<int> m_okResponse;

	private PropertyState<int> m_cancelResponse;

	private PropertyState<int> m_lastResponse;

	private DialogResponseMethodState m_respondMethod;

	public DialogResponseEventHandler OnRespond;

	public TwoStateVariableState DialogState
	{
		get
		{
			return m_dialogState;
		}
		set
		{
			if (m_dialogState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dialogState = value;
		}
	}

	public PropertyState<LocalizedText> Prompt
	{
		get
		{
			return m_prompt;
		}
		set
		{
			if (m_prompt != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_prompt = value;
		}
	}

	public PropertyState<LocalizedText[]> ResponseOptionSet
	{
		get
		{
			return m_responseOptionSet;
		}
		set
		{
			if (m_responseOptionSet != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_responseOptionSet = value;
		}
	}

	public PropertyState<int> DefaultResponse
	{
		get
		{
			return m_defaultResponse;
		}
		set
		{
			if (m_defaultResponse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_defaultResponse = value;
		}
	}

	public PropertyState<int> OkResponse
	{
		get
		{
			return m_okResponse;
		}
		set
		{
			if (m_okResponse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_okResponse = value;
		}
	}

	public PropertyState<int> CancelResponse
	{
		get
		{
			return m_cancelResponse;
		}
		set
		{
			if (m_cancelResponse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_cancelResponse = value;
		}
	}

	public PropertyState<int> LastResponse
	{
		get
		{
			return m_lastResponse;
		}
		set
		{
			if (m_lastResponse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastResponse = value;
		}
	}

	public DialogResponseMethodState Respond
	{
		get
		{
			return m_respondMethod;
		}
		set
		{
			if (m_respondMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_respondMethod = value;
		}
	}

	public DialogConditionState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2830u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAERpYWxvZ0NvbmRpdGlvblR5cGVJbnN0YW5jZQEADgsBAA4LDgsAAP////8dAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBcEAAuAERcEAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBdEAAuAERdEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAXhAALgBEXhAAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAF8QAC4ARF8QAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBgEAAuAERgEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAYRAALgBEYRAAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAYxAALgBEYxAAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBkEAAuAERkEAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaisALgBEaisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaysALgBEaysAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAEkjAC4AREkjAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEASiMALgBESiMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAZRAALgBEZRAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEASyMALwEAIyNLIwAAABX/////AQEBAAAAAQAsIwABAF8jAQAAABVgiQoCAAAAAAACAAAASWQBAEwjAC4AREwjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQBUIwAvAQAqI1QjAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFUjAC4ARFUjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAViMALwEAKiNWIwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBXIwAuAERXIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBYIwAvAQAqI1gjAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFkjAC4ARFkjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAWiMALgBEWiMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAFwjAC8BAEQjXCMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAWyMALwEAQyNbIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAXSMALwEARSNdIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAF4jAC4ARF4jAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAARGlhbG9nU3RhdGUBAF8jAC8BACMjXyMAAAAV/////wEBAQAAAAEALCMBAQBLIwQAAAAVYIkKAgAAAAAAAgAAAElkAQBgIwAuAERgIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAGQjAC4ARGQjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZiMALgBEZiMAABUDAgAAAGVuBgAAAEFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcjAC4ARGcjAAAVAwIAAABlbggAAABJbmFjdGl2ZQAV/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFByb21wdAEADwsALgBEDwsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFJlc3BvbnNlT3B0aW9uU2V0AQBoIwAuAERoIwAAABUBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAA8AAABEZWZhdWx0UmVzcG9uc2UBAGkjAC4ARGkjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABPa1Jlc3BvbnNlAQBqIwAuAERqIwAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2FuY2VsUmVzcG9uc2UBAGsjAC4ARGsjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0UmVzcG9uc2UBAGwjAC4ARGwjAAAABv////8BAf////8AAAAABGGCCgQAAAAAAAcAAABSZXNwb25kAQBtIwAvAQBtI20jAAABAQEAAAABAPkLAAEA3yIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbiMALgBEbiMAAJYBAAAAAQAqAQFMAAAAEAAAAFNlbGVjdGVkUmVzcG9uc2UABv////8AAAAAAwAAAAAlAAAAVGhlIHJlc3BvbnNlIHRvIHRoZSBkaWFsb2cgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_dialogState != null)
		{
			children.Add(m_dialogState);
		}
		if (m_prompt != null)
		{
			children.Add(m_prompt);
		}
		if (m_responseOptionSet != null)
		{
			children.Add(m_responseOptionSet);
		}
		if (m_defaultResponse != null)
		{
			children.Add(m_defaultResponse);
		}
		if (m_okResponse != null)
		{
			children.Add(m_okResponse);
		}
		if (m_cancelResponse != null)
		{
			children.Add(m_cancelResponse);
		}
		if (m_lastResponse != null)
		{
			children.Add(m_lastResponse);
		}
		if (m_respondMethod != null)
		{
			children.Add(m_respondMethod);
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
		case "DialogState":
			if (createOrReplace && DialogState == null)
			{
				if (replacement == null)
				{
					DialogState = new TwoStateVariableState(this);
				}
				else
				{
					DialogState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = DialogState;
			break;
		case "Prompt":
			if (createOrReplace && Prompt == null)
			{
				if (replacement == null)
				{
					Prompt = new PropertyState<LocalizedText>(this);
				}
				else
				{
					Prompt = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = Prompt;
			break;
		case "ResponseOptionSet":
			if (createOrReplace && ResponseOptionSet == null)
			{
				if (replacement == null)
				{
					ResponseOptionSet = new PropertyState<LocalizedText[]>(this);
				}
				else
				{
					ResponseOptionSet = (PropertyState<LocalizedText[]>)replacement;
				}
			}
			baseInstanceState = ResponseOptionSet;
			break;
		case "DefaultResponse":
			if (createOrReplace && DefaultResponse == null)
			{
				if (replacement == null)
				{
					DefaultResponse = new PropertyState<int>(this);
				}
				else
				{
					DefaultResponse = (PropertyState<int>)replacement;
				}
			}
			baseInstanceState = DefaultResponse;
			break;
		case "OkResponse":
			if (createOrReplace && OkResponse == null)
			{
				if (replacement == null)
				{
					OkResponse = new PropertyState<int>(this);
				}
				else
				{
					OkResponse = (PropertyState<int>)replacement;
				}
			}
			baseInstanceState = OkResponse;
			break;
		case "CancelResponse":
			if (createOrReplace && CancelResponse == null)
			{
				if (replacement == null)
				{
					CancelResponse = new PropertyState<int>(this);
				}
				else
				{
					CancelResponse = (PropertyState<int>)replacement;
				}
			}
			baseInstanceState = CancelResponse;
			break;
		case "LastResponse":
			if (createOrReplace && LastResponse == null)
			{
				if (replacement == null)
				{
					LastResponse = new PropertyState<int>(this);
				}
				else
				{
					LastResponse = (PropertyState<int>)replacement;
				}
			}
			baseInstanceState = LastResponse;
			break;
		case "Respond":
			if (createOrReplace && Respond == null)
			{
				if (replacement == null)
				{
					Respond = new DialogResponseMethodState(this);
				}
				else
				{
					Respond = (DialogResponseMethodState)replacement;
				}
			}
			baseInstanceState = Respond;
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
		if (Respond != null)
		{
			Respond.OnCall = OnRespondCalled;
		}
	}

	public void Activate(ISystemContext context)
	{
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateDialogActive", "en-US", "Active");
		DialogState.Value = new LocalizedText(translationInfo);
		DialogState.Id.Value = true;
		if (DialogState.TransitionTime != null)
		{
			DialogState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	public virtual void SetResponse(ISystemContext context, int response)
	{
		LastResponse.Value = response;
		TranslationInfo translationInfo = new TranslationInfo("ConditionStateDialogInactive", "en-US", "Inactive");
		DialogState.Value = new LocalizedText(translationInfo);
		DialogState.Id.Value = false;
		if (DialogState.TransitionTime != null)
		{
			DialogState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	protected override void UpdateEffectiveState(ISystemContext context)
	{
		if (!base.EnabledState.Id.Value)
		{
			base.UpdateEffectiveState(context);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string locale = null;
		if (DialogState.Value != null)
		{
			locale = DialogState.Value.Locale;
			stringBuilder.Append(DialogState.Value);
		}
		LocalizedText displayName = new LocalizedText(locale, stringBuilder.ToString());
		SetEffectiveSubState(context, displayName, DateTime.MinValue);
	}

	protected virtual ServiceResult OnRespondCalled(ISystemContext context, MethodState method, NodeId objectId, int selectedResponse)
	{
		ServiceResult serviceResult = null;
		try
		{
			if (!base.EnabledState.Id.Value)
			{
				return serviceResult = 2157510656u;
			}
			if (!DialogState.Id.Value)
			{
				return serviceResult = 2160918528u;
			}
			if (selectedResponse < 0 || selectedResponse >= ResponseOptionSet.Value.Length)
			{
				return serviceResult = 2160984064u;
			}
			if (OnRespond == null)
			{
				return serviceResult = 2151481344u;
			}
			serviceResult = OnRespond(context, this, selectedResponse);
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
		}
		finally
		{
			if (base.AreEventsMonitored)
			{
				AuditConditionRespondEventState auditConditionRespondEventState = new AuditConditionRespondEventState(null);
				TranslationInfo translationInfo = new TranslationInfo("AuditConditionDialogResponse", "en-US", "The Respond method was called.");
				auditConditionRespondEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
				auditConditionRespondEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
				auditConditionRespondEventState.SetChildValue(context, "SourceName", "Method/Respond", copy: false);
				auditConditionRespondEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
				auditConditionRespondEventState.SetChildValue(context, "InputArguments", new object[1] { selectedResponse }, copy: false);
				auditConditionRespondEventState.SetChildValue(context, "SelectedResponse", selectedResponse.ToString(), copy: false);
				ReportEvent(context, auditConditionRespondEventState);
			}
		}
		return serviceResult;
	}
}
