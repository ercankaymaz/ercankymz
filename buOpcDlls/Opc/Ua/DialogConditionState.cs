// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DialogConditionState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DialogConditionState(NodeState parent) : ConditionState(parent)
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2830U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAERpYWxvZ0NvbmRpdGlvblR5cGVJbnN0YW5jZQEADgsBAA4LDgsAAP////8dAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBcEAAuAERcEAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBdEAAuAERdEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAXhAALgBEXhAAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAF8QAC4ARF8QAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBgEAAuAERgEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAYRAALgBEYRAAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAYxAALgBEYxAAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBkEAAuAERkEAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaisALgBEaisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaysALgBEaysAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAEkjAC4AREkjAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEASiMALgBESiMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAZRAALgBEZRAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEASyMALwEAIyNLIwAAABX/////AQEBAAAAAQAsIwABAF8jAQAAABVgiQoCAAAAAAACAAAASWQBAEwjAC4AREwjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQBUIwAvAQAqI1QjAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFUjAC4ARFUjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAViMALwEAKiNWIwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBXIwAuAERXIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBYIwAvAQAqI1gjAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAFkjAC4ARFkjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAWiMALgBEWiMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAFwjAC8BAEQjXCMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAWyMALwEAQyNbIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAXSMALwEARSNdIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAF4jAC4ARF4jAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAARGlhbG9nU3RhdGUBAF8jAC8BACMjXyMAAAAV/////wEBAQAAAAEALCMBAQBLIwQAAAAVYIkKAgAAAAAAAgAAAElkAQBgIwAuAERgIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAGQjAC4ARGQjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZiMALgBEZiMAABUDAgAAAGVuBgAAAEFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcjAC4ARGcjAAAVAwIAAABlbggAAABJbmFjdGl2ZQAV/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFByb21wdAEADwsALgBEDwsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFJlc3BvbnNlT3B0aW9uU2V0AQBoIwAuAERoIwAAABUBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAA8AAABEZWZhdWx0UmVzcG9uc2UBAGkjAC4ARGkjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABPa1Jlc3BvbnNlAQBqIwAuAERqIwAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2FuY2VsUmVzcG9uc2UBAGsjAC4ARGsjAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0UmVzcG9uc2UBAGwjAC4ARGwjAAAABv////8BAf////8AAAAABGGCCgQAAAAAAAcAAABSZXNwb25kAQBtIwAvAQBtI20jAAABAQEAAAABAPkLAAEA3yIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbiMALgBEbiMAAJYBAAAAAQAqAQFMAAAAEAAAAFNlbGVjdGVkUmVzcG9uc2UABv////8AAAAAAwAAAAAlAAAAVGhlIHJlc3BvbnNlIHRvIHRoZSBkaWFsb2cgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  public TwoStateVariableState DialogState
  {
    get => this.m_dialogState;
    set
    {
      if (this.m_dialogState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dialogState = value;
    }
  }

  public PropertyState<LocalizedText> Prompt
  {
    get => this.m_prompt;
    set
    {
      if (this.m_prompt != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_prompt = value;
    }
  }

  public PropertyState<LocalizedText[]> ResponseOptionSet
  {
    get => this.m_responseOptionSet;
    set
    {
      if (this.m_responseOptionSet != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_responseOptionSet = value;
    }
  }

  public PropertyState<int> DefaultResponse
  {
    get => this.m_defaultResponse;
    set
    {
      if (this.m_defaultResponse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_defaultResponse = value;
    }
  }

  public PropertyState<int> OkResponse
  {
    get => this.m_okResponse;
    set
    {
      if (this.m_okResponse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_okResponse = value;
    }
  }

  public PropertyState<int> CancelResponse
  {
    get => this.m_cancelResponse;
    set
    {
      if (this.m_cancelResponse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_cancelResponse = value;
    }
  }

  public PropertyState<int> LastResponse
  {
    get => this.m_lastResponse;
    set
    {
      if (this.m_lastResponse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastResponse = value;
    }
  }

  public DialogResponseMethodState Respond
  {
    get => this.m_respondMethod;
    set
    {
      if (this.m_respondMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_respondMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_dialogState != null)
      children.Add((BaseInstanceState) this.m_dialogState);
    if (this.m_prompt != null)
      children.Add((BaseInstanceState) this.m_prompt);
    if (this.m_responseOptionSet != null)
      children.Add((BaseInstanceState) this.m_responseOptionSet);
    if (this.m_defaultResponse != null)
      children.Add((BaseInstanceState) this.m_defaultResponse);
    if (this.m_okResponse != null)
      children.Add((BaseInstanceState) this.m_okResponse);
    if (this.m_cancelResponse != null)
      children.Add((BaseInstanceState) this.m_cancelResponse);
    if (this.m_lastResponse != null)
      children.Add((BaseInstanceState) this.m_lastResponse);
    if (this.m_respondMethod != null)
      children.Add((BaseInstanceState) this.m_respondMethod);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 6:
          if (name == "Prompt")
          {
            if (createOrReplace && this.Prompt == null)
              this.Prompt = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Prompt;
            break;
          }
          break;
        case 7:
          if (name == "Respond")
          {
            if (createOrReplace && this.Respond == null)
              this.Respond = replacement != null ? (DialogResponseMethodState) replacement : new DialogResponseMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Respond;
            break;
          }
          break;
        case 10:
          if (name == "OkResponse")
          {
            if (createOrReplace && this.OkResponse == null)
              this.OkResponse = replacement != null ? (PropertyState<int>) replacement : new PropertyState<int>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.OkResponse;
            break;
          }
          break;
        case 11:
          if (name == "DialogState")
          {
            if (createOrReplace && this.DialogState == null)
              this.DialogState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DialogState;
            break;
          }
          break;
        case 12:
          if (name == "LastResponse")
          {
            if (createOrReplace && this.LastResponse == null)
              this.LastResponse = replacement != null ? (PropertyState<int>) replacement : new PropertyState<int>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastResponse;
            break;
          }
          break;
        case 14:
          if (name == "CancelResponse")
          {
            if (createOrReplace && this.CancelResponse == null)
              this.CancelResponse = replacement != null ? (PropertyState<int>) replacement : new PropertyState<int>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CancelResponse;
            break;
          }
          break;
        case 15:
          if (name == "DefaultResponse")
          {
            if (createOrReplace && this.DefaultResponse == null)
              this.DefaultResponse = replacement != null ? (PropertyState<int>) replacement : new PropertyState<int>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DefaultResponse;
            break;
          }
          break;
        case 17:
          if (name == "ResponseOptionSet")
          {
            if (createOrReplace && this.ResponseOptionSet == null)
              this.ResponseOptionSet = replacement != null ? (PropertyState<LocalizedText[]>) replacement : new PropertyState<LocalizedText[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ResponseOptionSet;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    if (this.Respond == null)
      return;
    this.Respond.OnCall = new DialogResponseMethodStateMethodCallHandler(this.OnRespondCalled);
  }

  public void Activate(ISystemContext context)
  {
    this.DialogState.Value = new LocalizedText(new TranslationInfo("ConditionStateDialogActive", "en-US", "Active"));
    this.DialogState.Id.Value = true;
    if (this.DialogState.TransitionTime != null)
      this.DialogState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  public virtual void SetResponse(ISystemContext context, int response)
  {
    this.LastResponse.Value = response;
    this.DialogState.Value = new LocalizedText(new TranslationInfo("ConditionStateDialogInactive", "en-US", "Inactive"));
    this.DialogState.Id.Value = false;
    if (this.DialogState.TransitionTime != null)
      this.DialogState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected override void UpdateEffectiveState(ISystemContext context)
  {
    if (!this.EnabledState.Id.Value)
    {
      base.UpdateEffectiveState(context);
    }
    else
    {
      StringBuilder stringBuilder = new StringBuilder();
      string locale = (string) null;
      if (this.DialogState.Value != (LocalizedText) null)
      {
        locale = this.DialogState.Value.Locale;
        stringBuilder.Append((object) this.DialogState.Value);
      }
      LocalizedText displayName = new LocalizedText(locale, stringBuilder.ToString());
      this.SetEffectiveSubState(context, displayName, DateTime.MinValue);
    }
  }

  protected virtual ServiceResult OnRespondCalled(
    ISystemContext context,
    MethodState method,
    NodeId objectId,
    int selectedResponse)
  {
    ServiceResult status = (ServiceResult) null;
    try
    {
      if (!this.EnabledState.Id.Value)
        return status = (ServiceResult) 2157510656U /*0x80990000*/;
      if (!this.DialogState.Id.Value)
        return status = (ServiceResult) 2160918528U /*0x80CD0000*/;
      if (selectedResponse < 0 || selectedResponse >= this.ResponseOptionSet.Value.Length)
        return status = (ServiceResult) 2160984064U /*0x80CE0000*/;
      if (this.OnRespond == null)
        return status = (ServiceResult) 2151481344U /*0x803D0000*/;
      status = this.OnRespond(context, this, selectedResponse);
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
    }
    finally
    {
      if (this.AreEventsMonitored)
      {
        AuditConditionRespondEventState e = new AuditConditionRespondEventState((NodeState) null);
        TranslationInfo translationInfo = new TranslationInfo("AuditConditionDialogResponse", "en-US", "The Respond method was called.");
        e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
        e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/Respond", false);
        e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "InputArguments", (object) new object[1]
        {
          (object) selectedResponse
        }, false);
        e.SetChildValue(context, (QualifiedName) "SelectedResponse", (object) selectedResponse.ToString(), false);
        this.ReportEvent(context, (IFilterTarget) e);
      }
    }
    return status;
  }
}
