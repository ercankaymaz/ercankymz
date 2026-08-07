// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AcknowledgeableConditionState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AcknowledgeableConditionState(NodeState parent) : ConditionState(parent)
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2881U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEFja25vd2xlZGdlYWJsZUNvbmRpdGlvblR5cGVJbnN0YW5jZQEAQQsBAEELQQsAAP////8ZAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD5EwAuAET5EwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD6EwAuAET6EwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA+xMALgBE+xMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPwTAC4ARPwTAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD9EwAuAET9EwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/hMALgBE/hMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAABQALgBEABQAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQABFAAuAEQBFAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAbCsALgBEbCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAbSsALgBEbSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAENvbmRpdGlvbk5hbWUBAG8jAC4ARG8jAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABCcmFuY2hJZAEAcCMALgBEcCMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFJldGFpbgEAAhQALgBEAhQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEVuYWJsZWRTdGF0ZQEAcSMALwEAIyNxIwAAABX/////AQECAAAAAQAsIwABAIUjAQAsIwABAI4jAQAAABVgiQoCAAAAAAACAAAASWQBAHIjAC4ARHIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABRdWFsaXR5AQB6IwAvAQAqI3ojAAAAE/////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAHsjAC4ARHsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAExhc3RTZXZlcml0eQEAfCMALwEAKiN8IwAAAAX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQB9IwAuAER9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQB+IwAvAQAqI34jAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAH8jAC4ARH8jAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAgCMALgBEgCMAAAAM/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAERpc2FibGUBAIIjAC8BAEQjgiMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAABgAAAEVuYWJsZQEAgSMALwEAQyOBIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAKAAAAQWRkQ29tbWVudAEAgyMALwEARSODIwAAAQEBAAAAAQD5CwABAA0LAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQjAC4ARIQjAACWAgAAAAEAKgEBRgAAAAcAAABFdmVudElkAA//////AAAAAAMAAAAAKAAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdG8gY29tbWVudC4BACoBAUIAAAAHAAAAQ29tbWVudAAV/////wAAAAADAAAAACQAAABUaGUgY29tbWVudCB0byBhZGQgdG8gdGhlIGNvbmRpdGlvbi4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAQWNrZWRTdGF0ZQEAhSMALwEAIyOFIwAAABX/////AQEBAAAAAQAsIwEBAHEjBAAAABVgiQoCAAAAAAACAAAASWQBAIYjAC4ARIYjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAiiMALgBEiiMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQCMIwAuAESMIwAAFQMCAAAAZW4MAAAAQWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAjSMALgBEjSMAABUDAgAAAGVuDgAAAFVuYWNrbm93bGVkZ2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ29uZmlybWVkU3RhdGUBAI4jAC8BACMjjiMAAAAV/////wEBAQAAAAEALCMBAQBxIwQAAAAVYIkKAgAAAAAAAgAAAElkAQCPIwAuAESPIwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAJMjAC4ARJMjAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAlSMALgBElSMAABUDAgAAAGVuCQAAAENvbmZpcm1lZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAJYjAC4ARJYjAAAVAwIAAABlbgsAAABVbmNvbmZpcm1lZAAV/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQCXIwAvAQCXI5cjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmCMALgBEmCMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAcAAABDb25maXJtAQCZIwAvAQCZI5kjAAABAQEAAAABAPkLAAEAASMBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAmiMALgBEmiMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.ConfirmedState != null)
      this.ConfirmedState.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAENvbmZpcm1lZFN0YXRlAQCOIwAvAQAjI44jAAAAFf////8BAQEAAAABACwjAQEAcSMEAAAAFWCJCgIAAAAAAAIAAABJZAEAjyMALgBEjyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQCTIwAuAESTIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAJUjAC4ARJUjAAAVAwIAAABlbgkAAABDb25maXJtZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQCWIwAuAESWIwAAFQMCAAAAZW4LAAAAVW5jb25maXJtZWQAFf////8BAf////8AAAAA");
    if (this.Confirm == null)
      return;
    this.Confirm.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAENvbmZpcm0BAJkjAC8BAJkjmSMAAAEBAQAAAAEA+QsAAQABIwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCaIwAuAESaIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public TwoStateVariableState AckedState
  {
    get => this.m_ackedState;
    set
    {
      if (this.m_ackedState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_ackedState = value;
    }
  }

  public TwoStateVariableState ConfirmedState
  {
    get => this.m_confirmedState;
    set
    {
      if (this.m_confirmedState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_confirmedState = value;
    }
  }

  public AddCommentMethodState Acknowledge
  {
    get => this.m_acknowledgeMethod;
    set
    {
      if (this.m_acknowledgeMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_acknowledgeMethod = value;
    }
  }

  public AddCommentMethodState Confirm
  {
    get => this.m_confirmMethod;
    set
    {
      if (this.m_confirmMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_confirmMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_ackedState != null)
      children.Add((BaseInstanceState) this.m_ackedState);
    if (this.m_confirmedState != null)
      children.Add((BaseInstanceState) this.m_confirmedState);
    if (this.m_acknowledgeMethod != null)
      children.Add((BaseInstanceState) this.m_acknowledgeMethod);
    if (this.m_confirmMethod != null)
      children.Add((BaseInstanceState) this.m_confirmMethod);
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
    switch (browseName.Name)
    {
      case "AckedState":
        if (createOrReplace && this.AckedState == null)
          this.AckedState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AckedState;
        break;
      case "ConfirmedState":
        if (createOrReplace && this.ConfirmedState == null)
          this.ConfirmedState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ConfirmedState;
        break;
      case "Acknowledge":
        if (createOrReplace && this.Acknowledge == null)
          this.Acknowledge = replacement != null ? (AddCommentMethodState) replacement : new AddCommentMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Acknowledge;
        break;
      case "Confirm":
        if (createOrReplace && this.Confirm == null)
          this.Confirm = replacement != null ? (AddCommentMethodState) replacement : new AddCommentMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Confirm;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    if (this.Acknowledge != null)
      this.Acknowledge.OnCall = new AddCommentMethodStateMethodCallHandler(this.OnAcknowledgeCalled);
    if (this.Confirm == null)
      return;
    this.Confirm.OnCall = new AddCommentMethodStateMethodCallHandler(this.OnConfirmCalled);
  }

  public virtual void SetAcknowledgedState(ISystemContext context, bool acknowledged)
  {
    if (acknowledged)
      this.UpdateStateAfterAcknowledge(context);
    else
      this.UpdateStateAfterUnacknowledge(context);
  }

  public virtual void SetConfirmedState(ISystemContext context, bool confirmed)
  {
    if (confirmed)
      this.UpdateStateAfterConfirm(context);
    else
      this.UpdateStateAfterUnconfirm(context);
  }

  protected override void UpdateEffectiveState(ISystemContext context)
  {
    if (!this.EnabledState.Id.Value)
      base.UpdateEffectiveState(context);
    else if (this.SupportsConfirm() && !this.ConfirmedState.Id.Value)
    {
      this.SetEffectiveSubState(context, this.ConfirmedState.Value, DateTime.MinValue);
    }
    else
    {
      if (this.AckedState == null)
        return;
      this.SetEffectiveSubState(context, this.AckedState.Value, DateTime.MinValue);
    }
  }

  protected virtual ServiceResult OnAcknowledgeCalled(
    ISystemContext context,
    MethodState method,
    NodeId objectId,
    byte[] eventId,
    LocalizedText comment)
  {
    ServiceResult status = this.ProcessBeforeAcknowledge(context, eventId, comment);
    if (ServiceResult.IsGood(status))
    {
      AcknowledgeableConditionState acknowledgeableBranch = this.GetAcknowledgeableBranch(eventId);
      if (acknowledgeableBranch != null)
      {
        acknowledgeableBranch.OnAcknowledgeCalled(context, method, objectId, eventId, comment);
        if (this.SupportsConfirm())
          this.ReplaceBranchEvent(eventId, (ConditionState) acknowledgeableBranch);
        else
          this.RemoveBranchEvent(eventId);
      }
      else
      {
        this.SetAcknowledgedState(context, true);
        if (this.SupportsConfirm())
          this.SetConfirmedState(context, false);
      }
      if (this.CanSetComment(comment))
        this.SetComment(context, comment, this.GetCurrentUserId(context));
      this.UpdateRetainState();
    }
    if (this.EventsMonitored())
    {
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
      AuditConditionAcknowledgeEventState e = new AuditConditionAcknowledgeEventState((NodeState) null);
      TranslationInfo translationInfo = new TranslationInfo("AuditConditionAcknowledge", "en-US", "The Acknowledge method was called.");
      e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
      e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/Acknowledge", false);
      e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "InputArguments", (object) new object[2]
      {
        (object) eventId,
        (object) comment
      }, false);
      e.SetChildValue(context, (QualifiedName) "ConditionEventId", (object) eventId, false);
      e.SetChildValue(context, (QualifiedName) "Comment", (object) comment, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    return status;
  }

  protected virtual ServiceResult ProcessBeforeAcknowledge(
    ISystemContext context,
    byte[] eventId,
    LocalizedText comment)
  {
    if (eventId == null)
      return (ServiceResult) 2157576192U /*0x809A0000*/;
    if (!this.EnabledState.Id.Value)
      return (ServiceResult) 2157510656U /*0x80990000*/;
    if (this.OnAcknowledge == null)
      return ServiceResult.Good;
    try
    {
      return this.OnAcknowledge(context, (ConditionState) this, eventId, comment);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error acknowledging a Condition.", objArray);
    }
  }

  protected virtual void UpdateStateAfterAcknowledge(ISystemContext context)
  {
    this.AckedState.Value = new LocalizedText(new TranslationInfo("ConditionStateAcknowledged", "en-US", "Acknowledged"));
    this.AckedState.Id.Value = true;
    if (this.AckedState.TransitionTime != null)
      this.AckedState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected virtual void UpdateStateAfterUnacknowledge(ISystemContext context)
  {
    this.AckedState.Value = new LocalizedText(new TranslationInfo("ConditionStateUnacknowledged", "en-US", "Unacknowledged"));
    this.AckedState.Id.Value = false;
    if (this.AckedState.TransitionTime != null)
      this.AckedState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected virtual ServiceResult OnConfirmCalled(
    ISystemContext context,
    MethodState method,
    NodeId objectId,
    byte[] eventId,
    LocalizedText comment)
  {
    ServiceResult status = this.ProcessBeforeConfirm(context, eventId, comment);
    if (ServiceResult.IsGood(status))
    {
      AcknowledgeableConditionState acknowledgeableBranch = this.GetAcknowledgeableBranch(eventId);
      if (acknowledgeableBranch != null)
      {
        acknowledgeableBranch.OnConfirmCalled(context, method, objectId, eventId, comment);
        this.RemoveBranchEvent(eventId);
      }
      else
        this.SetConfirmedState(context, true);
      if (this.CanSetComment(comment))
        this.SetComment(context, comment, this.GetCurrentUserId(context));
      this.UpdateRetainState();
    }
    if (this.EventsMonitored())
    {
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
      AuditConditionConfirmEventState e = new AuditConditionConfirmEventState((NodeState) null);
      TranslationInfo translationInfo = new TranslationInfo("AuditConditionConfirm", "en-US", "The Confirm method was called.");
      e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
      e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/Confirm", false);
      e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "InputArguments", (object) new object[2]
      {
        (object) eventId,
        (object) comment
      }, false);
      e.SetChildValue(context, (QualifiedName) "ConditionEventId", (object) eventId, false);
      e.SetChildValue(context, (QualifiedName) "Comment", (object) comment, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    return status;
  }

  protected virtual ServiceResult ProcessBeforeConfirm(
    ISystemContext context,
    byte[] eventId,
    LocalizedText comment)
  {
    if (eventId == null)
      return (ServiceResult) 2157576192U /*0x809A0000*/;
    if (!this.EnabledState.Id.Value)
      return (ServiceResult) 2157510656U /*0x80990000*/;
    if (this.OnConfirm == null)
      return ServiceResult.Good;
    try
    {
      return this.OnConfirm(context, (ConditionState) this, eventId, comment);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error confirming a Condition.", objArray);
    }
  }

  protected virtual void UpdateStateAfterConfirm(ISystemContext context)
  {
    if (this.ConfirmedState == null)
      return;
    this.ConfirmedState.Value = new LocalizedText(new TranslationInfo("ConditionStateConfirmed", "en-US", "Confirmed"));
    this.ConfirmedState.Id.Value = true;
    if (this.ConfirmedState.TransitionTime != null)
      this.ConfirmedState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected virtual void UpdateStateAfterUnconfirm(ISystemContext context)
  {
    if (this.ConfirmedState == null)
      return;
    this.ConfirmedState.Value = new LocalizedText(new TranslationInfo("ConditionStateUnconfirmed", "en-US", "Unconfirmed"));
    this.ConfirmedState.Id.Value = false;
    if (this.ConfirmedState.TransitionTime != null)
      this.ConfirmedState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  private bool CanSetComment(LocalizedText comment)
  {
    bool flag = false;
    if (comment != (LocalizedText) null)
    {
      flag = true;
      if (((comment.Text == null ? 1 : (comment.Text.Length == 0 ? 1 : 0)) & (comment.Locale == null ? 1 : (comment.Locale.Length == 0 ? 1 : 0))) != 0)
        flag = false;
    }
    return flag;
  }

  public bool SupportsConfirm()
  {
    bool flag = false;
    if (this.ConfirmedState != null && this.ConfirmedState.Value != (LocalizedText) null)
      flag = true;
    return flag;
  }

  private AcknowledgeableConditionState GetAcknowledgeableBranch(byte[] eventId)
  {
    AcknowledgeableConditionState acknowledgeableBranch = (AcknowledgeableConditionState) null;
    ConditionState branch = this.GetBranch(eventId);
    if (branch != null)
    {
      object obj = (object) (branch as AcknowledgeableConditionState);
      if (obj != null)
        acknowledgeableBranch = (AcknowledgeableConditionState) obj;
    }
    return acknowledgeableBranch;
  }

  protected override bool GetRetainState()
  {
    bool retainState = false;
    if (this.EnabledState.Id.Value)
    {
      retainState = base.GetRetainState();
      if (!this.AckedState.Id.Value)
        retainState = true;
      else if (this.SupportsConfirm() && !this.ConfirmedState.Id.Value)
        retainState = true;
    }
    return retainState;
  }
}
